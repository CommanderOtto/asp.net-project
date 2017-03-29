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


public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        advisor.Value = "2";
        int temp = int.Parse(advisor.Value);
        GetPrevDates(temp);

    }

    protected void GetPrevDates(int advisor)
    {
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        string holder = "SELECT Convert(VARCHAR(10), AvaDate, 110) AS Date, CONVERT(VARCHAR(5), AvaTime, 108)  AS Time FROM KBS_ADVISOR_TIMES WHERE AID =" + advisor + "AND Valid = 1";

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

    protected void GetDate(object sender, EventArgs e)
    {
       string date = Hidden.Value.ToString();
       string time = Time.SelectedValue.ToString();
       DateTime dates = Convert.ToDateTime(date);
        if(dates > DateTime.Now) 
        {
            DBoperations DB = new DBoperations();
            int temp = int.Parse(advisor.Value);
            Boolean truth = DB.CreateAdvisorTimes(date, time, temp);

            GetPrevDates(temp);
            
        }
        else
        {
            hold.Text = "This date is unavailable";
        }
       
    }

    protected void Paging(object sender, GridViewPageEventArgs e)
    {
        int temp = int.Parse(advisor.Value);
        GetPrevDates(temp);
        result.PageIndex = e.NewPageIndex;
        result.DataBind();
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }

    protected void Sort(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = result.DataSource as DataTable;

        if (dataTable != null)
        {
           DataView dataView = new DataView(dataTable);
           dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

           result.DataSource = dataView;
           result.DataBind();
       }
    }


    protected void DeleteTime(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)result.Rows[e.RowIndex];
        string date = row.Cells[0].Text;
        string time = row.Cells[1].Text;

        Boolean truth = DeleteRow(date, time);
       
        int temp = int.Parse(advisor.Value);
        GetPrevDates(temp);


    }


    protected Boolean DeleteRow(string date, string time)
    {
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete From KBS_ADVISOR_TIMES WHERE AvaDate='"+date+"' AND AvaTime ='"+time+"'", con);
            cmd.ExecuteNonQuery();
            return true;

        }
        catch (SqlException err)
        {
            err.ToString();
            return false;


        }
        finally
        {
            con.Close();
        }

    }
}