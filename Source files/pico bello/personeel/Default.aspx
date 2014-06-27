<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pico_bello.personeel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="container-fluid">
    <div class="row">
        <div class="col-md-12 text-align-center" id='loginform'>
            <% pico_bello.classes.loginmanager lg = new pico_bello.classes.loginmanager();%>
            <% if(lg.checkrole() < 3) { %> 
            <h2>Inloggen</h2>
                <form action="Default.aspx" method='post'>
                    <table class='logintable'>
                        <tr>
                            <td>
                                Gebruikersnaam
                            </td>
                            <td>
                                <input class='form-control' id='usernamefield' type="text" name='username'>
                            </td>
                            <td>
                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Wachtwoord
                            </td>
                            <td>
                                <input class='form-control' id='passwordfield' type='password' name='password'>
                            </td>
                            <td>
                            
                            </td>
                        </tr>
                    </table>
                    <input class='btn btn-default btn-lg' type='submit' Text="submit" value="login">
                </form>
            <% } %> 
        </div>
    </div>
</div>
</asp:Content>
