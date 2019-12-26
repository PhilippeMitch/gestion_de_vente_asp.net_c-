<%@ Page Language="C#" MasterPageFile="~/Administrateur/Administrateur.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ValerioWeb.UI.Administrateur.NouveauUser" %>
<%@ MasterType VirtualPath="~/Administrateur/Administrateur.Master" %>
<asp:Content ID="corps" runat="server" ContentPlaceHolderID="MainContent">
     <div id="Formulaire">
            <div id="res">
                <h3>Enregistrer Utilisateur
                </h3>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
 <div class="alert alert-success">
<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      <div class="panel panel-group">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <i class="fa fa-info"></i> Description
                                </h4>
                            </div>
                             <div class="panel panel-body">
                                 <table>
                                     <tr>
                                         <td> <strong>
                                             <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> 
                                             <asp:Label ID="lbldat" runat="server" Visible="false" Text=""></asp:Label>
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
          <div class="panel-group">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" href="#collapse1"><i class="fa fa-database"></i> Enregistrer Utilisateur</a>
                        </h4>
                    </div>
                     <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="row">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
 <div class="col-lg-6">
 <div class="panel panel-info">
 <div class="panel panel-heading">
 <i class="fa fa-pencil-square"></i> Veuillez remplir tous les champs
 </div>
     <div class="panel panel-body">
         <table>
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="Nom Utilisateur"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnomutil" runat="server"></asp:TextBox>
                 </td>
                  <td class="auto-style2">
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnomutil" ErrorMessage="Vous devez saisir le nom" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnomutil" ErrorMessage="Nom Utilisateur invalide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
 </td>
 </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="Mot de passe Utilisateur"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtpwdutil" runat="server"></asp:TextBox>
 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label3" runat="server" Text="Confirmer mot de passe"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtconfirm" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtemail" Width="180px" runat="server"></asp:TextBox>
                 </td>
                 <td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Email saisi incorrect" ControlToValidate="txtemail" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="valide">*</asp:RegularExpressionValidator>
</td>
 </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label5" runat="server" Text="Groupe Utilisateur"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtgputil" runat="server"></asp:TextBox>
                 </td>
             </tr>
         </table>
         </div>
 </div>
     </div>
         </ContentTemplate>
    </asp:UpdatePanel>
 <div class="col-lg-12">
 <div class="panel panel-info">
 <div class="panel panel-heading">
 <i class="fa fa-bookmark-o"></i> Action
 </div>
<table>
    <tr>
        <td>
            <asp:LinkButton ID="btnenregistrer" CssClass="btn btn-info" runat="server"> <i class="fa fa-save"></i> Enregistrer</asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="btnannuler" CssClass="btn btn-info" runat="server"> <i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
        </td>
    </tr>
</table>
 </div>
     </div>
  </div>
  </div>
  </div>
 </div>
 </div>
 </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style2 {
            width: 20px;
        }
        .auto-style3 {
            width: 308px;
        }
        .auto-style4 {
            width: 124px;
        }
    </style>
</asp:Content>
