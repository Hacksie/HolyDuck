// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace HackedDesign
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""bb82c208-6f55-41d1-a0ca-0132c1f925c0"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Button"",
                    ""id"": ""7e567fa1-9ab6-4a33-a05a-c0f4f5bdb470"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""apple"",
                    ""type"": ""Button"",
                    ""id"": ""0bf1ce85-def4-413b-bba3-40cf5ab242b7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""quack"",
                    ""type"": ""Button"",
                    ""id"": ""f0893262-60ef-4915-9694-92ff892cd8d9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""bite"",
                    ""type"": ""Button"",
                    ""id"": ""f6514716-3b29-420f-88de-760a4b01d254"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""splash"",
                    ""type"": ""Button"",
                    ""id"": ""ba5c6e7a-c8c9-40fe-8f39-5e8d194c4778"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""candy"",
                    ""type"": ""Button"",
                    ""id"": ""1fe25ff5-b768-4781-86cc-5ee707ad268d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""interact"",
                    ""type"": ""Button"",
                    ""id"": ""b366202a-cf0d-4cc9-9ce7-73127cc8b31b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""duck"",
                    ""type"": ""Button"",
                    ""id"": ""c418bdc2-78b4-47ab-9a69-9801b15b7b63"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""menu"",
                    ""type"": ""Button"",
                    ""id"": ""629cff92-ccf2-47d7-9169-6538a381f0f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""keypad"",
                    ""id"": ""a1f19781-bb87-4afe-9d4a-cd142e906956"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4a6eded0-eff3-40b0-b957-64580669d973"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""631a5769-688c-427a-9a06-9a65cb793fba"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dc8d9b2a-df32-4662-a17a-e9caaa5c1599"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b7cddae6-28a8-4aa1-ad9f-a53ed0ace471"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a8d640a7-0c81-4d99-8179-49c177d6a05e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""apple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15302039-81ef-41ff-a511-74cfe3b5661d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""quack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a507011-92c0-4099-ad2f-093739cfb224"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""bite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e1f3cc1-a1ae-4534-a912-b8361af1f137"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""splash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""190882b4-ac9b-4373-80be-04ac62a73fe0"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""candy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55f2b66b-722a-4e43-aac4-3a53e880cc31"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ad4f8d2-2e4e-4366-a07e-97949bc3ccd3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df8570ca-7e82-4f8f-9188-c27c85a28e2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // player
            m_player = asset.FindActionMap("player", throwIfNotFound: true);
            m_player_move = m_player.FindAction("move", throwIfNotFound: true);
            m_player_apple = m_player.FindAction("apple", throwIfNotFound: true);
            m_player_quack = m_player.FindAction("quack", throwIfNotFound: true);
            m_player_bite = m_player.FindAction("bite", throwIfNotFound: true);
            m_player_splash = m_player.FindAction("splash", throwIfNotFound: true);
            m_player_candy = m_player.FindAction("candy", throwIfNotFound: true);
            m_player_interact = m_player.FindAction("interact", throwIfNotFound: true);
            m_player_duck = m_player.FindAction("duck", throwIfNotFound: true);
            m_player_menu = m_player.FindAction("menu", throwIfNotFound: true);
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

        // player
        private readonly InputActionMap m_player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_player_move;
        private readonly InputAction m_player_apple;
        private readonly InputAction m_player_quack;
        private readonly InputAction m_player_bite;
        private readonly InputAction m_player_splash;
        private readonly InputAction m_player_candy;
        private readonly InputAction m_player_interact;
        private readonly InputAction m_player_duck;
        private readonly InputAction m_player_menu;
        public struct PlayerActions
        {
            private @InputActions m_Wrapper;
            public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @move => m_Wrapper.m_player_move;
            public InputAction @apple => m_Wrapper.m_player_apple;
            public InputAction @quack => m_Wrapper.m_player_quack;
            public InputAction @bite => m_Wrapper.m_player_bite;
            public InputAction @splash => m_Wrapper.m_player_splash;
            public InputAction @candy => m_Wrapper.m_player_candy;
            public InputAction @interact => m_Wrapper.m_player_interact;
            public InputAction @duck => m_Wrapper.m_player_duck;
            public InputAction @menu => m_Wrapper.m_player_menu;
            public InputActionMap Get() { return m_Wrapper.m_player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @apple.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApple;
                    @apple.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApple;
                    @apple.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApple;
                    @quack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuack;
                    @quack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuack;
                    @quack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuack;
                    @bite.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBite;
                    @bite.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBite;
                    @bite.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBite;
                    @splash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @splash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @splash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @candy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCandy;
                    @candy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCandy;
                    @candy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCandy;
                    @interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @duck.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
                    @duck.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
                    @duck.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDuck;
                    @menu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                    @menu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                    @menu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @move.started += instance.OnMove;
                    @move.performed += instance.OnMove;
                    @move.canceled += instance.OnMove;
                    @apple.started += instance.OnApple;
                    @apple.performed += instance.OnApple;
                    @apple.canceled += instance.OnApple;
                    @quack.started += instance.OnQuack;
                    @quack.performed += instance.OnQuack;
                    @quack.canceled += instance.OnQuack;
                    @bite.started += instance.OnBite;
                    @bite.performed += instance.OnBite;
                    @bite.canceled += instance.OnBite;
                    @splash.started += instance.OnSplash;
                    @splash.performed += instance.OnSplash;
                    @splash.canceled += instance.OnSplash;
                    @candy.started += instance.OnCandy;
                    @candy.performed += instance.OnCandy;
                    @candy.canceled += instance.OnCandy;
                    @interact.started += instance.OnInteract;
                    @interact.performed += instance.OnInteract;
                    @interact.canceled += instance.OnInteract;
                    @duck.started += instance.OnDuck;
                    @duck.performed += instance.OnDuck;
                    @duck.canceled += instance.OnDuck;
                    @menu.started += instance.OnMenu;
                    @menu.performed += instance.OnMenu;
                    @menu.canceled += instance.OnMenu;
                }
            }
        }
        public PlayerActions @player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnApple(InputAction.CallbackContext context);
            void OnQuack(InputAction.CallbackContext context);
            void OnBite(InputAction.CallbackContext context);
            void OnSplash(InputAction.CallbackContext context);
            void OnCandy(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnDuck(InputAction.CallbackContext context);
            void OnMenu(InputAction.CallbackContext context);
        }
    }
}
