<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="GestionEstablecimientos.aspx.cs" Inherits="SACG_APP.GestionEstablecimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
  

    <br />
        <div class="page-header">
            <h1>Registrar Nuevo Establecimiento</h1>
        </div>
    
    <asp:Table ID="tab" runat="server" Width="75%" CellSpacing="10" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDicose" runat="server" Text="DICOSE">12</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDicose" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDepartamento" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRut" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblSPolicial" runat="server" Text="Sec. Policial"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSPolicial" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBps" runat="server" Text="BPS"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBps" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblParaje" runat="server" Text="Paraje"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtParaje" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRazonSocial" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDireccion" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDocumento" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblSuperficie" runat="server" Text="Superficie"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSuperficie" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNombre" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTelefono" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtApellido" runat="server">999</asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" runat="server">999</asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClientClick="AltaEstablecimiento" CssClass="btn btn-primary"/>
                
            </asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
</asp:Content>