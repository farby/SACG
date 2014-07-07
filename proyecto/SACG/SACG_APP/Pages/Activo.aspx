<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Activo.aspx.cs" Inherits="SACG_APP.Pages.Activo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <asp:Panel ID="panEstablecimiento" runat="server" Visible="False">
        <div class="page-header">
            <h1>Responsable</h1>
        </div>
        <div class="panel panel-default" align="center">
            <asp:Label ID="lblErrorR" runat="server" Text="Documento Incorrecto" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
            <asp:Label ID="lblDocumento" runat="server" Text="Documento del nuevo Responsable del Establecimiento"></asp:Label><br />
            <asp:TextBox ID="txtDocumento" runat="server" Width="200px"></asp:TextBox><br /><br />
            <asp:Button ID="btnDocumento" runat="server" Text="Cambiar Responsable" CssClass="btn btn-primary" OnClick="btnDocumento_Click"/>
            <br />
            <br />
        </div>   
    </asp:Panel>     
    <asp:Panel ID="panUsuario" runat="server">
        <div class="page-header">
            <h1>Usuario</h1>
        </div>
        <div class="panel panel-default" align="center">
            <asp:Label ID="lblErrorU" runat="server" Text="Contraseña Incorrecta" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
            <asp:Label ID="lblPass" runat="server" Text="Nueva contraseña para este Usuario"></asp:Label><br />
            <asp:TextBox ID="txtPass" runat="server" Width="200px" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnPass" runat="server" Text="Cambiar Contraseña" CssClass="btn btn-primary" OnClick="btnPass_Click"/>
            <br />
            <br />
        </div>   
    </asp:Panel>    
</asp:Content>