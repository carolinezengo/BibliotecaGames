using BibliotecaGames.BLL.Exceptions;
using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;



namespace BibliotecaGames.BLL.Autenticacao
{
    public class JogosBo
    {
        private JogodDao _jogoDao;
        public List<Jogo> ObterTodosOsJogos()
        {
            _jogoDao = new JogodDao();
            return _jogoDao.ObterTodosOsJogos();

        }
        public Jogo ObterJogoPeloId(int id)
        {
            _jogoDao = new JogodDao();
            var jogo = _jogoDao.ObterJogoPeloId(id);
           
            if (jogo == null)
            {
                throw new JogoNaoEncontrado();
            }
        
            
                return jogo;
            
        }
        public void InserirNovoJogo(Jogo jogo)
        {
            

            _jogoDao = new JogodDao();


            ValidarJogo(jogo);
            var linhasAfetadas = _jogoDao.InserirJogo(jogo);
            if (linhasAfetadas == 0)
            {
                throw new JogoNaoCadastradoException();
            }
        }
        public void ValidarJogo(Jogo jogo)
        {
            if (string.IsNullOrWhiteSpace(jogo.Titulo) || 
                jogo.IdEditor == 0 || 
                jogo.IdGenero == 0)
            {
                throw new jogoInvalidoException();  

            }
        }
     public void AlterarJogo(Jogo jogo)
        {
            _jogoDao = new JogodDao();

            ValidarJogo(jogo);
            var linhasAfetadas = _jogoDao.AtualizarJogo(jogo);  
            if (linhasAfetadas == 0)
            {
                throw new JogoNaoEncontrado();
            }


        }
    }

}
