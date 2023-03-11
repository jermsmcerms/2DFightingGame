//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TDFG
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""c0fa802b-108e-4942-b57a-a07bbc98cb8b"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""5b557663-2b64-4283-81d5-13d3a253b805"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""0dc61afd-afc6-4d2c-a474-463c7605a1f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9ebb389e-04d9-43c3-90b3-ea814b1bddd8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00817ea3-ba7a-4b27-9c87-1d2ba36adb91"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2002d138-0771-4fe7-8674-b1c5f0baa222"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1cf5faff-6351-4555-94ce-ad63e67a8efc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f68b4566-ab3f-47b7-b525-e0cd508d5647"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""50e86350-5e56-4715-bbdb-3513d90b1f04"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MatchControls"",
            ""id"": ""6a8ab939-d97f-4bad-8d84-acf36720f13c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""63764aeb-4d87-4257-bc4d-49369d8420d8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9d12a2d9-be16-4203-a3ce-1f392e6cd67f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1af19d77-e085-4d54-a5b7-ba7579b1be96"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""35ff92bf-d622-48fa-a8d5-c63194662385"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fd148129-0d93-44cc-8c06-e5bbaf5babb4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e8b01e4-d668-48d7-8c16-f12f70488211"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Navigation = m_UI.FindAction("Navigation", throwIfNotFound: true);
            m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
            // MatchControls
            m_MatchControls = asset.FindActionMap("MatchControls", throwIfNotFound: true);
            m_MatchControls_Movement = m_MatchControls.FindAction("Movement", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Navigation;
        private readonly InputAction m_UI_Select;
        public struct UIActions
        {
            private @PlayerControls m_Wrapper;
            public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Navigation => m_Wrapper.m_UI_Navigation;
            public InputAction @Select => m_Wrapper.m_UI_Select;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Navigation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigation;
                    @Navigation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigation;
                    @Navigation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigation;
                    @Select.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Navigation.started += instance.OnNavigation;
                    @Navigation.performed += instance.OnNavigation;
                    @Navigation.canceled += instance.OnNavigation;
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                }
            }
        }
        public UIActions @UI => new UIActions(this);

        // MatchControls
        private readonly InputActionMap m_MatchControls;
        private IMatchControlsActions m_MatchControlsActionsCallbackInterface;
        private readonly InputAction m_MatchControls_Movement;
        public struct MatchControlsActions
        {
            private @PlayerControls m_Wrapper;
            public MatchControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_MatchControls_Movement;
            public InputActionMap Get() { return m_Wrapper.m_MatchControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MatchControlsActions set) { return set.Get(); }
            public void SetCallbacks(IMatchControlsActions instance)
            {
                if (m_Wrapper.m_MatchControlsActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_MatchControlsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_MatchControlsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_MatchControlsActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_MatchControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public MatchControlsActions @MatchControls => new MatchControlsActions(this);
        public interface IUIActions
        {
            void OnNavigation(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
        }
        public interface IMatchControlsActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}