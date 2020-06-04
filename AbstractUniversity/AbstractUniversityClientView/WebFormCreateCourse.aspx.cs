using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Unity;
using System.Web.UI.WebControls;
using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Enums;
using System.Drawing;

namespace AbstractUniversityClientView
{
    public partial class WebFormCreateCourse : System.Web.UI.Page
    {
        private readonly ICourseLogic logicC = Program.Container.Resolve<CourseLogic>();
        private readonly IDisciplineLogic logicD = Program.Container.Resolve<DisciplineLogic>();
        private List<DisciplineCourseViewModel> DisciplineCourses;
        private int id;
        private int price;
        private DisciplineCourseViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CourseViewModel view = logicC.GetCourse(id);
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
            else
            {
                this.DisciplineCourses = new List<DisciplineCourseViewModel>();

            }
            if (Session["SEId"] != null)
            {
                if ((Session["SEIs"] != null) && (Session["Change"].ToString() != "0"))
                {
                    model = new DisciplineCourseViewModel
                    {
                        Id = (int)Session["SEId"],
                        CourseId = (int)Session["SECourseId"],
                        DisciplineId = (int)Session["SEDisciplineId"],
                        DisciplineName = (string)Session["SEDisciplineName"],
                        Count = (int)Session["SECount"]
                    };
                    this.DisciplineCourses[(int)Session["SEIs"]] = model;
                    Session["Change"] = "0";
                }
                else
                {
                    model = new DisciplineCourseViewModel
                    {
                        CourseId = (int)Session["SECourseId"],
                        DisciplineId = (int)Session["SEDisciplineId"],
                        DisciplineName = (string)Session["SEDisciplineName"],
                        Count = (int)Session["SECount"]
                    };
                    this.DisciplineCourses.Add(model);
                }
                Session["SEId"] = null;
                Session["SECourseId"] = null;
                Session["SEDisciplineId"] = null;
                Session["SEDisciplineName"] = null;
                Session["SEStatus"] = null;
                Session["SECount"] = null;
                Session["SEIs"] = null;
            }
            List<DisciplineCourseBindingModel> disciplineCourses = new List<DisciplineCourseBindingModel>();
            for (int i = 0; i < this.DisciplineCourses.Count; ++i)
            {
                disciplineCourses.Add(new DisciplineCourseBindingModel
                {
                    Id = this.DisciplineCourses[i].Id,
                    CourseId = this.DisciplineCourses[i].CourseId,
                    DisciplineId = this.DisciplineCourses[i].DisciplineId,
                    DisciplineName = this.DisciplineCourses[i].DisciplineName,
                    Count = this.DisciplineCourses[i].Count
                });
            }
            if (disciplineCourses.Count != 0)
            {
                CalcSum();
                string name = "Введите название";
                if (TextBoxName.Text.Length != 0)
                {
                    name = TextBoxName.Text;
                }
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    logicC.CreateOrUpdate(new CourseBindingModel
                    {
                        Id = id,
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        Name = name,
                        Price = price,
                        Status = CourseStatus.Выполняется,
                        DisciplineCourses = disciplineCourses
                    });
                }
                else
                {
                    logicC.CreateOrUpdate(new CourseBindingModel
                    {
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        Name = name,
                        Price = price,
                        Status = CourseStatus.Выполняется,
                        DisciplineCourses = disciplineCourses
                    });
                    Session["id"] = logicC.Read(null).Last().Id.ToString();
                    Session["Change"] = "0";
                }
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (DisciplineCourses != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = DisciplineCourses;
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void CalcSum()
        {
            if (DisciplineCourses.Count != 0)
            {
                try
                {
                    price = 0;
                    for (int i = 0; i < DisciplineCourses.Count; i++)
                    {
                        DisciplineViewModel discipline = logicD.Read(new DisciplineBindingModel
                        {
                            Id =
                    id
                        })?[0];
                        price += Convert.ToInt32(discipline.Price * DisciplineCourses[i].Count);
                    }
                    TextBoxPrice.Text = price.ToString();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormCourseDiscipline.aspx");
        }

        protected void dataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            if (DisciplineCourses == null || DisciplineCourses.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Добавьте дисциплины');</script>");
                return;
            }
            try
            {
                List<DisciplineCourseBindingModel> disciplineCourses = new List<DisciplineCourseBindingModel>();
                for (int i = 0; i < DisciplineCourses.Count; ++i)
                {
                    disciplineCourses.Add(new DisciplineCourseBindingModel
                    {
                        Id = DisciplineCourses[i].Id,
                        CourseId = DisciplineCourses[i].CourseId,
                        DisciplineId = DisciplineCourses[i].DisciplineId,
                        DisciplineName = DisciplineCourses[i].DisciplineName,
                        Count = DisciplineCourses[i].Count
                    });
                }
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    logicC.CreateOrUpdate(new CourseBindingModel
                    {
                        Id = id,
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        Name = TextBoxName.Text,
                        Price = Convert.ToInt32(TextBoxPrice.Text),
                        Status = CourseStatus.Выполняется,
                        DisciplineCourses = disciplineCourses
                    });
                }
                Session["id"] = null;
                Session["Change"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Response.Redirect("/WebFormMain.aspx");
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

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                model = logicC.GetCourse(id).DisciplineCourses[dataGridView.SelectedIndex];
                Session["SEId"] = model.Id;
                Session["SECourseId"] = model.CourseId;
                Session["SEDisciplineId"] = model.DisciplineId;
                Session["SEDisciplineName"] = model.DisciplineName;
                Session["SEStatus"] = logicC.GetCourse(id).Status;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Session["Change"] = "0";
                Response.Redirect("/WebFormCourseDiscipline.aspx");
            }
        }

    }
}