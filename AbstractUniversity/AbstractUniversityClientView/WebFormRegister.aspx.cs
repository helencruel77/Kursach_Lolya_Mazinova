using AbstractUniversityBusinessLogic.Interfaces;
using System;
using System.Web.UI;
using AbstractUniversityImplementation.Implements;
using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityClientView.App_Start;
using Unity;

namespace AbstractUniversityClientView
{
    public partial class WebFormRegister : System.Web.UI.Page
    {
        private readonly IClientLogic service = Program.Container.Resolve<ClientLogic>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                String lastName = TextBoxLastName.Text;
                String name = TextBoxName.Text;
                String email = TextBoxEmail.Text;
                String password = TextBoxPassword.Text;

                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    service.CreateOrUpdate(new ClientBindingModel
                    {
                        ClientName = name,
                        ClientLastName = lastName,
                        Login = email,
                        Email = email,
                        Password = password
                    });
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Регистрация прошла успешно');</script>");

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