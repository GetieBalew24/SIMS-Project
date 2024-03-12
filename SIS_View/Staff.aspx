<%@ Page Title="" Language="C#" MasterPageFile="~/SIS.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="SIS_View.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Gv_staff" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" DataKeyNames="staffId" Font-Size="XX-Small" OnRowCancelingEdit="Gv_staff_RowCancelingEdit" OnRowDeleting="Gv_staff_RowDeleting" OnRowEditing="Gv_staff_RowEditing" OnRowUpdating="Gv_staff_RowUpdating" OnRowCommand="Gv_staff_RowCommand" ShowFooter="True" EmptyDataText="No Records Display" ShowHeaderWhenEmpty="True" AllowCustomPaging="True" AllowSorting="True" OnRowDataBound="Gv_staff_RowDataBound" OnSelectedIndexChanged="Gv_staff_SelectedIndexChanged" BorderWidth="1px" BorderColor="#CCCCCC">
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
            <asp:TemplateField HeaderText="staffId" SortExpression="staffId">
                <EditItemTemplate>
                    <asp:Label ID="Label29" runat="server" Text='<%# Eval("staffId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("staffId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="salutationCode" SortExpression="salutationCode">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSalutationCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="salutationName" DataValueField="salutationCode" Font-Size="XX-Small">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueSalutation" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insSalutationCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="salutationName" DataValueField="salutationCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueSalutation" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("salutationCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="firstName" SortExpression="firstName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstName" runat="server" Font-Size="XX-Small" Text='<%# Eval("firstName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insFirstName" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="fatherName" SortExpression="fatherName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtFatherName" runat="server" Font-Size="XX-Small" Text='<%# Eval("fatherName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insFatherName" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("fatherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="grandFatherName" SortExpression="grandFatherName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtGrandFatherName" runat="server" Font-Size="XX-Small" Text='<%# Eval("grandFatherName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insGrandFatherName" runat="server" Font-Size="XX-Small" Visible="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("grandFatherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="gender" SortExpression="gender">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlGender" runat="server" Font-Size="XX-Small">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insGender" runat="server" Font-Size="XX-Small" Visible="False">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("gender") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="phone" SortExpression="phone">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPhone" runat="server" Font-Size="XX-Small" Text='<%# Eval("phone") %>' TextMode="Phone"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insPhone" runat="server" Font-Size="XX-Small" Visible="False" TextMode="Phone"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="email" SortExpression="email">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Font-Size="XX-Small" Text='<%# Eval("email") %>' TextMode="Email"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="insEmail" runat="server" Font-Size="XX-Small" Visible="False" TextMode="Email"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="academicRankCode" SortExpression="academicrankCode">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAcademicRankCode" runat="server" DataSourceID="SqlDataSource2" DataTextField="academicRankName" DataValueField="academicRankCode" Font-Size="XX-Small">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueAcademicRank" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insAcademicRankCode" runat="server" DataSourceID="SqlDataSource2" DataTextField="academicRankName" DataValueField="academicRankCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueAcademicRank" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("academicrankCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="academicQualificationCode" SortExpression="academicQualificationCode">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAcademicQualificationCode" runat="server" DataSourceID="SqlDataSource3" DataTextField="academicQualificationName" DataValueField="academicQualificationCode" Font-Size="XX-Small">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueAcademicQualification" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insAcademicQualificationCode" runat="server" DataSourceID="SqlDataSource3" DataTextField="academicQualificationName" DataValueField="academicQualificationCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueAcademicQualification" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("academicQualificationCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="staffCategoryCode" SortExpression="staffCategoryCode">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlStaffCategoryCode" runat="server" DataSourceID="SqlDataSource4" DataTextField="staffCategoryName" DataValueField="staffCategoryCode" Font-Size="XX-Small">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueStaffCategory" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insStaffCategoryCode" runat="server" DataSourceID="SqlDataSource4" DataTextField="staffCategoryName" DataValueField="staffCategoryCode" Font-Size="XX-Small" Visible="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SISConnectionString %>" SelectCommand="RetriveUniqueStaffCategory" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("staffCategoryCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="isExternal" SortExpression="isExternal">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlIsExternal" runat="server" Font-Size="XX-Small">
                        <asp:ListItem>Internal</asp:ListItem>
                        <asp:ListItem>External</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="insIsExternal" runat="server" Font-Size="XX-Small" Visible="False">
                        <asp:ListItem>Internal</asp:ListItem>
                        <asp:ListItem>External</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("isexternal") %>'></asp:Label>
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
