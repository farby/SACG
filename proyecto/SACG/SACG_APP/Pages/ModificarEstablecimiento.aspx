<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ModificarEstablecimiento.aspx.cs" Inherits="SACG_APP.ModificarEstablecimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header">
        <h1>Modificar Establecimiento</h1>
    </div>
    <asp:Table ID="tab" runat="server" Width="75%" CellSpacing="10" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDicose" runat="server" Text="DICOSE"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDicose" runat="server" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDepartamento" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblSPolicial" runat="server" Text="Sec. Policial"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSPolicial" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBps" runat="server" Text="BPS"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBps" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblParaje" runat="server" Text="Paraje"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtParaje" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDocumento" runat="server" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblSuperficie" runat="server" Text="Superficie"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSuperficie" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="UpdEstablecimiento" CssClass="btn btn-primary"/> 
            </span>
        </div>
</asp:Content>
