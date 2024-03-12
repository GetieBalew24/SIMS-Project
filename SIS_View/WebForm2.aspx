<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="SIS_View.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="ID" SortExpression="ID"></asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name"></asp:TemplateField>
            <asp:TemplateField HeaderText="Dept" SortExpression="Dept"></asp:TemplateField>
            <asp:TemplateField HeaderText="Age" SortExpression="Age"></asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
