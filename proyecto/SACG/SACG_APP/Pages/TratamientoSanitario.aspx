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
                        OnSelectedIndexChanged="treatment_change" runat="server">
                    </asp:DropDownList>
                </td>
                <td></td><td></td>
            </tr>
            <tr id ="trRow1" runat="server">
                <td>
                    <asp:Label ID="Label4" runat="server">Fecha</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="yearList" AutoPostBack="True"
                        OnSelectedIndexChanged="Selection_Change" runat="server">
                    </asp:DropDownList>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr id ="trRow2" runat="server">
                <td>
                    <asp:Label ID="Label5" runat="server">Fecha</asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server">Peso Registrado</asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtKilos" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trRow3" runat="server">
                <td>
                    <asp:Label ID="Label7" runat="server">Nombre</asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtNombreVacuna" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server">Dosificacion</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDosisVacuna" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trRow4" runat="server">
                <td>
                    <asp:Label ID="Label9" runat="server">Nombre Tratamiento</asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtNomTratamiento" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server">Aplicacion</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAplicacionTratamiento" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trRow5" runat="server">
                <td>
                    <asp:Label ID="Label11" runat="server">Preniada desde</asp:Label>
                </td>
                <td>
                  <asp:Calendar ID="Calendar3" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server">Observaciones</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrenia" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr id="trRow6" runat="server">
                <td>
                    <asp:Label ID="Label13" runat="server">Fecha Parto</asp:Label>
                </td>
                <td>
                  <asp:Calendar ID="Calendar4" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server">Observaciones</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtParto" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>

        </table>
        <div class="panel-footer center-block">
            <span class="center-to-right">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="AltaTratamiento" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="cancel" CssClass="btn btn-primary" />
            </span>
        </div>
        </div>
</asp:Content>
