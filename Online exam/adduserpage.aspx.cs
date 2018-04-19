using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Registerbtn_Click(object sender, EventArgs e)
    {
        int IntReturnValue = ucObj.AddUser(usernameTextBox.Text.Trim(), pwdTextBox.Text.Trim(), transfer(sexRadioBL.SelectedItem.Text), questionTextBox.Text.Trim(), answerTextBox.Text.Trim(), IDCardTextBox.Text.Trim(), phoneTextBox.Text.Trim(), emailTextBox.Text.Trim(), classDropDownList.SelectedItem.Text.Trim());

        if (IntReturnValue == 1)
        {
            Response.Write(ccObj.MessageBoxPage("添加成功！"));
        }
        else
        {
            Response.Write(ccObj.MessageBoxPage("添加失败！"));

        }
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.close();</script>");
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