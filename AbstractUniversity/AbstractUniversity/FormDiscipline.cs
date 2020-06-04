using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
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
    public partial class FormDiscipline : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDisciplineLogic logic;
        private int? id;
        private List<PlaceDisciplineViewModel> placeDisciplines;
        public FormDiscipline(IDisciplineLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormDiscipline_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DisciplineViewModel view = logic.Read(new DisciplineBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.DisciplineName;
                        textBoxPrice.Text = view.Price.ToString();
                        placeDisciplines = view.PlaceDisciplines;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxPrice.Text = "0";

                placeDisciplines = new List<PlaceDisciplineViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (placeDisciplines != null)
                {
                    dataGridViewDiscipline.DataSource = null;
                    dataGridViewDiscipline.DataSource = placeDisciplines;
                    dataGridViewDiscipline.Columns[0].Visible = false;
                    dataGridViewDiscipline.Columns[1].Visible = false;
                    dataGridViewDiscipline.Columns[2].Visible = false;
                    dataGridViewDiscipline.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
   MessageBoxIcon.Error);
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (placeDisciplines == null || placeDisciplines.Count == 0)
            {
                MessageBox.Show("Заполните места", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<PlaceDisciplineBindingModel> placeDisciplinePD = new List<PlaceDisciplineBindingModel>();
                for (int i = 0; i < placeDisciplines.Count; ++i)
                {
                    placeDisciplinePD.Add(new PlaceDisciplineBindingModel
                    {
                        Id = placeDisciplines[i].Id,
                        PlaceId = placeDisciplines[i].PlaceId,
                        DisciplineId = placeDisciplines[i].DisciplineId,
                        Count = placeDisciplines[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new DisciplineBindingModel
                    {
                        Id = id.Value,
                        DisciplineName = textBoxName.Text,
                        Price = Int32.Parse(textBoxPrice.Text),
                        PlaceDisciplines = placeDisciplinePD
                    });
                }
                else
                {
                    logic.AddElement(new DisciplineBindingModel
                    {
                        DisciplineName = textBoxName.Text,
                        Price = Int32.Parse(textBoxPrice.Text),
                        PlaceDisciplines = placeDisciplinePD
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiscipline.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        placeDisciplines..RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiscipline.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPlaceDiscipline>();
                int id = Convert.ToInt32(dataGridViewDiscipline.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = placeDisciplines[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    placeDisciplines[form.Id] = (form.TypePlace, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlaceDiscipline>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (placeDisciplines.ContainsKey(form.Id))
                {
                    placeDisciplines[form.Id] = (form.TypePlace, form.Count);
                }
                else
                {
                    placeDisciplines.Add(form.Id, (form.TypePlace, form.Count));
                }
                LoadData();
            }
        }
    }
}