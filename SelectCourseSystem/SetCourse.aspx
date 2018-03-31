<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="SetCourse.aspx.cs" Inherits="SelectCourseSystem.SetCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="Ridge" BorderWidth="2px" DataKeyNames="CourseID" DataSourceID="LinqDataSource1" Font-Size="Large" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="White" CellPadding="3" CellSpacing="1" GridLines="None">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="CourseID" HeaderText="课程号" ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="CourseName" HeaderText="课程名" SortExpression="CourseName" />
            <asp:BoundField DataField="Credit" HeaderText="学分" SortExpression="Credit" />
            <asp:BoundField DataField="Room" HeaderText="教室" SortExpression="Room" />
            <asp:BoundField DataField="TeacherName" HeaderText="授课教师" SortExpression="TeacherName" />
            <asp:BoundField DataField="TimeAndRoom" HeaderText="时间地点" SortExpression="TimeAndRoom" />
            <asp:BoundField DataField="ElectiveStartTime" DataFormatString="{0:d}" HeaderText="选课开始时间" SortExpression="ElectiveStartTime" />
            <asp:BoundField DataField="ElectiveEndTime" DataFormatString="{0:d}" HeaderText="选课结束时间" SortExpression="ElectiveEndTime" />
            <asp:BoundField DataField="CurrentNumber" HeaderText="已选人数" SortExpression="CurrentNumber" />
            <asp:BoundField DataField="MaxNumber" HeaderText="目标人数" SortExpression="MaxNumber" />
            <asp:BoundField DataField="MajorType" HeaderText="限选专业" SortExpression="MajorType" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="详细" />
        </Columns>
        <EditRowStyle BorderStyle="Groove" Height="20%" HorizontalAlign="Center" Width="80%" Wrap="False" />
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
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="SelectCourseSystem.ustcsseDataContext" EnableUpdate="True" EntityTypeName="" TableName="CourseInfo" OnSelecting="LinqDataSource1_Selecting">
    </asp:LinqDataSource>
    <table class="auto-style4">
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Manage.aspx">返回管理</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
