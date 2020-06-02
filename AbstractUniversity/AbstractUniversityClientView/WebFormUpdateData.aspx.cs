using AbstractUniversityBusinessLogic.BindingModels;
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
    public partial class WebFormUpdateData : System.Web.UI.Page
    {
        private readonly IClientLogic logic = Program.Container.Resolve<ClientLogic>();
        public int Id { set { id = value; } }
        private int? id;

        //private int id;
        // private List<ClientViewModel> Clients;

        protected void Page_Load(object sender, EventArgs e)
        {

           /* if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    ClientViewModel view = logic.GetClient(id);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            TextBoxName.Text = view.ClientName;
                            TextBoxLastName.Text = view.ClientLastName;
                            TextBoxEmail.Text = view.Email;
                            TextBoxPassword.Text = view.Password;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
            */
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormMain.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////////доделать обновление
            try
            {
                if (!string.IsNullOrEmpty(TextBoxLastName.Text) 
                    && !string.IsNullOrEmpty(TextBoxName.Text) 
                    && !string.IsNullOrEmpty(TextBoxEmail.Text) 
                    && !string.IsNullOrEmpty(TextBoxPassword.Text))
                {
                    logic.CreateOrUpdate(new ClientBindingModel
                    {
                        ClientName = TextBoxName.Text,
                        ClientLastName = TextBoxLastName.Text,
                        Login = TextBoxEmail.Text,
                        Email = TextBoxEmail.Text,
                        Password = TextBoxPassword.Text
                    });
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Обновление прошло успешно');</script>");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните все поля');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}