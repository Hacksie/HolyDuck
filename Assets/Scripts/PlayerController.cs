﻿using System;
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

        [Header("Game Settings")]
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
            status.Reset();
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

                    if (hit.collider != null)
                    {
                        var crow = hit.collider.GetComponent<CrowBoss>();
                        if (crow != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = crow.gameObject,
                                source = gameObject,
                                sourceName = status.character,
                                initiative = status.initiative,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Shinies,
                                direction = direction,
                                damage = 0
                            });


                            return;
                        }

                        var npc = hit.collider.GetComponent<NPCController>();
                        if (npc != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = npc.gameObject,
                                source = gameObject,
                                sourceName = status.character,
                                initiative = status.initiative,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Interact,
                                direction = direction
                            });

                            return;
                        }

                        var enemy = hit.collider.GetComponent<EnemyController>();
                        if (enemy != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = enemy.gameObject,
                                source = gameObject,
                                sourceName = status.character,
                                initiative = status.initiative,
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
                        sourceName = status.character,
                        initiative = status.initiative,
                        player = true,
                        enemy = false,
                        action = ActionTypes.Move,
                        direction = direction
                    });
                }
            }
        }

        public void QuackEvent(InputAction.CallbackContext context)
        {
            if (state.currentState == GameStateEnum.PLAYING) // We only care about making turns if we're playing
            {
                if (context.phase == InputActionPhase.Performed)
                {
                    Logger.Log(name, "quack event");

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, colliderLayerMask);

                    if (hit.collider != null)
                    {

                        var enemy = hit.collider.GetComponent<EnemyController>();
                        if (enemy != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = enemy.gameObject,
                                source = gameObject,
                                sourceName = status.character,
                                initiative = status.initiative,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Quack,
                                direction = direction,
                                damage = 0
                            });


                            return;
                        }

                        var npc = hit.collider.GetComponent<NPCController>();
                        if (npc != null)
                        {
                            turnManager.QueueAction(new Action()
                            {
                                target = npc.gameObject,
                                source = gameObject,
                                sourceName = status.character,
                                initiative = status.initiative,
                                player = true,
                                enemy = false,
                                action = ActionTypes.Quack,
                                direction = direction,
                                damage = 0
                            });
                            return;
                        }


                        CoreGame.instance.AddActionMessage(status.character + " has nothing to quack!");

                    }
                    else
                    {
                        CoreGame.instance.AddActionMessage(status.character + " has nothing to quack!");
                    }
                }
            }
        }

        public int RollDamage()
        {
            return UnityEngine.Random.Range(status.minAttack, status.maxAttack + 1);
        }

        public void StarveEvent()
        {
            CoreGame.instance.AddActionMessage(status.character + " starved!");
            CoreGame.instance.SetGameOverStarved();
        }

        public void DieEvent()
        {
            CoreGame.instance.AddActionMessage(status.character + " died!");
            CoreGame.instance.SetGameOverDead();
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
                        sourceName = status.character,
                        initiative = status.initiative,
                        player = true,
                        enemy = false,
                        action = ActionTypes.Apple,
                        direction = Vector2.zero
                    });
                }
            }
        }

        public void MushroomEvent(InputAction.CallbackContext context)
        {
            if (state.currentState == GameStateEnum.PLAYING) // We only care about making turns if we're playing
            {
                if (context.phase == InputActionPhase.Performed)
                {
                    turnManager.QueueAction(new Action()
                    {
                        target = gameObject,
                        source = gameObject,
                        sourceName = status.character,
                        initiative = status.initiative,
                        player = true,
                        enemy = false,
                        action = ActionTypes.Mushroom,
                        direction = Vector2.zero
                    });
                }
            }
        }


        public void SplashEvent(InputAction.CallbackContext context)
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
    }
}
