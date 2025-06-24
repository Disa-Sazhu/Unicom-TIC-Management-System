using System;
using System.Windows.Forms;
using UnicomTIC_MS.Controllers;
using UnicomTIC_MS.DTOs;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Repositories;

namespace UnicomTIC_MS.View
{
    public partial class StudentForm : Form
    {
        private StudentController _controller = new StudentController();
        private CourseRepository _courseRepo = new CourseRepository();
        private int selectedId = -1;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadGenders();
            LoadData();
        }

        private void LoadCourses()
        {
            var courses = _courseRepo.GetAll();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseName";
        }

        private void LoadGenders()
        {
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _controller.GetAll();
            dataGridView1.ClearSelection();
        }

        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtNIC.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            selectedId = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new StudentDto
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                NIC = txtNIC.Text,
                Age = int.TryParse(txtAge.Text, out int a) ? a : 0,
                Gender = cmbGender.Text,
                Course = cmbCourse.Text,
                Role = "Student"
            };
            _controller.Add(dto);
            LoadData();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            var dto = new StudentDto
            {
                StudentID = selectedId,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                NIC = txtNIC.Text,
                Age = int.TryParse(txtAge.Text, out int a) ? a : 0,
                Gender = cmbGender.Text,
                Course = cmbCourse.Text,
                Role = "Student"
            };
            _controller.Update(dto);
            LoadData();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a student to delete.");
                return;
            }

            _controller.Delete(selectedId);
            LoadData();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["StudentID"].Value);
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtNIC.Text = row.Cells["NIC"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                cmbGender.Text = row.Cells["Gender"].Value.ToString();
                cmbCourse.Text = row.Cells["Course"].Value.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StudentForm
            // 
            this.ClientSize = new System.Drawing.Size(1079, 454);
            this.Name = "StudentForm";
            this.ResumeLayout(false);

        }
    }
}
