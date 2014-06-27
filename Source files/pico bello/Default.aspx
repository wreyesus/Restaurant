<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pico_bello.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="slider-wrapper theme-default">
                <div id="slider" class="nivoSlider">
                    <img src="bootstrap/images/waffle.jpg" alt="" title="Spastisch Fantastisch"/>
                    <img src="bootstrap/images/taart.jpg" alt="" />
                    <img src="bootstrap/images/chicken.jpg" alt="" />
                </div>
            </div>
            <script type="text/javascript" src="/bootstrap/nivo/jquery.nivo.slider.js"></script>
            <link href="/bootstrap/nivo/nivo-slider.css" rel="stylesheet" type="text/css" />
            <script type="text/javascript">
                $(window).load(function () {
                    $('#slider').nivoSlider({ effect: 'sliceDown', slices: 10, animSpeed: 500, pauseTime: 3000, startSlide: 0, directionNav: true, directionNavHide: true, controlNav: true, controlNavThumbs: false, controlNavThumbsFromRel: false, controlNavThumbsSearch: '/bootstrap/nivo/webresource.png', controlNavThumbsReplace: '/bootstrap/nivo/webresource.png', keyboardNav: true, pauseOnHover: true, manualAdvance: false, captionOpacity: 0.8, beforeChange: function () { }, afterChange: function () { }, slideshowEnd: function () { } });
                 });
            </script>
        </div>
    </div>
    <div class="row text-align-center defaultpage">
        <div class="col-md-4 text-align-center">
            <div class="row contentblok1" >
                <div class="col-md-12">
                    <h2>Voor jong en oud.</h2>
                    <p>
                        Pico Bello is een restaurant voor jong en oud, Met menus die zowel betrekking hebben op kinderen. Als volwassen Kan je hier zeker goed terecht voor een fantastische avond.
                    </p>
                </div>
            </div>        
        </div>
        <div class="col-md-4 text-align-center">
            <div class="row contentblok2"> 
                <div class="col-md-12">
                    <h2>Geprogrameerd door echte bazen.</h2>
                    <p>
                        In tegenstelling tot website's van veel andere restaurants, Is Pico Bello van de grond af ontworpen door echte bazen. Deze mensen zijn niet alleen uiterst bekwaam maar ook zeer aantrekkelijk.
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4 text-align-center">
            <div class="row contentblok3">
                <div class="col-md-12">
                    <h2>Uitstekende Feature rijke website.</h2>
                    <p>
                        De website van Pico bello bevat veel uistekende features. zoals onder andere:
                    </p>
                    <ul style="text-align:left;">
                        <li>Aantrekkelijk homepage met jquery slider</li>
                        <li>Intelligent reserveer systeem</li>
                        <li>Overzichtelijk reservatie overzicht</li>
                        <li>Duidelijk bewerk pagina's voor menu's klanten en gebruikers</li>
                        <li>Tijdsinschattingen voor reserveringen</li>
                    </ul>
                    <p>En nog veel meer!</p>
                </div>
            </div>
        </div>
    </div>
    <div class='row text-align-center contentblok4'>
        <div class='col-md-12'>
            <h2>Developed by 2 passioned maniacs, whom love code.</h2>
            <p>Corne Lukken & Jordy Jansen</p>
        </div>
    </div>
</asp:Content>
