using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class MoveActionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask colliderLayerMask;
        [SerializeField] private LayerMask spawnLayerMask;
        [SerializeField] private bool canWater = true;
        [SerializeField] private bool canGround = true;
        private Status status;


        public int distance = 1;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            if (status.dead)
            {
                CoreGame.instance.AddActionMessage(status.character + " is dead");
                return;
            }

            if (status.distractedByShinies)
            {
                CoreGame.instance.AddActionMessage(status.character + " is distracted by the shinies");
                return;
            }

            status.SapEnergy(1);
            Physics2D.SyncTransforms();
            var hits = Physics2D.RaycastAll(transform.position, action.direction, (float)distance + 0.1f, colliderLayerMask);

            // Check for collision with self
            if(hits.Any(h => h.collider.gameObject != gameObject))
            {
                CoreGame.instance.AddActionMessage(status.character + " was blocked " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
            }
            else
            {
                var spawnHits = Physics2D.RaycastAll(transform.position, action.direction, distance, spawnLayerMask);

                Logger.Log(name, "spawnhits count", spawnHits.Length.ToString());
                foreach(var spawnhit in spawnHits)
                {
                    Logger.Log(name, spawnhit.collider.name);
                }

                
                if(spawnHits.Length == 1)
                {
                    CoreGame.instance.AddActionMessage(status.character + " can't move to " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
                }
                else if(spawnHits.Any(s=>!CheckEnv(s.collider.GetComponent<Spawn>())))
                {
                    CoreGame.instance.AddActionMessage(status.character + " can't move to " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
                }
                else
                {
                    transform.Translate((action.direction * distance), Space.World);
                    Physics2D.SyncTransforms();
                    CoreGame.instance.AddActionMessage(status.character + " moved to " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
                }              
            }
        }

        public bool CheckEnv(Spawn s)
        {
            return ((s.spawnType == SpawnType.Ground && canGround) || (s.spawnType == SpawnType.Water && canWater));
        }
    }
}
