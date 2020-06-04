using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.HelperModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractUniversity
{
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;

        private readonly IRequestLogic requestLogic;
        private readonly IPlaceLogic placeLogic;
        private readonly ReportLogic reportLogic;

        public FormCreateRequest(MainLogic logic, IRequestLogic requestLogic, ReportLogic reportLogic, IPlaceLogic placeLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.requestLogic = requestLogic;
            this.placeLogic = placeLogic;
            this.reportLogic = reportLogic;

        }
        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                List<PlaceViewModel> list = placeLogic.Read(null);
                if (list != null)
                {
                    comboBoxTypePlace.DisplayMember = "TypePlace";
                    comboBoxTypePlace.ValueMember = "Id";
                    comboBoxTypePlace.DataSource = list;
                    comboBoxTypePlace.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                List<RequestViewModel> list = requestLogic.Read(null);
                if (list != null)
                {
                    comboBoxRequest.DisplayMember = "RequestName";
                    comboBoxRequest.ValueMember = "Id";
                    comboBoxRequest.DataSource = list;
                    comboBoxRequest.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxTypePlace.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип места", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxRequest.SelectedValue == null)
            {
                MessageBox.Show("Выберите заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateRequest(new RequestPlaceBindingModel
                {
                    Id = 0,
                    PlaceId = Convert.ToInt32(comboBoxTypePlace.SelectedValue),
                    RequestId = Convert.ToInt32(comboBoxRequest.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                string path = "D:\\улгту 2 курс\\2 СЕМЕСТРР\\тп\\курсач\\Отчет по заявкам.docx";
                string path1 = "D:\\улгту 2 курс\\2 СЕМЕСТРР\\тп\\курсач\\Отчет по заявкам.xlsx";

                try
                {
                    reportLogic.SaveProductsToWordFile(new ReportBindingModel
                    {
                        FileName = path,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddMilliseconds(100)
                    });

                    reportLogic.SaveRequestPlaceToExcelFile(new ReportBindingModel
                    {
                        FileName = path1,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddMilliseconds(100)
                    });


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
