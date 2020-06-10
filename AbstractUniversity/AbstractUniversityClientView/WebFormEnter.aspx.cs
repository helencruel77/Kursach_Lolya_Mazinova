using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityClientView.App_Start;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using System.Web.UI;
using System.Web.UI.WebControls;
using AbstractUniversityBusinessLogic.ViewModels;
using System.Text.RegularExpressions;

namespace AbstractUniversityClientView
{
    public partial class WebFormEnter : System.Web.UI.Page
    {

        private readonly IClientLogic logic = Program.Container.Resolve<ClientLogic>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormRegister.aspx");
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            String login = TextBoxLogin.Text;
            String password = TextBoxPassword.Text;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                var list = logic.Read(null);
                if (!Regex.IsMatch(login, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('В качестве логина должна быть указана почта');</script>");
                }
                else if (list != null)
                {
                    foreach (ClientViewModel client in list)
                    {
                        if (client.Login.Equals(login) && client.Password.Equals(password))
                        {
                            Session["ClientId"] = client.Id.ToString();
                            Session["Login"] = client.Login;
                            Response.Redirect("/WebFormMain.aspx");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Нет такого пользователя');</script>");
                }
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните все поля');</script>");
            }
        }
    }
}