using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utilities
{
    public class DualMesh
    {
        Center[] centers;

        public DualMesh(int pointCount)
        {
            centers = new Center[pointCount];
        }

        public int Size()
        {
            return centers.Length;
        }
    }
}
