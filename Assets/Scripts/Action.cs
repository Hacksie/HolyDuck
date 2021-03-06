﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Action
    {
        public GameObject target;
        public GameObject source;
        public string sourceName;
        public int initiative;
        public bool player;
        public bool enemy;
        public ActionTypes action;
        public Vector2 direction;
        public int damage;
    }
}