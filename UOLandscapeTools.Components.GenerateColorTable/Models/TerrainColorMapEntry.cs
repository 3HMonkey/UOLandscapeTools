using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOLandscapeTools.Components.GenerateColorTable.Models
{
    public class TerrainColorMapEntry
    {
        public string Name { get; set; }
        public int[] TileIds { get; set; }
        public Color Color { get; set; }
        public bool Randomize { get; set; }
    }
}
