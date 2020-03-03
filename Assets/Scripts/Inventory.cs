using System.Collections;
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
            Logger.Log(name, "Item dropped ", item);
        }

        public void PickupItem(string itemType, int count)
        {
            Logger.Log(name, "Item picked up ", itemType, " ", count.ToString());

            CoreGame.instance.AddActionMessage(name + " picked up " + count.ToString() + " " + (count == 1 ? itemType : itemType + "s"));

            if (itemType == "Chick")
            {

            }

            if (itemType == "Bread")
            {

            }



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
