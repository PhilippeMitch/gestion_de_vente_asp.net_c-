<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListerVente.aspx.cs" MasterPageFile="~/Commercial/Commercial.Master" Inherits="ValerioWeb.UI.Commercial.ListerVente" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Date Vente:</a>
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
                   <i class="fa fa-database"></i> Description vente
                </h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <!-- info -->
                    <div class="col-lg-5">
                        <div class="panel panel-info">
                            <div class="panel panel-heading">
                                <i class="fa fa-pencil-square"></i> Liste vente
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="420px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="Numero" HeaderText="Numero" />
                                            <asp:BoundField DataField="Montant" HeaderText="Montant" />
                                            <asp:BoundField DataField="Date Vente" HeaderText="Date Vente" />

                                            <asp:HyperLinkField DataNavigateUrlFields="Numero" ControlStyle-CssClass="btn btn-warning btn-sm" DataNavigateUrlFormatString="ListerVente.aspx?num={0}" Text="Contenu">
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
                            <br />
                        </div>
                    </div>

                    <div class="col-lg-7">
                        <div class="panel panel-info">
                            <div class="panel panel-heading">
                                <i class="fa fa-pencil-square"></i> Contenu vente
                            </div>
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" CellPadding="10" ForeColor="#333333" GridLines="Horizontal" Height="10px" Width="500px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="Numero" HeaderText="Vente" />
                                            <asp:BoundField DataField="Code Article" HeaderText="Code Article" />
                                            <asp:BoundField DataField="Quantite" HeaderText="Quantite" />
                                            <asp:BoundField DataField="Montant" HeaderText="Montant" />
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
        </div>  
</asp:content>