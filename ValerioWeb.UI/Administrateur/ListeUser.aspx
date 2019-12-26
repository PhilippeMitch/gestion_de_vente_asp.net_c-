<%@ Page Language="C#" MasterPageFile="~/Administrateur/Administrateur.Master" AutoEventWireup="true" CodeBehind="ListeUser.aspx.cs" Inherits="ValerioWeb.UI.Administrateur.ListeUser" %>
<%@ MasterType VirtualPath="~/Administrateur/Administrateur.Master" %>
<asp:Content ID="corps" runat="server" ContentPlaceHolderID="MainContent">
<div id="Formulaire">
            <div id="res">
                <h3>Lister Utilisateur
                </h3>
            </div>
    <table>
        <tr>
            <th colspan="3">
                <asp:Label ID="lblmessage" Font-Size="Large" ForeColor="#009900" runat="server" Text="Label"></asp:Label>
            </th>
        </tr>
    </table> <br />
     <div id="btnnew">
         <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info"  runat="server" > <i class="fa fa-file"></i> Ajouter un utilisateur </asp:LinkButton>
         </div>
    <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
<div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Nom du client:</a>
 <ul class="nav navbar-nav navbar-right ">
<div class="navbar-form navbar-left" role="search">
 <div class="form-group">
     <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
     <asp:LinkButton ID="LinkButton2" CssClass="btn btn-info" runat="server"> <i class="fa fa-search"></i> Rechercher </asp:LinkButton>
   </div>
    </div>
     </ul>
            </div>
    </div>
        </nav>

     <div class="panel panel-info">
            <div class="panel-heading">
                <h4 class="panel-title">
                   <i class="fa fa-database"></i> Liste des utilisateurs
                </h4>
            </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </div>
                    </div>
         </div>
    
         </div>
</asp:Content>