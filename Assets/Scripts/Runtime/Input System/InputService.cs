using System;
using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameControls;

public interface IInputService
{
    GameplayActions GameplaymapActions { get; }
    UIActions UImapActions { get; }
    InputAction MovementAction { get; }
    void ChangeInputMap(InputMapType inputMapType);
}

public sealed class InputService : IInputService, IInitializable, IDisposable
{
    private readonly GameControls inputActions;
    private readonly InputMapType startUpInputMap = InputMapType.Gameplay;

    private readonly GameplayActions gameplaymapActions;
    private readonly UIActions uiMapActions;

    public GameplayActions GameplaymapActions => gameplaymapActions;
    public UIActions UImapActions => uiMapActions;

    public InputAction MovementAction => gameplaymapActions.MovementAction;

    public InputService()
    {
        this.inputActions = new GameControls();

        this.gameplaymapActions = inputActions.Gameplay;
        this.uiMapActions = inputActions.UI;

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;
    }

    public void Initialize()
    {
        ChangeInputMap(startUpInputMap);

#if UNITY_EDITOR
        Debug.Log($"InputService is Initialized");
#endif
    }

    public void Dispose()
    {
        GameplaymapActions.Disable();
        UImapActions.Disable();

        InputSystem.onDeviceChange -= InputSystem_onDeviceChange;

#if UNITY_EDITOR
        Debug.Log($"Dispose InputService");
#endif
    }

    public void ChangeInputMap(InputMapType inputMapType)
    {
#if UNITY_EDITOR
        Debug.Log($"Changed Input Map on {inputMapType}");
#endif

        switch (inputMapType)
        {
            case InputMapType.Gameplay:
                GameplaymapActions.Enable();
                UImapActions.Disable();
#if UNITY_EDITOR
                Debug.Log($"Disabled Input Map {InputMapType.UI}");
#endif
                break;
            case InputMapType.UI:
                GameplaymapActions.Disable();
                UImapActions.Enable();
#if UNITY_EDITOR
                Debug.Log($"Disabled Input Map {InputMapType.Gameplay}");
#endif
                break;
        }
    }

    private void InputSystem_onDeviceChange(InputDevice device, InputDeviceChange deviceChange)
    {
        Debug.Log("onInputDeviceChange");
        switch (deviceChange)
        {
            case InputDeviceChange.Added:
                Debug.Log("Device added: " + device);
                break;
            case InputDeviceChange.Removed:
                Debug.Log("Device removed: " + device);
                break;
            case InputDeviceChange.ConfigurationChanged:
                Debug.Log("Device configuration changed: " + device);
                break;
        }
    }
}