﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Inventory : MonoBehaviour
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DropItem(string item, int count)
        {
            Logger.Log(name, "Item dropped ", item);
        }

        public void PickupItem(string itemType, int count)
        {
            Logger.Log(name, "Item picked up ", itemType, " ", count.ToString());

            if(itemType == "Chick")
            {

            }

            if(inventory.ContainsKey(itemType))
            {
                inventory[itemType] += count;
            }
            else
            {
                inventory.Add(itemType, count);
            }
            
        }
    }
}
