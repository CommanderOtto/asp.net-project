﻿using System;
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
        if (!Page.IsPostBack)
        {
            StudentInformation.Visible = true;
            ContactInformation.Visible = false;

            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            //always use try/catch for db connections

            try
            {
                ListItem newItem = new ListItem();
                newItem.Text = "Select Major";
                newItem.Value = "0";
                Major_Form.Items.Add(newItem);

                string selectSQL = "Select MajName,MID From VW_KBS_MAJORS";
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem NewItem = new ListItem();
                    NewItem.Text = reader["MajName"].ToString();
                    NewItem.Value = reader["MID"].ToString();
                    Major_Form.Items.Add(NewItem);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception err)
            {
                err.ToString();

            }
            finally
            {
                con.Close();

            }

        }
    }





    //This is the event. When the user clicks submit, it will do the following:
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DBoperations DB = new DBoperations();
        string username = UserName_Form.Text;
        string notes = "Tester";
        int SID= DB.GetStudentID(username);
        int ATID = Convert.ToInt32(TimeSlots_Form.SelectedValue);
       
        Boolean value = DB.CreateAppointment(ATID,SID,notes);
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        int APID = 0;
        try
        {
            string selectSQL = "Select APID FROM KBS_APPOINTMENTS WHERE ATID=" + ATID + ";";
            SqlCommand com = new SqlCommand(selectSQL, con);

            string setNonValid = "UPDATE KBS_ADVISOR_TIMES SET Valid=0 WHERE ATID=" + ATID + ";";
            SqlCommand edit = new SqlCommand(setNonValid, con);

            con.Open();
            APID = (int)com.ExecuteScalar();
            edit.ExecuteNonQuery();
           

        }
        catch (Exception err)
        {
            err.ToString();


        }
        finally
        {
            con.Close();

        }

        foreach(ListItem row in Reason_Form.Items)
        {
            if(row.Selected == true)
            {
                int reasons = Convert.ToInt32(row.Value);
                DB.MatchReasonsToAppointment(reasons, APID);
            }
        }
     
      
        DB = null;



    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        StudentInformation.Visible = false;
        ContactInformation.Visible = true;
        DBoperations DB = new DBoperations();

        string First = FirstName_Form.Text;
        string Last = LastName_Form.Text;
        string Email = Email_Form.Text;
        string UserName = UserName_Form.Text;
        string Major = Major_Form.SelectedValue;
        int Maj = Convert.ToInt32(Major);
        string Phone = Phone_Form.Text;
        string UID = SUID_Form.Text;

        Boolean Student = DB.SecureVerifyStudent(UserName);
        if (Student == false)
        {
            DB.CreateStudent(First, Last, Email, UserName, Maj, 1, UID, Phone);
        }
        DB = null;
        //Advisors
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Select Advisor";
            newItem.Value = "0";
            Advisor_Form.Items.Add(newItem);

            string selectSQL = "Select AID ,AdvFName, AdvLName From KBS_ADVISORS";
            SqlCommand comd = new SqlCommand(selectSQL, con);
            con.Open();
            SqlDataReader reads = comd.ExecuteReader();

            while (reads.Read())
            {
                ListItem NewItem = new ListItem();
                string first = reads["AdvFName"].ToString();
                string last = reads["AdvLName"].ToString();
                string full = first + " " + last;
                NewItem.Text = full;
                NewItem.Value = reads["AID"].ToString();
                Advisor_Form.Items.Add(NewItem);
            }
            reads.Close();
            con.Close();
        }
        catch (Exception err)
        {
            err.ToString();

        }
        finally
        {
            con.Close();

        }


        try
        {
            string selectSQL = "Select RID, ReaDesc FROM VW_KBS_REASONS";
            SqlCommand com = new SqlCommand(selectSQL, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                ListItem NewItem = new ListItem();
                NewItem.Text = reader["ReaDesc"].ToString();
                NewItem.Value = reader["RID"].ToString();
                Reason_Form.Items.Add(NewItem);
            }
            reader.Close();
            con.Close();
        }
        catch (Exception err)
        {
            err.ToString();

        }
        finally
        {
            con.Close();

        }




    }


    protected void drpChange_Time(object sender, EventArgs e)
    {
        TimeSlots_Form.Items.Clear();
        
        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Select Time";
            newItem.Value = "0";
            TimeSlots_Form.Items.Add(newItem);

            string selectSQL = "Select ATID , AvaTime, Convert(VARCHAR(10), AvaDate, 110) AS AvaDate From VW_KBS_ADVISOR_TIMES WHERE AID =" + Advisor_Form.SelectedIndex;
            SqlCommand comd = new SqlCommand(selectSQL, con);
            con.Open();
            SqlDataReader reads = comd.ExecuteReader();

            while (reads.Read())
            {
                ListItem NewItem = new ListItem();
                string first = reads["AvaDate"].ToString();
                string last = reads["AvaTime"].ToString();
                last.Substring(1, 5);
                string full = first + " " + last;
                NewItem.Text = full;
                NewItem.Value = reads["ATID"].ToString();
                TimeSlots_Form.Items.Add(NewItem);
            }
            reads.Close();
            con.Close();
        }
        catch (Exception err)
        {
            err.ToString();

        }
        finally
        {
            con.Close();

        }

    }

}