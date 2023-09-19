using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTT : MonoBehaviour
{
    [Header("Game Vars")]
    [SerializeField] private int _cols = 3;
    [SerializeField] private int _rows = 3;
    [SerializeField] private Transform _root;
    [SerializeField] private TBlock _blockUnit;
    [SerializeField] private float _displayGridMargin = 1.75f;
    private TBlock[,] _gridBlock;
    private TUnitType _activePlayerType = TUnitType.cross;
    [SerializeField] private bool _canSelect = true;
    public bool gameFinished = false;

    [Header("UI Vars")]
    [SerializeField] private Image ActivePlayerImg;
    public Sprite _circleSprite;
    public Sprite _crossSprite;
    public Sprite _nullSprite;
    public Sprite _blankSprite;

    public static GameManagerTT Instance { get; private set; }

    public TUnitType ActivePlayerType
    {
        get { return _activePlayerType; }
        private set { }
    }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _gridBlock = new TBlock[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                _gridBlock[i, j] = Instantiate(_blockUnit, _root).SetPos((_displayGridMargin * (i) - _displayGridMargin), (_displayGridMargin - _displayGridMargin * (j)));
                _gridBlock[i, j].CoordX = i;
                _gridBlock[i, j].CoordY = j;
            }
        }

        Debug.Log(_activePlayerType.ToString() + " Starts");
    }

    public void CheckGameTicTacToe(TUnitType CheckType)
    {
        if (CheckType == TUnitType.blank)
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
                if (_gridBlock[i, j]._blockWinner == CheckType)
                {
                    checks += 1;
                    if (checks == 3)
                    {
                        WinGame();
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
                if (_gridBlock[i, j]._blockWinner == CheckType)
                {
                    checks += 1;
                    if (checks == 3)
                    {
                        WinGame();
                        return;
                    }
                }
            }
            checks = 0;
        }

        //check each diag
        if ((_gridBlock[0, 0]._blockWinner == CheckType && _gridBlock[1, 1]._blockWinner == CheckType && _gridBlock[2, 2]._blockWinner == CheckType) ||
             (_gridBlock[0, 2]._blockWinner == CheckType && _gridBlock[1, 1]._blockWinner == CheckType && _gridBlock[2, 0]._blockWinner == CheckType))
        {
            WinGame();
            return;
        }

        //check if full
        for (int j = 0; j < _cols; j++)
        {
            for (int i = 0; i < _rows; i++)
            {
                if (_gridBlock[i, j]._blockWinner == TUnitType.blank)
                {
                    full = false;
                    return;
                }
            }
        }

        if (full)
            DrawGame();

        return;
    }

    public void DrawGame()
    {
        _canSelect = false;

        foreach (TBlock block in _gridBlock)
        {
            block.BlockThisBlock();
        }

        Debug.Log("Game Draw");
        gameFinished = true;

        UIManagerTT.Instance.ShowDrawScreen();
    }

    public void WinGame()
    {
        _canSelect = false;

        foreach (TBlock block in _gridBlock)
        {
            block.BlockThisBlock();
        }

        if(_activePlayerType == TUnitType.circle)
            Debug.Log("Circle Wins");
        else
            Debug.Log("Cross Wins");

        gameFinished = true;

        UIManagerTT.Instance.ShowWinScreen();
    }

    public void SelectBlock(TBlock selecetedBlock)
    {
        if (selecetedBlock._finished)
        {
            foreach (TBlock block in _gridBlock)
            {
                block.ReadyThisBlock();
            }

            _canSelect = true;
            return;
        }

        foreach (TBlock block in _gridBlock)
        {
            if(block.GetInstanceID() == selecetedBlock.GetInstanceID())
            {
                block.SelectThisBlock();
            }
            else
            {
                block.BlockThisBlock();
            }
        }

    }

    public void ChangePlayer()
    {
        if (_activePlayerType == TUnitType.cross)
        {
            _activePlayerType = TUnitType.circle;
            ActivePlayerImg.sprite = _circleSprite;
        }
        else
        {
            _activePlayerType = TUnitType.cross;
            ActivePlayerImg.sprite = _crossSprite;
        }

        Debug.Log(_activePlayerType.ToString() + " Play");
    }

    public void SelectBlockAfterPlay(Vector2 pos)
    {
        SelectBlock(_gridBlock[(int)pos.x, (int)pos.y]);
    }

    public TBlock GetBlockAfterPlay(Vector2 pos)
    {
        return _gridBlock[(int)pos.x, (int)pos.y];
    }

    public Sprite GetActivePlayerImage()
    {
        if (_activePlayerType == TUnitType.cross)
            return _crossSprite;
        else
            return _circleSprite;
    }

    public bool CanSelect()
    {
        return _canSelect;
    }

    public void SetCanSelect(bool var)
    {
        _canSelect = var;
    }
}
