<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="MySelectedCourse.aspx.cs" Inherits="SelectCourseSystem.MySelectedCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <p aria-orientation="horizontal">
        <table class="auto-style4">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="LinqDataSource1" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="CourseName" HeaderText="课程名称" ReadOnly="True" SortExpression="CourseName" />
                            <asp:BoundField DataField="CourseID" HeaderText="课程编号" ReadOnly="True" SortExpression="CourseID" />
                            <asp:BoundField DataField="Credit" HeaderText="学分" ReadOnly="True" SortExpression="Credit" />
                            <asp:BoundField DataField="MajorType" HeaderText="限选专业" ReadOnly="True" SortExpression="MajorType" />
                            <asp:BoundField DataField="IsSelected" HeaderText="是否中选" ReadOnly="True" SortExpression="IsSelected" />
                            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="取消选课" />
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="SelectCourseSystem.ustcsseDataContext" EntityTypeName="" Select="new (CourseName, CourseID, Credit, MajorType, IsSelected)" TableName="SelectInfo" OnSelecting="LinqDataSource1_Selecting">
                    </asp:LinqDataSource>
                </td>
            </tr>
        </table>
        <table class="auto-style4">
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentMain.aspx">返回管理</asp:HyperLink>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
