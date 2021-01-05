using System;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Center : Point
    {
        Edge edge;
        public Center(float x, float y, float z, int id)
        {
            this.id = id;
            loc = new Vector3(x, y, z);
        }
    }
}