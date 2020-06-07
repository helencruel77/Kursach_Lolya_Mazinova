using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation.Implements;
using AbstractUniversityBusinessLogic.BindingModels;
using System;
using System.Windows.Forms;
using Unity;
using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.HelperModels;

namespace AbstractUniversity
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly ICourseLogic сourseLogic;
        private readonly ReportLogic reportLogic;
        private readonly BackUpAbstractLogic backUpAbstractLogic;

        public FormMain(MainLogic logic, ReportLogic reportLogic, BackUpAbstractLogic backUpAbstractLogic, ICourseLogic сourseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.reportLogic = reportLogic;
            this.сourseLogic = сourseLogic;
            this.backUpAbstractLogic = backUpAbstractLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = сourseLogic.Read(null);
                if (list != null)
                {
                    //dataGridView.DataSource = list;
                 //   dataGridView.Columns[0].Visible = false;
                //    dataGridView.Columns[1].Visible = false;
                //    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void местоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlaces>();
            form.ShowDialog();
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDisciplines>();
            form.ShowDialog();
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }

        private void buttonCreateRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateRequest>();
            form.ShowDialog();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }            
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }
    }
}
