using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOLandscapeTools.IO
{
    public interface IJSONDataSaver
    {
        void SaveData<T>(string fileName, T metaData) where T : class;
    }
}
