using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HackedDesign
{
    public class Status : MonoBehaviour
    {
        [SerializeField] public int health = 100;
        [SerializeField] public int maxHealth = 100;
        [SerializeField] public int energy = 100;
        [SerializeField] public int maxEnergy = 100;
        [SerializeField] public int minAttack = 0;
        [SerializeField] public int maxAttack = 5;
        [SerializeField] public int defense = 1;
        [SerializeField] public int initiative = 10;

        [SerializeField] public int chicksSaved = 1;
        [SerializeField] private int breadEnergy = 30;
        [SerializeField] private int chipEnergy = 50;

        [SerializeField] public UnityEvent dieEvent;
        [SerializeField] public UnityEvent starveEvent;

        public void SaveChick()
        {
            chicksSaved++;
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

        public void TakeDamage(int damage)
        {
            health -= damage;
            if(health <=0)
            {
                dieEvent.Invoke();
            }
        }

        public void SapEnergy(int energy)
        {
            energy -= energy;
            if (health <= 0)
            {
                starveEvent.Invoke();
            }
        }
    }
}
