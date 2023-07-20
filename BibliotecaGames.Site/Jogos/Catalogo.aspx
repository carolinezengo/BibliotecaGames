<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="BibliotecaGames.Site.Jogos.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Content/Jogos/catalogo.css" rel="stylesheet" />
</asp:Content>

  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <h2>Catálogo de Jogos</h2>

      <a href="CadastroEdicaoJogo.aspx">Cadastrar Novo Jogo</a>
      <hr />

<asp:Repeater ID="RepeaterJogos" runat="server">

        <ItemTemplate>

            <div class="jogo" onclick="redirencionarParaPaginaDoJogo('<%= Session["Perfil"].ToString() %>',<%# DataBinder.Eval(Container.DataItem,"Id") %> )">
            <div class="capa-jogo">
                <img src="../Content/ImagensJogos/<%# DataBinder.Eval(Container.DataItem,"Imagem") %>" alt=" <%# DataBinder.Eval(Container.DataItem,"Titulo") %>" />
                    
               </div>
            <div class="nome-jogo"></div>
                <%# DataBinder.Eval(Container.DataItem,"Titulo") %> 
           </div>  

        </ItemTemplate>
    </asp:Repeater>
      <script>
          function redirecionarParaPaginaDoJogo(perfil, id) {
              if (perfil === "A") {
                  top.location.href = "CadastroEdicaoJogo.aspx?id=" + id;
              } else {
                  top.location.href = "DetalheJogo.aspx?id=" +id;
              }
          }
      </script>

</asp:Content>
