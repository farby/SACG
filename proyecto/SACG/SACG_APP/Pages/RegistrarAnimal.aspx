<%@ Page Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="RegistrarAnimal.aspx.cs" Inherits="SACG_APP.Pages.RegistrarAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
    <div class="page-header center">
        <h1>Nuevo Animal</h1>
    </div>

    <div class="panel panel-default">
        <div class="panel-body">
           <div class="row">
             <span class="label label-default">ID</span>
             <input class="text-info" id="idAnimal" />
        </div>
        </div>
    </div>

        <div class="form-group">
            <input type="text" class="form-control" placeholder="Search"/>
        </div>
        <button type="submit" class="btn btn-default">Submit</button>
        

</asp:Content>
