using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityBusinessLogic.HelperModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Unity;
using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.BindingModels;

namespace AbstractUniversityClientView
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        private readonly ICourseLogic logic = Program.Container.Resolve<CourseLogic>();
        List<CourseViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ButtonChangeData_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormUpdateData.aspx");
        }
        private void LoadData()
        {
            try
            {
                list = logic.GetClientList(Convert.ToInt32(Session["ClientId"]));
                dataGridView.DataSource = list;
                dataGridView.DataBind();
                dataGridView.ShowHeaderWhenEmpty = true;
                dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                dataGridView.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCreateCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormCreateCourse.aspx");
        }


        protected void ButtonReviewCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView.SelectedIndex >= 0) { 
                    string index = list[dataGridView.SelectedIndex].Id.ToString();
                    Session["id"] = index;
                    Response.Redirect("/WebFormReviewCourse.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Курс не выбран');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCourseReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedIndex >= 0)
                {
                    DateTime date = logic.CourseReservation(list[dataGridView.SelectedIndex].Id);
                    LoadData();
                    Response.Redirect("/WebFormMain.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Курс не выбран');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonGetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\Users\\helen\\Desktop\\Courses.docx";
                SaveToWord.CreateDoc(new WordInfo
                {
                    FileName = path,
                    Title = "Дисциплины по курсу",
                    RequestPlaces = null,
                    DisciplineCourses = logic.GetList()
                });
                logic.SendEmail(Session["Login"].ToString(), "Курсы клиента", "Отчет в формате doc", path);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Отчет отправлен на вашу почту');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonGetXls_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\Users\\helen\\Desktop\\Courses.xlsx";
                SaveToExcel.CreateDoc(new ExcelInfo
                {
                    FileName = path,
                    Title = "Дисциплины по курсу",
                    RequestPlaces = null,
                    DisciplineCourses = logic.GetList()
                });
                logic.SendEmail(Session["Login"].ToString(), "Курсы клиента", "Отчет в формате xls", path);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Отчет отправлен на вашу почту');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonGetPdf_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormReport.aspx");
        }
    }
}