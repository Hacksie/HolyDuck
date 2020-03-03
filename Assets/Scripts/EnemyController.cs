using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class EnemyController : MonoBehaviour
    {

        [Header("GameObjects")]
        [SerializeField] new SpriteRenderer renderer = null;


        [SerializeField] private Sprite leftWater = null;
        [SerializeField] private Sprite leftGround = null;
        [SerializeField] private Sprite rightWater = null;
        [SerializeField] private Sprite rightGround = null;

        [SerializeField] private Vector2 direction = Vector2.right;
        [SerializeField] private Vector2 facingDirection = Vector2.right;
        [SerializeField] private bool inWater = true;

        [SerializeField] private int health = 10;
        [SerializeField] private UnityEvent behaviour;

        private TurnManager turnManager = null;
        private GameState state = null;
        private Status status;
        private Transform player;

        void Awake()
        {
            status = GetComponent<Status>();
            if (leftWater == null) Logger.LogError(name, "left water sprite not set");
            if (rightWater == null) Logger.LogError(name, "right water sprite not set");
            if (leftGround == null) Logger.LogError(name, "left ground sprite not set");
            if (rightGround == null) Logger.LogError(name, "right ground sprite not set");
        }

        public void Initialize(TurnManager turnManager, GameState state, Transform player)
        {
            this.turnManager = turnManager;
            this.state = state;
            this.player = player;
        }

        public void SetInWater(bool flag)
        {
            inWater = flag;
            UpdateSprite();
        }

        public void UpdateFacing()
        {

        }

        public Vector2 DirectionToPlayer()
        {
            return player.position - transform.position;
        }

        public Vector2 RoundedDirectionToPlayer()
        {
            var dir = DirectionToPlayer().normalized;

            dir.x = Mathf.RoundToInt(dir.x);
            dir.y = Mathf.RoundToInt(dir.y);

            if(Mathf.Abs(dir.x) == Mathf.Abs(dir.y)) // Don't allow diagonals.
            {
                dir.y = 0;
            }

            return dir;
        }
        public float DistanceToPlayer()
        {
            return DirectionToPlayer().magnitude;
        }

        public void UpdateTurn()
        {
            if (transform.position.x < player.position.x)
            {
                facingDirection = Vector2.right;
            }
            if (transform.position.x > player.position.x)
            {
                facingDirection = Vector2.left;
            }
            UpdateSprite();

            behaviour.Invoke();
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

        public void Kill()
        {
            CoreGame.instance.AddActionMessage(name + " died!");
            gameObject.SetActive(false);
        }

        public void BiteEvent()
        {
            turnManager.QueueAction(new Action()
            {
                action = ActionTypes.Bite,
                source = gameObject,
                direction = RoundedDirectionToPlayer(),
                target = player.gameObject,
                damage = RollDamage(),
                enemy = true,
                initiative = status.initiative,
                player = false
            });
        }

        public void MoveTowardPlayerEvent()
        {
            turnManager.QueueAction(new Action()
            {
                action = ActionTypes.Move,
                source = gameObject,
                direction = RoundedDirectionToPlayer(),
                target = gameObject,
                damage = RollDamage(),
                enemy = true,
                initiative = status.initiative,
                player = false
            });
        }

        public void QueueAction(ActionTypes action, GameObject target, Vector2 direction, int damage)
        {

        }

        public int RollDamage()
        {
            return Random.Range(status.minAttack, status.maxAttack + 1);
        }
    }
}
