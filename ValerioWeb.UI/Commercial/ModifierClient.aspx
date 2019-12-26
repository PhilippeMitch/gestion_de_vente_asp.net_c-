﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Commercial/Commercial.Master" CodeBehind="ModifierClient.aspx.cs" Inherits="ValerioWeb.UI.Commercial.ModifierClient" %>
<%@ MasterType VirtualPath="~/Commercial/Commercial.Master" %>
<asp:Content ID="Corps" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulaire">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="res">
            <h3>Modifier un Client
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
                                                <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
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
                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-info" ValidationGroup="search" OnClick="BtnRechercher_Click" runat="server"><i class="fa fa-search"></i> Rechercher</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>
    </nav>

    <div class="panel-info">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse1"><i class="fa fa-list-alt"></i>Liste </a>
            </h4>
        </div>
        <div class="panel panel-group">
            <div id="collapse1" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="836px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Id_Client" HeaderText="Numero" />
                                        <asp:BoundField DataField="Nom_Client" HeaderText="Nom" />
                                        <asp:BoundField DataField="Prenom_Client" HeaderText="Prenom" />
                                        <asp:BoundField DataField="Nif_Cin" HeaderText="Identifiant" />
                                        <asp:BoundField DataField="Mail_Client" HeaderText="E-Mail" />

                                        <asp:HyperLinkField DataNavigateUrlFields="Id_Client" ControlStyle-CssClass="btn btn-warning btn-sm" DataNavigateUrlFormatString="ModifierClient.aspx?num={0}" Text="Editer">
                                            <ControlStyle CssClass="btn btn-warning btn-sm"></ControlStyle>
                                        </asp:HyperLinkField>

                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#006699" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" ForeColor="White" Height="26px" Width="120px" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="#EFEFEF" BorderWidth="2px" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="LinkButton2" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="panel panel-group">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" href="#collapse2"><i class="fa fa-database"></i>Description</a>
                </h4>
            </div>
            <div id="collapse2" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="row">
                        <!-- info -->
                        <div class="col-lg-6">
                            <div class="panel panel-info">
                                <div class="panel panel-heading">
                                    <i class="fa fa-pencil-square"></i>Information personnel
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="Numero"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtid" Width="130px" Enabled="false" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Nom Client"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnomclient" Width="180px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtnomclient" SetFocusOnError="true" ValidationGroup="valide" runat="server" ErrorMessage="Vous devez saisir un nom" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnomclient" ErrorMessage="Nom client non Valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Prenom client"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtprenomclient" Width="200px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vous devez saisir un prenom" ControlToValidate="txtprenomclient" ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="valide">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprenomclient" ErrorMessage="Prenom Saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>

                                                                <asp:RadioButton ID="rdbnif" OnCheckedChanged="Rdbnif_CkeckChange" GroupName="identifiant" Text=" NIF" Checked="true" runat="server" AutoPostBack="True" />
                                                                &nbsp;&nbsp;&nbsp;
                                                                            <asp:RadioButton ID="rdbcin" GroupName="identifiant" Text="CIN" OnCheckedChanged="Rdbcin_CkeckChange" runat="server" AutoPostBack="True" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtnif" placeholder="saisir nif" Width="180px" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtcin" Visible="false" placeholder="saisir cin" Width="210px" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNif" runat="server" ErrorMessage="Vous devez saisi un NIF" ControlToValidate="txtnif" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionNif" runat="server" ControlToValidate="txtnif" ErrorMessage="Nif saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="([0-9]{3})-([0-9]{3})-([0-9]{3})-([0-9]{1})+$">*</asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCin" runat="server" ErrorMessage="Vous devez saisi un CIN" ControlToValidate="txtnif" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionCin" runat="server" ControlToValidate="txtcin" ErrorMessage="CIN saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="([0-9]{2})-([0-9]{2})-([0-9]{2})-([0-9]{4})-([0-9]{2})-([0-9]{5})+$">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rdbcin" />
                                                    <asp:AsyncPostBackTrigger ControlID="rdbnif" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Telephone"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txttelf" Width="180px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vous devez saisir un numero de telephone" ControlToValidate="txttelf" ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="valide">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txttelf" ErrorMessage="Numero de telephone non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="([(])([0-9]{3})([)])([0-9]{4})-([0-9]{4})+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmail" Width="180px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Mail saisi non valide" ControlToValidate="txtmail" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="valide">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="panel panel-info">
                                <div class="panel panel-heading">
                                    <i class="fa fa-home"></i>Adresse
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Pays"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpays" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpays" ErrorMessage="Vous devez saisir le nom du pays" ValidationGroup="valide" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtpays" ErrorMessage="Pays saisi non valide" ValidationGroup="valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Ville"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtvile" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtvile" ErrorMessage="Vous devez saisir le nom d'une ville" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtvile" ErrorMessage="Ville non valide" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Region"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtregion" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtregion" ErrorMessage="Vous devez saisir la Zone" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtregion" ErrorMessage="Zone non valide" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-][a-zA-Z '\0-9]+$">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Rue"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtrue" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtrue" ValidationGroup="valide" ErrorMessage="Vous devez saisir la ruelle" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtrue" ValidationGroup="valide" ErrorMessage="Ruelle saisir non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Numero"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnum" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtnum" ErrorMessage="Vous devez saisir le numero" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtnum" ErrorMessage="Numero d'adresse non valide" ForeColor="#CC0000" ValidationGroup="valide" SetFocusOnError="True" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="panel panel-info">
                                <div class="panel panel-heading">
                                    <i class="fa fa-bookmark-o"></i>Action
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnenregistrer" CssClass="btn btn-info" OnClick="BtnModifier_Click" ValidationGroup="valide" runat="server"><i class="fa fa-save"></i> Enregistrer </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnannuler" CssClass="btn btn-info" OnClick="BtnAnnuler_Click" runat="server"><i class="fa fa-minus-circle"></i> Annuler  </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="panel panel-info">
                            <div class="panel panel-heading">
                                <i class="fa fa-flag"></i>Message d'erreur
                            </div>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ValidationGroup="valide" ID="ValidationSummary1" ForeColor="Red" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>