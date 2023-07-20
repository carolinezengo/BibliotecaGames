using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL.Exceptions
{
   public class JogoNaoEncontrado:Exception
    {
        public JogoNaoEncontrado() { 
        }
        public JogoNaoEncontrado(string message) : base(message)
        {

        }
    }
}
