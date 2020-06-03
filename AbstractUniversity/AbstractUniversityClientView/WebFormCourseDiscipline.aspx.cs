using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace AbstractUniversityClientView
{
    public partial class WebFormCourseDiscipline : System.Web.UI.Page
    {
        private readonly IDisciplineLogic serviceD = Program.Container.Resolve<DisciplineLogic>();
        private DisciplineCourseViewModel model;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    List<DisciplineViewModel> listD = serviceD.GetClientList(Convert.ToInt32(Session["PatientId"]));
                    if (listD != null)
                    {
                        DropDownList.DataSource = listD;
                        DropDownList.DataBind();
                        DropDownList.DataTextField = "DisciplineName";
                        DropDownList.DataValueField = "Id";
                    }
                    Page.DataBind();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownList.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите ингредиент');</script>");
                return;
            }
            try
            {
                if (Session["SEId"] == null)
                {
                    model = new DisciplineCourseViewModel
                    {
                        DisciplineId = Convert.ToInt32(DropDownList.SelectedValue),
                        DisciplineName = DropDownList.SelectedItem.Text,
                        Count = Convert.ToInt32(TextBoxCount.Text)
                    };
                    Session["SEId"] = model.Id;
                    Session["SECourseId"] = model.CourseId;
                    Session["SEDisciplineId"] = model.DisciplineId;
                    Session["SEDisciplineName"] = model.DisciplineName;
                    Session["SECount"] = model.Count;
                }
                else
                {
                    model.Count = Convert.ToInt32(TextBoxCount.Text);
                    Session["SEId"] = model.Id;
                    Session["SECourseId"] = model.CourseId;
                    Session["SEDisciplineId"] = model.DisciplineId;
                    Session["SEDisciplineName"] = model.DisciplineName;
                    Session["SECount"] = model.Count;
                    Session["Change"] = "1";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Response.Redirect("FormCreateTreatment.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCreateCourse.aspx");
        }

        protected void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void CalcSum()
        {
            if (DropDownList.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(DropDownList.SelectedValue);
                    DisciplineViewModel prescription = serviceD.GetElement(id);
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxSum.Text = (count * prescription.Price).ToString();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}