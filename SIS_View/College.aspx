<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="College.aspx.cs" Inherits="SIS_View.College" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Gv_college" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="collegeCode" Font-Size="XX-Small" OnRowCancelingEdit="Gv_college_RowCancelingEdit" OnRowDeleting="Gv_college_RowDeleting" OnRowEditing="Gv_college_RowEditing" OnRowUpdating="Gv_college_RowUpdating" OnRowCommand="Gv_college_RowCommand" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" OnRowDataBound="Gv_college_RowDataBound" OnSelectedIndexChanged="Gv_college_SelectedIndexChanged" BorderWidth="1px" BorderColor="#CCCCCC">
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
            <asp:TemplateField HeaderText="universityCode"> 
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlUniversityCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="universityName" DataValueField="universityCode" Font-Size="XX-Small">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueUniversity" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:SISConnectionString.ProviderName %>"></asp:SqlDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insUniversityCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="universityName" DataValueField="universityCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueUniversity" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                 
                <ItemTemplate>
                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("universityCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="collegeCode">
                <EditItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("collegeCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("collegeCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="collegeName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCollegeName" runat="server" Font-Size="XX-Small" Text='<%# Eval("collegeName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insCollegeName" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("collegeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedBy">
                <EditItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("recordedBy") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("recordedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedDate">
                <EditItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("recordedDate") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("recordedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="recordedTime">
                <EditItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("recordedTime") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("recordedTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedBy">
                <EditItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("lastModifiedBy") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("lastModifiedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedDate">
                <EditItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("lastModifiedDate") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("lastModifiedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="lastModifiedTime">
                <EditItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("lastModifiedTime") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("lastModifiedTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="currentStatus">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCurrentStatus" runat="server" Font-Size="XX-Small">
                        <asp:ListItem></asp:ListItem>
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
