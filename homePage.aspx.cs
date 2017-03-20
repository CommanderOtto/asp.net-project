using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KSB_Website_Files_homePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentLogin.aspx");

    }

    protected void AdvisorLogin(object sender, EventArgs e)
    {
        Response.Redirect("AdvisorLogin.aspx");

    }

    protected void GuestLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentLogin.aspx");
    }
}