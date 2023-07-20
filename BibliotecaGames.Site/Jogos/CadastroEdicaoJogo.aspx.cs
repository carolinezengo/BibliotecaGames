using BibliotecaGames.BLL;
using BibliotecaGames.BLL.Autenticacao;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Site.Jogos
{
    public partial class CadastroEdicaoJogo : System.Web.UI.Page
    {
        private GeneroBo _generoBo;
        private EditorBo _editorBo;
        private JogosBo _jogosBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarEditoresNaCombo();
                CarregarGenerosNaCombo();

                if (EstaEmModoEdicao())
                {
                    CarregarDadosParaEdicao();
                }
              
            }
         
        }

        
        protected JogosBo Get_jogosBo()
        {
            return _jogosBo;
        }

    
        private void CarregarEditoresNaCombo()
        { 
            _editorBo = new EditorBo();
            var editores = _editorBo.ObterTodososOsEditores();
            DdlEditor.DataSource= editores;
            DdlEditor.DataBind();   
                }
        private void CarregarGenerosNaCombo()
        {
            _generoBo = new GeneroBo();
            var generos = _generoBo.ObterTodososOsGeneros();
            DdlGenero.DataSource = generos;
            DdlGenero.DataBind();
        }

        protected void BtnGravar_Click(object sender, EventArgs e)
        {
            _jogosBo = new JogosBo();
            //var jogo = new Jogo();
            var jogo = ObterModeloPreenchido();
            
            try
            {
                jogo.Imagem = GravarImagemNoDisco();
            }
            catch { 
            lblMensagem.Text = "Ocorreu um erro ao salvar imagem";
            }
            
            try
            {
                var mensagemDeSucesso = "";
                if (EstaEmModoEdicao())
                {
                    jogo.Id = ObterIdDoJogo();  
                    _jogosBo.AlterarJogo(jogo);
                    mensagemDeSucesso = "Jogo Alterado com Sucesso!";
                }
                else
                {

                    _jogosBo.InserirNovoJogo(jogo);
                    mensagemDeSucesso = "Jogo cadastrado com Sucesso!";
                }

                lblMensagem.ForeColor = System.Drawing.Color.Green;  
                lblMensagem.Text = mensagemDeSucesso;

                BtnGravar.Enabled = false;
            }
            catch
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Ocorreu um erro ao gavar o jogo";
            }
        }
        private Jogo ObterModeloPreenchido()
        {
            var jogo = new Jogo();

            jogo.Titulo = TxtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(TxtValorPago.Text) ? (double?)null : Convert.ToDouble(TxtValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(TxtDataDeCompra.Text) ? (DateTime?)null : Convert.ToDateTime(TxtDataDeCompra.Text);
            jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
            jogo.Id = ObterIdDoJogo();
            return jogo;
        }
            private string GravarImagemNoDisco()
        {
            if (FileUploadImage.HasFile)
            {
                try
                {
                   var caminho = $"{ AppDomain.CurrentDomain.BaseDirectory}\\Content\\ImagensJogos\\";
                    var fileName =$"{DateTime.Now.ToString("yyymmddhhmmss")}_{FileUploadImage.FileName}";
                    FileUploadImage.SaveAs($"{caminho}{fileName}");
                    return fileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        public void CarregarDadosParaEdicao()
        {
            _jogosBo = new JogosBo();
            var id = ObterIdDoJogo(); 
            
            var jogo = _jogosBo.ObterJogoPeloId(id);
            TxtTitulo.Text = jogo.Titulo;
            TxtValorPago.Text = jogo.ValorPago.ToString();
            TxtDataDeCompra.Text = jogo.DataCompra.HasValue ? jogo.DataCompra.Value.ToString("yyy-MM-dd") : string.Empty;
            DdlEditor.SelectedValue = jogo.IdEditor.ToString();
            DdlGenero.SelectedValue = jogo.IdGenero.ToString();
        }
        public int ObterIdDoJogo()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                {
                    throw new Exception("ID invalido");
                }

                return id;
            }
            else
            {
                throw new Exception("ID invalido");
            }
        }
      public bool EstaEmModoEdicao()
        {
          return  Request.QueryString.AllKeys.Contains("id");
           
        }
    }

}