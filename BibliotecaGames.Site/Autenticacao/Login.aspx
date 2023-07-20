<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bibliotecaGames.Site.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>Usuario:</div>
        <div>
            <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>Senha:</div>
        <asp:TextBox ID="TxtSenha" runat="server"></asp:TextBox>
        <p>
            <asp:Label runat="server" ID="lblStatus"></asp:Label>
           
        </p>
        <p>
            <asp:Button ID="BtnEntrar" runat="server" OnClick="BtnEntrar_Click" Text="Entrar" />
           
        </p>
    </form>
</body>
</html>
