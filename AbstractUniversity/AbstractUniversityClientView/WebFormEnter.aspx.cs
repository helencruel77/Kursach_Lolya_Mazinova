using AbstractUniversityImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbstractUniversityClientView
{
    public partial class WebFormEnter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebFormRegister.aspx");
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            AbstractUniversityDatabase db = new AbstractUniversityDatabase();
            var clientLogin = (from client in db.Clients
                               where client.Login = TextBoxLogin.Text
                               select client
                               .ToArray());

        }
    }
}