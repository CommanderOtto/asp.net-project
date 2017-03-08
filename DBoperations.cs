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


    //function used to verify user credentials for login operation.
    public static Boolean SecureVerifyStudent(string UserName, string Password)
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("KBS_COUNT_STUDENT", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = UserName;

            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Password"].Value = Password;

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



    //function used to create student accounts.
    public static Boolean CreateStudent(string FirstName, string LastName, string Email, string UserName, string Password, int Major, int Guest, string ID, string Phone)
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
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

                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50));
                cmd.Parameters["@Password"].Value = Password;

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


    public static int ReturnStudentID(string username, string password)
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
        try
        {
            con.Open();


            SqlCommand cmd = new SqlCommand("KBS_GET_UID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
            cmd.Parameters["@UserName"].Value = username;

            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Password"].Value = password;

            cmd.Parameters.Add(new SqlParameter("@UID", SqlDbType.Int));
            cmd.Parameters["@UID"].Direction = ParameterDirection.Output;


            cmd.ExecuteNonQuery();

            int UID = (int)cmd.Parameters["@UID"].Value;
            con.Close();

            return UID;

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

    //function used to create appointments.
    public static Boolean CreateAppointment(int StudentId, int AdvisorTime)
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
        try
        {
            con.Open();

       
            SqlCommand cmd = new SqlCommand("KBS_INSERT_APPOINTMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@AdvisorTime", SqlDbType.NVarChar, 50));
            cmd.Parameters["@AdvisorTime"].Value = AdvisorTime;
            cmd.Parameters.Add(new SqlParameter("@Student", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Student"].Value = StudentId;

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50));
            cmd.Parameters["@Status"].Value = 3;

            cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar,200));
            cmd.Parameters["@Note"].Value = "";

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

    public static Boolean CreateAdvisor(string First, string Last, string UserName, string Password, int Status)
    {
        cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        con = new SqlConnection(cs);
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

            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
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
    }//end of CreateAccount



}



