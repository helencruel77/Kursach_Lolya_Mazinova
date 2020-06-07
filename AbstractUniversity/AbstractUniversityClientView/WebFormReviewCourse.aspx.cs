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
    public partial class WebFormReviewCourse : System.Web.UI.Page
    {
        private readonly ICourseLogic logic = Program.Container.Resolve<CourseLogic>();

        private List<DisciplineCourseViewModel> DisciplineCourses;

        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CourseViewModel view = logic.GetCourse(id);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            TextBoxName.Text = view.CourseName;
                            TextBoxPrice.Text = view.Price.ToString();
                        }
                        this.DisciplineCourses = view.DisciplineCourses;
                        LoadData();
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        private void LoadData()
        {
            try
            {
                if (DisciplineCourses != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = DisciplineCourses;
                    dataGridView.DataBind();
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormMain.aspx");
        }
    }
}