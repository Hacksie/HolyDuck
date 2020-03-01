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

        private void OnEnable()
        {

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
                    QueueAction(ActionTypes.Move, direction);
                }
            }
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

        private void OnDisable()
        {

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

        public void UpdateTransform()
        {
            // Movement augments (0 - 10) are reduced by a factor of 10
            //transform.Translate(movementVector * (baseMovementSpeed + (CoreGame.Instance.state.player.movementAugments / 10.0f)) * Time.fixedDeltaTime);
        }
    }
}