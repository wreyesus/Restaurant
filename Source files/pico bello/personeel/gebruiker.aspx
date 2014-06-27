<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true" CodeBehind="gebruiker.aspx.cs" Inherits="pico_bello.personeel.gebruiker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <asp:GridView ID="gridGebruiker" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
        GridLines="None" CssClass="GridKlant" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" ShowFooter="true" 
        AllowSorting="false" OnRowCancelingEdit="gridGebruiker_RowCancelingEdit" 
        OnRowEditing="gridGebruiker_RowEditing" OnRowDeleting="gridGebruiker_RowDeleting" 
        OnRowUpdating="gridGebruiker_RowUpdating" OnRowCommand="gridGebruiker_RowCommand">

        <Columns>
            <asp:TemplateField HeaderText="ID" SortExpression="id">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
                  <FooterTemplate>
                 <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" Text="Voeg toe"></asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Gebruikersnaam" SortExpression="naam">
                <ItemTemplate>
                    <asp:Label ID="lblNaam" runat="server" Text='<%# Bind("gebruikersnaam") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditNaam" runat="server" Text='<%# Bind("gebruikersnaam") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddNaam" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Wachtwoord" SortExpression="type">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='*****' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditWachtwoord" runat="server" Text='*****'></asp:TextBox>
                </EditItemTemplate>
                  <FooterTemplate>
                    <asp:TextBox ID="txtAddWachtwoord" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="KlantID" SortExpression="omschrijving">
                <ItemTemplate>
                    <asp:Label ID="lblKlantID" runat="server" Text='<%# Bind("klantid") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditKlantid" runat="server" Text='<%# Bind("klantid") %>'></asp:TextBox>
                </EditItemTemplate>
                 <FooterTemplate>
                    <asp:TextBox ID="txtAddKlantid" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rol" SortExpression="prijs">
                <ItemTemplate>
                    <asp:Label ID="lblrol" runat="server" Text='<%# Bind("rol") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditRol" runat="server" Text='<%# Bind("rol") %>'></asp:TextBox>
                </EditItemTemplate>
                  <FooterTemplate>
                    <asp:TextBox ID="txtAddRol" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" EditText="Wijzig" CancelText="Annuleer" UpdateText="Bijwerken" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Verwijder"/>
        </Columns>
        </asp:GridView>
        	<ul>
			<li>
				rol 1 niet geregistreerd</li>
			<li>
				rol 2&nbsp; klanten</li>
			<li>
				rol 3 - 9&nbsp; personeel</li>
		</ul>
</asp:Content>