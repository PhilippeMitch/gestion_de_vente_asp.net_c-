<%@ Page Language="C#" MasterPageFile="~/Administrateur/Administrateur.Master" AutoEventWireup="true" CodeBehind="ModifierUser.aspx.cs" Inherits="ValerioWeb.UI.Administrateur.WebForm1" %>
<%@ MasterType VirtualPath="~/Administrateur/Administrateur.Master" %>
<asp:Content ID="corps" runat="server" ContentPlaceHolderID="MainContent">
<div id="Formulaire">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="res">
                <h3>Modifier un Utilisateur
                </h3>
            </div>
     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
 <div class="alert alert-success">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <div class="panel panel-group">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <i class="fa fa-info"></i> Message
                                </h4>
                            </div>
                            <div class="panel panel-body">
                                <table>
<tr>
    <td>
<strong>
    <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lbldat" runat="server" Visible="false" Text=""></asp:Label>
    <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
</strong>
    </td>
</tr>
                                </table>
                                </div>
                            </div>
                        </div>
     </div>
     </ContentTemplate>
          <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnenregistrer" />
            </Triggers>
         </asp:UpdatePanel>
         </div>
     <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Nom du client:</a>

                <div class="navbar-form navbar-left" role="search">
                    <div class="form-group">
                        <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-info" ValidationGroup="search" runat="server"> <i class="fa fa-search"></i>Rechercher</asp:LinkButton>
   </div>
                    </div>
                </div>
            </div>
         </nav>
     <div class="panel-info">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse1"><i class="fa fa-list-alt"></i>Liste des utilisateurs </a>
            </h4>
        </div>
        <div class="panel panel-group">
            <div id="collapse1" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="836px" ></asp:GridView>
                        </ContentTemplate>
                            </asp:UpdatePanel>
   </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>

