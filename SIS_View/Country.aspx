﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="SIS_View.Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Gv_country" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="countryCode" Font-Size="XX-Small" OnRowCancelingEdit="Gv_country_RowCancelingEdit" OnRowDeleting="Gv_country_RowDeleting" OnRowCommand="Gv_country_RowCommand" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" OnRowDataBound="Gv_country_RowDataBound" OnSelectedIndexChanged="Gv_country_SelectedIndexChanged" BorderWidth="1px" BorderColor="#CCCCCC">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkCtrl" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="countryCode" SortExpression="countryCode">
                <EditItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("countryCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("countryCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="countryName" SortExpression="countryName">
                <FooterTemplate>
                    <asp:TextBox ID="insCountryName" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("countryName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="continent" SortExpression="continent">
                <FooterTemplate>
                    <asp:DropDownList ID="insContinent" runat="server" Font-Size="XX-Small" Visible="False">
                        <asp:ListItem>Africa</asp:ListItem>
                        <asp:ListItem>North America</asp:ListItem>
                        <asp:ListItem>South America</asp:ListItem>
                        <asp:ListItem>Asia</asp:ListItem>
                        <asp:ListItem>Europe</asp:ListItem>
                        <asp:ListItem>Australia</asp:ListItem>
                        <asp:ListItem>Antartica</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("continent") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="nationality" SortExpression="nationality">
                <FooterTemplate>
                    <asp:TextBox ID="insNationality" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("nationality") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedBy" SortExpression="recordedBy">
                <EditItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("recordedBy") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("recordedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedDate" SortExpression="recordedDate">
                <EditItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("recordedDate") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("recordedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedTime" SortExpression="recordedTime">
                <EditItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("recordedTime") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("recordedTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedBy" SortExpression="lastModifiedBy">
                <EditItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("lastModifiedBy") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("lastModifiedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedDate" SortExpression="lastModifieddate">
                <EditItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("lastModifiedDate") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("lastModifiedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedTime" SortExpression="lastModifiedTime">
                <EditItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("lastModifiedTime") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("lastModifiedTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="currentStatus" SortExpression="currentStatus">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCurrentStatus" runat="server" Font-Size="XX-Small">
                        <asp:ListItem Value="1">Currently Active</asp:ListItem>
                        <asp:ListItem Value="0">Currently Inactive</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("currentStatus") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkBtnUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                    &nbsp;|
                    <asp:LinkButton ID="LinkBtnCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="LinkBtnAdd" runat="server" CommandName="Add" Font-Underline="False">Add New</asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnSave" runat="server" CommandName="Save" Font-Underline="False" Visible="False">Save</asp:LinkButton>
                    &nbsp;<asp:Label ID="lblsep" runat="server" Text="|" Visible="False"></asp:Label>
                    &nbsp;<asp:LinkButton ID="LinkBtnCancel" runat="server" CommandName="Cancel" Font-Underline="False" Visible="False">Cancel</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkBtnEdit" runat="server" CommandName="Edit" Font-Underline="False">Edit</asp:LinkButton>
                    &nbsp;|
                    <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="Delete" OnClientClick="isDelete();" Font-Underline="False">Delete</asp:LinkButton>
                    &nbsp;|
                    <asp:LinkButton ID="LinkBtnSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField />
        </Columns>
         <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small" BorderColor="#CCCCCC" BorderWidth="1px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <PagerTemplate>
            1
        </PagerTemplate>
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <asp:Button ID="btnDisplay" runat="server" Text="Show selected Data" OnClick="BtmDisplay_Click" />
	
    <br /><br />
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
</asp:Content>