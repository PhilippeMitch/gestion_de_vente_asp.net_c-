<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Directeur/ModelDirecteur.Master" CodeBehind="AddDepotCategorieRayon.aspx.cs" Inherits="ValerioWeb.UI.Directeur.AddDepot" %>
<%@ MasterType  virtualPath="~/Directeur/ModelDirecteur.Master"%>
<asp:Content ID="Corps" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulaire">
        <!--Tite -->
        <div id="res">
            <h3>Gestion Produit
            </h3>
        </div>
        <!-- -->
        <!-- grand panel-->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-info">
                <div class="panel panel-heading">
                    <i class="fa fa-database"></i> Produit
                </div>
                   <div class="panel panel-body">
                    <!--depot -->
                    <div class="col-lg-4">
                        <div class="panel panel-info">
                            <div class="panel panel-heading">
                                <i class="fa fa-dedent"></i> Entrepot
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th colspan="3">
                                                <asp:Label ID="lblsmsentrepot" runat="server" Text=""></asp:Label>
                                            </th>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lblenregistrerdepot" />
                                </Triggers>
                            </asp:UpdatePanel>
                             
                                <asp:Panel ID="pandepot" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label1" runat="server" Text="ID entrepot"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtidentrepot" Width="150px" Enabled="false" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:Label ID="Label2" runat="server" Text="Nom "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtnondepot" Width="180px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <asp:LinkButton ID="lblenregistrerdepot" CssClass="btn btn-info" OnClick="LblenregistrerDepo_Click" runat="server"><i class="fa fa-save"></i> Enregistrer</asp:LinkButton>
                                                    </td>

                                                    <td>
                                                        <asp:LinkButton ID="lblanulerdepot" CssClass="btn btn-info" OnClick="LblanulerDepot_Click" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lblanulerdepot" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                           
                        </div>
                    </div>
                    <!--fin depot -->
                    <!-- Categorie -->
                    <div class="col-lg-4">
                        <div class="panel panel-info">
                            <div class="panel panel-heading ">
                                <i class="fa fa-dedent"></i> Categorie
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th colspan="3">
                                                <asp:Label ID="lblsmscategorie" runat="server" Text=""></asp:Label>
                                            </th>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lblenregistre_categorie" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="ID Categorie"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtidcategorie" Width="150px" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Nom Categorie"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnomcategorie" Width="180px" runat="server"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Entrepot"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlentrepot" Width="150px" Height="27px" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nom_depot" DataValueField="Nom_depot" ></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT [Nom_depot] FROM [Depot] WHERE ([Active] = @Active)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lblenregistre_categorie" CssClass="btn btn-info" OnClick="Lblenregistrer_Categorie_Click" runat="server"><i class="fa fa-save"></i> Enregistrer</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lblanuler_categorie" CssClass="btn btn-info" OnClick="LblanulerCategorie_Click" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lblanuler_categorie" />
                                </Triggers>
                            </asp:UpdatePanel>
                                
                            
                        </div>
                    </div>
                    <!-- fin categorie-->
                    <!-- rayon-->
                       <div class="col-lg-4">
                           <div class="panel panel-info">
                               <div class="panel panel-heading">
                                   <i class="fa fa-dedent"></i>Rayon
                               </div>
                               <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                   <ContentTemplate>
                                       <table>
                                           <tr>
                                               <th colspan="3">
                                                   <asp:Label ID="lblrayon" runat="server" Text=""></asp:Label>
                                               </th>
                                           </tr>
                                       </table>
                                   </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="lblenregistrer_rayon" />
                                   </Triggers>
                               </asp:UpdatePanel>
                               <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                   <ContentTemplate>
                                       <table>
                                           <tr>
                                               <td>
                                                   <asp:Label ID="Label6" runat="server" Text="Id rayon"></asp:Label>
                                               </td>
                                               <td>
                                                   <asp:TextBox ID="txtidrayon" Width="150px" runat="server" Enabled="False"></asp:TextBox>
                                               </td>
                                               <td></td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <asp:Label ID="Label7" runat="server" Text="Nom Rayon"></asp:Label>
                                               </td>
                                               <td>
                                                   <asp:TextBox ID="txtnomrayon" Width="180px" runat="server"></asp:TextBox>
                                               </td>
                                               <td></td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <asp:Label ID="Label8" runat="server" Text="Categorie"></asp:Label>
                                               </td>
                                               <td>
                                                   <asp:DropDownList ID="ddlcategorie" Width="150px" Height="27px" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nom_categorie" DataValueField="Nom_categorie" ></asp:DropDownList>
                                                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT [Nom_categorie] FROM [Categorie] WHERE ([Active] = @Active)">
                                                       <SelectParameters>
                                                           <asp:Parameter DefaultValue="true" Name="Active" Type="Boolean" />
                                                       </SelectParameters>
                                                   </asp:SqlDataSource>
                                               </td>
                                               <td></td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <asp:LinkButton ID="lblenregistrer_rayon" CssClass="btn btn-info" OnClick="Lblenregistrer_Rayon_Click" runat="server"><i class="fa fa-save"></i> Enregistrer</asp:LinkButton>
                                               </td>
                                               <td>
                                                   <asp:LinkButton ID="lblanuler_rayon" CssClass="btn btn-info" OnClick="LblenAnuler_Rayon_Click" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
                                               </td>
                                           </tr>
                                       </table>
                                   </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="lblanuler_rayon" />
                                   </Triggers>
                               </asp:UpdatePanel>

                           </div>
                       </div>
                    <!-- fin rayon-->
                   </div>
                </div>
            </div>
            </div>
        </div>
        <!-- fin -->
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 86px;
        }
    </style>
</asp:Content>
