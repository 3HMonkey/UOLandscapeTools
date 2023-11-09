using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOLandscapeTools.Components.GenerateBitmapTemplates
{
    public interface IGenerateBitmapTemplates
    {
        void MakeTerrainMap(int xSize, int ySize, string DefaultTerrain);
    }
}
