using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    public interface IUiHandler
    {
        string AskForString(string message);

        void WriteMessage(string message);
    }
}
