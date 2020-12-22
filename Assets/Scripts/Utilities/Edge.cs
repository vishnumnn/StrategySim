using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Edge
    {
        Vertex start, end;
        Edge next, previous;
        Edge twin;
        Center center;

        public Edge(Vertex start, Center center)
        {
            this.start = start;
            this.center = center;
        }
    }
}
