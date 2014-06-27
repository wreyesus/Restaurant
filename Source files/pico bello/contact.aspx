<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true"
    CodeBehind="contact.aspx.cs" Inherits="pico_bello.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="contact ConEen">
        <div class='row row-offset-fix'>
            <div class="col-md-3 col-md-offset-2 text-align-center ConTwee">
            <h3>Contact-Info</h3>
                <address>
                    <strong>Pico Bello</strong><br/>
                    Spoorstraat 38<br/>
                    Alkmaar 1815 BK<br/>
                    <abbr title="Telefoon">
                        T:</abbr>
                    (072) 413-7890<br/>
                    <a href="mailto:pico@bello.nl">pico@bello.nl</a>
                </address>
            </div>
            <div class="col-md-5 text-align-center ConDrie">
            <h3>Locatie</h3>
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d2421.299756758497!2d4.743029300000001!3d52.63649720000001!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47cf57b093fd34f1%3A0xb9d608804da66534!2sSpoorstraat+38!5e0!3m2!1snl!2snl!4v1401182138545"
                    width="400" height="300" frameborder="0" style="border: 0"></iframe>
                <p class="contactinfo">
                    Pico Bello is gevestigd op de Spoorstraat 38 te Alkmaar, vlak bij het treinstation
                    van Alkmaar.<br />
                    U kunt gratis bij ons restaurant parkeren op de aangewezen parkeerplaatsen
                    achter ons restaurant.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
