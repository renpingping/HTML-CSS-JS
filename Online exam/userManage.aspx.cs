using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "True")
            {
                e.Row.Cells[4].Text = "男";
            }
            if (e.Row.Cells[4].Text.ToString() == "False")
            {
                e.Row.Cells[4].Text = "女";
            }
        }
    }
}