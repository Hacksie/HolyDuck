using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackedDesign
{
    public class Area
    {
        public AreaEdgeTypes top;
        public AreaEdgeTypes left;
        public AreaEdgeTypes bottom;
        public AreaEdgeTypes right;
        public bool isStart;
        public bool isBoss;
        public bool isGooseBoss;
        public bool isCrowBoss;
        public bool isSwanBoss;
        public bool isSnipeBoss;
        public bool isSandpiperBoss;
        public bool isSeagullBoss;

        //public bool 

        public override string ToString()
        {
            return "[" + EdgeTypeToString(top) + EdgeTypeToString(left) + EdgeTypeToString(bottom) + EdgeTypeToString(right) + "]";
        }

        private string EdgeTypeToString(AreaEdgeTypes type)
        {
            switch(type)
            {
                case AreaEdgeTypes.CREEK:
                    return "C";
                case AreaEdgeTypes.OCEAN:
                    return "O";
                case AreaEdgeTypes.RIVER:
                    return "R";
                case AreaEdgeTypes.TREES:
                    return "T";
                default:
                    return "_";
            }
        }
    }
}
