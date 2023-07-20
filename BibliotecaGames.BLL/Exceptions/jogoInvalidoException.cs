using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL.Exceptions
{
public class jogoInvalidoException:Exception
    {
        public jogoInvalidoException()
        {
        }
        public jogoInvalidoException(string message) : base(message)
        {

        }
    }
}
