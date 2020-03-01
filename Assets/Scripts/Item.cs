using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Item : MonoBehaviour
    {
        // Start is called before the first frame update
        public SpriteRenderer sprite;
        public bool hasBeenPickedUp = false;
        public string itemType = "";
        public int count = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hasBeenPickedUp) return;
            //Logger.Log(name, collision.gameObject.name);

            // Does the other object have an inventory?
            var inventory = collision.gameObject.GetComponent<Inventory>();
            if (inventory == null) return;

            inventory.PickupItem(itemType, count);

            hasBeenPickedUp = true;
            sprite.gameObject.SetActive(false);
        }
    }

}