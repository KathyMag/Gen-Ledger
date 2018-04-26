using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using Elmah;
using CSFI.GLEntries.App_Code.BusinessEntities;
using CSFI.GLEntries.App_Code.BusinessManager;
using CSFI.GLEntries.App_Code.Enum;
using CSFI.GLEntries.App_Code.Utility;

namespace CSFI.GLEntries.App_Code.DataAccess
{
    /// <summary>
    /// Summary description for UserDa
    /// </summary>
    public class UserDA
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SBUINVConnectionString"].ToString();
        private static SqlDataReader reader;
        private User user;    
       

        //public static string GetUserName(User user)
        public UserDA(User user)
        {
            SqlConnection conn;
            SqlCommand cmd;

            conn = new SqlConnection(connectionString);
            //string test = HashString.Encrypt(user.Password);
            //test = HashString.Decrypt(test);
            try
            {
                if (conn.State == ConnectionState.Closed)
                conn.Open();

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDetails_UserName";
                cmd.Parameters.AddWithValue("@username", user.Username);
                //cmd.Parameters.AddWithValue("@password", user.Password);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {                    
                    reader.Read();
                    user.ID = DBNull.Value.Equals(Convert.ToInt16(reader["id"])) ? 0 : Convert.ToInt16(reader["id"]);
                    user.Username = DBNull.Value.Equals(Convert.ToString(reader["username"])) ? String.Empty : Convert.ToString(reader["username"]);
                    user.Password = DBNull.Value.Equals(Convert.ToString(reader["password"])) ? String.Empty : Convert.ToString(reader["password"]);
                    user.Email_Address = DBNull.Value.Equals(Convert.ToString(reader["email_address"])) ? String.Empty : Convert.ToString(reader["email_address"]);
                    user.Staff_Code = DBNull.Value.Equals(Convert.ToString(reader["staff_code"])) ? String.Empty : Convert.ToString(reader["staff_code"]);
                    user.Firstname = DBNull.Value.Equals(Convert.ToString(reader["firstname"])) ? String.Empty : Convert.ToString(reader["firstname"]);
                    user.Lastname = DBNull.Value.Equals(Convert.ToString(reader["lastname"])) ? String.Empty : Convert.ToString(reader["lastname"]);
                    user.Is_Active = DBNull.Value.Equals(Convert.ToBoolean(reader["is_active"])) ? false : Convert.ToBoolean(reader["is_active"]);
                    user.Access_Level = DBNull.Value.Equals(Convert.ToInt16(reader["access_level"])) ? 0 : Convert.ToInt16(reader["access_level"]);
                }
                

                this.user = user;

                //conn.Close();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            finally
            {
                System.GC.Collect();
            }
        }

        public Authentication Authenticate(User userDetails, string inputtedPassword)
        {
            if (!reader.HasRows)
                return Authentication.IsNotFound;
            //else if (userDetails.Is_Locked)
            //    return Authentication.IsActive;
            else if (userDetails.Is_Active == false)
                return Authentication.IsActive;
            else if (String.Compare(HashString.Decrypt(userDetails.Password), inputtedPassword) == 0)
                return Authentication.IsSuccessful;
            else
                return Authentication.IsFailed;
        }

        //public bool Update(User userDetails)
        //{
        //    SqlConnection conn;
        //    SqlCommand cmd;

        //    try
        //    {
        //        conn = new SqlConnection(connectionString);
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();

        //        cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "AXA.Update_Referrer";
        //        cmd.Parameters.AddWithValue("@firstname", userDetails.Firstname);
        //        cmd.Parameters.AddWithValue("@lastname", referrer.Lastname);
        //        cmd.Parameters.AddWithValue("@birthDate", referrer.BirthDate);
        //        cmd.Parameters.AddWithValue("@gender", referrer.Gender);
        //        cmd.Parameters.AddWithValue("@emailAddress", referrer.EmailAddress);
        //        cmd.Parameters.AddWithValue("@mobilePhoneNumber", referrer.MobilePhoneNumber);
        //        cmd.Parameters.AddWithValue("@employeeCode", referrer.EmployeeCode);
        //        cmd.Parameters.AddWithValue("@bankBranchCode", referrer.BankBranchCode);
        //        cmd.Parameters.AddWithValue("@positionName", referrer.PositionName);
        //        cmd.Parameters.AddWithValue("@modifiedBy", referrer.ModifiedId);
        //        cmd.Parameters.AddWithValue("@referrerId", referrer.ReferrerId);
        //        cmd.Parameters.AddWithValue("@isActive", referrer.IsActive);
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorSignal.FromCurrentContext().Raise(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        System.GC.Collect();

        //    }
        //}

    }
}