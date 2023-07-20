using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL.Exceptions
{
   public class JogoNaoAlterado :Exception
    {
        public JogoNaoAlterado() { 
        }
        public JogoNaoAlterado(string message) : base(message)
        {

        }
    }
}
