<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ActivarEstablecimiento.aspx.cs" Inherits="SACG_APP.ActivarEstablecimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="page-header">
        <h1>Activar / Desactivar<br />Establecimiento Registrado</h1>
    </div>
    <div align="Center">
        <asp:Label ID="lblError" runat="server" Text="No has seleccionado ningún DICOSE" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
        <asp:Label ID="lblDicosesPendientes" runat="server" Text="DICOSEs Pendientes:"></asp:Label><br />
        <asp:ListBox ID="lstPendientes" runat="server" style="text-align: center" Width="200px" Rows="10"></asp:ListBox><br /><br />
        <asp:Button ID="btnActivar" runat="server" Text="Activar Establecimiento" Width="200px" OnClick="btnActivar_Click" CssClass="btn btn-primary"/><br /><br /><br />
        <asp:Label ID="lblDicosesActivos" runat="server" Text="DICOSEs Activos:"></asp:Label><br />
        <asp:ListBox ID="lstActivos" runat="server" style="text-align: center" Width="200px" Rows="10"></asp:ListBox><br /><br />
        <asp:Button ID="btnDesactivar" runat="server" Text="Dar de baja Establecimiento" Width="200px" OnClick="btnDesactivar_Click" CssClass="btn btn-primary"/>
    </div>
    
</asp:Content>
