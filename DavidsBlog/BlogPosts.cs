using System;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace Blog
{
    public class BlogPosts
    {
        public static string connectionString()
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["BlogDatabase"];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;

        }
        public static DataSet getPosts()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString());
            SqlCommand cmd = new SqlCommand("dbo.displayPosts", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                adp.Fill(ds, "Posts");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                con.Close();
            }


            return ds;
        }
        public static DataSet getPost(int postident)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString());
            SqlCommand cmd = new SqlCommand("dbo.displayPost", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@postId", SqlDbType.Int));
            cmd.Parameters["@postId"].Value = postident;
            try
            {
                con.Open();
                adp.Fill(ds, "Post");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                con.Close();
            }


            return ds;
        }


        public static void addPost(string title, string cont, string auth)
        {
            SqlConnection con = new SqlConnection(connectionString());
            SqlCommand cmd = new SqlCommand("dbo.addPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pTitle", SqlDbType.VarChar, 200));
            cmd.Parameters["@pTitle"].Value = title;
            cmd.Parameters.Add(new SqlParameter("@pContent", SqlDbType.NVarChar, -1));
            cmd.Parameters["@pContent"].Value = cont;
            cmd.Parameters.Add(new SqlParameter("@pAuthor", SqlDbType.VarChar, 150));
            cmd.Parameters["@pAuthor"].Value = auth;
            int added = 0;
            try
            {
                con.Open();
                added = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }
    }
}