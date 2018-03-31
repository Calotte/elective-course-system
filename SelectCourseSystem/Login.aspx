<%@ Page Title="" Language="C#" MasterPageFile="~/School.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SelectCourseSystem.Login" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            height: 92px;
        }
        .auto-style9 {
            height: 89px;
            text-align: center;
        }
        .auto-style11 {
            height: 97px;
        }
        .auto-style12 {
            height: 23px;
        }
        .auto-style13 {
            height: 92px;
            text-align: center;
        }
        .auto-style14 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
  <div align="center">
    <asp:Login ID="Login1" runat="server" BackColor="#9966FF" BorderColor="#CC99FF" BorderPadding="4" BorderStyle="Groove" BorderWidth="1px" Font-Names="微软雅黑 Light" Font-Size="X-Large" ForeColor="White" Height="240px" OnAuthenticate="Login1_Authenticate" TitleText="你好，请登录" UserNameLabelText="学号:" Width="520px" FailureText="您的登录尝试不成功，请重试。">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LayoutTemplate>
            <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0" style="height:243px;width:520px;" aria-orientation="horizontal">
                            <tr>
                                <td align="center" style="color:White;background-color:#507CD1;font-size:0.9em;font-weight:bold;">你好，请登录</td>
                            </tr>
                            <tr>
                                <td aria-orientation="horizontal" class="auto-style13">
                                    
                                    <asp:TextBox ID="UserName"  placeholder="用户名"  runat="server" Font-Size="medium" style="font-size: x-large" Height="40px" Width="450px" BackColor="White"></asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">
                                    <asp:TextBox ID="Password" placeholder="密码" runat="server" Font-Size="0.8em" TextMode="Password" style="font-size: x-large" Height="40px" Width="450px" BackColor="White"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />                                 
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color:Red;" class="auto-style12">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="auto-style11">
                                    <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="微软雅黑 Light" Font-Size="Medium" ForeColor="#284E98" Text="登录" ValidationGroup="Login1" style="font-size: x-large" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
          </div>
    <p>
    </p>
</asp:Content>