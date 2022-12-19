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



namespace FileManagementSystem

{

    public partial class UploadFiles : System.Web.UI.Page

    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)

        {

            GridView1.DataBind();



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

            DeleteFileByID();

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



        void DeleteFileByID()

        {

            if (CheckIfFileExists())

            {
                if(Session["UserType"].ToString() == "1")
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



                    GridView1.DataBind();



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



         void DownloadFile(string file)
        {
            var fi = new FileInfo(file);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fi.Name);
            Response.TransmitFile(Server.MapPath("~/file_inventory/"+ fi.Name));
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





                string filepath = "~/file_inventory/file1.png";

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                FileUpload1.SaveAs(Server.MapPath("file_inventory/" + filename));

                filepath = "~/file_inventory/" + filename;





                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)

                {

                    con.Open();

                }



                SqlCommand cmd = new SqlCommand("INSERT INTO file_table(File_Name,File_Path,File_type,Date) values(@file_name,@path,@type,@date)", con);



                cmd.Parameters.AddWithValue("@file_name", TextBox2.Text.Trim());

                cmd.Parameters.AddWithValue("@path", filepath);

                cmd.Parameters.AddWithValue("@type", "pdf");

                cmd.Parameters.AddWithValue("@date", DateTime.Now);
               


                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('File added successfully.');</script>");

                GridView1.DataBind();



            }

            catch (Exception ex)

            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

       
    }

}