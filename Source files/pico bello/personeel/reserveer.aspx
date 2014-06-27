<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true" CodeBehind="reserveer.aspx.cs" Inherits="pico_bello.personeel.reserveer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='/bootstrap/moment.js'  type="text/javascript"></script>
    <link type="text/css" href='/bootstrap/fullcalender/fullcalendar.css' rel="stylesheet"/>
    <link type="text/css" href='/bootstrap/fullcalender/fullcalendar.print.css' rel="stylesheet"/>
    <script src='/bootstrap/fullcalender/fullcalendar.js'  type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $("html").css("overflow-y","visible");
            $("#calendar").css("overflow-y","hidden");

            $('#calendar').fullCalendar({
             eventClick: function(event) {
                    //alert('View: ' + event.id);
                    $("<div class='float'><iframe src='wijzigres.aspx?id=" + event.id + "' height='500px'  width='500px'/></div>").appendTo('body');
                    $("<div class='close'><img src='/bootstrap/images/close-button.gif'></div>").appendTo('body');

                    $(".close").css('position', 'absolute');
                    $(".close").css('padding-top', $( window ).height() / 2 - 250 + 5);
                    $(".close").css('padding-left', $( window ).width() / 2 - 250 + 5);

                    $(".float").css('padding-top', $( window ).height() / 2 - 250);
                    $(".float").css('padding-left', $( window ).width() / 2 - 250);

                    event.title = "Gewijzigd!";
                    $('#calendar').fullCalendar('updateEvent', event);

                    $(this).css('border-color', 'red');

                    $(".close").click(function (e) {
                        $('.float').remove();
                        $(this).remove();
                    });
                },
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                viewRender: function(view){
                    var h = NaN;
                    if(view.name != "month") h = 9999;
                    $("#calendar").fullCalendar("option", "contentHeight", h);
                },
                editable: false,
                events: [
                <%@ Import namespace="System.Data" %>
                <%@ Import namespace="System.Web.UI" %>
                <%
                    pico_bello.classes.databasemanager dm = new pico_bello.classes.databasemanager();
                    DataTable result = dm.getdatatablebyquery("select * from [reservering]");

                    foreach (DataRow row in result.Rows)
                    {
                        DateTime datetms = new DateTime();
                        DateTime.TryParse(row["datumstart"].ToString(), out datetms);
                        string datestartsemifinal = datetms.ToString("yyyy-MM-ddTHH:mm:ss");

                        DateTime datetme = new DateTime();
                        DateTime.TryParse(row["datumeind"].ToString(), out datetme);
                        string dateendsemifinal = datetme.ToString("yyyy-MM-ddTHH:mm:ss");
                        %>
                        {
                            id: '<%=row["id"]%>',
                            start: '<%=datestartsemifinal%>',
                            end: '<%=dateendsemifinal%>',
                        },
                        <%
                    }
               %>
			]
            });
        });
    </script>
    <div id='calendar'></div>
</asp:Content>

