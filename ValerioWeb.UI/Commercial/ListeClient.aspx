<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Commercial/Commercial.Master" CodeBehind="ListeClient.aspx.cs" Inherits="ValerioWeb.UI.Commercial.ListeClient" %>

<%@ MasterType VirtualPath="~/Commercial/Commercial.Master"%>
<asp:content id="corps" contentplaceholderid="MainContent" runat="server">


    <div id="Formulaire">
        <div id="res">
            <h2>Lister un client
            </h2>
        </div>
        <table>
            <tr>
                <th colspan="3">
                    <asp:Label ID="lblmessage" runat="server" Font-Size="Large" ForeColor="#009900"></asp:Label>
                </th>

            </tr>

        </table>
        <br />
        <div id="btnnew">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-info" runat="server"><i class="fa fa-file"></i> Ajouter un Client</asp:LinkButton>
        </div>

        <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Nom du client:</a>
                    <ul class="nav navbar-nav navbar-right ">
                        <div class="navbar-form navbar-left" role="search">
                            <div class="form-group">
     <asp:TextBox ID="txtidrech" runat="server"></asp:TextBox>
<asp:LinkButton ID="LinkButton2" CssClass="btn btn-info" runat="server"><i class="fa fa-search"></i> Rechercher</asp:LinkButton>
                            </div>
                        </div>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="panel panel-info">
            <div class="panel-heading">
                <h4 class="panel-title">
                   <i class="fa fa-database"></i> Description
                </h4>
            </div>
                <div class="panel-body">
                    <div class="row">
                        <!-- info -->
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="836px" DataKeyNames="Numero">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero" ReadOnly="True" />
                                        <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                                        <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                                        <asp:BoundField DataField="Identifiant" HeaderText="Identifiant" SortExpression="Identifiant" />
                                        <asp:BoundField DataField="TElephone" HeaderText="Telephone" SortExpression="TElephone" />
                                        <asp:BoundField DataField="E-mail" HeaderText="E-mail" SortExpression="E-mail" />

                                        <asp:HyperLinkField DataNavigateUrlFields="Numero" ControlStyle-CssClass="btn btn-warning btn-sm" DataNavigateUrlFormatString="ModifierClient.aspx?num={0}" Text="Editer">
                                            <ControlStyle CssClass="btn btn-warning btn-sm"></ControlStyle>
                                        </asp:HyperLinkField>

                                        <asp:ButtonField Text="Supprimer" CommandName="Update" ControlStyle-CssClass="btn btn-danger">
                                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                        </asp:ButtonField>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Id_Client AS Numero, Nom_Client AS Nom, Prenom_Client AS Prenom, Nif_Cin AS Identifiant, Tel_Client AS Telephone, Mail_Client AS [E-mail] FROM Client WHERE (Active = 1)" UpdateCommand="UPDATE Client set Active=0 where Id_Client=@Numero"></asp:SqlDataSource>
                        <br />    
                    </div>
                </div>
            </div>

       </div>   
</asp:content>
