using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;


using System.Web.UI.WebControls.WebParts;



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

    protected void GoBack(object sender, EventArgs e)
    {
        Response.Redirect("AdvisorPortal.aspx");
    }

    protected void GetAppoint(object sender, EventArgs e)
    {
        
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        string search = keyword_search.Text;
        string holder = "Select * From VW_KBS_APPOINTMENTS Where StuFName LIKE '%" + search + "%' OR StuLName LIKE '%" + search + "%' OR StaDesc LIKE '%" + search + "%' OR StuEmail = '%" + search + "%' OR StuPhone LIKE '%" + search + "%' OR StuIUID LIKE '%" + search + "%'; ";
        SqlCommand cmd = new SqlCommand(holder,con);


        try
        {
            con.Open();
            System.Data.DataTable results = new DataTable();
            SqlDataAdapter SqlData = new SqlDataAdapter(cmd);

            SqlData.Fill(results);
            result.DataSource = results;
            result.DataBind();
            con.Close();
            SqlData.Dispose();
        }
        catch (SqlException err)
        {
            err.ToString();

           
        }
        finally
        {
            con.Close();
        }
    }

    protected void GetAppointDate(object sender, EventArgs e)
    {
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        if (SingleDate.Visible == false)
        {
            
            string Date1 = datepickerFrom.Text;
            string Date2 = datepickerTo.Text;
            string holder = "Select * From VW_KBS_APPOINTMENTS Where AvaDate BETWEEN '" + Date1 + "' AND '" + Date2 + "'OR AvaDate ='" + Date1 + "'OR AvaDate = '" + Date2 + "';";
            SqlCommand cmd = new SqlCommand(holder, con);

            try
            {
                con.Open();
                System.Data.DataTable results = new DataTable();
                SqlDataAdapter SqlData = new SqlDataAdapter(cmd);

                SqlData.Fill(results);
                result.DataSource = results;
                result.DataBind();
                con.Close();
                SqlData.Dispose();
            }
            catch (SqlException err)
            {
                err.ToString();


            }
            finally
            {
                con.Close();
            }
        }
        if (SingleDate.Visible == true)
        {
            string Date = datepicker.Text;
            string holder = "Select * From VW_KBS_APPOINTMENTS Where AvaDate ='" + Date + "';";
            SqlCommand cmd = new SqlCommand(holder, con);

            try
            {
                con.Open();
                System.Data.DataTable results = new DataTable();
                SqlDataAdapter SqlData = new SqlDataAdapter(cmd);

                SqlData.Fill(results);
                result.DataSource = results;
                result.DataBind();
                con.Close();
                SqlData.Dispose();
            }
            catch (SqlException err)
            {
                err.ToString();


            }
            finally
            {
                con.Close();
            }
        }
    }
}