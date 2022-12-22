using System;
using System.Collections.Generic;

using System.Configuration;

using System.Data;

using System.Data.SqlClient;

using System.IO;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Drawing;



namespace FileManagementSystem

{

    public partial class UploadFiles : System.Web.UI.Page

    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        string filename = string.Empty;

        protected void Page_Load(object sender, EventArgs e)

        {

            if(!IsPostBack)
            {
                bindGridView();
            }



        }



      



        // update button click

        protected void Button3_Click(object sender, EventArgs e)

        {
            try

            {

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)

                {

                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT * from file_table WHERE File_Name='" + TextBox2.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)

                {

                    string filename = dt.Rows[0]["File_Name"].ToString();


                    string myfile = @"~\MyFiles\filename.pdf"; //this wouldn't be a static string 
                    DownloadFile(myfile);











                }

                else

                {

                    Response.Write("<script>alert('Invalid File Name');</script>");

                }



            }

            catch (Exception ex)

            {



            }



        }

        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfFileExists())

            {
                if (Session["UserType"].ToString() == "1")
                {
                    try

                    {

                        SqlConnection con = new SqlConnection(strcon);

                        if (con.State == ConnectionState.Closed)

                        {

                            con.Open();

                        }



                        SqlCommand cmd = new SqlCommand("DELETE from file_table WHERE File_Name='" + TextBox2.Text.Trim() + "'", con);



                        cmd.ExecuteNonQuery();

                        con.Close();

                        Response.Write("<script>alert('File Deleted Successfully');</script>");



                        bindGridView();



                    }

                    catch (Exception ex)

                    {

                        Response.Write("<script>alert('" + ex.Message + "');</script>");

                    }



                }
                else
                {
                    Response.Write("<script>alert('You do not have permission to delete this file!!!Contact Admin.');</script>");
                }
            }

            else

            {

                Response.Write("<script>alert('Invalid User Name');</script>");

            }
        }

        // add button click

        protected void Button1_Click(object sender, EventArgs e)

        {

            if (CheckIfFileExists())

            {

                Response.Write("<script>alert('File Already Exists, try some other File');</script>");

            }

            else

            {

                AddNewFile();

            }

        }

      




        // user defined functions







        void DownloadFile(string file)
        {
            var fi = new FileInfo(file);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fi.Name);
            Response.TransmitFile(Server.MapPath("~/file_inventory/" + fi.Name));
            //Response.WriteFile(file);
            Response.End();
        }













        bool CheckIfFileExists()

        {

            try

            {

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)

                {

                    con.Open();

                }



                SqlCommand cmd = new SqlCommand("SELECT * from file_table where File_Name='" + TextBox2.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);



                if (dt.Rows.Count >= 1)

                {

                    return true;

                }

                else

                {

                    return false;

                }





            }

            catch (Exception ex)

            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;

            }

        }



        void AddNewFile()

        {

            try

            {





                string FileName = string.Empty;
                string FilePath = string.Empty;
                string extension = string.Empty;
                

                if (FileUpload1.HasFile)

                {
                    extension = Path.GetExtension(FileUpload1.FileName);
                    FileName = FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~/file_inventory/" + FileName.Trim()));
                    FilePath = @"~/file_inventory/" + FileName.Trim().ToString();
                    
                }
                else
                {
                    Response.Write("<script>alert('Please select a file.');</script>");
                }


                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)

                {

                    con.Open();

                }

                
               
                

                SqlCommand cmd = new SqlCommand("INSERT INTO file_table(File_Name,File_Path,File_type,Date,Ref_ID) values(@file_name,@path,@type,@date,@id)", con);


               
                cmd.Parameters.AddWithValue("@file_name", FileName);

                cmd.Parameters.AddWithValue("@path", FilePath);

                cmd.Parameters.AddWithValue("@type", extension);

                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", Session["ID"]);



                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Response.Write("<script>alert('File added successfully.');</script>");
                    bindGridView();
                }


            }


            catch (Exception ex)

            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void bindGridView()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cma = new SqlCommand("SELECT User_ID from user_table WHERE User_Name ='" + Session["UserName"] + "';", con);
            Session["ID"] = (int)cma.ExecuteScalar();

            con.Close();
            SqlCommand cma1 = new SqlCommand("SELECT * from file_table WHERE Ref_ID ='" + Session["ID"]+ "';", con);

            SqlDataAdapter da = new SqlDataAdapter(cma1);

            DataTable dt = new DataTable();

            da.Fill(dt);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvFiles.DataSource = ds;
            gvFiles.DataBind();
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
         
            
            if(e.CommandName=="Download")
            {


            Response.Clear();
            Response.ContentType = "application/octet-stream";
             
            Response.AppendHeader("Content-Disposition", "attachment,filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/file_inventory/") + e.CommandArgument);
            Response.End();
            }
            
        }

       
     
    }
}