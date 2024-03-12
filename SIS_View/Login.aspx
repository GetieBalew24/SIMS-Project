<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIS_View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblvalid" runat="server" Text="Label"></asp:Label>
    <hr  />
    <p style="margin-left: 300px; margin-top: 50px">

            <img src="assets/img/question.png" height="15" />
            <asp:Label ID="lblusername" runat="server" Text="[username]"></asp:Label>
            <br />
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        <br />
        <br />
            <img src="assets/img/question.png" height="15" />
            <asp:Label ID="lblpassword" runat="server" Text="[password]"></asp:Label>
            <br />
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnLogin" runat="server" Text="[Login]" OnClick="BtnLogin_Click" />
    </p>
    <hr  width="98%"/>
</asp:Content>
