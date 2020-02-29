using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{

    public class PlayerController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] new SpriteRenderer renderer;
        [SerializeField] public InputActions controls;

        [SerializeField] private Sprite leftWater;
        [SerializeField] private Sprite leftGround;
        [SerializeField] private Sprite rightWater;
        [SerializeField] private Sprite rightGround;

        private TurnManager turnManager;

        [SerializeField] private Vector2 direction = Vector2.right;
        [SerializeField] private bool inWater = true;


        void Awake()
        {
            if (leftWater == null) Logger.LogError(name, "left water sprite not set");
            if (rightWater == null) Logger.LogError(name, "right water sprite not set");
            if (leftGround == null) Logger.LogError(name, "left ground sprite not set");
            if (rightGround == null) Logger.LogError(name, "right ground sprite not set");
        }

        public void Initialize(TurnManager actionManager)
        {
            this.turnManager = actionManager;
        }

        private void OnEnable()
        {

        }

        public void MoveEvent(InputAction.CallbackContext context)
        {

            if (context.phase == InputActionPhase.Performed)
            {
                direction = context.ReadValue<Vector2>().normalized;
                QueueAction(ActionTypes.Move, direction);
            }
        }

        public void UpdateSprite()
        {
            if (inWater)
            {
                if (direction == Vector2.right)
                {
                    renderer.sprite = rightWater;
                }
                if (direction == Vector2.left)
                {
                    renderer.sprite = leftWater;
                }
            }
            else
            {
                if (direction == Vector2.right)
                {
                    renderer.sprite = rightGround;
                }
                if (direction == Vector2.left)
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