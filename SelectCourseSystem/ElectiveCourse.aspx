<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="ElectiveCourse.aspx.cs" Inherits="SelectCourseSystem.ElectiveCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table class="auto-style4">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource1" GridLines="None" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="CourseID" HeaderText="课程ID" SortExpression="CourseID" />
                        <asp:BoundField DataField="CourseName" HeaderText="课程名称" SortExpression="CourseName" />
                        <asp:BoundField DataField="Credit" HeaderText="学分" SortExpression="Credit" />
                        <asp:BoundField DataField="Room" HeaderText="上课地点" SortExpression="Room" />
                        <asp:BoundField DataField="TeacherName" HeaderText="教师姓名" SortExpression="TeacherName" />
                        <asp:BoundField DataField="TimeAndRoom" HeaderText="时间和地点" SortExpression="TimeAndRoom" />
                        <asp:BoundField DataField="ElectiveStartTime" HeaderText="选课开始时间" SortExpression="ElectiveStartTime" />
                        <asp:BoundField DataField="ElectiveEndTime" HeaderText="选课结束时间" SortExpression="ElectiveEndTime" />
                        <asp:BoundField DataField="CurrentNumber" HeaderText="已选人数" SortExpression="CurrentNumber" />
                        <asp:BoundField DataField="MaxNumber" HeaderText="目标人数" SortExpression="MaxNumber" />
                        <asp:BoundField DataField="MajorType" HeaderText="限选专业" SortExpression="MajorType" />
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="选择此课" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ustcsseConnectionString %>"  SelectCommand="SELECT [CourseID], [CourseName], [Credit], [Room], [TeacherName], [TimeAndRoom], [ElectiveStartTime], [ElectiveEndTime], [CurrentNumber], [MaxNumber], [MajorType] FROM [CourseInfo]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentMain.aspx">返回管理</asp:HyperLink>
            </td>
        </tr>
    </table>
    </asp:Content>