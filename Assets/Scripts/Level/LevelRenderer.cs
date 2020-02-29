using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class LevelRenderer : MonoBehaviour
    {
        [Header("AreaTilemaps")]
        [SerializeField] private GameObject waterTile;
        [SerializeField] private List<GameObject> areaTilemaps;
        [SerializeField] private List<GameObject> borderTiles;

        public void Render(Level level, Transform parent)
        {
            ClearLevel(parent);
            Instantiate(borderTiles[0], new Vector2(-1 * 14, level.height * 8), Quaternion.identity, parent);
            for (int x = 0; x < level.width; x++)
            {
                Instantiate(borderTiles[1], new Vector2(x * 14, level.height * 8), Quaternion.identity, parent);
            }
            Instantiate(borderTiles[2], new Vector2(level.width * 14, level.height * 8), Quaternion.identity, parent);

            for (int y = 0; y < level.height; y++)
            {
                Instantiate(borderTiles[3], new Vector2(-1*14, (level.height - y - 1) * 8), Quaternion.identity, parent);
                //RenderBorder(new Vector2(-14, (level.height - y - 1) * 8), parent);

                for (int x = 0; x < level.width; x++)
                {
                    RenderArea(level.map[x, y], new Vector2(x * 14, (level.height - y - 1) * 8), parent);
                }

                Instantiate(borderTiles[4], new Vector2(level.width * 14, (level.height - y - 1) * 8), Quaternion.identity, parent);

                
            }

            Instantiate(borderTiles[5], new Vector2(-1 * 14, -8), Quaternion.identity, parent);
            for (int x = 0; x < level.width; x++)
            {
                Instantiate(borderTiles[6], new Vector2(x * 14, -8), Quaternion.identity, parent);
            }
            Instantiate(borderTiles[7], new Vector2(level.width * 14, -8), Quaternion.identity, parent);
        }

        public Vector2 LevelToWorldCoords(Vector2Int position, Level level)
        {
            return new Vector2(position.x * 14, (level.height - position.y - 1) * 8);
        }

        private void ClearLevel(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                GameObject.Destroy(parent.GetChild(i).gameObject);
            }
        }

        private void RenderBorder(Vector2 position, Transform parent)
        {
            //Instantiate(borderTile, position, Quaternion.identity, parent);
        }

        private void RenderArea(Area area, Vector2 position, Transform parent)
        {
            //var bl = GameObject.Instantiate(areaTilemaps[0], position, Quaternion.identity, parent);
            if(area == null)
            {
                return; // don't bother & probably log an error
            }

            var blobj = FindCorner("bl", area.bottom, area.left);
            if (blobj != null)
            {
                Instantiate(blobj, position, Quaternion.identity, parent);
            }

            var brobj = FindCorner("br", area.bottom, area.right);
            if (brobj != null)
            {
                Instantiate(brobj, position, Quaternion.identity, parent);
            }

            var tlobj = FindCorner("tl", area.top, area.left);
            if (tlobj != null)
            {
                Instantiate(tlobj, position, Quaternion.identity, parent);
            }

            var trobj = FindCorner("tr", area.top, area.right);
            if (trobj != null)
            {
                Instantiate(trobj, position, Quaternion.identity, parent);
            }
        }

        private GameObject FindCorner(string corner, AreaEdgeTypes edge1, AreaEdgeTypes edge2)
        {
            return areaTilemaps.FirstOrDefault(t => MatchTileName(t.name, corner, edge1, edge2));
        }

        private bool MatchTileName(string name, string corner, AreaEdgeTypes edge1, AreaEdgeTypes edge2)
        {
            //Logger.Log(this.name, name, corner + "_" + EdgeToString(edge1) + EdgeToString(edge2), name.StartsWith(corner + "_" + EdgeToString(edge1) + EdgeToString(edge2)).ToString());
            return name.StartsWith(corner + "_" + EdgeToString(edge1) + EdgeToString(edge2));
        }

        private string EdgeToString(AreaEdgeTypes edge)
        {
            switch (edge)
            {
                case AreaEdgeTypes.CREEK:
                    return "c";
                case AreaEdgeTypes.OCEAN:
                    return "o";
                case AreaEdgeTypes.RIVER:
                    return "r";
                case AreaEdgeTypes.TREES:
                    return "t";
                default:
                    return " ";
            }
        }
    }
}
