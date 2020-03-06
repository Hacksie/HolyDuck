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

        [Header("Game Settings")]
        [SerializeField] private Vector2 direction = Vector2.right;
        [SerializeField] private Vector2 facingDirection = Vector2.right;
        [SerializeField] private bool inWater = true;
        [SerializeField] private bool visible = true;

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
            Logger.Log(name, "initialize");
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

            if ((Mathf.Abs(dir.x) >= Mathf.Abs(dir.y)))
            {
                dir.x = Mathf.RoundToInt(dir.x);
                dir.y = 0;
            }
            else
            {
                dir.x = 0;
                dir.y = Mathf.RoundToInt(dir.y);
            }


            return dir;
        }

        public void SetVisible(bool flag)
        {
            renderer.enabled = flag;
        }

        public bool IsVisible()
        {
            return renderer.enabled;
        }

        public float DistanceToPlayer()
        {
            return DirectionToPlayer().magnitude;
        }

        public void UpdateTurn()
        {
            Logger.Log(name, player.transform.position.ToString());
            if (transform.position.x < player.position.x)
            {
                facingDirection = Vector2.right;
            }
            if (transform.position.x > player.position.x)
            {
                facingDirection = Vector2.left;
            }
            UpdateSprite();

            if (status.stunned)
            {
                CoreGame.instance.AddActionMessage(status.character, " is stunned!");
                status.stunnedCounter--;

                if (status.stunnedCounter <= 0)
                {
                    CoreGame.instance.AddActionMessage(status.character, " will recover next turn!");
                    status.stunned = false;
                }

            }
            else
            {

                behaviour.Invoke();
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

        public void Kill()
        {
            CoreGame.instance.AddActionMessage(status.character + " died!");
            gameObject.SetActive(false);
            status.dead = true;
        }

        public void BiteEvent()
        {
            turnManager.QueueAction(new Action()
            {
                action = ActionTypes.Bite,
                source = gameObject,
                sourceName = status.character,
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
                sourceName = status.character,
                direction = RoundedDirectionToPlayer(),
                target = gameObject,
                damage = RollDamage(),
                enemy = true,
                initiative = status.initiative,
                player = false
            });
        }

        public void SubmergeEvent()
        {
            turnManager.QueueAction(new Action()
            {
                action = ActionTypes.Submerge,
                source = gameObject,
                sourceName = status.character,
                direction = RoundedDirectionToPlayer(),
                target = gameObject,
                damage = 0,
                enemy = true,
                initiative = status.initiative,
                player = false
            });
        }
        public void EmergeEvent()
        {
            turnManager.QueueAction(new Action()
            {
                action = ActionTypes.Emerge,
                source = gameObject,
                sourceName = status.character,
                direction = RoundedDirectionToPlayer(),
                target = gameObject,
                damage = 0,
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
