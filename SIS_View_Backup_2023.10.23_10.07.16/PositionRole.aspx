<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="PositionRole.aspx.cs" Inherits="SIS_View.PositionRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Gv_positionRole" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="positionRoleCode" Font-Size="XX-Small" OnRowCancelingEdit="Gv_positionRole_RowCancelingEdit" OnRowDeleting="Gv_positionRole_RowDeleting"  OnRowCommand="Gv_positionRole_RowCommand" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" OnRowDataBound="Gv_positionRole_RowDataBound" OnSelectedIndexChanged="Gv_positionRole_SelectedIndexChanged" BorderWidth="1px" BorderColor="#CCCCCC">
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
            <asp:TemplateField HeaderText="positionRoleCode" SortExpression="positionRoleCode">
                <EditItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("positionRoleCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("positionRoleCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="positionCode" SortExpression="positionCode">
                <FooterTemplate>
                    <asp:DropDownList ID="insPositionCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="positionName" DataValueField="positionCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniquePosition" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("positionCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="roleCode" SortExpression="roleCode">
                <FooterTemplate>
                    <asp:DropDownList ID="insRoleCode" runat="server" DataSourceID="SqlDataSource2" DataTextField="roleName" DataValueField="roleCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueRoles" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("roleCode") %>'></asp:Label>
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
                <FooterTemplate>
                    <asp:LinkButton ID="LinkBtnAdd" runat="server" CommandName="Add" Font-Underline="False">Add New</asp:LinkButton>
                    <asp:LinkButton ID="LinkBtnSave" runat="server" CommandName="Save" Font-Underline="False" Visible="False">Save</asp:LinkButton>
                    &nbsp;<asp:Label ID="lblsep" runat="server" Text="|" Visible="False"></asp:Label>
                    &nbsp;<asp:LinkButton ID="LinkBtnCancel" runat="server" CommandName="Cancel" Font-Underline="False" Visible="False">Cancel</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
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
	
    <br /><br />
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
</asp:Content>
