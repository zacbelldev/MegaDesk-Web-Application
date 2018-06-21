using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Web_Application
{
    class Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int NumOfDrawers { get; set; }
        public enum Surface
        {
            Oak,
            Laminate,
            Pine,
            Rosewood,
            Veneer
        }
        public Surface SurfaceMaterial;
    }
}



