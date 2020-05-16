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
    public partial class FormPlaceDiscipline : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxPlace.SelectedValue); }
            set { comboBoxPlace.SelectedValue = value; }
        }
        public string TypePlace { get { return comboBoxPlace.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormPlaceDiscipline(IPlaceLogic logic)
        {
            InitializeComponent();
            List<PlaceViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxPlace.DisplayMember = "TypePlace";
                comboBoxPlace.ValueMember = "Id";
                comboBoxPlace.DataSource = list;
                comboBoxPlace.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPlace.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип места", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();

        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
