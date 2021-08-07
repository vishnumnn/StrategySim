using System;
using UnityEngine;

namespace Utilities
{
    public class Point : IComparable
    {
        public int id;
        public Vector3 loc;
        public int CompareTo(object obj)
        {
            if (obj == null)
                return -1;
            Center obj2 = (Center)obj;
            if (loc.y < obj2.loc.y)
                return -1;
            else if (loc.y > obj2.loc.y)
                return 1;
            else if (loc.x < obj2.loc.x)
                return -1;
            else if (loc.x == obj2.loc.x)
                return 0;
            return 1;
        }
    }
}
