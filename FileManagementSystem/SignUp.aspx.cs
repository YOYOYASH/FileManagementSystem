using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FileManagementSystem
{
        public partial class SignUp : System.Web.UI.Page
        {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // sign up button click event
        protected void Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_table(User_Name,Date_Of_Birth,Email,Contact_No,Password,UserType_ID) values(@User_name,@dob,@email,@contact_no,@password,@type)", con);
                cmd.Parameters.AddWithValue("@User_name", Box1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", Box2.Text.Trim());

                cmd.Parameters.AddWithValue("@email", Box4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", Box3.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Box9.Text.Trim());
                cmd.Parameters.AddWithValue("@type", Box8.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                Response.Redirect("UserLogin.aspx");
            }
            

               
                
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
