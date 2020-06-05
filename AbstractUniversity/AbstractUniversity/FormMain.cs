using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation.Implements;
using AbstractUniversityBusinessLogic.BindingModels;
using System;
using System.Windows.Forms;
using Unity;
using AbstractUniversityBusinessLogic.BuisnessLogic;

namespace AbstractUniversity
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly ICourseLogic сourseLogic;
        private readonly ReportLogic reportLogic;


        public FormMain(MainLogic logic, ReportLogic reportLogic, ICourseLogic сourseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.reportLogic = reportLogic;
            this.сourseLogic = сourseLogic;
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

        private void списокЗаказовExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SaveRequestPlaceToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void списокЗаказовWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveProductsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
