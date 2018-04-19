using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerifyCode : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] str = new string[4];
            string serverCode = "";
            //生成随机生成器 
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                str[i] = random.Next(10).ToString().Substring(0, 1);
            }
            ccObj.CreateCheckCodeImage(str);
            foreach (string s in str)
            {
                serverCode += s;
            }
            Session["serverCode"] = serverCode;

        }
    }
}