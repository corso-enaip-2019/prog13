using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    public interface IDictionaryLoader
    {
        List<string> LoadDictionary();
    }
}
