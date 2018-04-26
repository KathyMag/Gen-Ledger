using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSFI.GLEntries;


namespace CSFI.GLEntries.App_Code.BusinessEntities
{

    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email_Address { get; set; }

        public string Staff_Code { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        //public bool Is_Locked { get; set; }

        public bool Is_Active { get; set; }

        public bool IsChangePassword { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public int CreatedId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int ModifiedId { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int Access_Level { get; set; }

        //private string username;
        //private string password;
        //private string email_address;
        //private bool is_locked;

        //public string UserName
        //{
        //    get { return username; }
        //    set { username = value; }
        //}

        //public string Password
        //{
        //    get { return password; }
        //    set { password = value; }
        //}

        //public string Email_Address
        //{
        //    get { return email_address; }
        //    set { email_address = value; }
        //}

        //public bool Is_Locked
        //{
        //    get { return is_locked; }
        //    set { is_locked = value; }
        //}

    }
}