<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="reserveren.aspx.cs" Inherits="pico_bello.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href='/bootstrap/datepicker/datetimepicker.css' rel="stylesheet"/>
    <script src='/bootstrap/moment.js'  type="text/javascript"></script>
    <script src='/bootstrap/datepicker/datetimepicker.min.js'  type="text/javascript"></script>
    <script type="text/javascript" src="/bootstrap/js/reserveermanager.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="reserveer ReserEen">
        <div class="row">
          <% pico_bello.classes.loginmanager lg = new pico_bello.classes.loginmanager();%>
          <% if (lg.checklogin() == false) { %> 
                <div class="col-lg-12 text-align-center ReserTwee">
                    <h2>Je bent niet ingelogd, Wilt u eenmalig reserveren of een account maken ?</h2>
                </div>
                <div class="col-lg-5 col-md-offset-1 padding-left-none">
                    <iframe src='registreren.aspx' class="iframeregister">
                    </iframe>
                </div>
                <div class="col-lg-5 text-align-center ReserDrie">
                    <h2>Inloggen</h2>
                    <form action='/reserveren.aspx' method='post'>
                        <table class='logintable'>
                            <tr>
                                <td>
                                    Gebruikersnaam
                                </td>
                                <td>
                                    <input class='form-control' id='usernamefield' type="text" name='username'>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Wachtwoord
                                </td>
                                <td>
                                    <input class='form-control' id='passwordfield' type='password' name='password'>
                                </td>
                            </tr>
                        </table>
                        <input class='btn btn-default btn-lg' type='submit' value="login">
                    </form>
                </div>
            </div>
          <div class="row">
          <% } %>
          <div class="col-lg-10 col-md-offset-1 ReserVier">
              <div class="row">
                <div class="col-md-6 text-align-center">
                    <% if (lg.checklogin() == false) { %>
                    <h2>Eenmalig reserveren</h2>
                    <% } else { %>
                    <h2>Reserveren op account</h2>
                    <% } %>
                    <form action='/reserveren.aspx' method='post'>
                        <table class='logintable'>
                            <tr>
                                <td>
                                    Aantal gasten
                                </td>
                                <td>
                                    <input class='form-control' id='Text1' type="text" name='gasten'>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Datum & Tijd
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class='input-group date' id='datetime'>
                                            <input type='text' class="form-control" name='datum'/>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                            </div>
                                        </div>
                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetime').datetimepicker();
                                        });
                                    </script>
                                </td>
                            </tr>
                            <% if (lg.checklogin() == false) { %>
                            <tr>
                                <td>
                                    Email
                                </td>
                                <td>
                                    <input class='form-control' id='Text2' type="text" name='email'>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Naam
                                </td>
                                <td>
                                    <input class='form-control' id='Text3' type="text" name='naam'>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Adres
                                </td>
                                <td>
                                    <input class='form-control' id='Text4' type="text" name='adres'>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Telefoonnummer
                                </td>
                                <td>
                                    <input class='form-control' id='Text5' type="text" name='telefoonnummer'>
                                </td>
                            </tr>
                            <% } %>
                            <tr>
                                <td>
                                    Van tevoren bestellen
                                </td>
                                <td>
                                    <span style="heigth: 50px;"><input class='form-control' type="checkbox" id="bestellen" name='bestellen' style="width: 34px !important; margin: 0 !important; padding: 0 !important; float:none !important; display: inline;"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Voorwaarden accepteren
                                </td>
                                <td>
                                    <span style="heigth: 50px;"><input class='form-control' type="checkbox" name='voorwaarden' style="width: 34px !important; margin: 0 !important; padding: 0 !important; float:none !important; display: inline;"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input class='form-control' type="submit" value="reserveren" />
                                </td>
                                <td>
                                    <asp:Label ID="reserveererror" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            <div class="col-md-6" id="besteldiv"">
                <h2>Van tevoren bestellen</h2>
                    <table class='logintable'> 
                    <%@ Import namespace="System.Data" %>
                    <%@ Import namespace="System.Web.UI" %>
                    <%
                        pico_bello.classes.databasemanager dm = new pico_bello.classes.databasemanager();
                        DataTable result = dm.getdatatablebyquery("select * from [menu-product] WHERE type='hoofdgerechten'");
                        int numberrows = 0;
                        
                        foreach (DataRow row in result.Rows)
                        {
                            numberrows = Convert.ToInt32(row["id"]);
                            %>
                                <tr><td><input class='form-control' type="text" name="<%=row["id"]%>" /></td><td><div id="<%=row["id"]%>"><%=row["naam"]%> - <%=row["prijs"]%></div></td></tr>
                            <%
                        }
                    %>
                    <input type='hidden' name='numberrows' value='<%=numberrows%>'/>
                </table>
              </div>
            </div>
        </div>
        <div class="col-lg-10 col-md-offset-1 ReserVier">
            <p>1.1 De klant word geacht aanwezig te zijn op tijd van reservatie, tenzij er 24 uur van te voren is afgebeld.</p>
            <p>Anders zal er een bedrag van 65 euro in rekening worden gebracht.</p>
            <p>1.2 In geval van no-show zal de gast in alle gevallen verplicht zijn 100% van de reserveringswaarde te betalen.</p>
        </div>
    </div>
</asp:Content>
