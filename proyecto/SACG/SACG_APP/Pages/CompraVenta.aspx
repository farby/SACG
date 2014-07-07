<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="CompraVenta.aspx.cs" Inherits="SACG_APP.Pages.CompraVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header center">
        <h1>Tratamiento Sanitario</h1>
    </div>



    <div class="panel panel-default">

        <table class="table">
                <tr>
                <td>
                    <asp:Label ID="Label1" runat="server">Dicose Origen</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listEstablecimientos" AutoPostBack="True"
                        OnSelectedIndexChanged="Selection_Change" runat="server">
                        </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server">Dicose Destino</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listEstablecimientosDestino" AutoPostBack="True"
                         runat="server">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server">Tipo Operacion</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listOperacion" AutoPostBack="True"
                         runat="server">
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:Label ID="Label4" runat="server">Seleccione Animal</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listAnimales" AutoPostBack="True"
                         runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server">Fecha</asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server">Observaciones</asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtObs" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
        </table>
                <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="RealizarTransaccion" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="cancel" CssClass="btn btn-primary" />
            </span>
        </div>
    </div>
</asp:Content>