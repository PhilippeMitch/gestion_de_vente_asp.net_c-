<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Erreur.aspx.cs" MasterPageFile="~/Login.Master" Inherits="ValerioWeb.UI.Erreur" %>


<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<img src="Images/logo-00.png" width="120" height="66" />


    <div class="container">
        <div class="row">
            <div class="span12">
                <div class="hero-unit center">
                    <h1> Page non disponible <small>Erreur 403</small></h1>
                    <br />
                    <p> Vous ne pouvez pas acceder a cette page <b> Retour</b> bouton retour pour accéder à la page que vous avez déjà accede</p>
                    <p><b>Ou vous pouvez simplement appuyer sur ce petit bouton soignée:</b></p>
                    <a href="Default.aspx" class="btn btn-large btn-info"><i class="icon-home icon-white"></i>Retour a la page d'acceuil</a>
                </div>               
                <!-- By ConnerT HTML & CSS Enthusiast -->
            </div>
        </div>
    </div>

    <div id="footer_erreur">
        <p>&copy; <%: DateTime.Now.Year %>Valerio Canez Web Application | Fourni par 
            <br />
            <strong>Les Meilleurs</strong></p>
    </div>

</asp:Content>