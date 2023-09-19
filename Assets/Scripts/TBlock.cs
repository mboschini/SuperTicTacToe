using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBlock : MonoBehaviour
{
    [Header("Block vars")]
    private TUnit[,] _gridUnits;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    [SerializeField] private TUnit _cellUnit;
    [SerializeField] private SpriteRenderer _imgDisplay;
    [SerializeField] private SpriteRenderer _imgDisplayBG;
    [SerializeField] private Color _imgDisplayBGSelected;
    [SerializeField] private Color _imgDisplayBGBlocked;
    [SerializeField] private Color _imgDisplayBGAvailable;
    [SerializeField] private bool _free = true;
    public bool _finished = false;
    public TUnitType _blockWinner = TUnitType.blank;
    public Vector2 NextGrid = Vector2.zero;
    
    [Header("Coord")]
    public int CoordX = 0;
    public int CoordY = 0;

    private void Start()
    {
        _gridUnits = new TUnit[_cols, _rows];
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                _gridUnits[i, j] = Instantiate(_cellUnit, this.transform).SetPos(i, j);
                _gridUnits[i, j].CoordX = i;
                _gridUnits[i, j].CoordY = j;
            }
        }
        _imgDisplayBG.color = _imgDisplayBGAvailable;
    }

    

    public void CheckBlockTicTacToe(TUnitType CheckType)
    {
        if (!_free)
        {
            Debug.Log("Block Not Free");
            return;
        }

        if(CheckType == TUnitType.blank)
        {
            Debug.Log("Blank not permitted");
            return;
        }

        //necesita llegar a 3 para ganar el tateti
        int checks = 0; 

        //checkIfFull
        bool full = true;

        //check each col
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                if (_gridUnits[i, j].unitType == CheckType)
                {
                    checks += 1;
                    if(checks == 3)
                    {
                        _free = false;
                        WinBlock(CheckType);
                        return;
                    }
                }
            }
            checks = 0;
        }

        //check each row
        for (int j = 0; j < _cols; j++)
        {
            for (int i = 0; i < _rows; i++)
            {
                if (_gridUnits[i, j].unitType == CheckType)
                {
                    checks += 1;
                    if (checks == 3)
                    {
                        _free = false;
                        WinBlock(CheckType);
                        return;
                    }
                }
            }
            checks = 0;
        }

        //check each diag
        if ( (_gridUnits[0, 0].unitType == CheckType && _gridUnits[1, 1].unitType == CheckType && _gridUnits[2, 2].unitType == CheckType) ||
             (_gridUnits[0, 2].unitType == CheckType && _gridUnits[1, 1].unitType == CheckType && _gridUnits[2, 0].unitType == CheckType) )
        {
            _free = false;
            WinBlock(CheckType);
            return;
        }

        //check if full
        for (int j = 0; j < _cols; j++)
        {
            for (int i = 0; i < _rows; i++)
            {
                if (_gridUnits[i, j].unitType == TUnitType.blank)
                {
                    full = false;
                    return;
                }
            }
        }

        if (full)
        {
            _free = false;
            LockBlock();
        }

        return;
    }

    private void LockBlock()
    {
        if (_free == true) return;

        _imgDisplay.sprite = GameManagerTT.Instance._nullSprite;
        
        //adjust img size
        Vector2 size = _imgDisplay.size;
        _imgDisplay.size += new Vector2(3f - size.x, 3f - size.y);

        //adjust img color
        _imgDisplayBG.color = _imgDisplayBGBlocked;
        _imgDisplayBG.sortingOrder = 1;

        //este bloque deja de interactuar
        _blockWinner = TUnitType.draw;
        _finished = true;

        BlockAllUnits();

        GameManagerTT.Instance.CheckGameTicTacToe(TUnitType.draw);
    }

    private void WinBlock(TUnitType CheckType)
    {
        if (_free == true) return;

        if(CheckType == TUnitType.cross)
            _imgDisplay.sprite = GameManagerTT.Instance._crossSprite;
        else
            _imgDisplay.sprite = GameManagerTT.Instance._circleSprite;

        Vector2 size = _imgDisplay.size;
        _imgDisplay.size += new Vector2(3f - size.x, 3f - size.y);

        _imgDisplayBG.color = _imgDisplayBGBlocked;
        _imgDisplayBG.sortingOrder = 1;

        //este bloque deja de interactuar
        _blockWinner = CheckType;
        _finished = true;

        BlockAllUnits();

        GameManagerTT.Instance.CheckGameTicTacToe(CheckType);
    }

    private void BlockAllUnits()
    {
        foreach (TUnit unit in _gridUnits)
        {
            unit.BlockUnit();
        }
    }

    private void FreeAllUnits()
    {
        foreach (TUnit unit in _gridUnits)
        {
            unit.UnBlockUnit();
        }
    }

    public void SelectThisBlock()
    {
        if (_finished) return;

        _free = true;

        _imgDisplayBG.color = _imgDisplayBGSelected;

        FreeAllUnits();
    }

    //este bloque no puede ser elegido
    public void BlockThisBlock()
    {
        if (_finished) return;

        _free = false;

        _imgDisplayBG.color = _imgDisplayBGBlocked;

        BlockAllUnits();
    }

    //este bloque puede ser elegido
    public void ReadyThisBlock()
    {
        if (_finished) return;

        _free = true;

        _imgDisplayBG.color = _imgDisplayBGAvailable;

        FreeAllUnits();
    }

    public void FindUnitInGrid(TUnit UnitSelected)
    {
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                if (UnitSelected.GetInstanceID() == _gridUnits[i, j].GetInstanceID())
                {
                    NextGrid = new Vector2(i, j);
                    return;
                }
            }
        }

        Debug.Log("Failed Find Unit");
        NextGrid = Vector2.zero;
    }

    public TBlock SetParentGrid(Transform parent)
    {
        transform.SetParent(parent);
        return this;
    }
    public TBlock SetPos(float x, float y)
    {
        transform.localPosition = new Vector3(x, y, 0f);
        transform.localScale = new Vector3(0.5f, 0.5f, 0f);        
        return this;
    }
    public void PlusImgSize()
    {
        if (!_free)
        {
            _imgDisplay.size += new Vector2(1.5f, 1.5f);
            Debug.Log("Sprite size: " + _imgDisplay.size.ToString("F2"));
        }
        else
        {
            Debug.Log("Block FREE");
        }
    }
}
