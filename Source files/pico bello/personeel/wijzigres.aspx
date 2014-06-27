<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wijzigres.aspx.cs" Inherits="pico_bello.personeel.wijzigres" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Swanky and Moo Moo">
    <script type="text/javascript" src='/bootstrap/jquery.js'></script>
    <script type="text/javascript" src='/bootstrap/js/bootstrap.js'></script>
    <link type="text/css" href='/bootstrap/css/bootstrap.css' rel="stylesheet"/>
    <link type="text/css" href='/bootstrap/datepicker/datetimepicker.css' rel="stylesheet"/>
    <script src='/bootstrap/moment.js'  type="text/javascript"></script>
    <script src='/bootstrap/datepicker/datetimepicker.min.js'  type="text/javascript"></script>
    <script type="text/javascript" src="/bootstrap/js/reserveermanager.js"></script>
    <link type="text/css" href='/bootstrap/style.css' rel="stylesheet"/>
</head>
<body style='background:white;'>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-12 text-align-center">
                    <h2> Wijzigen reservering</h2>
                    <% if(!string.IsNullOrEmpty(Request.QueryString["id"])) { %>
                        <%@ Import namespace="System.Data" %>
                        <%@ Import namespace="System.Web.UI" %>
                        <%
                        pico_bello.classes.databasemanager dm = new pico_bello.classes.databasemanager();
                        DataTable result = dm.getdatatablebyquery("select * from [reservering] WHERE id='" + Request.QueryString["id"] +"'");

                        foreach (DataRow row in result.Rows) { %>
                        <!--Your event id= <%=Request.QueryString["id"]%>-->
                        <form action='/personeel/wijzigres.aspx' method='post'>
                            <input type="hidden" name='id' value='<%=Request.QueryString["id"]%>' />
                                <table class='logintable'>
                                    <tr>
                                        <td>
                                            Datum start
                                        </td>
                                        <td>
                                            <%                             
                                                    DateTime datest = Convert.ToDateTime(row["datumstart"].ToString());
                                                    string datestart = datest.ToString("MM/dd/yyyy HH:mm tt");
                                            %>
                                            <div class="form-group">
                                                <div class='input-group date' id='datumstart'>
                                                    <input type='text' class="form-control" name='datumstart' value='<%=datestart%>'/>
                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                                    </div>
                                                </div>
                                            <script type="text/javascript">
                                                $(function () {
                                                    $('#datumstart').datetimepicker();
                                                });
                                            </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Datum eind
                                        </td>
                                        <td>
                                            <%                             
                                                    DateTime datend = Convert.ToDateTime(row["datumeind"].ToString());
                                                    string dateend = datend.ToString("MM/dd/yyyy HH:mm tt");
                                            %>
                                            <div class="form-group">
                                                <div class='input-group date' id='datumeind'>
                                                    <input type='text' class="form-control" name='datumeind' value='<%=dateend%>'/>
                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                                    </div>
                                                </div>
                                            <script type="text/javascript">
                                                $(function () {
                                                    $('#datumeind').datetimepicker();
                                                });
                                            </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Personen
                                        </td>
                                        <td>
                                            <input class='form-control' type='text' name='personen' value='<%=row["personen"]%>'/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Klant id
                                        </td>
                                        <td>
                                            <input class='form-control' type='text' name='klant' value='<%=row["klant"]%>'/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Rekening
                                        </td>
                                        <td>
                                            <input class='form-control' type='text' name='rekening' value='<%=row["rekening"]%>'/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Bediende
                                        </td>
                                        <td>
                                            <input class='form-control' type='text' name='bediende' value='<%=row["bediende"]%>'/>
                                        </td>
                                    </tr>
                                </table>
                            <input class='btn btn-default btn-lg' type='submit' Text="submit" value="wijzigen">
                        </form>
                        <asp:Label ID="reserveererror" runat="server" Text=""></asp:Label>
                            <%
                                DataTable tafels = dm.getdatatablebyquery("select * from [plaats] WHERE nummer='" + Request.QueryString["id"] +"'");
                                int tables = 0;
                                int personen = 0;
                                foreach (DataRow row2 in tafels.Rows)
                                {
                                    tables = tables + 1;
                                    if (tables > 0)
                                    {
                                        DataTable plaatsen = dm.getdatatablebyquery("select * from [tafels] WHERE tafel='" + row2["tafel"] + "'");
                                        foreach (DataRow row3 in plaatsen.Rows)
                                        {
                                            personen = personen + Convert.ToInt16(row3["plaatsen"].ToString());
                                        }
                                    } 
                                }
                            %>
                            <p>Er is voor <%=row["personen"]%> gasten gereserveerd en er zijn <%=tables%> tafels aan toegewezen voor <%=personen%></p>
                            <a href="/personeel/indelen.aspx?id=<%=Request.QueryString["id"]%>">Nu meer tafels toewijzen!</a>
                    <% } %>
                <% } %>
            </div>
        </div>
    </form>
</body>
</html>
