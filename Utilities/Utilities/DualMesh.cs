using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class DualMesh
    {
        private Center[] centers;
        private List<Vertex> vertices;

        public DualMesh(int pointCount)
        {
            centers = new Center[pointCount];
            this.CreateCenters(centers);
        }

        private void CreateCenters(Center[] centers)
        {
            for(int i = 0; i < centers.Length; i++)
            {
                Random x = new Random(20);
                centers[i] = new Center((float) x.NextDouble(), (float) x.NextDouble(), (float) x.NextDouble(), i);
            }
        }

        private void RelaxCenters(Center[] centers)
        {

        }

        private void CreateVoronoiDiagram(Center[] centers)
        {
            Heap<Point> q = new Heap<Point>(centers, false);
            while(q.Count() > 0)
            {
                Point x = q.ExtractTop();
                if(x.GetType().Name == "Vertex")
                {
                    Vertex point_event = (Vertex) x;
                }
                else if(x.GetType().Name == "Center")
                {
                    Center int_event = (Center) x;
                }
            }

        }

        private void CreateTriangulation(Center[] centers)
        {

        }

        public int Size()
        {
            return centers.Length;
        }
    }
}
