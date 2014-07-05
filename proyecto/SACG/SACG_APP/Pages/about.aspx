<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Sitio.Master" CodeBehind="about.aspx.cs" Inherits="SACG_APP.Pages.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <br />
        <div class="page-header">
            <h1>Datos del equipo</h1>
        </div>

    <div class="row">
        
        <div class="col-sm-4">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Fabricio Benitez : XXXXXX</h3>
            </div>
            <div class="panel-body">
                <img src="/Content/img/User_Avatar_1.png"/>
            </div>
          </div>
        </div>

        <div class="col-sm-4">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Nicolas Bordenave : 103333</h3>
            </div>
            <div class="panel-body">
                <img src="/Content/img/User_Avatar_1.png"/>
            </div>
          </div>
        </div>

    </div>
</asp:Content>
