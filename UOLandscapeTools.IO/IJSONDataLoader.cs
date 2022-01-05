using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOLandscapeTools.IO
{
    public interface IJSONDataLoader
    {
        T LoadData<T>(string fileName) where T : class;
    }
}
