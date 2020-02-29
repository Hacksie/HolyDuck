using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    //FIXME: make this a scriptable object instead?
    public class TurnManager : MonoBehaviour
    {
        [Header("State")]
        [SerializeField] public int gameturn = 0;
        [SerializeField] public Dictionary<int, List<Action>> actions = new Dictionary<int, List<Action>>();

        private GameState state;

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void QueueAction(Action action)
        {
            List<Action> turnActions;
            if (actions.ContainsKey(gameturn))
            {
                turnActions = actions[gameturn];
            }
            else
            {
                turnActions = new List<Action>();
                actions.Add(gameturn, turnActions);
            }

            Logger.Log(name, gameturn.ToString(), " - ", "action queued: ", action.source.name, " ", action.action.ToString(), " ", action.direction.ToString());
            turnActions.Add(action);
        }

        public bool PlayerTurnCompleted()
        {
            if (!actions.ContainsKey(gameturn)) return false;

            return actions[gameturn].Exists(a => a.player);
        }

        public void ProcessTurn()
        {
            if (actions.ContainsKey(gameturn))
            {
                var turnActions = actions[gameturn];

                foreach(var action in turnActions)
                {
                    switch(action.action)
                    {
                        case ActionTypes.Move:
                            var move = action.source.GetComponent<MoveActionHandler>();

                            move.Handle(action.source, action.direction);

                            break;
                        default:
                            Logger.Log(name, "unknown action");
                            break;
                    }
                }
            }

            gameturn++;
        }
    }
}
