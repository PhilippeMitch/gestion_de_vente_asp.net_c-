<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Commercial/Commercial.Master" CodeBehind="EnregistrerVente.aspx.cs" Inherits="ValerioWeb.UI.Commercial.EnregistrerVente" %>
<%@ MasterType virtualpath="~/Commercial/Commercial.Master" %>
<asp:Content ID="corps" runat="server" ContentPlaceHolderID="MainContent">

    <div id="Formulaire">
            <div id="res">
                <h3>Enregistrer Vente
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

            <!-- fin message -->
            <!-- information -->
        <div class="panel-group">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h4 class="panel-title">
                     <i class="fa fa-database"></i> Description Vente
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
                                                <asp:TextBox ID="txtidvente" Visible="false" runat="server"></asp:TextBox>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridView2" runat="server" OnRowCreated="Gridview1_RowCreated" ShowFooter="true" AutoGenerateColumns="False" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="1000px">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" HeaderText="Ligne" />
                                                        <asp:TemplateField HeaderText="Numero vente">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNumVente" Enabled="false" Width="100px" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Code article">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCodeArt" Width="100px" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Quantite">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtQuantite" Width="80px" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Prix Unitaire">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtPx" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Estimation">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtEstimation" Width="100px" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Rabais">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtRabais" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Montant">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtMontant" Width="100px" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>                                                          
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnannuler" CssClass="btn btn-danger" OnClick="LinkButton1_Click" runat="server"><i class="fa fa-recycle"></i> Supprimer </asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:LinkButton ID="ButtonAjouter" CssClass="btn btn-info" OnClick="ButtonAdd_Click" runat="server"><i class="fa fa-save"></i> Ajouter au Corbeil</asp:LinkButton>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
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
                                            </td>
                                        </tr>
                                    </table>
                                            </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnenregistrer" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>
                        <br />

                         <div class="row">
                              <div class="col-lg-4">
                                <div class="panel panel-info">
                                    <div class="panel panel-heading">
                                        <i class="fa fa-user-md"></i> Client
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="Nom Client"></asp:Label>
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
                                                <asp:Label ID="Label6" runat="server" Text="Prenom client"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtprenomclient" Width="200px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vous devez saisir un prenom" ControlToValidate="txtprenomclient" ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="valide">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprenomclient" ErrorMessage="Prenom Saisi non valide" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z' /-]+$" ValidationGroup="valide">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                                        <div class="col-lg-4">
                                            <div class="panel panel-info">
                                                <div class="panel panel-heading">
                                                    <i class="fa fa-indent"></i> Action
                                                </div>
                                                <div class="panel panel-body">

                                                    <table>

                                                        <!--<tr>
                                                            <td>
                                                                <asp:LinkButton ID="btnajouter" CssClass="btn btn-info" runat="server"><i class="fa fa-save"></i> Ajouter au Corbeil</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btncorbeil" CssClass="btn btn-info" runat="server"><i class="fa fa-minus-circle"></i> Annuler </asp:LinkButton>
                                                            </td>
                                                        </tr>-->
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Montant Total"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtmontant" runat="server" Width="130px"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                      
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="btnenregistrer" CssClass="btn btn-info" OnClick="BtnSave_Click" runat="server"><i class="fa fa-save"></i> Enregistrer </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="btnannuler" CssClass="btn btn-info" runat="server"><i class="fa fa-minus-circle"></i> Annuler  </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                        <br />                    
                    </div>
                </div>
        </div>
   
         </div>   <!-- fin information-->
</asp:Content>