using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class LevelGenerator : MonoBehaviour
    {
        public Level GenerateRandomLevel(int levelWidth, int levelHeight)
        {
            var level = new Level(levelWidth, levelHeight);

            //Temp
            for(int j=0;j<levelHeight;j++)
            {
                for(int i=0;i<levelWidth;i++)
                {
                    level.map[i, j] = new Area()
                    {
                        top = AreaEdgeTypes.OCEAN,
                        left = AreaEdgeTypes.OCEAN,
                        bottom = AreaEdgeTypes.OCEAN,
                        right = AreaEdgeTypes.OCEAN,
                        isBoss = false,
                        isFinalBoss = false,
                        isStart = false
                    };
                }
            }
            
            GenerateStartingLocation(level, levelWidth, levelHeight);

            return level;
        }

        public void GenerateStartingLocation(Level level, int levelWidth, int levelHeight)
        {
            Vector2Int position = new Vector2Int((levelWidth - 1) / 2, (levelHeight - 1) / 2);

            level.map[position.x, position.y] = new Area()
            {
                top = AreaEdgeTypes.RIVER,
                left = AreaEdgeTypes.RIVER,
                right = AreaEdgeTypes.RIVER,
                bottom = AreaEdgeTypes.RIVER,
                isStart = true
            };

        }

        public void GenerateGooseLeeLocation()
        {

        }

        
    }
}
