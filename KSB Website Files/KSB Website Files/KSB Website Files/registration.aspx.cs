using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//importing asp.net libraries to handle the sql and database connections.
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Registration : System.Web.UI.Page
{

    //retrieving and saving to variables all the information in the form.
    string FirstName = "";
    string LastName = "";
    string Email = "";
    string Gender = "";
    string Major = "";
    string Phone = "";
    string Advisor = "";
    string TimeSlot = "";
    string Reason = "";
    string Date = "";
    int StudentId;


    protected void Page_Load(object sender, EventArgs e)
    {
        StudentInformation.Visible = true;
        ContactInformation.Visible = false;

        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        //always use try/catch for db connections
        try
        {
            //use the customerdb utility class to retrieve data
            ArrayList result = customerdb.getrows("select question, id from securityquestion");
            // response.write("<script>alert(\"result is " + result.count + "\")</script>");

            for (int i = 0; i < result.Count; i++)
            {
                ArrayList row = (ArrayList)result[i];
                //Response.Write("<script>alert(\"" + row[0].ToString() + "\")</script>");
                ListItem NewItem = new ListItem(row[0].ToString(), row[1].ToString());
                DrpSq1.Items.Add(NewItem);
                DrpSq2.Items.Add(NewItem);


            }

        }

        catch (Exception err)
        {
            Response.Write("<script>alert(\"" + err.Message + "\");</script>");
            Response.Write(err.Message);
            LblMsg.Text = "Cannot submit information now. Please try again later.";

        }

        finally //must make sure the connection is properly closed
        { //the finally block will always run whether there is an error or not
            con.Close();

        }


    }

    //This is the event. When the user clicks submit, it will do the following:
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);

        //1.check if email exists.
        //2. if it does not, insert data into appointment and account table.

        try
        {
            //check if the email already exist, email must be unique as this is the username
            //retrieving and saving to variables all the information in the form.

            FirstName = FirstName_Form.Text;
            LastName = LastName_Form.Text;
            Major = Major_Form.Text;
            Email = Email_Form.Text;
            Phone = Phone_Form.Text;
            Reason = Reason_Form.Text;
            Advisor = Advisor_Form.Text;
            TimeSlot = TimeSlots_Form.Text;


            string sql = "select count(*) from customer where email = '" + Email + "'";
            con.Open();

            int count= DBoperations.GetOneInt(sql);

            if (count != 0)
            {//email already exisits
                LblMsg.Text = "The email you entered already exists in the database. Please login to access your account or register with a different email. ";

            }
            else
            {
                DBoperations.CreateAccount(FirstName,LastName,Major,Email,Phone);
                StudentId = 1;//insert CreateAccount outparameter in here so that createappointment can work.
                DBoperations.CreateAppointment(StudentId,Reason,Advisor,Date,TimeSlot,Phone);

            }
        }
        catch (Exception err)
        {


            LblMsg.Text = "Cannot submit information now. Please try again later.";

        }
        finally //must make sure the connection is properly closed
        { //the finally block will always run whether there is an error or not
            con.Close();
        }

    }
    
    protected void btnNext_Click(object sender, EventArgs e)
    {
        StudentInformation.Visible = false;
        ContactInformation.Visible = true;
    }



}