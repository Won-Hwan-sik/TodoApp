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

namespace TodoApp.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private ITodoRepository _repository;

        public Form1()
        {
            InitializeComponent();
            _repository = new TodoRepositoryInJson(@"C:\\Temp\\TodoApp\\Todos.json");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = _repository.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
