using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Rescue : MonoBehaviour
    {
        public void PickupChick()
        {
            CoreGame.instance.AddActionMessage(name + " rescued a chick!");
            CoreGame.instance.SaveChick(); 
        }
    }
}
