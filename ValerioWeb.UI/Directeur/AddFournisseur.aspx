<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Directeur/ModelDirecteur.Master" CodeBehind="AddFournisseur.aspx.cs" Inherits="ValerioWeb.UI.Directeur.AddFournisseur" %>

<%@ MasterType  virtualPath="~/Directeur/ModelDirecteur.Master"%>


<asp:Content ID="Corps" ContentPlaceHolderID="MainContent" runat="server">

        <div id="formulaire">

            <div id="res">
                <h3>Enregistrement Fournisseur
                </h3>
            </div>
           <!-- Message -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                <asp:Label ID="lbldat" runat="server" Visible="false"  Text=""></asp:Label>
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
       
        <!-- fin message -->
            <div class="panel-group">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" href="#collapse1"><i class="fa fa-database"></i> Enregistrer Fournisseur</a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="row">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <!-- ifo personnel-->
                                        <div class="col-lg-6">
                                            <div class="panel panel-info">
                                                <div class="panel panel-heading">
                                                    <i class="fa fa-pencil-square"></i> Information personnelle
                                                </div>
                                                <div class="panel panel-body">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Id Fournisseur"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtid" Width="150px" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Nom fournisseur"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtnomfour" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnomfour" ErrorMessage="Vous devez saisir le nom" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnomfour" ErrorMessage="Nom Fournisseur invalide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Representant"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtrepresentant" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrepresentant" ErrorMessage="Vous devez saisir le representant" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtrepresentant" ErrorMessage="Representant non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Telephone"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtphone" ErrorMessage="Vous devez saisir le numero de telephone" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtphone" ErrorMessage="Numero telephone non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="E-mail"></asp:Label>
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
                                        <!--fin info perso-->
                                        <!-- Adressse-->
                                        <div class="col-lg-6">
                                            <div class="panel panel-info">
                                                <div class="panel panel-heading ">
                                                    <i class="fa fa-home"></i> Adresse
                                                </div>
                                                <div class="pane panel-body">
                                                    <table>
                                                        <tr>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label5" runat="server" Text="Pays"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtpaysfour" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpaysfour" ErrorMessage="Vous devez saisir le pays" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtpaysfour" ErrorMessage="Pays non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label6" runat="server" Text="Ville"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtvilefour" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtvilefour" ErrorMessage="Vous devez saisir la ville" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtvilefour" ErrorMessage="Ville non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label7" runat="server" Text="Zone"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtregionfour" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtregionfour" ErrorMessage="Vous devez saisir la Zone" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtregionfour" ErrorMessage="Zone non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label8" runat="server" Text="Rue"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtruefour" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtruefour" ErrorMessage="Vous devez saisir la ruelle" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtruefour" ErrorMessage="Ruelle saisir non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label9" runat="server" Text="Numero"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtnumero" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtnumero" ErrorMessage="Vous devez saisir le numero" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtnumero" ErrorMessage="Numero d'adresse non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
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
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnanuler" />
                                    </Triggers>
                                </asp:UpdatePanel>


                                <!-- bouton action -->
                                <div class="col-lg-12">
                                    <div class="panel panel-info">
                                        <div class="panel panel-heading">
                                            <i class="fa fa-bookmark-o"></i> Action
                                        </div>

                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="btnenregistrer" CssClass="btn btn-info" OnClick="btnenregistrer_Click" runat="server"> <i class="fa fa-save"></i> Enregistrer </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="btnanuler" CssClass="btn btn-info" OnClick="BtnAnnuler_Click" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <!-- fin bouton action-->
                            </div>
                        </div>
                    </div>
                </div>
                <!-- -->

             
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
