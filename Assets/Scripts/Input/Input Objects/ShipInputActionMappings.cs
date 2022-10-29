//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Scripts/Input/Input Objects/ShipInputActionMappings.inputactions
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

public partial class @ShipInputActionMappings : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipInputActionMappings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInputActionMappings"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""c5d3eede-322e-4470-9263-5b0a29bdb5b9"",
            ""actions"": [
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""daddc2f8-c22a-4731-8494-7bf200f80f43"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LinearMovement"",
                    ""type"": ""Value"",
                    ""id"": ""0c7d97f8-00f3-4ede-b2b8-e6599a69ea5d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Horn"",
                    ""type"": ""Button"",
                    ""id"": ""f08dcef6-a59e-45d7-8c10-9aa0e7787e09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""969473e5-640d-403c-934d-d0d75600c9f5"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""0dd70163-6676-41e5-9063-63cf4b3263e8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""c572311f-665e-4acb-a755-2df2bc73e25e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""0e5e678f-0b15-4f7e-aeb6-60a13f0f2d28"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec44c317-ed76-4337-994b-610c96ad702b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4724fdaa-86db-4293-ba10-65f95e78534d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""df38edca-8dfd-4885-bd5e-d4f0a252a760"",
                    ""path"": ""<XRController>{RightHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""UpDown"",
                    ""id"": ""1888fe77-48f5-4ea8-bd34-551e1e79ce56"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""60a42ae7-025a-4fd6-8608-eb4258044859"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""de84322c-d94e-42d1-a8f4-9cd8bf63b5cf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""cc5f4bb1-93c2-4d72-95a3-893a074ddd28"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2476c3ab-a9ee-4c89-be0f-87292ec82093"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d8a1dafa-e5dd-43e9-8318-17536003b020"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1e6500a2-b236-455d-bd4c-d7b936a4e9cf"",
                    ""path"": ""<XRController>{LeftHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LinearMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3078a785-575f-45a9-9d7c-9ed63571e990"",
                    ""path"": ""<Keyboard>/#(H)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Steer = m_Ship.FindAction("Steer", throwIfNotFound: true);
        m_Ship_LinearMovement = m_Ship.FindAction("LinearMovement", throwIfNotFound: true);
        m_Ship_Horn = m_Ship.FindAction("Horn", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Steer;
    private readonly InputAction m_Ship_LinearMovement;
    private readonly InputAction m_Ship_Horn;
    public struct ShipActions
    {
        private @ShipInputActionMappings m_Wrapper;
        public ShipActions(@ShipInputActionMappings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steer => m_Wrapper.m_Ship_Steer;
        public InputAction @LinearMovement => m_Wrapper.m_Ship_LinearMovement;
        public InputAction @Horn => m_Wrapper.m_Ship_Horn;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Steer.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteer;
                @LinearMovement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnLinearMovement;
                @LinearMovement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnLinearMovement;
                @LinearMovement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnLinearMovement;
                @Horn.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnHorn;
                @Horn.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnHorn;
                @Horn.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnHorn;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @LinearMovement.started += instance.OnLinearMovement;
                @LinearMovement.performed += instance.OnLinearMovement;
                @LinearMovement.canceled += instance.OnLinearMovement;
                @Horn.started += instance.OnHorn;
                @Horn.performed += instance.OnHorn;
                @Horn.canceled += instance.OnHorn;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    public interface IShipActions
    {
        void OnSteer(InputAction.CallbackContext context);
        void OnLinearMovement(InputAction.CallbackContext context);
        void OnHorn(InputAction.CallbackContext context);
    }
}
