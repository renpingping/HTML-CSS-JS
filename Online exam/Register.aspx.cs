using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    protected void Registerbtn_Click(object sender, EventArgs e)
    {
        int IntReturnValue = ucObj.AddUser(usernameTextBox.Text.Trim(),pwdTextBox.Text.Trim(),transfer(sexRadioBL.SelectedItem.Text), questionTextBox.Text.Trim(), answerTextBox.Text.Trim(),IDCardTextBox.Text.Trim(), phoneTextBox.Text.Trim(),emailTextBox.Text.Trim(),classDropDownList.SelectedItem.Text.Trim());

        if (IntReturnValue == 1)
        {
            Response.Write(ccObj.MessageBox("恭喜您，注册成功！返回登录！", "login.aspx"));
        }
        else
        {
            Response.Write(ccObj.MessageBoxPage("注册失败！"));

        }
    }
    protected bool transfer(string strValue)
    {
        if (strValue == "男")
        {
            return true;
        }
        else
        {
            return false;

        }
    }
}