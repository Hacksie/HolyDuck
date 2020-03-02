using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{

    public class PlayerController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] new SpriteRenderer renderer = null;
        [SerializeField] public InputActions controls = null;

        [SerializeField] private Sprite leftWater = null;
        [SerializeField] private Sprite leftGround = null;
        [SerializeField] private Sprite rightWater = null;
        [SerializeField] private Sprite rightGround = null;

        

        [SerializeField] private Vector2 direction = Vector2.right;
        [SerializeField] private Vector2 facingDirection = Vector2.right;
        [SerializeField] private bool inWater = true;

        private TurnManager turnManager = null;
        private GameState state = null;


        void Awake()
        {
            if (leftWater == null) Logger.LogError(name, "left water sprite not set");
            if (rightWater == null) Logger.LogError(name, "right water sprite not set");
            if (leftGround == null) Logger.LogError(name, "left ground sprite not set");
            if (rightGround == null) Logger.LogError(name, "right ground sprite not set");
        }

        public void Initialize(TurnManager turnManager, GameState state)
        {
            this.turnManager = turnManager;
            this.state = state;
        }

        public void SetInWater(bool flag)
        {
            inWater = flag;
            UpdateSprite();
        }



        public void MenuEvent(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                CoreGame.instance.SetMenu();
            }
        }

        public void MoveEvent(InputAction.CallbackContext context)
        {
            if (state.currentState == GameStateEnum.PLAYING) // We only care about making turns if we're playing
            {
                if (context.phase == InputActionPhase.Performed)
                {

                    direction = context.ReadValue<Vector2>().normalized;
                    if (direction == Vector2.left) facingDirection = Vector2.left;
                    if (direction == Vector2.right) facingDirection = Vector2.right;

                    //Check for bite attack here
                    QueueAction(ActionTypes.Move, direction);
                }
            }
        }

        public void AppleEvent(InputAction.CallbackContext context)
        {
            if (state.currentState == GameStateEnum.PLAYING) // We only care about making turns if we're playing
            {
                if (context.phase == InputActionPhase.Performed)
                {
                }
            }
        }

        public void CandyEvent(InputAction.CallbackContext context)
        {

        }

        public void QuackEvent(InputAction.CallbackContext context)
        {

        }

        public void BiteEvent(InputAction.CallbackContext context)
        {

        }

        public void SplashEvent(InputAction.CallbackContext context)
        {

        }

        public void InteractEvent(InputAction.CallbackContext context)
        {

        }

        public void DuckEvent(InputAction.CallbackContext context)
        {

        }


        public void UpdateSprite()
        {
            if (inWater)
            {
                if (facingDirection == Vector2.right)
                {
                    renderer.sprite = rightWater;
                }
                if (facingDirection == Vector2.left)
                {
                    renderer.sprite = leftWater;
                }
            }
            else
            {
                if (facingDirection == Vector2.right)
                {
                    renderer.sprite = rightGround;
                }
                if (facingDirection == Vector2.left)
                {
                    renderer.sprite = leftGround;
                }
            }
        }

        public void QueueAction(ActionTypes actionType, Vector2 direction)
        {
            turnManager.QueueAction(new Action()
            {
                source = gameObject,
                initiative = 10,
                player = true,
                enemy = false,
                action = actionType,
                direction = direction
            });
        }
    }
}
 