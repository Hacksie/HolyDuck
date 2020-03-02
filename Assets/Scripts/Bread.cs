using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Bread : MonoBehaviour
    {
        // Start is called before the first frame update
        public SpriteRenderer sprite;
        public bool hasBeenPickedUp = false;
        public bool isBread = true;
        public bool isChip = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hasBeenPickedUp) return;
            //Logger.Log(name, collision.gameObject.name);

            // Does the other object have an inventory?
            var consumer = collision.gameObject.GetComponent<Consumer>();
            if (consumer == null) return;

            //FIXME: handle enemy consumption of bread

            if (isBread) consumer.PickupBread();
            if (isChip) consumer.PickupChip();

            hasBeenPickedUp = true;
            sprite.gameObject.SetActive(false);
        }
    }

}