using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSFI.GLEntries.App_Code.BusinessEntities;
using CSFI.GLEntries.App_Code.BusinessManager;
using CSFI.GLEntries.App_Code.DataAccess;
using CSFI.GLEntries.App_Code.Enum;
using System.Configuration;

namespace CSFI.GLEntries
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["isValid"] = String.Empty;
            Session["fullname"] = String.Empty;
            Session["email"] = String.Empty;
            Session["member_id"] = String.Empty;
            Session["UserType"] = String.Empty;
            Session["levelNo"] = String.Empty;

            divSuccess.Visible = false;
            divError.Visible = false;
        }


        public void ShowStatus(string message, bool is_success)
        {
            if (is_success == true)
            {
                divSuccess.InnerText = message;
                divSuccess.Visible = true;
                divError.InnerText = String.Empty;
                divError.Visible = false;
            }
            else
            {
                divError.InnerText = message;
                divError.Visible = true;
                divSuccess.InnerText = String.Empty;
                divSuccess.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == String.Empty)
            {
                ShowStatus("Username is required.", false);
                txtUsername.Focus();
                return;
            }

            if (txtPassword.Text == String.Empty)
            {
                ShowStatus("Password is required.", false);
                txtPassword.Focus();
                return;
            }

            User userDetails = new User();

            userDetails.Username = txtUsername.Text;
            userDetails.Password = txtPassword.Text;

            UserDA userDA = new UserDA(userDetails);
            switch (userDA.Authenticate(userDetails, txtPassword.Text))
            {
                case Authentication.IsNotFound:
                    ShowStatus("Sorry. We can't find your account.", false);
                    break;
                case Authentication.IsActive:
                    ShowStatus("Sorry. Your account is inactive. Please contact kjmagracia@contis.ph to activate account.", false);//enterpriseit@contis.ph
                    break;
                case Authentication.IsSuccessful:
                    //referrerDA.Update(referrer);

                    //Session["referrerID"] = referrer.ReferrerId;
                    //Session["employeeCode"] = referrer.EmployeeCode;
                    //Session["fullname"] = String.Format("{0} {1}", referrer.Firstname, referrer.Lastname);
                    //Session["username"] = txtUsername.Text.Trim();
                    //Session["isValid"] = "Yes";

                    Session["userID"] = userDetails.ID;
                    Session["staffCode"] = userDetails.Staff_Code;
                    Session["fullname"] = String.Format("{0} {1}", userDetails.Firstname, userDetails.Lastname);
                    Session["username"] = txtUsername.Text.Trim();
                    Session["isValid"] = "Yes";
                    Session["accessLevel"] = userDetails.Access_Level;
                    Response.Redirect("~/Pages/Dashboard");

                    if (userDetails.IsChangePassword)
                        Response.Redirect("~/Account/Profile");
                    else
                        Response.Redirect("~/Account/ChangePassword?action=activate");

                    break;

                case Authentication.IsFailed:
                    ShowStatus(String.Format("Your username or password is invalid. "), false);
                    break;
                    //Profile profile = new Profile();
                    //profile.email = txtEmail.Text.Trim();

                    //ProfileDA profileDA = new ProfileDA();
                    //profileDA.New(profile);
                    //switch (profileDA.Authenticate(profile, txtPassword.Text))
                    //{
                    //    case ProfileDA.Authentication.IsNotFound:
                    //        ShowStatus("Your email or password is invalid.", false);
                    //        break;
                    //    case ProfileDA.Authentication.IsLocked:
                    //        ShowStatus("Your account is locked out.", false);
                    //        break;
                    //    case ProfileDA.Authentication.IsSuccessful:
                    //        profile.FailedAttempts = 0;
                    //        profileDA.Update(profile);

                    //        Session["member_id"] = profile.MemberID;
                    //        Session["fullname"] = profile.FName;
                    //        Session["email"] = profile.email;
                    //        Session["isValid"] = "Yes";
                    //        Session["UserType"] = profile.UserType;
                    //        Session["level_id"] = profile.level_id;
                    //        Session["levelNo"] = profile.levelNo;
                    //        Response.Redirect("Reports.aspx");
                    //        break;
                    //    case ProfileDA.Authentication.IsFailed:
                    //        profile.FailedAttempts += 1;
                    //        profileDA.Update(profile);
                    //        ShowStatus("Login Failed (" + profile.FailedAttempts.ToString() + ")", false);
                    //        break;
                    //}

            }
        }
    }
}