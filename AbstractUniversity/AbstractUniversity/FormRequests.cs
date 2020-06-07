using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.HelperModels;
using AbstractUniversityBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractUniversity
{
    public partial class FormRequests : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestLogic logic;
        public FormRequests(IRequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormRequests_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[4].Visible = false;
                    dataGridView.Columns[5].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequest>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRequest>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                    try
                    {
                        logic.Delete(new RequestBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSendReportWord_Click(object sender, EventArgs e)
        {
            string path = "D:\\улгту 2 курс\\2 СЕМЕСТРР\\тп\\курсач\\Отчет по заявкам.docx";


            MailLogic.MailSend(new MailSendInfo
            {
                MailAddress = "olgailina1003@gmail.com",
                Subject = $"Оповещение по заявке",
                Text = $"Поступила заявка на места",
                Path = path

            }); ;
            MessageBox.Show("Отчет отправлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSendReportExcel_Click(object sender, EventArgs e)
        {
            string path = "D:\\улгту 2 курс\\2 СЕМЕСТРР\\тп\\курсач\\Отчет по заявкам.xlsx";

            MailLogic.MailSend(new MailSendInfo
            {
                MailAddress = "olgailina1003@gmail.com",
                Subject = $"Оповещение по заявке",
                Text = $"Поступила заявка на места",
                Path = path

            }); ;
            MessageBox.Show("Отчет отправлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
