using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace AnagramGame
{
    public class FileDictionaryLoader : IDictionaryLoader
    {
        readonly string _dictionaryPath = string.Concat(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            Path.DirectorySeparatorChar,
            "660000_parole_italiane.txt");

        public List<string> LoadDictionary()
        {
            try
            {
                return File.ReadAllLines(_dictionaryPath).ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading file { _dictionaryPath }", e);
            }
        }
    }
}
