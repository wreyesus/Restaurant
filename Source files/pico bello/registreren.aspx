<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="pico_bello.registreren" %>
<html>
<head>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Swanky and Moo Moo">
    <script type="text/javascript" src='/bootstrap/jquery.js'></script>
    <script type="text/javascript" src='/bootstrap/js/bootstrap.js'></script>
    <link type="text/css" href='/bootstrap/css/bootstrap.css' rel="stylesheet"/>
    <link type="text/css" href='/bootstrap/style.css' rel="stylesheet"/>
</head>
<body>
<div class="row">
  <% pico_bello.classes.loginmanager lg = new pico_bello.classes.loginmanager();%>
  <% if (lg.checklogin() == false) { %> 
        <div class="col-lg-12 text-align-center">
            <h2>Registreren</h2>
            <form action='/registreren.aspx' method='post'>
                 <table class='logintable'>
                        <tr>
                            <td>
                                E-mail
                            </td>
                            <td>
                                <input class='form-control' type='text' name='email' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Wachtwoord
                            </td>
                            <td>
                                <input class='form-control' type='password' name='wachtwoord' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Naam
                            </td>
                            <td>
                                <input class='form-control' type='text' name='naam' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Adres
                            </td>
                            <td>
                                <input class='form-control' type='text' name='adres' />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                Telefoonnummer
                            </td>
                            <td>
                                <input class='form-control' type='text' name='telefoonnummer' />
                            </td>
                        </tr>
                    </table>
                    <input class='btn btn-default btn-lg' type='submit' Text="submit" value="registreren">
                    <asp:Label ID="error" runat="server" Text="Label" Visible="False"></asp:Label>
            </form>
        </div>
       <% } %>
    </div>
</body>
</html>