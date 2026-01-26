// GENERATED AUTOMATICALLY FROM 'Assets/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""Android"",
            ""id"": ""ae86027f-825e-49e9-885d-d879248bfc94"",
            ""actions"": [
                {
                    ""name"": ""Maju"",
                    ""type"": ""Button"",
                    ""id"": ""967f5ec8-e1df-425a-a5a2-206d8dddb5b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mundur"",
                    ""type"": ""Button"",
                    ""id"": ""4bbf9a54-27ab-4ced-87b6-bf6f07562f41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d626c196-a233-403e-a819-7bd4506cd11a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Maju"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0d0727-798a-4216-a33e-789b3288d7f1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mundur"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Android
        m_Android = asset.FindActionMap("Android", throwIfNotFound: true);
        m_Android_Maju = m_Android.FindAction("Maju", throwIfNotFound: true);
        m_Android_Mundur = m_Android.FindAction("Mundur", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Android
    private readonly InputActionMap m_Android;
    private IAndroidActions m_AndroidActionsCallbackInterface;
    private readonly InputAction m_Android_Maju;
    private readonly InputAction m_Android_Mundur;
    public struct AndroidActions
    {
        private @Control m_Wrapper;
        public AndroidActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Maju => m_Wrapper.m_Android_Maju;
        public InputAction @Mundur => m_Wrapper.m_Android_Mundur;
        public InputActionMap Get() { return m_Wrapper.m_Android; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AndroidActions set) { return set.Get(); }
        public void SetCallbacks(IAndroidActions instance)
        {
            if (m_Wrapper.m_AndroidActionsCallbackInterface != null)
            {
                @Maju.started -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMaju;
                @Maju.performed -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMaju;
                @Maju.canceled -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMaju;
                @Mundur.started -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMundur;
                @Mundur.performed -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMundur;
                @Mundur.canceled -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMundur;
            }
            m_Wrapper.m_AndroidActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Maju.started += instance.OnMaju;
                @Maju.performed += instance.OnMaju;
                @Maju.canceled += instance.OnMaju;
                @Mundur.started += instance.OnMundur;
                @Mundur.performed += instance.OnMundur;
                @Mundur.canceled += instance.OnMundur;
            }
        }
    }
    public AndroidActions @Android => new AndroidActions(this);
    public interface IAndroidActions
    {
        void OnMaju(InputAction.CallbackContext context);
        void OnMundur(InputAction.CallbackContext context);
    }
}
