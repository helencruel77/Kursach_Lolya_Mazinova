﻿using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
                dataGridView.Columns[1].Visible = false;
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
    }
}