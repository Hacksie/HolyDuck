using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class LevelGenerator : MonoBehaviour
    {
        public Level GenerateRandomLevel(int levelWidth, int levelHeight)
        {
            var startTime = Time.unscaledTime;
            var level = new Level(levelWidth, levelHeight);

            //Temp


            
            level.map[Random.Range((levelWidth - 1) / 2 + 2, levelWidth - 2), Random.Range(1, (levelHeight - 1) / 2 - 2)] = GenerateBossArea();

            level.map[Random.Range(1, (levelWidth - 1) / 2 - 2), Random.Range((levelHeight - 1) / 2 + 2, levelHeight - 2)] = GenerateBossArea();
            level.map[Random.Range((levelWidth - 1) / 2 + 2, levelWidth - 2), Random.Range((levelHeight - 1) / 2 + 2, levelHeight - 2)] = GenerateBossArea();



            level.map[(levelWidth - 1) / 2, (levelHeight - 2)] = GenerateFinalBossArea();
            level.map[(levelWidth - 1) / 2, (levelHeight - 3)] = GenerateCrowBossArea();
            level.map[(levelWidth - 1) / 2, (levelHeight - 1) / 2] = GenerateStartingArea();

            level.map[Random.Range(1, (levelWidth - 1) / 2 - 2), Random.Range(1, (levelHeight - 1) / 2 - 2)] = GenerateSwanBossArea();



            level.playerStart = new Vector2Int((levelWidth - 1) / 2, (levelHeight - 1) / 2);

            // Construct the level out from the start
            for (int k = 0; k < Mathf.Max(levelWidth, levelHeight); k++)
            //for (int k = 0; k < 1; k++)
            {
                for (int j = 0; j < levelHeight; j++)
                {
                    for (int i = 0; i < levelWidth; i++)
                    {
                        if (level.map[i, j] != null)
                        {
                            GenerateArea(level, new Vector2Int(i, j - 1), levelWidth, levelHeight);
                            GenerateArea(level, new Vector2Int(i - 1, j), levelWidth, levelHeight);
                            GenerateArea(level, new Vector2Int(i, j + 1), levelWidth, levelHeight);
                            GenerateArea(level, new Vector2Int(i + 1, j), levelWidth, levelHeight);
                        }
                    }
                }
            }

            Logger.Log(name, "Level generated in ", (Time.unscaledTime - startTime).ToString());


            return level;
        }

        public Area GenerateStartingArea()
        {
            return new Area()
            {
                top = AreaEdgeTypes.RIVER,
                left = AreaEdgeTypes.RIVER,
                right = AreaEdgeTypes.RIVER,
                bottom = AreaEdgeTypes.RIVER,
                isStart = true
            };
        }


        public Area GenerateBossArea()
        {
            return new Area()
            {
                top = AreaEdgeTypes.RIVER,
                left = AreaEdgeTypes.RIVER,
                right = AreaEdgeTypes.RIVER,
                bottom = AreaEdgeTypes.RIVER,
                isBoss = true,
                isStart = false,
                isGooseBoss = false
            };
        }

        public Area GenerateFinalBossArea()
        {
            return new Area()
            {
                top = AreaEdgeTypes.OCEAN,
                left = AreaEdgeTypes.OCEAN,
                right = AreaEdgeTypes.OCEAN,
                bottom = AreaEdgeTypes.OCEAN,
                isGooseBoss = true,
                isCrowBoss = false,
                isSwanBoss = false,
                isSnipeBoss = false,
                isSandpiperBoss = false,
                isSeagullBoss = false,
                isStart = false,
                isBoss = false
            };
        }

        public Area GenerateCrowBossArea()
        {
            return new Area()
            {
                top = AreaEdgeTypes.OCEAN,
                left = AreaEdgeTypes.OCEAN,
                right = AreaEdgeTypes.OCEAN,
                bottom = AreaEdgeTypes.OCEAN,
                isGooseBoss = false,
                isCrowBoss = true,
                isSandpiperBoss = false,
                isSnipeBoss = false,
                isSwanBoss = false,
                isStart = false,
                isBoss = false
            };
        }

        public Area GenerateSwanBossArea()
        {
            return new Area()
            {
                top = AreaEdgeTypes.OCEAN,
                left = AreaEdgeTypes.OCEAN,
                right = AreaEdgeTypes.OCEAN,
                bottom = AreaEdgeTypes.OCEAN,
                isGooseBoss = false,
                isCrowBoss = false,
                isSandpiperBoss = false,
                isSnipeBoss = false,
                isSwanBoss = true,
                isStart = false,
                isBoss = false
            };
        }


        public bool GenerateArea(Level level, Vector2Int position, int levelWidth, int levelHeight)
        {
            if (position.x < 0 || position.x >= levelWidth || position.y < 0 || position.y >= levelHeight) // Don't try to move off the level
            {
                return false;
            }


            if (level.map[position.x, position.y] != null)
            {
                return false;
            }

            Area area = new Area()
            {
                top = AreaEdgeTypes.OCEAN,
                left = AreaEdgeTypes.OCEAN,
                bottom = AreaEdgeTypes.OCEAN,
                right = AreaEdgeTypes.OCEAN,
                isBoss = false,
                isGooseBoss = false,
                isStart = false
            };

            var freeChoice = new List<AreaEdgeTypes>() { AreaEdgeTypes.TREES, AreaEdgeTypes.CREEK, AreaEdgeTypes.OCEAN, AreaEdgeTypes.RIVER };

            var tops = PossibleTopEdges(position, freeChoice, level, levelWidth, levelHeight);
            var lefts = PossibleLeftEdges(position, freeChoice, level, levelWidth, levelHeight);
            var bottoms = PossibleBottomEdges(position, freeChoice, level, levelWidth, levelHeight);
            var rights = PossibleRightEdges(position, freeChoice, level, levelWidth, levelHeight);

            tops.Randomize();
            lefts.Randomize();
            bottoms.Randomize();
            rights.Randomize();

            area.top = PossibleTopEdges(position, freeChoice, level, levelWidth, levelHeight).GetRandomElement();
            area.left = PossibleLeftEdges(position, freeChoice, level, levelWidth, levelHeight).GetRandomElement();
            area.bottom = PossibleBottomEdges(position, freeChoice, level, levelWidth, levelHeight).GetRandomElement();
            area.right = PossibleRightEdges(position, freeChoice, level, levelWidth, levelHeight).GetRandomElement();


            level.map[position.x, position.y] = area;

            return true;

        }



        List<AreaEdgeTypes> PossibleTopEdges(Vector2Int position, List<AreaEdgeTypes> freeChoice, Level level, int levelWidth, int levelHeight)
        {
            List<AreaEdgeTypes> edges = new List<AreaEdgeTypes>();

            //if (position.y <= 0 || position.y >= (levelHeight - 1) || position.x <= 0 || position.x >= (levelWidth - 1))
            if (position.y <= 0)
            {
                edges.Add(AreaEdgeTypes.TREES);
                return edges;
            }

            Area above = level.map[position.x, position.y - 1];

            if (above == null) // free choice
            {
                return freeChoice;
            }

            edges.Add(above.bottom);
            return edges;
        }

        List<AreaEdgeTypes> PossibleLeftEdges(Vector2Int position, List<AreaEdgeTypes> freeChoice, Level level, int levelWidth, int levelHeight)
        {
            List<AreaEdgeTypes> edges = new List<AreaEdgeTypes>();

            if (position.x <= 0)
            {
                edges.Add(AreaEdgeTypes.TREES);
                return edges;
            }

            Area left = level.map[position.x - 1, position.y];

            if (left == null) // free choice
            {
                return freeChoice;
            }

            edges.Add(left.right);
            return edges;
        }

        List<AreaEdgeTypes> PossibleBottomEdges(Vector2Int position, List<AreaEdgeTypes> freeChoice, Level level, int levelWidth, int levelHeight)
        {
            List<AreaEdgeTypes> edges = new List<AreaEdgeTypes>();

            if (position.y >= (levelHeight - 1))
            {
                edges.Add(AreaEdgeTypes.TREES);
                return edges;
            }


            Area below = level.map[position.x, position.y + 1];

            if (below == null) // free choice
            {
                return freeChoice;
            }

            edges.Add(below.top);
            return edges;
        }

        List<AreaEdgeTypes> PossibleRightEdges(Vector2Int position, List<AreaEdgeTypes> freeChoice, Level level, int levelWidth, int levelHeight)
        {
            List<AreaEdgeTypes> edges = new List<AreaEdgeTypes>();

            if (position.x >= (levelWidth - 1))
            {
                edges.Add(AreaEdgeTypes.TREES);
                return edges;
            }

            Area right = level.map[position.x + 1, position.y];

            if (right == null) // free choice
            {
                return freeChoice;
            }

            edges.Add(right.left);
            return edges;
        }
    }
}
