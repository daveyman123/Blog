using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DavidsBlog
{
    public partial class displayPost : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = BlogPosts.getPosts();
                drpPosts.DataSource = ds;
                drpPosts.DataTextField = ds.Tables[0].Columns["PostTitle"].ToString();
                drpPosts.DataValueField = ds.Tables[0].Columns["PostId"].ToString();
                drpPosts.DataBind();
            }
        }
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            DataSet dat = BlogPosts.getPost(Convert.ToInt32(drpPosts.SelectedValue));
            frmPosts.DataSource = dat;
            frmPosts.DataBind();
            getcomms();

        }

        protected void getcomms()
        {
            DataSet ds = Comments.GetComments(Convert.ToInt32(drpPosts.SelectedValue));
            rptComments.DataSource = ds;
            rptComments.DataBind();
        }
        protected void btnAddComm_Click(object sender, EventArgs e)
        {
            Comments.addComment(Convert.ToInt32(drpPosts.SelectedValue), txtName.Text, txtComm.Text);
            getcomms();
        }


    }
}