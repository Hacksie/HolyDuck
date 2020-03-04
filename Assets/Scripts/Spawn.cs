using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Spawn : MonoBehaviour
    {
        public SpawnType spawnType;
        public bool playerStart = false;
        public bool finalBossStart = false;
        public bool finalBossStart2 = false;
        public bool crowBossStart = false;
        public bool swanStart = false;
        public bool seagullStart = false;
        public bool snipeStart = false;
        public bool sandpiperStart = false;
        public bool princessStart = false;
        public bool active = true;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.SetInWater(spawnType == SpawnType.Water);
            }


            var npcController = collision.gameObject.GetComponent<NPCController>();

            if (npcController != null)
            {
                npcController.SetInWater(spawnType == SpawnType.Water);
            }



            // Do other character here, using npc controller
            /*
            if(collision.gameObject.CompareTag("Player"))
            {

            }*/
        }
    }

    [System.Serializable]
    public enum SpawnType
    {
        Water,
        Ground,
        Prop
    }
}