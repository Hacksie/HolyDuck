﻿using UnityEngine;

namespace HackedDesign
{
    public class InteractActionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask colliderLayerMask;

        private Status status;



        public int distance = 1;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            CoreGame.instance.AddActionMessage(action.sourceName + " interacts with " + status.character);
            /*
            RaycastHit2D hit = Physics2D.Raycast(transform.position, action.direction, distance, colliderLayerMask);

            if (hit.collider != null)
            {
                Logger.Log(name, hit.collider.gameObject.name.ToString());
                CoreGame.instance.AddActionMessage(action.source.name + " interacts with " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
            }
            else
            {
                //transform.Translate((direction * distance), Space.World);
                CoreGame.instance.AddActionMessage(action.source.name + " tried to interact by the npc moved");
            }*/
        }
    }
}
