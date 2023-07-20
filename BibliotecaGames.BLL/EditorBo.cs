using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL
{
  public class EditorBo
    {
        private EditorDao _editorDao;
        public List<Editor> ObterTodososOsEditores()
        { 
            _editorDao = new EditorDao();
            return _editorDao.ObterTodosOsEditores();
        }
    }
}
