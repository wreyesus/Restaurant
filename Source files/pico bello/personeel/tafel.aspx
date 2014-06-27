<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true" CodeBehind="tafel.aspx.cs" Inherits="pico_bello.personeel.tafel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/bootstrap/jqueryui/jqueryui.js"></script>
<script type="text/javascript" src="/bootstrap/js/tafelmanager.js"></script>
<%--<link type="text/css" href='/bootstrap/jqueryui/jqueryui.css' rel="stylesheet"/>--%>
<link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class='row'>
        <div class='col-md-12'>
            <div class="knopjetafel">
                <button type="button" class="btn btn-primary btnTafel">Tafels opslaan</button>
            </div>
            <div class='ui-interface-identifier'>
                
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            if ($(window).width() < $(window).height() - 92) {
                marginleft = ($(window).height() - $(window).width()) / 2;
                $(".ui-interface-identifier").css("width", $(window).width());
                $(".ui-interface-identifier").css("height", $(window).width());
                $(".ui-interface-identifier").css("margin-left", marginleft);
                scale = $(window).width() / 1000;
            }
            else {
                marginleft = ($(window).width() - $(window).height()) / 2;
                $(".ui-interface-identifier").css("width", $(window).height() - 92);
                $(".ui-interface-identifier").css("height", $(window).height() - 92);
                $(".ui-interface-identifier").css("margin-left", marginleft);
                scale = ($(window).height() - 92) / 1000;
            }
                console.log(scale);
                <%@ Import namespace="System.Data" %>
                <%@ Import namespace="System.Web.UI" %>
                <%
                    pico_bello.classes.databasemanager dm = new pico_bello.classes.databasemanager();
                    DataTable result = dm.getdatatablebyquery("select * from [tafel]");

                    foreach (DataRow row in result.Rows)
                    {
                        %>
                            $("<div class='tafel'><p class='tafeltext1'>Tafel:<%=row["id"]%></p><p class='tafeltext2'>Personen:<%=row["plaatsen"]%></p><p class='tafeltext3'>Status:</p><div class='close'><img src='/bootstrap/images/close-button.gif'</div></div>").appendTo('.ui-interface-identifier');
                            $(".tafel").last().css('top', ((<%=row["starty"]%> * scale)) + 36);
                            $(".tafel").last().css('left', ((<%=row["startx"]%> * scale) + (marginleft + 12))); // 12 * scale weird fucking offset hack but works so / care
                            $(".tafel").last().css('height', ((<%=row["sizey"]%> * scale + 1)));
                            $(".tafel").last().css('width', ((<%=row["sizex"]%> * scale + 1)));
                            $(".tafel").last().css('position', 'absolute');
                            $('.tafel').draggable({ containment: "parent" });
                            $('.tafel').resizable();
                        <%
                    }
               %>
        });
</script>
</asp:Content>
