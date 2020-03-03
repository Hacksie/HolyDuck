﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class Inventory : MonoBehaviour
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();

        private Status status;
        // Start is called before the first frame update
        void Start()
        {
            status = GetComponent<Status>();
        }

        public int ItemCount(string item)
        {
            if (inventory.ContainsKey(item))
            {
                return inventory[item];
            }

            return 0;
        }

        public bool ConsumeItem(string item, int count)
        {
            if(ItemCount(item) >= count)
            {
                inventory[item] -= count;
                return true;
            }

            return false;
        }

        public void DropItem(string item, int count)
        {
            //Logger.Log(name, "Item dropped ", item);
        }

        public void PickupItem(string itemType, int count)
        {
            Logger.Log(name, "Item picked up ", itemType, " ", count.ToString());

            CoreGame.instance.AddActionMessage(status.character + " picked up " + count.ToString() + " " + (count == 1 ? itemType : itemType + "s"));

            if (inventory.ContainsKey(itemType))
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
