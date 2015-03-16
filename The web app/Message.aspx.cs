using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The_web_app
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnGetMessages_Click(object sender, EventArgs e)
        {
            BindData();
        }       

        protected void grdViewMessages_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["sortexpression"] = e.SortExpression;

            if (ViewState["sortdirection"] == null)
            {
                ViewState["sortdirection"] = "asc";
            }
            else
            {
                if (ViewState["sortdirection"].ToString() == "asc")
                {
                    ViewState["sortdirection"] = "desc";
                }
                else
                {
                    ViewState["sortdirection"] = "asc";
                }
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                MessageService messageService = new MessageService();
                DataTable dt = messageService.GetAllMessages();
                DataView dv = new DataView(dt);
                if (ViewState["sortexpression"] != null)
                {
                    
                    dv.Sort = ViewState["sortexpression"].ToString()
                    + " " + ViewState["sortdirection"].ToString();
                }
                grdViewMessages.DataSource = dv;
                grdViewMessages.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
            }
        }
    }
}