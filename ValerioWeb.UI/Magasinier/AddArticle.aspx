<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Magasinier/MagasinierModel.Master" CodeBehind="AddArticle.aspx.cs" Inherits="ValerioWeb.UI.Responsable_des_Achats.AddArticle" %>

<%@ MasterType  virtualPath="~/Magasinier/MagasinierModel.Master"%>

<asp:Content ID="Corps" runat="server" ContentPlaceHolderID="MainContent">

    <div id="Formulaire">
        <script>        
            function readURL(imgFile) {
                var newPreview = document.getElementById('preview_ie');
                newPreview.filters.item('DXImageTransform.Microsoft.AlphaImageLoader').src = imgFile.value;             
                newPreview.style.width = '160px';
                newPreview.style.height = '120px';
            }
        </script>

        <div id="res">
            <h3>Gestion Article
            </h3>
        </div>
        <!-- Message -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
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
                                                <asp:Label ID="lblsms" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lbldat" runat="server" Visible="False"></asp:Label>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        </div>
                    </div>
        
       
        <!-- fin message -->
        <!-- form  insertion-->
         <div class="panel-group">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" href="#collapse1"> <i class="fa fa-database"></i> Description Article</a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="panel panel-info">
                                        <div class="panel panel-heading">
                                            <i class="fa fa-pencil-square"></i> Info
                                         </div>
                                        <div class="panel panel-body">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text="Code produit"></asp:Label>
                                                     </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcode" Width="120px" Enabled="false" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Nom Article"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtnom" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnom" ErrorMessage="Vous devez saisir le nom du produit!" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnom" ErrorMessage="Nom produit nom valide !" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[a-zA-Z][a-zA-Z '\-]+$">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="Prix Achat"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtpx_achat" Width="130px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpx_achat" ErrorMessage="Vous devez saisir le prix d'achat !" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpx_achat" ErrorMessage="Prix achat non valide !" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="Prix Vente"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtpx_vente" Width="130px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpx_vente" ErrorMessage="Vous devez saisir le prix de vente !" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtpx_vente" ErrorMessage="Prix de vente non valide !" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="Categorie"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlcategorie" runat="server" Height="26px" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Nom_categorie" DataValueField="Nom_categorie">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Nom_categorie FROM Categorie WHERE (Active = @active)">
                                                            <SelectParameters>
                                                                <asp:Parameter DefaultValue="true" Name="active" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Text="Fournisseur"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlfournisseur" Width="160px" Height="26px" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nom_fournisseur" DataValueField="Nom_fournisseur"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Nom_fournisseur FROM Fournisseur WHERE (Active = @active)">
                                                            <SelectParameters>
                                                                <asp:Parameter DefaultValue="true" Name="active" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td></td>
                                                </tr>                                          
                                                                                             
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="panel panel-info">
                                        <div class="panel panel-heading">
                                            <i class="fa fa-image"></i> Image produit
                                        </div>
                                        <div class="panel panel-body">
                                           
                                                    <div class="panel panel-info">
                                                        <img src="#" id="blah" alt="image article" width="210" height="223" />
                                                    </div>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span class="btn btn-info btn-file"> <i class="fa fa-camera"></i>Image
                                                                  <!-- <input id="FileUpload1" type="file-->
                                                                  <asp:FileUpload ID="FileUpload1" onchange="document.getElementById('blah').src = window.URL.createObjectURL(this.files[0])"  runat="server" />
                                                                </span>
                                                            </td> 
                                                                                                                                                                                                                                         
                                                        </tr>
                                                    
                                                    </table>
                                               
                                        </div>
                                    </div>
                                </div>
                                <div class="col col-lg-5">
                                    <div class="panel panel-info">
                                        <div class="panel panel-heading">                                           
                                            <i class="fa fa-pencil-square"></i> Info                                      
                                        </div>
                                        <div class="panel panel-body">
                                            <table>
                                                 <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Description "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdescription" runat="server" width="170px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtdescription" runat="server" ErrorMessage="Vous devez saisir la description de l'article">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="Quantite en Stock"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtqtestock" Width="130px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtqtestock" ErrorMessage="Vous devez saisir la quantitee en stock !" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtqtestock" ErrorMessage="Quantite en Stock non valide !" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="Quantite d'alerte"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtqtealerte" Width="130px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtqtealerte" ErrorMessage="Vous devez saisir la quantitee d'alerte !" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtqtealerte" ErrorMessage="Quantite d'alerte non valide !" ForeColor="#CC0000" SetFocusOnError="True" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <div id="row">
                                    <div class="col-lg-5">
                                        <div class="panel panel-info">
                                            <div class="panel panel-heading">
                                                <i class="fa fa-bookmark-o"></i>Action
                                            </div>

                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lbtnEnregistrer"  OnClick="BtnEnregistrer_Click" CssClass="btn btn-info" runat="server"><i class="fa fa-save"></i> Enregistrer produit</asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lbtnAnnuler" CssClass="btn btn-info" OnClick="BtnAnnuler_Click" ValidationGroup="papa" runat="server"><i class="fa fa-minus-circle"></i> Annuler</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="panel panel-info">
                                        <div class="panel panel-heading">
                                            <i class="fa fa-flag"></i> Message d'erreur
                                        </div>
                                        <div class="panel panel-body">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" SetFocusOnError="True" ErrorMessage="Seulement les fichiers jpg,png ou bmp sont acceptes!" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G))$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="True" ErrorMessage="Vous devez choisir une image!" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
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
        <!-- fin form insertion -->
       
        <!-- fin form-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            margin-right: 80px;
        }
    </style>
    </asp:Content>
