<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ReporteSinPesar.aspx.cs" Inherits="SACG_APP.Pages.ReporteSinPesar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="page-header">
        <h1>Reporte de Animales sin Pesar</h1>
    </div>
    <div align="Center">
        <asp:Label ID="lblError" runat="server" Text="No hay animales sin pesar desde la fecha seleccionada" Font-Italic="True" ForeColor="Red" Visible="False"></asp:Label><br />
        <asp:Label ID="lblFecha" runat="server" Text="Seleccione la Fecha"></asp:Label><br />
        <asp:Calendar ID="calFecha" runat="server"></asp:Calendar>
        <asp:Label ID="lblSinPesar" runat="server" Text="Pesajes de Animal" Font-Bold="True" Font-Size="Large"></asp:Label><br />
        <asp:BulletedList ID="bullSinPesar" runat="server" Width="600px"></asp:BulletedList><br />
        <asp:Button ID="btnConfirmar" runat="server" Text="Generar Reporte" Width="200px" CssClass="btn btn-primary" OnClick="btnConfirmar_Click"/><br /><br />
    </div>
</asp:Content>
