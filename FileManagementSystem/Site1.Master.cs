using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["Role"] != null)
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //sign up
                    LinkButton4.Visible = true;
                    LinkButton3.Visible = true;
                    
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Text = "Hello " + Session["UserName"].ToString();
                    
                }
                else
                {
                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //sign up
                    LinkButton4.Visible = false;
                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false; //hello user

                }

            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadFiles.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["Role"] = null;
            Session["UserType"] = null;
            Response.Redirect("UserLogin.aspx");
        }
    }
}