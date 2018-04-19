<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adduserpage.aspx.cs" Inherits="page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加考生</title>
    <link rel="stylesheet" type="text/css" href="/css/Register.css"/>
    <style>
        *{
            margin:0;
            padding:0;
        }
        .html{
            width:1000px;
            height:auto;
        }
        .content_body ul {
            margin-left: 200px;
        }
        .registerInput {
            margin-left: 0; 
        }
        .textBoxInput, .sexRadio {
            margin-left: 43%;
        }
        .registerBtn {
            margin-left: 218px;
        }
        .resetBtn {
            margin-left: 46%;
        }
        .registerLabel{
            margin-left: 23%;
        }
        ul li{
            list-style:none;
        }
        .bottom{
            width:100%;
            height:50px;
            background-color:#1A8Dff;
            margin-top:100px;
        }
        .registertext{
            margin-bottom:50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content_body">
        <h2 class="registertext">添加考生</h2>
        <br />
        <ul>
            <li class="registerInput">
                <asp:Label ID="Label1" runat="server" Text="用 户 名：" CssClass="registerLabel"></asp:Label>
            <asp:TextBox ID="usernameTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernameTextBox" Display="Dynamic" ErrorMessage="RequiredFieldValidator" CssClass="validator">请输入用户名</asp:RequiredFieldValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="sexlabel" runat="server" Text="Label" CssClass="registerLabel">性&nbsp; &nbsp; &nbsp;别：</asp:Label>
            <asp:RadioButtonList ID="sexRadioBL" runat="server" CssClass="sexRadio" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
            </asp:RadioButtonList>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="pwdLabel" runat="server" Text="Label" CssClass="registerLabel">密&nbsp; &nbsp; &nbsp;码：</asp:Label>
            <asp:TextBox ID="pwdTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pwdTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入密码</asp:RequiredFieldValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="confirmpwdLabel" runat="server" Text="Label" CssClass="registerLabel">确认密码：</asp:Label>
            <asp:TextBox ID="confirmpwdTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmpwdTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请再次输入确认密码</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="pwdTextBox" ControlToValidate="confirmpwdTextBox" Display="Dynamic" ErrorMessage="CompareValidator" CssClass="validator" ForeColor="Red">两次输入的密码不同</asp:CompareValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="questionLabel" runat="server" Text="Label" CssClass="registerLabel">提示问题：</asp:Label>
            <asp:TextBox ID="questionTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="questionTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入提示问题</asp:RequiredFieldValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="answerLabel" runat="server" Text="Label" CssClass="registerLabel">问题答案：</asp:Label>
            <asp:TextBox ID="answerTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="answerTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入问题答案</asp:RequiredFieldValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="IDCardLabel" runat="server" Text="Label" CssClass="registerLabel">身份证号：</asp:Label>
            <asp:TextBox ID="IDCardTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="IDCardTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入身份证号码</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="IDCardTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic" CssClass="validator">格式错误，请重新输入</asp:RegularExpressionValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="phoneLabel" runat="server" Text="Label" CssClass="registerLabel">手机号码：</asp:Label>
            <asp:TextBox ID="phoneTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="phoneTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入手机号码</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="phoneTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{11}" Display="Dynamic" CssClass="validator">格式错误，请重新输入</asp:RegularExpressionValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="emailLabel" runat="server" Text="Label" CssClass="registerLabel">邮 &nbsp; &nbsp; &nbsp;箱：</asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server" CssClass="textBoxInput"></asp:TextBox>
        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="emailTextBox" ErrorMessage="RequiredFieldValidator" Display="Dynamic" CssClass="validator">请输入邮箱</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" CssClass="validator">格式错误，请重新输入</asp:RegularExpressionValidator>
        
            </li>
            <li class="registerInput">
                <asp:Label ID="classLabel" runat="server" Text="Label" CssClass="registerLabel">班 &nbsp; &nbsp; &nbsp;级：</asp:Label>
            <asp:DropDownList ID="classDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ClassId" DataValueField="ClassId" CssClass="textBoxInput">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:administratorConnectionString %>" SelectCommand="SELECT [ClassId] FROM [Classes]"></asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="classDropDownList" Display="Dynamic" CssClass="validator">请选择班级</asp:RequiredFieldValidator>
        
            </li>
            <li class="registerInput">
                <asp:LinkButton ID="registerbtn" runat="server" OnClick="Registerbtn_Click" CssClass="registerBtn">添加</asp:LinkButton>
                <asp:LinkButton ID="resetbtn" runat="server" CssClass="resetBtn">重置</asp:LinkButton>
        
            </li>
        </ul>
        
    </div>
        <div class="bottom">   
        </div>
    </form>
</body>
</html>
