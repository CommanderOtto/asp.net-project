using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appointments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ShowRange.Checked == true)
        {
            SingleDate.Visible = false;
            RangeDate.Visible = true;
        }
        else
        {
            SingleDate.Visible = true;
            RangeDate.Visible = false;
        }
    }

    protected void Show_MultiDate(object sender, EventArgs e)
    {
        if(ShowRange.Checked == true)
        {
            SingleDate.Visible = false;
            RangeDate.Visible = true;
        }
        else
        {
            SingleDate.Visible = true;
            RangeDate.Visible = false;
        }
    }

    protected void GoBack(object sender, EventArgs e)
    {
        Response.Redirect("AdvisorPortal.aspx");
    }
}