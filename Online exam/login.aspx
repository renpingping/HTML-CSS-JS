<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content ="width=device-width" />
    <title>在线考试系统</title>
    <link rel="stylesheet" type="text/css" href="/css/login.css"/>
</head>
<body>
    <div class="img-bg">
        <img class="img-bg" src="/image/login-bg-small.jpg"/>
    </div>
    <div class ="login-content-wrap">
        <div class ="login-content">
            <form id="loginForm" runat="server">
                <div class="main-error-tips" id="errormsg">
                <img src="/image/logo.png" alt="logo" class="logo"/></div>
                <div class="username">
                    <span id="usernameicon">|</span>
                    <asp:TextBox ID="username" runat="server" CssClass="userNameInput" placeholder="用户名"></asp:TextBox>
                </div>
                 <div class="password">
                    <span id="passwordicon">|</span>
                    
                    <asp:TextBox ID="password" runat="server" CssClass="passwordInput" placeholder="密码" TextMode="Password"></asp:TextBox>
                </div>
                
                <asp:LinkButton ID="forgetPassword" runat="server" CssClass="forgetPassword">忘记密码</asp:LinkButton>
                <div class="VerifyCode">
                    <asp:TextBox ID="Verification" runat="server" CssClass="Verification" placeholder="验证码"></asp:TextBox>

                    <asp:Image ID="imgVerify" CssClass="Verify" runat="server" alt="看不清？点击更换" src="VerifyCode.aspx?" onclick="this.src=this.src+'?'" />

                </div>  
                <div class="radiobtn1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="radiobtn1" RepeatDirection="Horizontal" Width="202px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True">考生</asp:ListItem>
                        <asp:ListItem>老师</asp:ListItem>
                        <asp:ListItem>管理员</asp:ListItem>
                    </asp:RadioButtonList> 
                </div>  
                
                <asp:LinkButton ID="btnLogin" runat="server" CssClass="btnLogin" OnClick="btnLogin_Click">登录</asp:LinkButton>
                   
                <asp:LinkButton ID="btnRegist" runat="server" CssClass="btnRegist" OnClick="btnRegist_Click">注册</asp:LinkButton>
            </form>
        </div>
    </div>
    
</body>
</html>
