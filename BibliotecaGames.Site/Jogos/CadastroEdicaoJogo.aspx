<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogo.aspx.cs" Inherits="BibliotecaGames.Site.Jogos.CadastroEdicaoJogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="form-horizontal"></div>
   <div class="form-group">
      <div class="col-md-2">
     <label for="exampleInputEmail">Titulo:</label>
      <br />
     <asp:TextBox runat="server" ID="TxtTitulo" CssClass="form-control" Width="349px">
     </asp:TextBox>
          <asp:RequiredFieldValidator ID="RfvTitulo" runat="server" ControlToValidate="TxtTitulo" ErrorMessage="È necessario preencher o campo Titulo" Text="*"></asp:RequiredFieldValidator>
       </div>
             </div>
       <br />
       <br />

       <div class="form-group">
         <div class="col-md-2">
       <label for="exampleInputEmail"> Valor Pago:<br /> </label>
       <asp:TextBox runat="server" ID="TxtValorPago" CssClass="form-control" TextMode="Number" Width="145px" ></asp:TextBox>
       <br />
             </div>
   </div>

   
   <div class="form-group">
       <div class="col-md-2">
       <label for="exampleInputEmail"> Data Compra:<br />
       </label>
       <asp:TextBox runat="server" ID="TxtDataDeCompra" CssClass="form-control" TextMode="Date" Width="142px" ></asp:TextBox>
       <br />
      </div>
       </div>

    <div class="form-group"> 
        <div class="col-md-2">
       <label for="exampleInputEmail">Imagem:<br />
        </label>
      <asp:FileUpload ID="FileUploadImage" runat="server" CssClass="form-control" />
        <br />
        </div>
        </div>

   <div class="form-group">  
       <div class="col-md-2">
      <label for="exampleInputEmail">Editor:  </label> 
       <br />
      <asp:DropDownList ID="DdlEditor" runat="server" DataValueField="Id" DataTextField="Nome" CssClass="form-control" Height="25px" Width="202px"></asp:DropDownList>
       
      <asp:RequiredFieldValidator ID="RfvEditor" runat="server" ControlToValidate="DdlEditor" ErrorMessage="È necessario preencher o campo Genero" Text="*">
      </asp:RequiredFieldValidator>
           </div>
       <br />
       <br />

    </div>
      
    <div class="form-group">  
        <div class="col-md-2">
      <label for="exampleInputEmail"> Gênero:<br />
        </label>
      <asp:DropDownList ID="DdlGenero" runat="server" DataValueField="Id" DataTextField="Descricao" CssClass="form-control" Height="19px" Width="196px"></asp:DropDownList>
      <asp:RequiredFieldValidator ID="RfvGenero" runat="server" ControlToValidate="DdlGenero" ErrorMessage="È necessario preencher o campo Editor" Text="*">
      </asp:RequiredFieldValidator>
        <br />
      </div>
    </div>
     <br />
    
     <asp:ValidationSummary ID="valsum" DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" HeaderText="Você precisa corrigir alguns campos
     :" runat="server" />
    <br />
    <asp:Label runat="server" ID="lblMensagem"></asp:Label>
  <br />
    <asp:Button ID="BtnGravar" Text="Gravar" CssClass="form-control" runat="server" OnClick="BtnGravar_Click" /> 
 <br />
    <a href="Catalogo.aspx">Voltar ao catálogo de jogos</a>
   
</asp:Content>



