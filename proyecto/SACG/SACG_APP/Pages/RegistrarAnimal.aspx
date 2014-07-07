<%@ Page Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="RegistrarAnimal.aspx.cs" Inherits="SACG_APP.Pages.RegistrarAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header center">
        <h1>Nuevo Animal</h1>
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
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server">Sexo</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="genderList" AutoPostBack="True"
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
            <tr>
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
            <tr>
                <td></td><td></td>
                <td>
                    <asp:Label ID="Label7" runat="server">RFID</asp:Label>
                    <asp:CheckBox ID="chkRfid" AutoPostBack="true" Checked="false" runat="server" text="(si lo tiene)" OnCheckedChanged="chkRfid_CheckedChanged"/>
                </td>
                <td>
                    <asp:TextBox ID="txtRfid" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                </td>
             </tr>
        </table>
        <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="AltaAnimal" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="cancel" CssClass="btn btn-primary" />
            </span>
        </div>
        </div>
</asp:Content>
