<%@ Page Title="" Language="C#" MasterPageFile="~/personeel/personeel.Master" AutoEventWireup="true"
    CodeBehind="klant.aspx.cs" Inherits="pico_bello.personeel.klant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="gridKlanten" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
        GridLines="None" CssClass="GridKlant" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnRowCancelingEdit="gridKlanten_RowCancelingEdit" 
        OnRowEditing="gridKlanten_RowEditing"
        OnRowDeleting="gridKlanten_RowDeleting"
        OnRowUpdating="gridKlanten_RowUpdating" ShowFooter="False">
        <Columns>
           <asp:TemplateField HeaderText="id">
                <ItemTemplate>
                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>' ></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Naam" SortExpression="naam">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditNaam" runat="server" Text='<%# Bind("naam") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNaam" runat="server" Text='<%# Bind("naam") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddNaam" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adres" SortExpression="adres">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditAdres" runat="server" Text='<%# Bind("adres") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdres" runat="server" Text='<%# Bind("adres") %>'></asp:Label>
                </ItemTemplate>
                 <FooterTemplate>
                    <asp:TextBox ID="txtAddAdres" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefoonnummer" SortExpression="telefoonnummer">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditTelefoon" runat="server" Text='<%# Bind("telefoonnummer") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTelefoon" runat="server" Text='<%# Bind("telefoonnummer") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddTelefoon" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-mail" SortExpression="email">
            
               <%--to disable email changes --%>
               <EditItemTemplate>   
                    <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                </EditItemTemplate> 

                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddEmail" runat="server"></asp:TextBox>
                          
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" EditText="Wijzig" CancelText="Annuleer" UpdateText="Bijwerken" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Verwijder"/>
        </Columns>
    </asp:GridView>
</asp:Content>
