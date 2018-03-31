<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="StudentMain.aspx.cs" Inherits="SelectCourseSystem.StudentMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
            border-collapse: collapse;
            border-left-style: solid;
            border-left-width: 2px;
            border-right: 2px solid #C0C0C0;
            border-top-style: solid;
            border-top-width: 2px;
            border-bottom: 2px solid #C0C0C0;
        }
        .auto-style7 {
            height: 61px;
            width: 158px;
        }
        .auto-style8 {
            height: 67px;
            width: 158px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style10 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style7">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="LinqDataSource1" GridLines="None" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="maxCredit" HeaderText="限选学分" ReadOnly="True" SortExpression="maxCredit" />
                        <asp:BoundField DataField="currentCredit" HeaderText="已选学分" ReadOnly="True" SortExpression="currentCredit" />
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
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="SelectCourseSystem.ustcsseDataContext" EntityTypeName="" OnSelecting="LinqDataSource1_Selecting" Select="new (maxCredit, currentCredit)" TableName="Student">
                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="Button1" runat="server" Font-Size="Large" OnClick="Button1_Click" Text="选课列表" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="Button2" runat="server" Font-Size="Large" OnClick="Button2_Click" Text="我的选课" />
                <table class="auto-style9">
                    <tr>
                        <td class="auto-style10">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出登录</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
