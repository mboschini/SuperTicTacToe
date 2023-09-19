using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TUnitType
{
    blank = 0,
    circle = 1,
    cross = 2,
    draw = 3,
}

public class TUnit : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] private SpriteRenderer _imgDisplay;
    [SerializeField] private TUnitType _unitType;
    public bool _free = true;
    public bool _finished = false;

    [Header("Coord")]
    public int CoordX = 0;
    public int CoordY = 0;

    public TUnitType unitType { get { return _unitType; } }

    void Start()
    {
        _imgDisplay.sprite = GameManagerTT.Instance._blankSprite;
        _unitType = TUnitType.blank;
    }

    public void Clicked()
    {
        if (_finished)
        {
            Debug.Log("Unit With Setted Value Can't Change");
            return;
        }

        //si la celda esta usada no modificarla
        if (_free == false)
        {
            Debug.Log("Unit Not Free");
            return;
        }

        if (GameManagerTT.Instance.ActivePlayerType == TUnitType.cross)
        {
            _imgDisplay.sprite = GameManagerTT.Instance._crossSprite;
            _unitType = TUnitType.cross;
            _finished = true;
        }
        else
        {
            _imgDisplay.sprite = GameManagerTT.Instance._circleSprite;
            _unitType = TUnitType.circle;
            _finished = true;
        }


        //check if this block's finished
        GetParent().CheckBlockTicTacToe(_unitType);

        //change player
        GameManagerTT.Instance.ChangePlayer();
    }

    public TUnit SetParentGrid(Transform parent)
    {
        transform.SetParent(parent);
        return this;
    }
    public TUnit SetPos(float x, float y)
    {
        transform.localPosition = new Vector3(x-1f, 1f-y, 0f);
        return this;
    }

    public TBlock GetParent()
    {
        return transform.parent.GetComponent<TBlock>();
    }

    public void BlockUnit()
    {
        if(_finished == false)
            _free = false;
    }

    public void UnBlockUnit()
    {
        if (_finished == false)
            _free = true;
    }
}
