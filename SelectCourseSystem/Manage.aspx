<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SelectCourseSystem.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style6 {
            height: 70px;
        }
        .auto-style8 {
            height: 57px;
        }
        .auto-style9 {
            height: 61px;
        }
        .auto-style10 {
            height: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style9">
                <asp:Button ID="Button1" runat="server" Font-Size="Larger" OnClick="Button1_Click" Text="学生信息导入" Height="30px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="Button2" runat="server" Font-Size="Larger" OnClick="Button2_Click" Text="课程信息导入" Height="30px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="Button3" runat="server" Font-Size="Larger" Height="30px" OnClick="Button3_Click" Text="课程抽签" Width="150px" />
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style10">
                            <asp:Button ID="Button4" runat="server" Font-Size="Larger" Height="30px" OnClick="Button4_Click" Text="课程设置" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">退出登录</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
