<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="RegistrarEstablecimiento.aspx.cs" Inherits="SACG_APP.RegistrarEstablecimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header center">
        <h1>Registrar Nuevo Establecimiento</h1>
    </div>
    <div class="panel panel-default">
        <asp:Table ID="tab" runat="server" Width="75%" CellSpacing="10" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblDicose" runat="server" Text="DICOSE"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDicose" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDepartamento" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblSPolicial" runat="server" Text="Sec. Policial"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtSPolicial" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBps" runat="server" Text="BPS"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtBps" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblParaje" runat="server" Text="Paraje"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtParaje" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtRazonSocial" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblSuperficie" runat="server" Text="Superficie"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtSuperficie" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="AddEstablecimiento" CssClass="btn btn-primary"/> 
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="Cancelar" CssClass="btn btn-primary"/>
            </span>
        </div>
    </div>
</asp:Content>
