<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="SIS_View.UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Search" Font-Size="XX-Small"></asp:Label>&nbsp; <asp:TextBox ID="txtSearchCriteria" runat="server" TextMode="Search" Font-Size="XX-Small"></asp:TextBox>&nbsp;<asp:DropDownList ID="ddlSearch" runat="server" Font-Size="XX-Small">
        <asp:ListItem>username</asp:ListItem>
        <asp:ListItem>firstname</asp:ListItem>
        <asp:ListItem Value="alluser">all user</asp:ListItem>
    </asp:DropDownList>&nbsp; <asp:LinkButton ID="LinkBtnSearch" runat="server" Font-Size="XX-Small" OnClick="LinkBtnSearch_Click">Search</asp:LinkButton>
    <asp:GridView ID="Gv_userRole1" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="staffId" Font-Size="XX-Small" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" BorderWidth="1px" BorderColor="#CCCCCC" AllowPaging="True" OnSelectedIndexChanged="Gv_userRole1_SelectedIndexChanged" Width="655px" OnRowDataBound="Gv_userRole1_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkCtrl" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No." SortExpression="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="staffId" SortExpression="staffId">
                <ItemTemplate>
                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("staffId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="fullname" SortExpression="fullname">
                <ItemTemplate>
                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("fullname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedDate" SortExpression="recordedDate">
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("recordedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkBtnSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            <asp:Label ID="Label17" runat="server" Text="No Records"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small" BorderColor="#CCCCCC" BorderWidth="1px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="False"></asp:Label>

    <br />
<asp:DropDownList ID="ddlRoless" runat="server" Font-Size="XX-Small">
</asp:DropDownList>
&nbsp;
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>

    <br />
    <asp:GridView ID="Gv_userRole2" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="userRoleCode" Font-Size="XX-Small" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" BorderWidth="1px" BorderColor="#CCCCCC" Width="836px" style="margin-right: 0px" OnRowDeleting="Gv_userRole2_RowDeleting" OnRowCancelingEdit="Gv_userRole2_RowCancelingEdit" OnRowCommand="Gv_userRole2_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkCtrl0" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No." SortExpression="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="userRoleCode" SortExpression="userRoleCode">
                <ItemTemplate>
                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("userRoleCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="username" SortExpression="username">
                <ItemTemplate>
                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="roleCode" SortExpression="roleCode">
                <FooterTemplate>
                    <asp:DropDownList ID="insRoleCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="roleName" DataValueField="roleCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueRoles" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("roleCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="createdDate" SortExpression="createdDate">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("createdDate") %>'></asp:Label>
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
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            <asp:Label ID="Label17" runat="server" Text="No Records"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small" BorderColor="#CCCCCC" BorderWidth="1px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    
</asp:Content>
