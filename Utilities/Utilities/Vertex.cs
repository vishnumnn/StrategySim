using UnityEngine;

namespace Utilities
{
    public class Vertex : Point
    {
        public Vertex(float x, float y, float z, int id)
        {
            this.id = id;
            loc = new Vector3(x, y, z);
        }
        
    }
}
