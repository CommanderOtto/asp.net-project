using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Web.Configuration;


/// <summary>
/// Summary description for DBoperations
/// </summary>
public class DBoperations
{
    //variable declaration
    public static SqlConnection con;
    public static String cs;

    //constructor
    public DBoperations()
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
    }

    //Function to count in database to verify if the email inserted by user already exists.
    //used for login operation and for avoiding double entry in registration.
    public int GetOneInt(string sql)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            int value = (int)cmd.ExecuteScalar();

            con.Close();

            return value;
        }
        catch (Exception err)
        {
            err.ToString();
            return -9999;
        }
        finally
        {
            con.Close();

        }
    }//end of GetOneInt()

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //                                        INSERTION METHODS
    //
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public Boolean MatchReasonsToAppointment(int reason, int appointment)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_REASON_LOOKUP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.Int));
            cmd.Parameters["@Reason"].Value = reason;

            cmd.Parameters.Add(new SqlParameter("@Appointment", SqlDbType.Int));
            cmd.Parameters["@Appointment"].Value = appointment;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Create Major


    public Boolean CreateAdvisorStatus(string status)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_ADVISOR_STATUS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20));
            cmd.Parameters["@Status"].Value = status;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Create Major


    public Boolean CreateAppointmentStatus(string status)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_APPOINTMENT_STATUS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20));
            cmd.Parameters["@Status"].Value = status;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Appointment Status


    public Boolean CreateAdvisorTimes(string available, string time, int advisor)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_ADVISOR_TIME", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Available", SqlDbType.Date));
            cmd.Parameters["@Available"].Value = available;

            cmd.Parameters.Add(new SqlParameter("@Time", SqlDbType.Time,7));
            cmd.Parameters["@Time"].Value = time;

            cmd.Parameters.Add(new SqlParameter("@Advisor", SqlDbType.Int));
            cmd.Parameters["@Advisor"].Value = advisor;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Create Advisor Times 


    //function used to create appointments.
    public Boolean CreateAppointment(int AdvisorTime, int StudentID, string notes)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_APPOINTMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@AdvisorTime", SqlDbType.Int));
            cmd.Parameters["@AdvisorTime"].Value = AdvisorTime;

            cmd.Parameters.Add(new SqlParameter("@Student", SqlDbType.Int));
            cmd.Parameters["@Student"].Value = StudentID;

            cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 200));
            cmd.Parameters["@Note"].Value = notes;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }
    }//end of CreateAppointment

    public Boolean CreateMajor(string majname)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_MAJOR", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Major"].Value = majname;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Create Major

    public Boolean CreateReason(string reason)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_REASON", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Reason"].Value = reason;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Create Reason

    //function used to create student accounts.
    public Boolean CreateStudent(string FirstName, string LastName, string Email, string UserName, int Major, int Guest, string ID, string Phone)
    {
        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_STUDENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@First", SqlDbType.NVarChar, 50));
            cmd.Parameters["@First"].Value = FirstName;

            cmd.Parameters.Add(new SqlParameter("@Last", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Last"].Value = LastName;

            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Email"].Value = Email;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = UserName;

            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Phone"].Value = Phone;

            cmd.Parameters.Add(new SqlParameter("@SMID", SqlDbType.NVarChar, 50));
            cmd.Parameters["@SMID"].Value = Major;

            cmd.Parameters.Add(new SqlParameter("@Prospective", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Prospective"].Value = Guest;

            cmd.Parameters.Add(new SqlParameter("@SUID", SqlDbType.NChar, 10));
            cmd.Parameters["@SUID"].Value = ID;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }
    }//end of CreateStudent.

    public Boolean CreateAdvisor(string First, string Last, string UserName, string Password, int Status)
    {

        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_INSERT_ADVISOR", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@first", SqlDbType.NVarChar, 50));
            cmd.Parameters["@first"].Value = First;
            cmd.Parameters.Add(new SqlParameter("@last", SqlDbType.NVarChar, 50));
            cmd.Parameters["@last"].Value = Last;

            cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 25));
            cmd.Parameters["@username"].Value = UserName;

            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
            cmd.Parameters["@password"].Value = Password;

            cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
            cmd.Parameters["@status"].Value = Status;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }
    }//end of CreateAdvisor

    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    //
    //                                VALIDATION AND SECURITY METHODS
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    //function used to verify user credentials for login operation. -- uses unique username and password
    public Boolean SecureVerifyStudent(string UserName)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_COUNT_STUDENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = UserName;

            cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
            cmd.Parameters["@count"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int count = (int)cmd.Parameters["@count"].Value;
            con.Close();

            if (count == 1) //specify the exact expected number, instead of count > 0
                return true;
            else return false;
        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }
    }//end of SecureVerifyStudent

    //Get student id from unique username -- used for insertion methods 
    public int GetStudentID(string username)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_GET_UID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = username;

            cmd.Parameters.Add(new SqlParameter("@UID", SqlDbType.Int));
            cmd.Parameters["@UID"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int count = (int)cmd.Parameters["@UID"].Value;
            con.Close();
            return count;


        }

        catch (Exception err)
        {
            err.ToString();
            return -1;

        }
        finally
        {
            con.Close();

        }
    }

    //function used to verify user credentials for login operation. -- uses unique username and password
    public Boolean SecureVerifyAdvisor(string UserName)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_COUNT_ADVISOR", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 25));
            cmd.Parameters["@UserName"].Value = UserName;

            cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
            cmd.Parameters["@count"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int count = (int)cmd.Parameters["@count"].Value;
            con.Close();

            if (count == 1)
            {
                //specify the exact expected number, instead of count > 0
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }
    }//end of SecureVerifyAdvisor



    //Get advisor id from unique username for seeing specific appointments 
    public int GetAdvisorID(string username)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_GET_AID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = username;

            cmd.Parameters.Add(new SqlParameter("@UID", SqlDbType.Int));
            cmd.Parameters["@UID"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int count = (int)cmd.Parameters["@UID"].Value;
            con.Close();
            return count;


        }

        catch (Exception err)
        {
            err.ToString();
            return -1;

        }
        finally
        {
            con.Close();

        }
    }

    //Get what the advisor's level is
    public int GetAdvisorAccess(int AID)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_GET_ASTAT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@AID", SqlDbType.Int));
            cmd.Parameters["@AID"].Value = AID;

            cmd.Parameters.Add(new SqlParameter("@Stat", SqlDbType.Int));
            cmd.Parameters["@Stat"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int count = (int)cmd.Parameters["@Stat"].Value;
            con.Close();
            return count;


        }

        catch (Exception err)
        {
            err.ToString();
            return -1;

        }
        finally
        {
            con.Close();

        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //                                            UPDATE METHODS
    //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    public Boolean UpdateMajor(int mid, string majname)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_MAJOR", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@MID", SqlDbType.Int));
            cmd.Parameters["@MID"].Value = mid;

            cmd.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Major"].Value = majname;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Major Status

    public Boolean UpdateAppointmentStatus(int stid, string description)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_APPOINTMENT_STATUS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@STID", SqlDbType.Int));
            cmd.Parameters["@STID"].Value = stid;

            cmd.Parameters.Add(new SqlParameter("@StaDesc", SqlDbType.NVarChar, 20));
            cmd.Parameters["@StaDesc"].Value = description;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Appointment Status

    //updates status of advisors 
    public Boolean UpdateAdvisorStatus(int asid, string status)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_ADVISOR_STATUS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ASID", SqlDbType.Int));
            cmd.Parameters["@ASID"].Value = asid;

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20));
            cmd.Parameters["@Status"].Value = status;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Advisor Status

    //updates reasons 
    public Boolean UpdateReasons(int rid, string reason)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_REASON", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@RID", SqlDbType.Int));
            cmd.Parameters["@MID"].Value = rid;

            cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Major"].Value = reason;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Reasons

    //updating Appointments 
    public Boolean UpdateAppointments(int apid, int atid, int sid, int status, string notes)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_APPOINTMENTS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@APID", SqlDbType.Int));
            cmd.Parameters["@APID"].Value = apid;

            cmd.Parameters.Add(new SqlParameter("@ATID", SqlDbType.Int));
            cmd.Parameters["@ATID"].Value = atid;

            cmd.Parameters.Add(new SqlParameter("@SID", SqlDbType.Int));
            cmd.Parameters["@SID"].Value = sid;

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int));
            cmd.Parameters["@Status"].Value = status;

            cmd.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, 200));
            cmd.Parameters["@Notes"].Value = notes;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Appointments

    //updating advisor time
    public Boolean UpdateAdvisorTimes(int atid, DateTime date, DateTime time, int aid, int valid)
    {
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_ADVISOR_TIMES", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ATID", SqlDbType.Int));
            cmd.Parameters["@ATID"].Value = atid;

            cmd.Parameters.Add(new SqlParameter("@AvaDate", SqlDbType.Date));
            cmd.Parameters["@AvaDate"].Value = date;

            cmd.Parameters.Add(new SqlParameter("@AvaTime", SqlDbType.Int));
            cmd.Parameters["@AvaTime"].Value = time;

            cmd.Parameters.Add(new SqlParameter("@AID", SqlDbType.Int));
            cmd.Parameters["@AID"].Value = aid;

            cmd.Parameters.Add(new SqlParameter("@Valid", SqlDbType.Int));
            cmd.Parameters["@Valid"].Value = valid;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Advisor time

    //updating Advisors 
    public Boolean UpdateAdvisors(int aid, string advfname, string advlname, string username, string password, int status, int active)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_ADVISOR", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@AID", SqlDbType.Int));
            cmd.Parameters["@AID"].Value = aid;

            cmd.Parameters.Add(new SqlParameter("@AdvFName", SqlDbType.Int));
            cmd.Parameters["@AdvFName"].Value = advfname;

            cmd.Parameters.Add(new SqlParameter("@AdvLName", SqlDbType.Int));
            cmd.Parameters["@AdvLName"].Value = advlname;

            cmd.Parameters.Add(new SqlParameter("@AdvUserName", SqlDbType.NVarChar, 25));
            cmd.Parameters["@AdvUserName"].Value = username;

            cmd.Parameters.Add(new SqlParameter("@AdvPassword", SqlDbType.NVarChar, 50));
            cmd.Parameters["@AdvPassword"].Value = password;

            cmd.Parameters.Add(new SqlParameter("@AdvStatus", SqlDbType.Int));
            cmd.Parameters["@AdvStatus"].Value = status;

            cmd.Parameters.Add(new SqlParameter("@AdvActive", SqlDbType.Int));
            cmd.Parameters["@AdvActive"].Value = active;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Advisors

    public Boolean UpdateAdvisor(int aid, string advfname, string advlname)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_ADVISORS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@AID", SqlDbType.Int));
            cmd.Parameters["@AID"].Value = aid;

            cmd.Parameters.Add(new SqlParameter("@AdvFName", SqlDbType.Int));
            cmd.Parameters["@AdvFName"].Value = advfname;

            cmd.Parameters.Add(new SqlParameter("@AdvLName", SqlDbType.Int));
            cmd.Parameters["@AdvLName"].Value = advlname;

           
            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Advisors

    //updating Students
    public Boolean UpdateStudents(int sid, string stufname, string stulname, string email, string phone)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_UPDATE_STUDENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@SID", SqlDbType.Int));
            cmd.Parameters["@SID"].Value = sid;

            cmd.Parameters.Add(new SqlParameter("@StuFName", SqlDbType.NVarChar,50));
            cmd.Parameters["@StuFName"].Value = stufname;

            cmd.Parameters.Add(new SqlParameter("@StuLName", SqlDbType.NVarChar,50));
            cmd.Parameters["@StuLName"].Value = stulname;

            cmd.Parameters.Add(new SqlParameter("@StuEmail", SqlDbType.NVarChar, 80));
            cmd.Parameters["@StuEmail"].Value = email;

            cmd.Parameters.Add(new SqlParameter("@StuPhone", SqlDbType.NVarChar, 50));
            cmd.Parameters["@StuPhone"].Value = phone;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Update Students

    //////////////////////////////////////////////////////////////////////////////////
    //                         DELETE METHODS
    //////////////////////////////////////////////////////////////////////////////////

    public Boolean DeleteAppointments(int apid)
    {

        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_DELETE_APPOINTMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@APID", SqlDbType.Int));
            cmd.Parameters["@APID"].Value = apid;

            cmd.ExecuteNonQuery();
            return true;

        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();

        }

    }//end of Delete Appointments

}



