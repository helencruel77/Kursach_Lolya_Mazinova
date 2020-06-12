using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace AbstractUniversityClientView
{
    public partial class WebFormReviewDiscipline : System.Web.UI.Page
    {
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    if (!Page.IsPostBack)
                    {
                        TextBoxName.Text = Session["SEDisciplineName"].ToString();
                        TextBoxCount.Text = Session["Price"].ToString();
                        TextBoxPrice.Text = Session["SECount"].ToString();
                    }
                    
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormCreateCourse.aspx");
        }
    }
}