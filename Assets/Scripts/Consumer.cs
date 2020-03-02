using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Consumer : MonoBehaviour
    {
        public void PickupBread()
        {
            CoreGame.instance.AddActionMessage(name + " ate some bread");
            CoreGame.instance.EatBread();
            //CoreGame.instance.SaveChick();
        }

        public void PickupChip()
        {
            CoreGame.instance.AddActionMessage(name + " ate a chip");
            CoreGame.instance.EatChip();
        }
    }
}
