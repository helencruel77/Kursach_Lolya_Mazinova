using AbstractUniversityBusinessLogic.Interfaces;
using System;
using System.Web.UI;
using AbstractUniversityImplementation.Implements;
using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityClientView.App_Start;
using Unity;
using System.Text.RegularExpressions;

namespace AbstractUniversityClientView
{
    public partial class WebFormRegister : System.Web.UI.Page
    {
        private readonly IClientLogic logic = Program.Container.Resolve<ClientLogic>();
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 10;

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
                if (password.Length > _passwordMaxLength
               || password.Length < _passwordMinLength
               || !Regex.IsMatch(password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Пароль должен быть длиной от 10 до 50 и должен состоять из цифр, букв и небуквенных символов');</script>");
                }
                else if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Электронная почта указана неверно');</script>");

                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) 
                && !string.IsNullOrEmpty(password))
                     {
                        logic.CreateOrUpdate(new ClientBindingModel
                        {
                            ClientName = name,
                            ClientLastName = lastName,
                            Login = email,
                            Email = email,
                            Password = password
                        });
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Регистрация прошла успешно');</script>");
                        Response.Redirect("/WebFormEnter.aspx");
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

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormEnter.aspx");
        }


    }
}