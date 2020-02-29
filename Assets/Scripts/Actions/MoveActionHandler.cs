using UnityEngine;

namespace HackedDesign
{
    public class MoveActionHandler : MonoBehaviour
    {
        public int distance = 1;
        public void Handle(GameObject source, Vector2 direction) => transform.Translate((direction * distance), Space.World);
    }
}
