<%@ Page Title="Register Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consumer._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <fieldset>
        <legend>Cliente</legend>
        <br />
        <asp:Label Text="Nome:" ID="lblNome" ClientIDMode="Static" AssociatedControlID="txtNome" runat="server" />
        <asp:TextBox ID="txtNome" ClientIDMode="Static" runat="server" TabIndex="1" />
        <br />
        <br />
        <asp:Label Text="E-mail:" ID="lblEmail" ClientIDMode="Static" AssociatedControlID="txtEmail" runat="server" />
        <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" TabIndex="2" />
        <br />
        <br />
        <asp:Label Text="Data de Nascimento:" ID="lblDtNascimento" ClientIDMode="Static" AssociatedControlID="txtDtNascimento" runat="server" />
        <asp:TextBox ID="txtDtNascimento" ClientIDMode="Static" runat="server" TabIndex="3" />
        <br />
        <br />
        <asp:Label Text="Telefone Celular:" ID="lblTelCelular" ClientIDMode="Static" AssociatedControlID="txtTelCelular" runat="server" />
        <asp:TextBox ID="txtTelCelular" ClientIDMode="Static" runat="server" TabIndex="4" />
        <br />
        <br />
        <asp:Label Text="Telefone Residencial:" ID="lblTelRes" ClientIDMode="Static" AssociatedControlID="txtTelRes" runat="server" />
        <asp:TextBox ID="txtTelRes" ClientIDMode="Static" runat="server" TabIndex="5" />
        <br />
        <hr />
        <asp:Button Text="Salvar" ClientIDMode="Static" ID="btnSalvar" OnClientClick="callService(); return false;" runat="server" />
    </fieldset>
</asp:Content>
