using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, InputController.IGameplayActions, InputController.IKeysActions
{
    #region Singleton
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new GameObject("Game Input").AddComponent<InputManager>();
            }

            DontDestroyOnLoad(_instance.gameObject);

            return _instance;
        }
    }
    #endregion

    private InputController input;

    private void Awake()
    {
        if (input == null)
        {
            input = new InputController();

            input.Gameplay.AddCallbacks(this);
            input.Keys.AddCallbacks(this);

            input.Enable();
        }
    }

    private void OnDestroy()
    {
        if (input != null)
        {
            input.Disable();
        }
    }

    public void OnAxis(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();

        GameInput.SetAxis(AxisType.Horizontal, axis.x);
        GameInput.SetAxis(AxisType.Vertical, axis.y);
    }

    public void OnPressQ(InputAction.CallbackContext context)
    {
        string key = context.control.displayName;

        if (context.phase is InputActionPhase.Started)
        {
            GameInput.AddKey(key);
        }
        else if (context.phase is InputActionPhase.Canceled)
        {
            GameInput.RemoveKey(key);
        }
    }

    public void OnPressE(InputAction.CallbackContext context)
    {

    }
}
