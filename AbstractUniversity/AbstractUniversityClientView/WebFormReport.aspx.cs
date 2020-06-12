using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.HelperModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.UI;
using Unity;

namespace AbstractUniversityClientView
{
    public partial class WebFormReport : System.Web.UI.Page
    {
        private readonly ReportLogic reportLogic;
        private readonly ICourseLogic logic = Program.Container.Resolve<CourseLogic>();
        ReportBindingModel model;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormMain.aspx");
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDate", "<script>alert('Дата начала должна быть меньше даты окончания');</script>");
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                                            "c " + Calendar1.SelectedDate.ToShortDateString() +
                                            " по " + Calendar2.SelectedDate.ToShortDateString());
                ReportViewer.LocalReport.SetParameters(parameter);
                var dataSource = reportLogic.GetCoursePlace(new ReportBindingModel
                {
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                ReportDataSource source = new ReportDataSource("DataSetCoursePlace");
                ReportViewer.LocalReport.DataSources.Add(source);
                ReportViewer.DataBind();
                string path = "C:\\Users\\helen\\Desktop\\CoursePlace.pdf";
                reportLogic.SaveCoursePlaceToPdfFile(new ReportBindingModel
                {
                    FileName = path,
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });

                logic.SendEmail(Session["Login"].ToString(), "Курсы клиента", "Отчет в формате pdf", path);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}