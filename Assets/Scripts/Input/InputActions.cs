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
                    ""name"": ""splash"",
                    ""type"": ""Button"",
                    ""id"": ""ba5c6e7a-c8c9-40fe-8f39-5e8d194c4778"",
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
                    ""name"": ""menu"",
                    ""type"": ""Button"",
                    ""id"": ""629cff92-ccf2-47d7-9169-6538a381f0f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""one"",
                    ""type"": ""Button"",
                    ""id"": ""fa87287d-a842-4b5c-b539-fcde6a9d1fa9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""two"",
                    ""type"": ""Button"",
                    ""id"": ""1ed6d77b-dc57-4ab6-8eb3-d082cda78070"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""three"",
                    ""type"": ""Button"",
                    ""id"": ""fe28bf97-eb32-4f92-a9b9-aee229e8aa17"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""four"",
                    ""type"": ""Button"",
                    ""id"": ""05d0ae13-7f68-4a41-bb18-f8b710d5e0f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""five"",
                    ""type"": ""Button"",
                    ""id"": ""981734ca-158b-4df5-b4c0-de81370a633f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""six"",
                    ""type"": ""Button"",
                    ""id"": ""1f261bdc-3949-4672-9d50-37ed994bedea"",
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
                    ""id"": ""df8570ca-7e82-4f8f-9188-c27c85a28e2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a38a8c2f-da91-4ed3-b23e-225afb0ee719"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""one"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d007558-4356-4c8f-9b97-b19803fcc9bd"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a41d33f7-4066-4042-b11b-a8b4fdea01f9"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1b5ec69-3ec1-4078-acf9-c74ac85c0463"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""four"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c2732d2-a00c-49b8-99db-b714d0124534"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""five"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3bc0165-22c1-4f01-9808-e32893225e15"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""six"",
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
            m_player_splash = m_player.FindAction("splash", throwIfNotFound: true);
            m_player_interact = m_player.FindAction("interact", throwIfNotFound: true);
            m_player_menu = m_player.FindAction("menu", throwIfNotFound: true);
            m_player_one = m_player.FindAction("one", throwIfNotFound: true);
            m_player_two = m_player.FindAction("two", throwIfNotFound: true);
            m_player_three = m_player.FindAction("three", throwIfNotFound: true);
            m_player_four = m_player.FindAction("four", throwIfNotFound: true);
            m_player_five = m_player.FindAction("five", throwIfNotFound: true);
            m_player_six = m_player.FindAction("six", throwIfNotFound: true);
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
        private readonly InputAction m_player_splash;
        private readonly InputAction m_player_interact;
        private readonly InputAction m_player_menu;
        private readonly InputAction m_player_one;
        private readonly InputAction m_player_two;
        private readonly InputAction m_player_three;
        private readonly InputAction m_player_four;
        private readonly InputAction m_player_five;
        private readonly InputAction m_player_six;
        public struct PlayerActions
        {
            private @InputActions m_Wrapper;
            public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @move => m_Wrapper.m_player_move;
            public InputAction @apple => m_Wrapper.m_player_apple;
            public InputAction @quack => m_Wrapper.m_player_quack;
            public InputAction @splash => m_Wrapper.m_player_splash;
            public InputAction @interact => m_Wrapper.m_player_interact;
            public InputAction @menu => m_Wrapper.m_player_menu;
            public InputAction @one => m_Wrapper.m_player_one;
            public InputAction @two => m_Wrapper.m_player_two;
            public InputAction @three => m_Wrapper.m_player_three;
            public InputAction @four => m_Wrapper.m_player_four;
            public InputAction @five => m_Wrapper.m_player_five;
            public InputAction @six => m_Wrapper.m_player_six;
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
                    @splash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @splash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @splash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSplash;
                    @interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @menu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                    @menu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                    @menu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                    @one.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                    @one.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                    @one.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                    @two.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                    @two.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                    @two.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                    @three.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                    @three.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                    @three.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                    @four.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                    @four.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                    @four.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                    @five.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                    @five.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                    @five.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                    @six.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
                    @six.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
                    @six.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
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
                    @splash.started += instance.OnSplash;
                    @splash.performed += instance.OnSplash;
                    @splash.canceled += instance.OnSplash;
                    @interact.started += instance.OnInteract;
                    @interact.performed += instance.OnInteract;
                    @interact.canceled += instance.OnInteract;
                    @menu.started += instance.OnMenu;
                    @menu.performed += instance.OnMenu;
                    @menu.canceled += instance.OnMenu;
                    @one.started += instance.OnOne;
                    @one.performed += instance.OnOne;
                    @one.canceled += instance.OnOne;
                    @two.started += instance.OnTwo;
                    @two.performed += instance.OnTwo;
                    @two.canceled += instance.OnTwo;
                    @three.started += instance.OnThree;
                    @three.performed += instance.OnThree;
                    @three.canceled += instance.OnThree;
                    @four.started += instance.OnFour;
                    @four.performed += instance.OnFour;
                    @four.canceled += instance.OnFour;
                    @five.started += instance.OnFive;
                    @five.performed += instance.OnFive;
                    @five.canceled += instance.OnFive;
                    @six.started += instance.OnSix;
                    @six.performed += instance.OnSix;
                    @six.canceled += instance.OnSix;
                }
            }
        }
        public PlayerActions @player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnApple(InputAction.CallbackContext context);
            void OnQuack(InputAction.CallbackContext context);
            void OnSplash(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnMenu(InputAction.CallbackContext context);
            void OnOne(InputAction.CallbackContext context);
            void OnTwo(InputAction.CallbackContext context);
            void OnThree(InputAction.CallbackContext context);
            void OnFour(InputAction.CallbackContext context);
            void OnFive(InputAction.CallbackContext context);
            void OnSix(InputAction.CallbackContext context);
        }
    }
}
