using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class FastTutorial : MonoBehaviour
{
    public Ease ease = Ease.Linear;
    private SpriteGroup _sprGroup;
    private Controls _controls;
    private bool _hasMoved;
    
    private bool _gameStarted;
    
    void OnEnable() => _controls.Player.Enable();
    void OnDisable() => _controls.Player.Disable();
    
    void Awake()
    {
        _sprGroup = GetComponent<SpriteGroup>();
        _controls = new Controls();
        _controls.Player.Move.performed += HasMove;
    }
    void Start()
    {
        enabled = false;
        GameManager.instance.OnStateChanged += HandleStateChanged;
        
        DOTween.To(
            () => _sprGroup.Alpha, 
            x=> _sprGroup.Alpha = x, 0, 0.4f)
            .SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }

    void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStateChanged -= HandleStateChanged;
        }
    }

    private void HandleStateChanged(GameState state)
    {
        enabled = (state == GameState.Playing);
    }

    void HasMove(InputAction.CallbackContext context)
    {
        if (_hasMoved) return;
        DOTween.KillAll();
        _sprGroup.Alpha = 0;
        _hasMoved = true;
    }

   
    
    
}
