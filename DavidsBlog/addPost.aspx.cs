using System;

using System.Data;

using System.Data.SqlClient;

namespace DavidsBlog
{
    public partial class addPost : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


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


        protected void adsf(object sender, EventArgs e)
        {

            var textTitle = txtTitle.Text;
            string textCont = txtCont.Text;
            string textAuth = txtAuth.Text;
            BlogPosts.addPost(textTitle, textCont, textAuth);
        }
    }
}