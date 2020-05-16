using System;
using System.Windows.Forms;
using Unity;


namespace AbstractUniversity
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void местоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlaces>();
            form.ShowDialog();
        }
    }
}
