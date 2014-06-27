<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="pico_bello.personeel.menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

   <asp:GridView ID="gridMenu" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
        GridLines="None" CssClass="GridKlant" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnRowCancelingEdit="gridMenu_RowCancelingEdit" 
        OnRowEditing="gridMenu_RowEditing" OnRowDeleting="gridMenu_RowDeleting" OnRowUpdating="gridMenu_RowUpdating" 
        AllowSorting="false" OnRowCommand="gridMenu_RowCommand" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="id" SortExpression="id">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
                  <FooterTemplate>
                 <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" Text="Voeg toe"></asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Naam" SortExpression="naam">
                <ItemTemplate>
                    <asp:Label ID="lblNaam" runat="server" Text='<%# Bind("naam") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditNaam" runat="server" Text='<%# Bind("naam") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddNaam" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="type">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditType" runat="server" Text='<%# Bind("type") %>'></asp:TextBox>
                </EditItemTemplate>
                  <FooterTemplate>
                    <asp:TextBox ID="txtAddType" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Omschrijving" SortExpression="omschrijving">
                <ItemTemplate>
                    <asp:Label ID="lblOmschrijving" runat="server" Text='<%# Bind("omschrijving") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditOmschrijving" runat="server" Text='<%# Bind("omschrijving") %>'></asp:TextBox>
                </EditItemTemplate>
                 <FooterTemplate>
                    <asp:TextBox ID="txtAddOmschrijving" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prijs" SortExpression="prijs">
                <ItemTemplate>
                    <asp:Label ID="lblPrijs" runat="server" Text='<%# Bind("prijs") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditPrijs" runat="server" Text='<%# Bind("prijs") %>'></asp:TextBox>
                </EditItemTemplate>
                  <FooterTemplate>
                    <asp:TextBox ID="txtAddPrijs" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Beschikbaar" SortExpression="beschikbaar">
                <ItemTemplate>
                    <asp:Label ID="lblBeschikbaar" runat="server" Text='<%# Bind("beschikbaar") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditBeschikbaar" runat="server" Text='<%# Bind("beschikbaar") %>'></asp:TextBox>
                </EditItemTemplate>
                  <FooterTemplate>
                    <asp:TextBox ID="txtAddBeschikbaar" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" EditText="Wijzig" CancelText="Annuleer" UpdateText="Bijwerken" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Verwijder"/>
        </Columns>

        </asp:GridView>
</asp:Content>
