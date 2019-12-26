<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Essai.aspx.cs" Inherits="ValerioWeb.UI.Essai" %>

 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <style type="text/css">
        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</head>
<body>
    






 <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Caption = "Using ImageField">
    <Columns>
    <asp:BoundField DataField = "ID" HeaderText = "ID" />
    <asp:BoundField DataField = "Name" HeaderText = "Image Name" />
    <asp:ImageField DataImageUrlField = "ID" DataImageUrlFormatString = "Essai.aspx?ImageID={0}" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>
    </Columns>

</asp:GridView>
        

<!--<asp:FileUpload ID="FileUpload1" runat="server" />

<asp:Button ID="pnlUploadImage" runat="server" Text="Upload" OnClick="btnUpload_Click" />

<br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Article.Code_article, Rayon.Nom_rayon, Article.Description_article, Article.Qte_stock, Article.Qte_alerte, Article_Fournit.Id_fournisseur, Article_Fournit.Prix_achat_article, Article_Fournit.Prix_vente_article, Rayon.Date_enregistrement, Image.ID_img, Image.Nom_img, Image.Extn_img, Image.Contenu_img FROM Rayon INNER JOIN Article ON Rayon.Id_rayon = Article.Id_rayon INNER JOIN Image ON Article.ID_img = Image.ID_img INNER JOIN Article_Fournit ON Article.Code_article = Article_Fournit.Code_article WHERE (Article.Code_article = @code_art)">
            <SelectParameters>
                <asp:Parameter DefaultValue="cd" Name="code_art" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblMessage" runat="server" Text=""
            Font-Names="Arial"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="btnUpload" runat="server">
                    <asp:FileUpload ID="fuldImage" runat="server"></asp:FileUpload>


                    <asp:LinkButton ID="lnkbUpload" runat="server" OnClick="btnUpload_Click">Add</asp:LinkButton>
                </asp:Panel>



            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkbUpload" />
            </Triggers>
        </asp:UpdatePanel>-->

        <!--<div>
            <div class="messagealert" id="alert_container">
            </div>

            <!-- <div style="margin-top: 100px; text-align:center;">
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Rayon.Nom_rayon, Article.Description_article, Article.Qte_stock, Article.Qte_alerte, Rayon.Id_categorie FROM Article INNER JOIN Rayon ON Article.Id_rayon = Rayon.Id_rayon WHERE (Rayon.Nom_rayon = @nom) AND (Article.Description = @description)">
                     <SelectParameters>
                         <asp:Parameter Name="nom" />
                         <asp:Parameter Name="description" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Rayon.Nom_rayon, Rayon.Id_categorie, Article.Code_article, Article.Description_article, Article.Qte_stock, Article.Qte_alerte, Article.Date_enregistrement, Article.Id_rayon, Article_Fournit.Id_fournisseur, Article_Fournit.Prix_achat_article, Article_Fournit.Prix_vente_article, Image.Contenu_img FROM Rayon INNER JOIN Article ON Rayon.Id_rayon = Article.Id_rayon INNER JOIN Image ON Article.ID_img = Image.ID_img INNER JOIN Article_Fournit ON Article.Code_article = Article_Fournit.Code_article where Rayon.Nom_rayon=@nom">
                     <SelectParameters>
                         <asp:Parameter DefaultValue="Generatrice" Name="nom" />
                     </SelectParameters>
                 </asp:SqlDataSource>
            <asp:Button ID="btnSuccess" runat="server" Text="Submit" CssClass="btn btn-success"
                OnClick="btnSuccess_Click" />
            <asp:Button ID="btnDanger" runat="server" Text="Danger" CssClass="btn btn-danger"
                OnClick="btnDanger_Click" />
            <asp:Button ID="btnWarning" runat="server" Text="Warning" CssClass="btn btn-warning"
                OnClick="btnWarning_Click" />
            <asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-info"
                OnClick="btnInfo_Click" />
            </div>
        </div>-->
     <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Id_vente AS Numero, Montant, Date_vente AS [Date Vente] FROM Vente"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ValerioCanezDBConnectionString %>" SelectCommand="SELECT Id_vente AS Numero, Montant, Date_vente AS [Date Vente] FROM Vente WHERE (Active = @active)">
         <SelectParameters>
             <asp:Parameter Name="active" />
         </SelectParameters>
     </asp:SqlDataSource>
    </form>
</body>
</html>