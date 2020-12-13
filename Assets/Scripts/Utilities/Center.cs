﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    class Center
    {
        int id;
        Vertex[] vertices;
        Edge[] edges;
        Vector3 loc;

        public Center(float x, float y, float z, int id)
        {
            this.id = id;
            loc = new Vector3(x, y, z);
        }
    }
}