using System;
using System.Collections.Generic;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation.Implements;
using AbstractUniversityBusinessLogic.BindingModels;
using System.Windows.Forms;
using Unity;
using AbstractUniversityBusinessLogic.ViewModels;

namespace AbstractUniversity
{
    public partial class FormRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private readonly IRequestLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> requestPlaces;
        public FormRequest(IRequestLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = logic.Read(new RequestBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RequestName;
                        requestPlaces = view.RequestPlaces;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                requestPlaces = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (requestPlaces != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.ColumnCount = 3;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].HeaderText = "Место";
                    dataGridView.Columns[2].HeaderText = "Количество";
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (var rp in requestPlaces)
                    {
                        dataGridView.Rows.Add(new object[] { rp.Key, rp.Value.Item1, rp.Value.Item2 });
                    }
                }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new RequestBindingModel
                {
                    Id = id,
                    RequestName = textBoxName.Text,
                    DateCreate = DateTime.Now

                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
