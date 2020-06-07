using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Unity;
using AbstractUniversityBusinessLogic.BindingModels;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace AbstractUniversityClientView
{
    public partial class WebFormCreateCourse : System.Web.UI.Page
    {
        private readonly ICourseLogic logicC = Program.Container.Resolve<CourseLogic>();
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
                Session["SEIsReserved"] = null;
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
                    logicC.UpdateCourse(new CourseBindingModel
                    {
                        Id = id,
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        CourseName = name,
                        Price = price,
                        isReserved = false,
                        DisciplineCourses = disciplineCourses
                    });
                }
                else
                {
                    logicC.CreateCourse(new CourseBindingModel
                    {
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        CourseName = name,
                        Price = price,
                        isReserved = false,
                        DisciplineCourses = disciplineCourses
                    });
                    Session["id"] = logicC.GetList().Last().Id.ToString();
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
                    dataGridView.DataBind();
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    DisciplineCourses.RemoveAt(dataGridView.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
            }
        }
        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Добавьте рецепты');</script>");
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
                    logicC.UpdateCourse(new CourseBindingModel
                    {
                        Id = id,
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        CourseName = TextBoxName.Text,
                        Price = Convert.ToInt32(TextBoxPrice.Text),
                        isReserved = false,
                        DisciplineCourses = disciplineCourses
                    });
                }
                else
                {
                    logicC.CreateCourse(new CourseBindingModel
                    {
                        ClientId = Int32.Parse(Session["ClientId"].ToString()),
                        CourseName = TextBoxName.Text,
                        Price = Convert.ToInt32(TextBoxPrice.Text),
                        isReserved = false,
                        DisciplineCourses = disciplineCourses
                    });
                }
                Session["id"] = null;
                Session["Change"] = null;
                TextBoxName = null;
                TextBoxPrice = null;
                dataGridView.DataSource = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.Redirect("/WebFormMain.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (logicC.GetList().Count != 0 && logicC.GetList().Last().CourseName == null)
            {
                logicC.Delete(logicC.GetList().Last().Id);
            }
            if (!String.Equals(Session["Change"], null))
            {
                logicC.Delete(id);
            }
            Session["id"] = null;
            Session["Change"] = null;
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
                Session["SEisReserved"] = logicC.GetCourse(id).isReserved;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Session["Change"] = "0";
                Response.Redirect("/WebFormCourseDiscipline.aspx");
            }
        }

        protected void dataGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
                LoadData();
        }

    }
}