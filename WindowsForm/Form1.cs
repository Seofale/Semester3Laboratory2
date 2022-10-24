using System;
using System.Linq;
using System.Windows.Forms;
using Bl;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.logic = new Logic();
        }

        public Logic logic;

        private void ReloadStudentsListView()
        {
            listView1.Clear();

            foreach (var studentRepr in logic.AllStudents())
            {

                ListViewItem lvi = new ListViewItem();

                lvi.Text = studentRepr;

                listView1.Items.Add(lvi);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadStudentsListView();
        }

        private void ReloadGist()
        {
            if (Application.OpenForms.OfType<Form2>().Count() == 1)
            {
                Application.OpenForms.OfType<Form2>().First().Close();

                Form2 newForm2 = new Form2(logic);

                newForm2.Show();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            logic.AddStudent(NameBox.Text, SpecialityBox.Text, GroupBox.Text);

            ReloadStudentsListView();

            ReloadGist();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            logic.DeleteStudent(int.Parse(listView1.SelectedItems[0].Text.Split(' ')[1].Remove(listView1.SelectedItems[0].Text.Split(' ')[1].Length - 1)));

            ReloadStudentsListView();

            ReloadGist();
        }

        private void buttonViewGraph_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Form2>().Count() == 1)
            {
                Application.OpenForms.OfType<Form2>().First().Close();
            }

            Form2 newForm2 = new Form2(logic);

            newForm2.Show();
        }

    }
}
