<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Login.Master" CodeBehind="Login.aspx.cs" Inherits="ValerioWeb.UI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<img src="Images/logo-00.png" width="120" height="66" />


    <div class="fieldset">

        <div id="tit_con">Connexion</div>
        <div id="form_con">
            <table>
                <tr>
                    <td><span class="input-group-addon"><i class="fa fa-user"></i></span></td>
                    <td>
                        <asp:TextBox ID="txtnom" placeholder="Nom Utilisateur" runat="server" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnom" ErrorMessage="Vous devez saisir le nom d'utilisateur" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>

                    </td></tr>
                <%--</tr>--%>
                <tr>
                    <td><span class="input-group-addon"><i class="fa fa-lock"></i></span></td>
                    <td>
                        <asp:TextBox ID="txtpass" TextMode="Password" placeholder="Mot de passe" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vous devez saisir votre mot de passe" ControlToValidate="txtpass" ForeColor="#CC0000" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text=" Se souvenir de moi" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblsms" runat="server" Text=""></asp:Label>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
                    </td>
                    <td>

                    </td>
                </tr>
            </table>

        </div>
        <div id="bou">
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnconnect" CssClass="btn btn-success" runat="server" Text="Connecter" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>

    </div>

    <div id="footer">
        <p>&copy; <%: DateTime.Now.Year %>Valerio Canez Web Application | Fourni par 
            <br />
            <strong>Les Meilleurs</strong></p>
    </div>

</asp:Content>
