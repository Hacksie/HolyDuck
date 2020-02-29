using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class Level
    {
        public int width, height;
        public Area[,] map;
        public Vector2Int playerStart;

        public Level(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new Area[width, height];
        }

        public void DebugPrint()
        {
            for(int y = 0; y<height;y++)
            {
                string line = null;
                for(int x=0;x<width;x++)
                {
                    line = string.Join(",", line, map[x, y].ToString());                  
                }

                Logger.Log("Level", line);
            }
        }
    }
}
