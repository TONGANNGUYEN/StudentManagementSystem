using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        List<SinhVien> Students = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }

        void AddItemToListView(SinhVien student)
        {
            ListViewItem listViewItem = new ListViewItem(student.id);
            listViewItem.Tag = student;
            listViewItem.SubItems.Add(student.firstName);
            listViewItem.SubItems.Add(student.lastName);
            listViewItem.SubItems.Add(student.firstName + " " + student.lastName);
            listView1.Items.Add(listViewItem);
        }

        void AddItemsToListView()
        {
            foreach (SinhVien student in Students)
                AddItemToListView(student);
        }

        void InsertStudent()
        {
            listView1.Items.Clear();
            AddItemsToListView();
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string id = txtId.Text;
            if (firstName == "" || lastName == "" || id == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin sinh viên cần thêm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SinhVien student = new SinhVien(firstName, lastName, id);
            AddItemToListView(student);
            Students.Add(student);
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtId.Text = "";
            txtId.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertStudent();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SinhVien student = listView1.SelectedItems[0].Tag as SinhVien;
                listView1.Items.Remove(listView1.SelectedItems[0]);
                Students.Remove(student);
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtId.Text = "";
                txtId.Focus();
            }
        }

        void SearchStudent()
        {
            string keyWord = txtKeyWord.Text.ToLower();
            if (keyWord == "")
            {
                MessageBox.Show("Nhập mã số sinh viên hoặc tên cần tìm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listView1.Items.Clear();
            foreach (SinhVien student in Students)
            {
                if (student.id.ToLower().Contains(keyWord) || student.lastName.ToLower().Contains(keyWord))
                {
                    AddItemToListView(student);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            Students.Sort((s1, s2) => s1.lastName.CompareTo(s2.lastName));
            listView1.Items.Clear();
            AddItemsToListView();
        }

        private void txtKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TextBox txt = sender as TextBox;
                if (txt.Name == "txtKeyWord") SearchStudent();
                else InsertStudent();
            }
        }
    }
}
