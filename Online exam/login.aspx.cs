using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //清空Session对象
        Session["Ad_name"] = null;
        Session["Ad_password"] = null;
        Session["St_name"] = null;
        Session["St_pwd"] = null;
        Session["Tc_name"] = null;
        Session["Tc_password"] = null;
        if (this.username.Text.Trim() == "" || this.password.Text.Trim() == "")
        {
            Response.Write(ccObj.MessageBoxPage("用户名和密码不能为空！！！"));

        }
        else
        {
            // 考生登录判断
            if (Session["serverCode"].ToString() == this.Verification.Text.Trim())
            {
                if (RadioButtonList1.SelectedIndex == 0)
                {
                    DataTable dsTable = ucObj.StudentLogin(this.username.Text.Trim(), this.password.Text.Trim());

                    if (dsTable.Rows.Count != 0) //判断用户是否存在
                    {
                        Session["St_name"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存用户ID
                        Session["St_pwd"] = dsTable.Rows[0][1].ToString(); //保存用户登录名
                        Response.Redirect("StudentIndex.aspx"); //跳转到当前请求的虚拟路径
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBoxPage("您的登录有误，请核对后再重新登录！"));
                        Verification.Text = "";
                        password.Text = "";
                    }
                }
                // 教师登录判断
                if (RadioButtonList1.SelectedIndex == 1)
                {
                    DataTable dsTable = ucObj.TeacherLogin(this.username.Text.Trim(), this.password.Text.Trim());

                    if (dsTable.Rows.Count != 0) //判断用户是否存在
                    {
                        Session["Tc_name"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存用户ID
                        Session["Tc_password"] = dsTable.Rows[0][1].ToString(); //保存用户登录名
                        Response.Redirect("TeacherIndex.aspx"); //跳转到当前请求的虚拟路径
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBoxPage("您的登录有误，请核对后再重新登录！"));
                        Verification.Text = "";
                        password.Text = "";
                    }
                }
                // 管理员登录判断
                if (RadioButtonList1.SelectedIndex == 2)
                {
                    DataTable dsTable = ucObj.ManagerLogin(this.username.Text.Trim(), this.password.Text.Trim());

                    if (dsTable.Rows.Count != 0) //判断用户是否存在
                    {
                        Session["Ad_name"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存用户ID
                        Session["Ad_password"] = dsTable.Rows[0][1].ToString(); //保存用户登录名
                        Response.Redirect("ManagerIndex.aspx"); //跳转到当前请求的虚拟路径
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBoxPage("您的登录有误，请核对后再重新登录！"));
                        Verification.Text = "";
                        password.Text = "";
                    }
                }
            }
            else
            {
                Response.Write(ccObj.MessageBoxPage("请正确输入验证码！"));
            }
         
        }
    }
    protected void btnRegist_Click(object sender, EventArgs e)
    {
        Session["Ad_name"] = null;
        Session["Ad_password"] = null;
        Session["St_name"] = null;
        Session["St_pwd"] = null;
        Session["Tc_name"] = null;
        Session["Tc_password"] = null;
        Response.Redirect("Register.aspx");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        username.Text = "";
        password.Text = "";
        Verification.Text = "";
    }
}