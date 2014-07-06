<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SACG_APP.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header">
        <h1>Login</h1>
    </div>
    <div class="panel panel-default" align="center">
        <asp:Label ID="lblError" runat="server" Text="Usuario o Contraseña incorrectos" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
        <asp:Label ID="lblUser" runat="server" Text="Usuario"></asp:Label><br />
        <asp:TextBox ID="txtUser" runat="server" Width="200px"></asp:TextBox><br /><br />
        <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label><br />
        <asp:TextBox ID="txtPass" runat="server" Width="200px" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click"/>
    </div>       
</asp:Content>