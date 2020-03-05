using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [System.Serializable]
    public class Difficulty
    {
        [Header("Game Settings")]
        [SerializeField] public int levelWidth = 11;
        [SerializeField] public int levelHeight = 11;
        [SerializeField] public int chickCount = 99;
        [SerializeField] public int eggCount = 99;
        [SerializeField] public int breadCount = 99;
        [SerializeField] public int chipCount = 30;
        [SerializeField] public int appleCount = 20;
        [SerializeField] public int mushroomCount = 10;
        [SerializeField] public int mummaDucks = 20;
        [SerializeField] public int snakesCount = 20;
        [SerializeField] public int ratsCount = 20;
        [SerializeField] public int hawkCount = 5;
        [SerializeField] public int crocsCount = 10;
        [SerializeField] public int crabsCount = 20;
        [SerializeField] public int enemyRadius = 10;


    }
}
