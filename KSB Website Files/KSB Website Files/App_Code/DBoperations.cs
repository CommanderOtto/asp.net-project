using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;


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
    public static int GetOneInt(string sql)
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
    public static Boolean SecureVerifyStudent(string email, string pwd)
    {
        try
        {
            con.Open();

            /*
            create procedure SP_SecureVerifyStudent
            @em nvarchar(100),
            @pwd nvarchar(50),
            @count int OUTPUT
            As
            set @count = (select count(*) from customer where email = @em and pwd=@pwd);
            */

            SqlCommand cmd = new SqlCommand("SP_VerifyStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@em", SqlDbType.NVarChar, 100));
            cmd.Parameters["@em"].Value = email;

            cmd.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar, 50));
            cmd.Parameters["@pwd"].Value = pwd;

            cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int, 4));
            cmd.Parameters["@count"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            //int c = (int)cmd.ExecuteScalar();
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



    //function used to create accounts.
    public static Boolean CreateAccount(string FirstName, string LastName,string Major, string Email, string Phone)
    {
        try
        {
            con.Open();

            //Create procedure SP_CreateAccount
            //(
            //@firstname Varchar(50),
            //@lastname varchar(50),
            //@Major Varchar(50),
            //@Email Varchar(50),
            //@Phone Varchar(50),

            //)
            //as
            //begin
            //Insert into Student(FirstName,LastName,Major,Email,Phone) values(@firstname,@lastname,@major,@email,@phone)
            //End



            //make sure datatypes are the same througout app and database.
            //below, instructions to work with stored procedure.
            SqlCommand cmd = new SqlCommand("SP_CreateAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar, 50));
            cmd.Parameters["@firstname"].Value = FirstName;

            cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 50));
            cmd.Parameters["@lastname"].Value = LastName;

            cmd.Parameters.Add(new SqlParameter("@major", SqlDbType.VarChar, 50));
            cmd.Parameters["@major"].Value = Major;

            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
            cmd.Parameters["@email"].Value = Email;

            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 50));
            cmd.Parameters["@phone"].Value = Phone;

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



    //function used to create appointments.
    public static Boolean CreateAppointment(int StudentId, string Reason, string Advisor, string Date, string TimeSlot, string Phone)
    {
        try
        {
            con.Open();

            //CreateAccount will need an out parameter to store the ID and pass it on to CreateAppointment

            //Create procedure SP_CreateAppointment
            //(
            //@studentid int(50),
            //@reason Varchar(50),
            //@advisor varchar(50),
            //@date Varchar(50),
            //@timeSlot Varchar(50),
            //@phone Varchar(50),

            //)
            //as
            //begin
            //Insert into Apppointment(StudentId,Reason,Advisor,Date,TimeSlot,Phone) values(@studentid,@reason,@advisor,@date,@timeslot,@phone)
            //End



            //make sure datatypes are the same througout app and database.
            //below, instructions to work with stored procedure.
            SqlCommand cmd = new SqlCommand("SP_CreateAppointment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@studentid", SqlDbType.VarChar, 50));
            cmd.Parameters["@studentid"].Value = StudentId;

            cmd.Parameters.Add(new SqlParameter("@reason", SqlDbType.VarChar, 50));
            cmd.Parameters["@reason"].Value = Reason;

            cmd.Parameters.Add(new SqlParameter("@advisor", SqlDbType.VarChar, 50));
            cmd.Parameters["@advisor"].Value = Advisor;

            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar, 50));
            cmd.Parameters["@date"].Value = Date;

            cmd.Parameters.Add(new SqlParameter("@timeslot", SqlDbType.VarChar, 50));
            cmd.Parameters["@timeslot"].Value = TimeSlot;

            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 50));
            cmd.Parameters["@phone"].Value = Phone;

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


