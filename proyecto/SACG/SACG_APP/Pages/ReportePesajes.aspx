<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ReportePesajes.aspx.cs" Inherits="SACG_APP.Pages.ReportePesajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="page-header">
        <h1>Reporte de Pesajes de un Animal</h1>
    </div>
    <div align="Center">
        <asp:Label ID="lblError" runat="server" Text="No se le han realizado pesajes a este Animal aún" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
        <asp:Label ID="lblAnimal" runat="server" Text="Seleccione el Animal"></asp:Label><br />
        <asp:DropDownList ID="ddlAnimal" runat="server"></asp:DropDownList><br /><br />
        <asp:Label ID="lblPesajes" runat="server" Text="Pesajes de Animal" Font-Bold="True" Font-Size="Large"></asp:Label><br />
        <asp:BulletedList ID="bullPesajes" runat="server" Width="301px"></asp:BulletedList><br />
        <asp:Button ID="btnConfirmar" runat="server" Text="Generar Reporte" Width="200px" CssClass="btn btn-primary" OnClick="btnConfirmar_Click"/><br /><br />
    </div>
</asp:Content>
