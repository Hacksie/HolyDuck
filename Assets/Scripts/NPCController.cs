using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class NPCController : MonoBehaviour
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
