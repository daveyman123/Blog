using System;

using System.Data;

using System.Data.SqlClient;
namespace DavidsBlog
{
    public class Comments
    {
        public static string connectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "daveyman123.database.windows.net";
            builder.UserID = "daveyman123";
            builder.Password = "dJGTT901";
            builder.InitialCatalog = "daveyman123";
            string connString = builder.ConnectionString;

            return connString;


        }
        public static DataSet GetComments(int post)
        {
            SqlConnection con = new SqlConnection(connectionString());
            SqlCommand cmd = new SqlCommand("dbo.displayComments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.Parameters.Add(new SqlParameter("@PostId", SqlDbType.Int));
            cmd.Parameters["@PostId"].Value = post;

            DataSet dSet = new DataSet();
            try
            {
                con.Open();
                adp.Fill(dSet, "Comments");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                con.Close();
            }
            return dSet;
        }

        public static void addComment(int post, string name, string com)
        {
            SqlConnection con = new SqlConnection(connectionString());
            SqlCommand cmd = new SqlCommand("dbo.addComment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@postId", SqlDbType.Int));
            cmd.Parameters["@postId"].Value = post;
            cmd.Parameters.Add(new SqlParameter("@cName", SqlDbType.VarChar, 150));
            cmd.Parameters["@cName"].Value = name;
            cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, -1));
            cmd.Parameters["@comment"].Value = com;

            int added = 0;
            try
            {
                con.Open();
                added = cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
