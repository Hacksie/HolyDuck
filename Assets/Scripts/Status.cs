using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    public class Status : MonoBehaviour
    {
        [SerializeField] public string character = "";
        [SerializeField] public int health = 100;
        [SerializeField] public int maxHealth = 100;
        [SerializeField] public bool reqEnergy = false;
        [SerializeField] public int energy = 100;
        [SerializeField] public int maxEnergy = 100;
        [SerializeField] public int minAttack = 0;
        [SerializeField] public int maxAttack = 5;
        [SerializeField] public int defense = 1;
        [SerializeField] public int initiative = 10;
        [SerializeField] public int attackPrice = 10;
        [SerializeField] public int defensePrice = 10;
        [SerializeField] public int initiativePrice = 10;
        [SerializeField] public int applePrice = 10;
        [SerializeField] public int mushroomPrice = 10;
        [SerializeField] public int breadPrice = 1;

        //[SerializeField] public int chicksSaved = 1;
        [SerializeField] private int breadEnergy = 30;
        [SerializeField] private int chipEnergy = 50;

        [SerializeField] private bool quacked = false;
        [SerializeField] private int quackedTurnStart = 0;
        [SerializeField] private int quackedTurnCounter = 1;

        [SerializeField] public bool stunned = false;
        [SerializeField] public int stunnedCounter = 0;
        

        [SerializeField] public UnityEvent dieEvent;
        [SerializeField] public UnityEvent starveEvent;

        public void SaveChick()
        {
            //chicksSaved++;
            Logger.Log(name, "Chick saved!");
        }

        public void EatBread()
        {
            energy += breadEnergy;
            energy = Mathf.Min(energy, 100);
        }

        public void EatChip()
        {
            energy += chipEnergy;
            energy = Mathf.Min(energy, 100);
        }

        public void AddHealth(int health)
        {
            this.health = Mathf.Max(Mathf.Min(this.health + health, this.maxHealth), 0);
            if (this.health <= 0)
            {
                dieEvent.Invoke();
            }
        }

        public void SapEnergy(int energy)
        {
            if (reqEnergy)
            {
                this.energy -= energy;
                if (this.energy <= 0)
                { 
                    starveEvent.Invoke();
                }
            }
        }
    }
}
