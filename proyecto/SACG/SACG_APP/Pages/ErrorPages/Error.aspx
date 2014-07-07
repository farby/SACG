<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="Error.aspx.cs" Inherits="SACG_APP.Pages.ErrorPages.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header">
        <h1>Ocurrio algun Error</h1>
    </div>

    <div class="panel panel-default">


        <table class="table">
            <tr role="alert">
                <td>
                    <span class="label label-danger">Error: </span>
                </td>
                <td>
                    <asp:TextBox ID="txtError" runat="server" class="label"></asp:TextBox>
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
