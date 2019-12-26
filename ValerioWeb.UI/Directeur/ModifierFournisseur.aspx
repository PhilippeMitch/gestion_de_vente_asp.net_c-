<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Directeur/ModelDirecteur.Master" CodeBehind="ModifierFournisseur.aspx.cs" Inherits="ValerioWeb.UI.Directeur.ModifierFournisseur" %>
<%@ MasterType  virtualPath="~/Directeur/ModelDirecteur.Master"%>
<asp:Content ID="Corps" ContentPlaceHolderID="MainContent" runat="server">
        
        <div id="formulaire">
            <div id="res">
                <h3>Modification Fournisseur
                </h3>
            </div>

            <table>
                <tr>
                    <th colspan="3">
                        <asp:Label ID="lblmessage" runat="server" Font-Size="Large" ForeColor="#009900"></asp:Label>
                    </th>
                </tr>
            </table>

            <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Nom fournisseur:</a>
                        <ul class="nav navbar-nav navbar-right">
                            <div class="navbar-form navbar-left" role="search">
                                <div class="form-group">
                                    <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnReh" Height="30px" Font-Size="13px" CssClass="btn btn-info" runat="server" Text="Rechercher" OnClick="btnReh_Click" ValidationGroup="Search" />
                                </div>
                            </div>
                        </ul>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <!-- 
                        <ul class="nav navbar-nav">
                            <li class="dropdown">
                                <asp:DropDownList ID="DropDownList1" Width="150px" Height="25px" runat="server"></asp:DropDownList>
                            </li>
                        </ul>
                        -->        
                        
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container-fluid -->
            </nav>

            <div class="panel-group">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" href="#collapse1">Contact Fournisseur</a>
                        </h4>
                    </div>
                  
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <table>
                               
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
                    <asp:Label ID="lbldat" runat="server" Text="" Visible="False"></asp:Label>
                    <asp:Label ID="lblidAd" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lbluser" runat="server" Visible="False"></asp:Label>
                </div>
                <div class="panel-group">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" href="#collapse2"> Adresse Fournisseur</a>
                            </h4>
                        </div>
                        <div id="collapse2" class="panel-collapse collapse">
                            <div class="panel-body">
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
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtnumero" ErrorMessage="Numero d'adresse non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
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
                </div>

            <!-- -->
            
            <!-- -->
                

            <div id="bartop">
                <asp:Panel ID="panBout" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnenregistrer" runat="server" CssClass="btn btn-info" Text="Enregistrer" Width="194px" Height="30px" OnClick="btnenregistrer_Click"  />&nbsp;
                                <asp:Button ID="btnanuler" runat="server" CssClass="btn btn-info" Text="Annuler" Width="155px" Height="30px" ValidationGroup="Annuler" OnClick="btnanuler_Click" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </asp:Panel>
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
