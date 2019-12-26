<%@ Page Language="C#" MasterPageFile="~/Commercial/Commercial.Master" AutoEventWireup="true" CodeBehind="DescriptionCommande.aspx.cs" Inherits="ValerioWeb.UI.Commercial.DescriptionCommande" %>
<%@ MasterType virtualpath="~/Commercial/Commercial.Master" %>
<asp:Content ID="corps" runat="server" ContentPlaceHolderID="MainContent">
    <div id="Formulaire">
          <div id="res">
              <h3> Description Commande
                </h3>
              </div>
         <!-- Message -->
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">
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
                                                <asp:Label ID="Label2" runat="server" Visible="false" Text=""></asp:Label>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
        </div>
    </div>
    </div>
                    </div>
                </ContentTemplate>
</asp:UpdatePanel>
         <div class="panel-group">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h4 class="panel-title">
                     <i class="fa fa-database"></i> Description Commande
                    </h4>
                </div>
 <div class="panel-body">
<div class="row">
 <div class="col-lg-12">
 <div class="panel panel-info">
 <div class="panel panel-heading">
     <i class="fa fa-shopping-cart"></i> Corbeil
        </div>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
<table>
    <tr>
        <td colspan="3">
            <asp:Label ID="Label1" runat="server" Text="Montant Total"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtmnttotal" runat="server"></asp:TextBox>
        </td>
        <td colspan="3">
            <asp:Label ID="Label3" runat="server" Text="Delai Livraison"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtdelai" runat="server"></asp:TextBox>
        </td>
    </tr>
    
</table>
             </ContentTemplate>
         </asp:UpdatePanel>
     </div>
        </div>
    </div>
    <br />
 <div class="panel-group">
           
                <div class="panel-body">
<div class="row">
 <div class="col-lg-12">
 <div class="panel panel-info">
 <div class="panel panel-heading">
     <i class="fa fa-shopping-cart"></i> Info
        </div>
      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
         <ContentTemplate>
             <table>
                 <tr>
                     <td colspan="3">
<asp:RadioButton ID="rdbnif" GroupName="identifiant" Text="Nif" Checked=" True" runat="server" AutoPostBack="true" />
 &nbsp;&nbsp;&nbsp;
<asp:RadioButton ID="rdbcin" GroupName="identifiant" Text="Cin" Checked="true" runat="server" AutoPostBack="true" />
                     </td>
<td>
    <asp:TextBox ID="txtnif" Width="180px" runat="server"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcin" Width="210px" runat="server"></asp:TextBox>
</td>
<td>
 <asp:RequiredFieldValidator ID="RequiredFieldValidatorNif" runat="server" ErrorMessage="Vous devez saisi un NIF" ControlToValidate="txtnif" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="RegularExpressionNif" runat="server" ControlToValidate="txtnif" ErrorMessage="Nif saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="([0-9]{3})-([0-9]{3})-([0-9]{3})-([0-9]{1})+$">*</asp:RegularExpressionValidator>
  <asp:RequiredFieldValidator ID="RequiredFieldValidatorCin" runat="server" ErrorMessage="Vous devez saisi un CIN" ControlToValidate="txtnif" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="RegularExpressionCin" runat="server" ControlToValidate="txtcin" ErrorMessage="CIN saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="([0-9]{2})-([0-9]{2})-([0-9]{2})-([0-9]{4})-([0-9]{2})-([0-9]{5})+$">*</asp:RegularExpressionValidator>
  
</td>
<td>
    <asp:Button ID="btnverifier" runat="server" Text="Verifier" />
</td>
 </tr>
 </table>
  </ContentTemplate>
<Triggers>
  <asp:AsyncPostBackTrigger ControlID="rdbcin" />
  <asp:AsyncPostBackTrigger ControlID="rdbnif" />
  </Triggers>
          </asp:UpdatePanel>
     </div>
     </div>
    </div>
    </div>
                </div>
     </div>


 <div class="panel panel-info">
 <div class="panel-heading">
 <h4 class="panel-title">
 <a data-toggle="collapse" href="#collapse1"><i class="fa fa-database"></i> Client </a>
 </h4>
 </div>
 <div id="collapse1" class="panel-collapse collapse">
 <div class="panel-body">
<div class="row">
    <div class="col-lg-6">
    <div class="panel panel-info">
    <div class="panel panel-heading">
    <i class="fa fa-pencil-square"></i> Information personnelle
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<table>
<tr>
    <td>
        <asp:Label ID="lblnom" runat="server" Text="Nom"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtnom" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtnom" SetFocusOnError="true" ValidationGroup="valide"  runat="server" ErrorMessage="Vous devez saisir un nom" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnom" ErrorMessage="Nom client non Valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>                                       
</td>
</tr>
    <tr>
<td>
    <asp:Label ID="Label4" runat="server" Text="Prenom"></asp:Label>
</td>
        <td>
            <asp:TextBox ID="txtprenom" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtprenom" SetFocusOnError="true" ValidationGroup="valide"  runat="server" ErrorMessage="Vous devez saisir le prenom" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprenom" ErrorMessage="Prenom client non Valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
       </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Telephone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txttel" runat="server"></asp:TextBox>
        </td>
        <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txttel" SetFocusOnError="true" ValidationGroup="valide"  runat="server" ErrorMessage="Vous devez saisir un tel" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txttel" ErrorMessage="Telephone non Valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
 </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style2">
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmail" ErrorMessage="Voud devez saisir l'adresse mail" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtmail" ErrorMessage="Adresse mail non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
</td>
    </tr>
</table>
        </div>
</div>
    </div>
<div class="col-lg-6">
<div class="panel panel-info">
<div class="panel panel-heading ">
<i class="fa fa-home"></i> Adresse
    </div>
 <div class="pane panel-body">
<table>
<tr>
   <td class="auto-style4">
        <asp:Label ID="Label7" runat="server" Text="Pays"></asp:Label>
    </td>
    <td class="auto-style3">
        <asp:TextBox ID="txtpays" runat="server"></asp:TextBox>
    </td>
     <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpays" ErrorMessage="Vous devez saisir le pays" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtpays" ErrorMessage="Pays non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
 </td>                                                       
</tr>
    <tr>
       <td class="auto-style4">
           <asp:Label ID="Label8" runat="server" Text="Ville"></asp:Label>
        </td>
       <td class="auto-style3">
            <asp:TextBox ID="txtville" runat="server"></asp:TextBox>
        </td>
 <td>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtville" ErrorMessage="Vous devez saisir la ville" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtville" ErrorMessage="Ville non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
  </td>
  </tr>
    <tr>
         <td class="auto-style4">
             <asp:Label ID="Label9" runat="server" Text="Region"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtregion" runat="server"></asp:TextBox>
        </td>
         <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtregion" ErrorMessage="Vous devez saisir la Zone" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtregion" ErrorMessage="Zone non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
 </td>
    </tr>
    <tr>
       <td class="auto-style4">
            <asp:Label ID="Label10" runat="server" Text="Rue"></asp:Label>
        </td>
     <td class="auto-style3">
            <asp:TextBox ID="txtrue" runat="server"></asp:TextBox>
        </td>
 <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtrue" ErrorMessage="Vous devez saisir la ruelle" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtrue" ErrorMessage="Ruelle saisie n'est pas valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
 </td>
    </tr>
    <tr>
         <td class="auto-style4">
            <asp:Label ID="Label11" runat="server" Text="Numero"></asp:Label>
        </td>
       <td class="auto-style3">
            <asp:TextBox ID="txtnum" runat="server"></asp:TextBox>
        </td>
         <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtnum" ErrorMessage="Vous devez saisir le numero" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtnum" ErrorMessage="Numero d'adresse non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
 </td>
    </tr>
     <tr>
 <td colspan="3">
 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
  </td>
  </tr>
</table>
     </div>
    </div>
</div>
  <ContentTemplate>

   <Triggers>
  <asp:AsyncPostBackTrigger ControlID="btnanuler" />
 </Triggers> 
                        
  </asp:UpdatePanel>

   <div class="col-lg-12">
   <div class="panel panel-info">
   <div class="panel panel-heading">
   <i class="fa fa-bookmark-o"></i> Action
   </div>  
       <table>
<tr>
    <td>
<asp:LinkButton ID="btnenregistrer" CssClass="btn btn-info" runat="server"><i class="fa fa-save"></i> Enregistrer</asp:LinkButton>
    </td>
    <td>
<asp:LinkButton ID="btnannuler" CssClass="btn btn-info" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
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