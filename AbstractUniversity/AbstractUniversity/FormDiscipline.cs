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
        private Dictionary<int, (string, int)> placeDisciplines;
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
                placeDisciplines = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (placeDisciplines != null)
                {
                    dataGridViewDiscipline.Rows.Clear();
                    foreach (var pc in placeDisciplines)
                    {
                        dataGridViewDiscipline.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
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
                logic.CreateOrUpdate(new DisciplineBindingModel
                {
                    Id = id,
                    DisciplineName = textBoxName.Text,
                  //  Price = Convert.ToDecimal(textBoxPrice.Text),
                //    PlaceDisciplines = placeDisciplines
                });
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

                        placeDisciplines.Remove(Convert.ToInt32(dataGridViewDiscipline.SelectedRows[0].Cells[0].Value));
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