<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="indelen.aspx.cs" Inherits="pico_bello.personeel.indelen" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <h2>Tafels toewijzen</h2>
                    <% if(!string.IsNullOrEmpty(Request.QueryString["id"])) { %>
                        <%@ Import namespace="System.Data" %>
                        <%@ Import namespace="System.Web.UI" %>
                        <%@ Import namespace="System.Globalization" %>
                        <%@ Import namespace="System.Data.SqlClient" %>
                        <%
                        pico_bello.classes.databasemanager dm = new pico_bello.classes.databasemanager();
                        DataTable result = dm.getdatatablebyquery("select * from [reservering] WHERE id='" + Request.QueryString["id"] + "'");

                        foreach (DataRow row in result.Rows) { %>
                        <!--Your event id= <%=Request.QueryString["id"]%>-->
                        <form action='/personeel/indelen.aspx' method='post'>
                            <input type="hidden" name='id' value='<%=Request.QueryString["id"]%>' />
                                <table class='logintable'>
                                    <tr>
                                        <td>
                                            Personen
                                        </td>
                                        <td>
                                            <input class='form-control' type='text' name='personen' disabled value='<%=row["personen"]%>'/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tafelnummer
                                        </td>
                                        <td>
                                        <select class='form-control' name="tafel">
                                    <%
                                    //DateTime datetms = @row["datumstart"];
                                    // DateTime.TryParse(@row["datumstart"].ToString(), out datetms);
                                    //string datestartsemifinal = datetms.ToString("yyyy-MM-dd HH:mm:ss tt");

                                    //DateTime datetend = @row["datumeind"];
                                    //DateTime.TryParse((DateTime)@row["datumeind"], out datetend);
                                    //string dateendsemifinal = datetend.ToString("yyyy-MM-dd HH:mm:ss tt");
                            
                                    DataTable tafellijst = dm.getdatatablebyquery("select * from [tafel]");
                                    foreach (DataRow tafelrow in tafellijst.Rows) { %> 
                                        <option value="<%=tafelrow["id"]%>">nummer - <%=tafelrow["id"]%> | plaatsen - <%=tafelrow["plaatsen"]%></option>                                    
                                    <% } %>
                                        </select>    
                                        </td>
                                    </tr>
                                </table>
                            <input class='btn btn-default btn-lg' type='submit' Text="submit" value="toevoegen">
                            <%
                                    DataTable ordersbetween = dm.getdatatablebyquery("select * from [reservering] WHERE datumstart BETWEEN " + @row["datumstart"] + " AND " + @row["datumeind"] + "");
                                    int totalorders = 0;
                            
                                        totalorders = ordersbetween.Rows.Count;

                                    if (totalorders > 0)
                                    {
                                        %> Er zijn andere reserveringen binnen dit tijdstip <%
                                    }
                            %>
                        </form>
                        <asp:Label ID="reserveererror" runat="server" Text=""></asp:Label>
                    <% } %>
                <% } %>
            </div>
        </div>
    </form>
</body>
</html>
