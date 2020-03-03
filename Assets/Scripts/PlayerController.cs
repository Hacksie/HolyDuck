using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class PlayerController : MonoBehaviour
    {
        private Status status;

        [Header("GameObjects")]
        [SerializeField] new SpriteRenderer renderer = null;
        [SerializeField] public InputActions controls = null;

        [SerializeField] private Sprite leftWater = null;
        [SerializeField] private Sprite leftGround = null;
        [SerializeField] private Sprite rightWater = null;
        [SerializeField] private Sprite rightGround = null;


        [SerializeField] private LayerMask colliderLayerMask;
        [SerializeField] public int distance = 1;
        [SerializeField] private Vector2 direction = Vector2.right;
        [SerializeField] private Vector2 facingDirection = Vector2.right;
        [SerializeField] private bool inWater = true;

        private TurnManager turnManager = null;
        private GameState state = null;


        void Awake()
        {
            status = GetComponent<Status>();
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

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, colliderLayerMask);

                    if(hit.collider != null)
                    {
                        var npc = hit.collider.GetComponent<NPCController>();
                        if (npc != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = npc.gameObject,
                                source = gameObject,
                                initiative = 10,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Interact,
                                direction = direction
                            });

                            return;
                        }

                        var enemy = hit.collider.GetComponent<EnemyController>();
                        if(enemy != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = enemy.gameObject,
                                source = gameObject,
                                initiative = 10,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Bite,
                                direction = direction,
                                damage = RollDamage()
                            }); ;

                            return;
                        }
                    }


                    turnManager.QueueAction(new Action()
                    {
                        target = gameObject,
                        source = gameObject,
                        initiative = status.initiative,
                        player = true,
                        enemy = false,
                        action = ActionTypes.Move,
                        direction = direction
                    });
                }
            }
        }

        public int RollDamage()
        {
            return UnityEngine.Random.Range(status.minAttack, status.maxAttack + 1);
        }

        public void AppleEvent(InputAction.CallbackContext context)
        {
            if (state.currentState == GameStateEnum.PLAYING) // We only care about making turns if we're playing
            {
                if (context.phase == InputActionPhase.Performed)
                {
                    turnManager.QueueAction(new Action()
                    {
                        target = gameObject,
                        source = gameObject,
                        initiative = 10,
                        player = true,
                        enemy = false,
                        action = ActionTypes.Apple,
                        direction = Vector2.zero
                    });
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

        }
    }
}
 