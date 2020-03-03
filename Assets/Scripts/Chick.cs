using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Chick : MonoBehaviour
    {
        // Start is called before the first frame update
        public SpriteRenderer sprite;
        public bool hasBeenPickedUp = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (hasBeenPickedUp) return;

            // Does the other object have an inventory?
            var rescue = collision.gameObject.GetComponent<Rescue>();
            if (rescue == null) return;

            rescue.PickupChick();

            hasBeenPickedUp = true;
            sprite.gameObject.SetActive(false);
        }
    }

}