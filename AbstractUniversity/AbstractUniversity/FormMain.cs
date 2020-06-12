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
        private readonly IBackUp backUpLogic;

        public FormMain(MainLogic logic, ReportLogic reportLogic, IBackUp backUpAbstractLogic, ICourseLogic сourseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.reportLogic = reportLogic;
            this.сourseLogic = сourseLogic;
            this.backUpLogic = backUpAbstractLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = сourseLogic.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false; 
                    dataGridView.Columns[2].Visible = false;
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
                if (backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpLogic.SaveJsonRequest(fbd.SelectedPath);
                        backUpLogic.SaveJsonRequestPlaces(fbd.SelectedPath);
                        backUpLogic.SaveJsonPlace(fbd.SelectedPath);
                        backUpLogic.SaveJsonPlaceDiscipline(fbd.SelectedPath);
                        backUpLogic.SaveJsonDiscipline(fbd.SelectedPath);
                        MailLogic.MailSendBackUp(new MailSendInfo
                        {
                            MailAddress = "olgailina1003@gmail.com",
                            Subject = $"JSON бекап",
                            Text = $"Бекап",
                            Type = "json",
                            FileName = fbd.SelectedPath

                        });
                        MessageBox.Show("Бекап создан и отправлен на почту", "Сообщение",
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

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpLogic.SaveXmlRequest(fbd.SelectedPath);
                        backUpLogic.SaveXmlRequestPlaces(fbd.SelectedPath);
                        backUpLogic.SaveXmlPlaceDiscipline(fbd.SelectedPath);
                        backUpLogic.SaveXmlDiscipline(fbd.SelectedPath);
                        backUpLogic.SaveXmlPlace(fbd.SelectedPath);
                        MailLogic.MailSendBackUp(new MailSendInfo
                        {
                            MailAddress = "olgailina1003@gmail.com",
                            Subject = $"XML бекап",
                            Text = $"Бекап",
                            Type = "xml",
                            FileName = fbd.SelectedPath

                        });
                        MessageBox.Show("Бекап создан и отправлен на почту", "Сообщение",
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

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
