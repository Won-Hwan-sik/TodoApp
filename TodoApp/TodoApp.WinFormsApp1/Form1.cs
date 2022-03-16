using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoApp.Models;

namespace TodoApp.WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ITodoRepository _repository;

        public Form1()
        {
            InitializeComponent();
            _repository = new TodoRepositoryInJson(@"C:\\Temp\\TodoApp\\Todos.json");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            dataGridView1.DataSource = _repository.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            bool isDone = chkIsDone.Checked;

            var todo = new Todo() { Title = title, IsDone = isDone };
            _repository.Add(todo);

            DisplayData();
        }
    }
}
