<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="TratamientoSanitario.aspx.cs" Inherits="SACG_APP.Pages.TratamientoSanitario" %>

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
                    <asp:Label ID="Label1" runat="server">Dicose</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listEstablecimientos" AutoPostBack="True"
                        OnSelectedIndexChanged="Selection_Change" runat="server">
                        </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server">ID Animal</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listAnimales" AutoPostBack="True"
                         runat="server">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server">Tipo Tratamiento</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listTratamiento" AutoPostBack="True"
                        OnSelectedIndexChanged="Selection_Change" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server">Fecha</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="yearList" AutoPostBack="True"
                        OnSelectedIndexChanged="Selection_Change" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id ="trRow1" runat="server">
                <td>
                    <asp:Label ID="Label5" runat="server">Estacion del anio</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="stationList" AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change" runat="server" class="dropdown">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server">RazaCruza</asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtRaza" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>

        </table>
        <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="cancel" CssClass="btn btn-primary" />
            </span>
        </div>
        </div>
</asp:Content>
