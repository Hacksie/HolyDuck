using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Action
    {
        public GameObject source;
        public int initiative;
        public bool player;
        public bool enemy;
        public ActionTypes action;
        public Vector2 direction;
    }
}