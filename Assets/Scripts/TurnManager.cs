using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    //FIXME: make this a scriptable object instead?
    public class TurnManager : MonoBehaviour
    {
        [Header("State")]
        //[SerializeField] public int gameturn = 0;
        [SerializeField] public Dictionary<int, List<Action>> actions = new Dictionary<int, List<Action>>();

        private GameState state;

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void QueueAction(Action action)
        {
            List<Action> turnActions;
            if (actions.ContainsKey(state.turn))
            {
                turnActions = actions[state.turn];
            }
            else
            {
                turnActions = new List<Action>();
                actions.Add(state.turn, turnActions);
            }

            Logger.Log(name, state.turn.ToString(), " - ", "action queued: ", action.source.name, " ", action.action.ToString(), " ", action.direction.ToString());
            turnActions.Add(action);
        }

        public bool PlayerTurnCompleted()
        {
            if (!actions.ContainsKey(state.turn)) return false;

            return actions[state.turn].Exists(a => a.player);
        }

        public void ProcessTurn()
        {
            if (actions.ContainsKey(state.turn))
            {
                var turnActions = actions[state.turn].OrderBy(a=>a.initiative);

                foreach(var action in turnActions)
                {
                    switch(action.action)
                    {
                        case ActionTypes.Move:
                            var move = action.target.GetComponent<MoveActionHandler>();
                            if (move != null)
                            {
                                move.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't move");
                            }

                            break;
                        case ActionTypes.Interact:
                            var interact = action.target.GetComponent<InteractActionHandler>();
                            if (interact != null)
                            {
                                interact.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't interact with " + action.target.name);
                            }
                            break;
                        case ActionTypes.Bite:
                            var bite = action.target.GetComponent<BiteActionHandler>();
                            if (bite != null)
                            {
                                bite.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't bite " + action.target.name);
                            }
                            break;
                        case ActionTypes.Apple:
                            var apple = action.target.GetComponent<AppleActionHandler>();
                            if (apple != null)
                            {
                                apple.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't eat an apple");
                            }
                            break;
                        case ActionTypes.Submerge:
                            var submerge = action.target.GetComponent<SubmergeActionHandler>();
                            if(submerge != null)
                            {
                                submerge.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't submerge");
                            }
                            break;
                        case ActionTypes.Emerge:
                            var emerge = action.target.GetComponent<SubmergeActionHandler>();
                            if (emerge != null)
                            {
                                emerge.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't emerge");
                            }
                            break;
                        case ActionTypes.Quack:
                            var quack = action.target.GetComponent<QuackActionHandler>();
                            if (quack != null)
                            {
                                quack.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't quack that!");
                            }
                            break;
                        case ActionTypes.Mushroom:
                            var mushroom = action.target.GetComponent<MushroomActionHandler>();
                            if (mushroom != null)
                            {
                                mushroom.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't mushroom!");
                            }
                            break;
                        case ActionTypes.Shinies:
                            var shiny = action.target.GetComponent<ShinyActionHandler>();
                            if (shiny != null)
                            {
                                shiny.Handle(action);
                            }
                            else
                            {
                                CoreGame.instance.AddActionMessage(action.sourceName + " can't shiny that!");
                            }
                            break;

                        default:
                            Logger.Log(name, "unknown action");
                            break;
                    }
                }
            }

            state.IncrementTurn();
        }
    }
}
