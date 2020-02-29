using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    //FIXME: make this a scriptable object instead?
    public class TurnManager : MonoBehaviour
    {
        [Header("State")]
        [SerializeField] public int gameturn = 1;
        [SerializeField] public Dictionary<int, List<Action>> actions = new Dictionary<int, List<Action>>();

        public void QueueAction(Action action)
        {
            List<Action> turnActions;
            if(actions.ContainsKey(gameturn))
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
    }
}
