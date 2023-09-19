using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _tUnitLayer;
    public TBlock _lastBlockClicked;
    public TUnit _lastUnitClicked;
    private Camera _camera;
    private PlayerInput inputActions;

    private void Awake()
    {
        _camera = Camera.main;
        inputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        inputActions.Gameplay.TouchPress.started += ctx => StartTouch(ctx);
        inputActions.Gameplay.TouchPress.started += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch " + inputActions.Gameplay.TouchPosition.ReadValue<Vector2>());
        //Vector2 rawCoord = inputActions.Gameplay.TouchPosition.ReadValue<Vector2>();
        //Vector3 ScreenCoord = new Vector3(rawCoord.x, rawCoord.y, _camera.nearClipPlane);

        if (GameManagerTT.Instance.gameFinished) return;

        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(inputActions.Gameplay.TouchPosition.ReadValue<Vector2>()), _tUnitLayer);
        if (!rayHit.collider) return;

        //guardo la unidad clickeada
        _lastUnitClicked = rayHit.transform.GetComponent<TUnit>();

        //Puedo elegir donde jugar
        if (GameManagerTT.Instance.CanSelect())
        {
            GameManagerTT.Instance.SetCanSelect(false);
            //GameManager.Instance.SetCanPlay(true);

            //guardo el bloque clickeado
            _lastBlockClicked = _lastUnitClicked.GetParent();

            GameManagerTT.Instance.SelectBlock(_lastBlockClicked);
            return;
        }

        //si la celda elejida ya esta usada no se usa.
        if (_lastUnitClicked._finished)
            return;

        //puedo jugar
        if (_lastUnitClicked.GetParent().GetInstanceID() == _lastBlockClicked.GetInstanceID()) //GameManager.Instance.CanPlay() && 
        {
            //GameManager.Instance.SetCanPlay(true);

            _lastBlockClicked.FindUnitInGrid(_lastUnitClicked);
            _lastUnitClicked.Clicked();

            //selecciono el proximo bloque a jugar
            GameManagerTT.Instance.SelectBlockAfterPlay(_lastBlockClicked.NextGrid);
            _lastBlockClicked = GameManagerTT.Instance.GetBlockAfterPlay(_lastBlockClicked.NextGrid);
            return;
        }
        
    }

#region ANDROID_INPUT



#endregion



    #region PC_INPUT
    public void OnClick(InputAction.CallbackContext context)
    {
        if (GameManagerTT.Instance.gameFinished) return;

        if (!context.started) return;
        
        var rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()), _tUnitLayer);
        if (!rayHit.collider) return;

        //guardo la unidad clickeada
        _lastUnitClicked = rayHit.transform.GetComponent<TUnit>();

        //Puedo elegir donde jugar
        if (GameManagerTT.Instance.CanSelect())
        {
            GameManagerTT.Instance.SetCanSelect(false);
            //GameManager.Instance.SetCanPlay(true);

            //guardo el bloque clickeado
            _lastBlockClicked = _lastUnitClicked.GetParent();

            GameManagerTT.Instance.SelectBlock(_lastBlockClicked);
            return;
        }

        //si la celda elejida ya esta usada no se usa.
        if (_lastUnitClicked._finished)
            return;

        //puedo jugar
        if (_lastUnitClicked.GetParent().GetInstanceID() == _lastBlockClicked.GetInstanceID()) //GameManager.Instance.CanPlay() && 
        {
            //GameManager.Instance.SetCanPlay(true);

            _lastBlockClicked.FindUnitInGrid(_lastUnitClicked);
            _lastUnitClicked.Clicked();

            //selecciono el proximo bloque a jugar
            GameManagerTT.Instance.SelectBlockAfterPlay(_lastBlockClicked.NextGrid);
            _lastBlockClicked = GameManagerTT.Instance.GetBlockAfterPlay(_lastBlockClicked.NextGrid);
            return;
        }
    }

#endregion
    public void OnPulsBlockImgSize(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (_lastBlockClicked == null) return;
        _lastBlockClicked.PlusImgSize();
    }
}
