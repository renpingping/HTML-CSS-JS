<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="userManage.aspx.cs" Inherits="userManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/css/userManage.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">   
        <div>    
            <ul>
                <li>
                    <a href="#" onclick="manageStudent">管理考生</a>
                    <div class="none1">
                        <a href="#" onclick="openAddst()">添加考生</a>
                        
                    </div>
                </li>

                <li>
                    <a href="#" onclick="manageTeacher">管理老师</a>
                    <div class="none1">
                        <a href="#" onclick="openAddtc()">添加老师</a>
                        
                    </div>
                </li>
            </ul>

        </div>
        <div class="studentlist">   
            
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="St_id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" ForeColor="#333333" GridLines="None" Height="300px" Width="99%" Font-Size="Small">
                <AlternatingRowStyle BackColor="White" BorderColor="#507CD1" VerticalAlign="Middle" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" HeaderText="操作" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="St_id" HeaderText="学号" InsertVisible="False" ReadOnly="True" SortExpression="St_id" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_name" HeaderText="姓名" SortExpression="St_name" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_pwd" HeaderText="密码" SortExpression="St_pwd" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_sex" HeaderText="性别" SortExpression="St_sex" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_question" HeaderText="提示问题" SortExpression="St_question" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_answer" HeaderText="答案" SortExpression="St_answer" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_cardNo" HeaderText="身份证号" SortExpression="St_cardNo" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_phone" HeaderText="手机号" SortExpression="St_phone" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_email" HeaderText="邮箱" SortExpression="St_email" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="St_joinTime" HeaderText="注册时间" SortExpression="St_joinTime" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ClassId" HeaderText="班级" SortExpression="ClassId" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Width="800px" HorizontalAlign="Left" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:administratorConnectionString %>" DeleteCommand="DELETE FROM [Student] WHERE [St_id] = @St_id" InsertCommand="INSERT INTO [Student] ([St_name], [St_pwd], [St_sex], [St_joinTime], [St_question], [St_answer], [St_cardNo], [St_phone], [St_email], [ClassId]) VALUES (@St_name, @St_pwd, @St_sex, @St_joinTime, @St_question, @St_answer, @St_cardNo, @St_phone, @St_email, @ClassId)" SelectCommand="SELECT * FROM [Student] ORDER BY [St_id], [St_name], [ClassId]" UpdateCommand="UPDATE [Student] SET [St_name] = @St_name, [St_pwd] = @St_pwd, [St_sex] = @St_sex, [St_joinTime] = @St_joinTime, [St_question] = @St_question, [St_answer] = @St_answer, [St_cardNo] = @St_cardNo, [St_phone] = @St_phone, [St_email] = @St_email, [ClassId] = @ClassId WHERE [St_id] = @St_id">
                <DeleteParameters>
                    <asp:Parameter Name="St_id" Type="Int64" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="St_name" Type="String" />
                    <asp:Parameter Name="St_pwd" Type="String" />
                    <asp:Parameter Name="St_sex" Type="Boolean" />
                    <asp:Parameter Name="St_joinTime" Type="DateTime" />
                    <asp:Parameter Name="St_question" Type="String" />
                    <asp:Parameter Name="St_answer" Type="String" />
                    <asp:Parameter Name="St_cardNo" Type="String" />
                    <asp:Parameter Name="St_phone" Type="String" />
                    <asp:Parameter Name="St_email" Type="String" />
                    <asp:Parameter Name="ClassId" Type="Int64" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="St_name" Type="String" />
                    <asp:Parameter Name="St_pwd" Type="String" />
                    <asp:Parameter Name="St_sex" Type="Boolean" />
                    <asp:Parameter Name="St_joinTime" Type="DateTime" />
                    <asp:Parameter Name="St_question" Type="String" />
                    <asp:Parameter Name="St_answer" Type="String" />
                    <asp:Parameter Name="St_cardNo" Type="String" />
                    <asp:Parameter Name="St_phone" Type="String" />
                    <asp:Parameter Name="St_email" Type="String" />
                    <asp:Parameter Name="ClassId" Type="Int64" />
                    <asp:Parameter Name="St_id" Type="Int64" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" DataKeyNames="Ad_id" DataSourceID="SqlDataSource2" Font-Size="Small" ForeColor="#333333" GridLines="None" Height="300px" Width="99%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Ad_id" HeaderText="工号" InsertVisible="False" ReadOnly="True" SortExpression="Ad_id">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ad_name" HeaderText="姓名" SortExpression="Ad_name">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ad_password" HeaderText="密码" SortExpression="Ad_password">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ad_phone" HeaderText="手机号码" SortExpression="Ad_phone">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ad_email" HeaderText="邮箱" SortExpression="Ad_email">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:administratorConnectionString %>" DeleteCommand="DELETE FROM [Manager] WHERE [Ad_id] = @Ad_id" InsertCommand="INSERT INTO [Manager] ([Ad_name], [Ad_password], [Ad_phone], [Ad_email]) VALUES (@Ad_name, @Ad_password, @Ad_phone, @Ad_email)" SelectCommand="SELECT * FROM [Manager] ORDER BY [Ad_id], [Ad_name]" UpdateCommand="UPDATE [Manager] SET [Ad_name] = @Ad_name, [Ad_password] = @Ad_password, [Ad_phone] = @Ad_phone, [Ad_email] = @Ad_email WHERE [Ad_id] = @Ad_id">
                <DeleteParameters>
                    <asp:Parameter Name="Ad_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Ad_name" Type="String" />
                    <asp:Parameter Name="Ad_password" Type="String" />
                    <asp:Parameter Name="Ad_phone" Type="String" />
                    <asp:Parameter Name="Ad_email" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Ad_name" Type="String" />
                    <asp:Parameter Name="Ad_password" Type="String" />
                    <asp:Parameter Name="Ad_phone" Type="String" />
                    <asp:Parameter Name="Ad_email" Type="String" />
                    <asp:Parameter Name="Ad_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
        </div>
    </div>
    <script>    
        function openAddst() {
            window.open("adduserpage.aspx", "newwindow", "height=400, width=1180, top=100, left=120, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no") //写成一行  
        }
        function openAddtc() {
            window.open("adduserpage.aspx", "newwindow", "height=400, width=1180, top=100, left=120, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no") //写成一行  
        }
        function manageStudent() {
            var showstu = document.getElementById("GridView2");
            showstu.style.display = "none";
            var nonetc = document.getElementById("GridView1");
            nonetc.style.display = "black";
        }
        function manageTeacher() {
            var nonestu = document.getElementById("GridView1");
            nonestu.style.display = "none";
            var showtc = document.getElementById("GridView2");
            showtc.style.display = "black";
        }
    </script>
</asp:Content>

