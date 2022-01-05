using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOLandscapeTools.Components.GenerateBitmapTemplates.Models;

namespace UOLandscapeTools.Components.GenerateBitmapTemplates
{
    internal class DefaultMapInfos
    {
        public List<MapInfo> MapInfos { get; private set; }

        public DefaultMapInfos()
        {
            MapInfos = new List<MapInfo>()
            {
                new(){Name = "Pre-Alpha", Description = "", MapNumber = 0, MapWidth = 1024, MapHeight = 1024},
                new(){Name = "Felucca Pre-ML", Description = "", MapNumber = 0, MapWidth = 6144, MapHeight = 4096},
                new(){Name = "Felucca", Description = "", MapNumber = 0, MapWidth = 7168, MapHeight = 4096},
                new(){Name = "Trammel Pre-ML", Description = "", MapNumber = 1, MapWidth = 6144, MapHeight = 4096},
                new(){Name = "Trammel", Description = "", MapNumber = 1, MapWidth = 7168, MapHeight = 4096},
                new(){Name = "Ilshenar", Description = "", MapNumber = 2, MapWidth = 2304, MapHeight = 1600},
                new(){Name = "Malas", Description = "", MapNumber = 3, MapWidth = 2560, MapHeight = 2048},
                new(){Name = "Tokuno", Description = "", MapNumber = 4, MapWidth = 1448, MapHeight = 1448},
                new(){Name = "TerMur", Description = "", MapNumber = 5, MapWidth = 1280, MapHeight = 4096},
            };
        }
    }
}
