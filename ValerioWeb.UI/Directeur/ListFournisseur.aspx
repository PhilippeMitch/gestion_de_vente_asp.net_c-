<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Directeur/ModelDirecteur.Master" CodeBehind="ListFournisseur.aspx.cs" Inherits="ValerioWeb.UI.Directeur.ListFournisseur" %>
<%@ MasterType  virtualPath="~/Directeur/ModelDirecteur.Master"%>
<asp:content id="Corps" contentplaceholderid="MainContent" runat="server">
   

        <div id="formulaire">

            <div id="res">
                <h3>Liste des fournisseur
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
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" OnClick="HyperLink_Click" runat="server"><i class="fa fa-file"></i> Ajouter fournisseur</asp:LinkButton>
                <!--<button type="button" class="btn btn-primary"><i class="fa fa-file">Ajouter Nouveau</i></button>-->
            </div>

            <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Nom fournisseur:</a>
                        <ul class="nav navbar-nav navbar-right">
                            <div class="navbar-form navbar-left" role="search">
                                <div class="form-group">
                                    <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
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

            <fieldset>
                <legend></legend>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Width="865px" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" Height="10px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Representant" HeaderText="Representant" SortExpression="Representant"></asp:BoundField>
                        <asp:BoundField DataField="Societe" HeaderText="Societe" SortExpression="Societe"></asp:BoundField>
                        <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone" />
                        <asp:BoundField DataField="E-mail" HeaderText="E-mail" SortExpression="E-mail" />
                        <asp:BoundField DataField="Pays" HeaderText="Pays" SortExpression="Pays" />

                        <asp:HyperLinkField DataNavigateUrlFields="Societe" ControlStyle-CssClass="btn btn-warning btn-sm" DataNavigateUrlFormatString="ModifierFournisseur.aspx?num={0}" Text="Editer">
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Fournisseur.Id_Fournisseur AS ID, Fournisseur.Representant, Fournisseur.Nom_fournisseur AS Societe, Fournisseur.Telephone, Fournisseur.[E-mail], Adresse.Pays  FROM Fournisseur INNER JOIN Adresse ON Adresse.Id_Adresse = Fournisseur.Id_Adresse where Fournisseur.Active=1" UpdateCommand="UPDATE Fournisseur set Active=0 where Id_fournisseur=@ID">
                    <UpdateParameters>
                        <asp:Parameter Name="ID" />
                    </UpdateParameters>

                </asp:SqlDataSource>

            </fieldset>

        </div>
    
    </asp:content>
