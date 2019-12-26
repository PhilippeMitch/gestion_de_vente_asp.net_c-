<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Magasinier/MagasinierModel.Master" CodeBehind="ListerArticle.aspx.cs" Inherits="ValerioWeb.UI.Magasinier.ListerArticle" %>

<%@ MasterType  virtualPath="~/Magasinier/MagasinierModel.Master"%>
<asp:content id="Corps" contentplaceholderid="MainContent" runat="server">
            <div id="formulaire">

            <div id="res">
                <h3>Liste des Article
                </h3>
            </div>
            <table>
                <tr>
                    <th colspan="3">
                        <asp:Label ID="lblmessage" runat="server" Font-Size="Large" ForeColor="#009900"></asp:Label>
                    </th>
                </tr>
            </table>
            <br />

            <div id="btnNew">
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info" OnClick="HyperLink_Click" runat="server"><i class="fa fa-file"></i> Ajouter Article</asp:LinkButton>
             
            </div>

            <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Nom Article:</a>
                        <ul class="nav navbar-nav navbar-right">
                            <div class="navbar-form navbar-left" role="search">
                                <div class="form-group">
                                    <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </ul>
                    </div>
                </div>
                <!-- /.container-fluid -->
            </nav>

            <fieldset>
                <legend></legend>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Width="1069px" DataSourceID="SqlDataSource1" AllowPaging="True" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" Height="10px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                        <asp:BoundField DataField="Article" HeaderText="Article" SortExpression="Article"></asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                        <asp:BoundField DataField="Fournisseur" HeaderText="Fournisseur" SortExpression="Fournisseur" />
                        <asp:BoundField DataField="Prix Achat" HeaderText="Prix Achat" SortExpression="Prix Achat" />
                        <asp:BoundField DataField="Prix Vente" HeaderText="Prix Vente" SortExpression="Prix Vente" />
                        <asp:BoundField DataField="Disponibilite" HeaderText="Disponibilite" SortExpression="Disponibilite" />
                        <asp:BoundField DataField="Quantite Minimum" HeaderText="Quantite Minimum" SortExpression="Quantite Minimum" />  
                        <asp:ImageField DataImageUrlField = "Picture" DataImageUrlFormatString = "Lister.aspx?Img={0}" ControlStyle-Width = "30" ControlStyle-Height = "30" HeaderText = "Picture">
<ControlStyle Height="50px" Width="50px"></ControlStyle>
                        </asp:ImageField>
                        <asp:HyperLinkField DataNavigateUrlFields="Code" ControlStyle-CssClass="btn btn-warning btn-sm" DataNavigateUrlFormatString="ModifierArticle.aspx?num={0}" Text="Editer">
                            <ControlStyle CssClass="btn btn-warning btn-sm"></ControlStyle>
                        </asp:HyperLinkField>
                         <asp:ButtonField Text="Supprimer" CommandName="Update" ControlStyle-CssClass="btn btn-danger">
                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                        </asp:ButtonField>

                    </Columns>
                    <EditRowStyle BackColor="#999999" Font-Size="Smaller" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="2px" Height="26px" HorizontalAlign="Left" Width="120px" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="#EFEFEF" BorderWidth="2px" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Article.Code_article AS Code, Rayon.Nom_rayon AS Article, Article.Description_article AS Description, Fournisseur.Nom_fournisseur AS Fournisseur, Article_Fournit.Prix_achat_article AS [Prix Achat], Article_Fournit.Prix_vente_article AS [Prix Vente], Article.Qte_stock AS Disponibilite, Article.Qte_alerte AS [Quantite Minimum], Image.Contenu_img AS [Picture] FROM Rayon INNER JOIN Article ON Rayon.Id_rayon = Article.Id_rayon INNER JOIN Article_Fournit ON Article.Code_article = Article_Fournit.Code_article INNER JOIN Fournisseur ON Article_Fournit.Id_fournisseur = Fournisseur.Id_Fournisseur INNER JOIN Image ON Article.ID_img = Image.ID_img where (Article.Active=1)" UpdateCommand="UPDATE Article set Active=0 where Code_Article=@Code">
                    <UpdateParameters>
                        <asp:Parameter Name="Code" />
                    </UpdateParameters>
                </asp:SqlDataSource>

            </fieldset>

        </div>

    </asp:content>
