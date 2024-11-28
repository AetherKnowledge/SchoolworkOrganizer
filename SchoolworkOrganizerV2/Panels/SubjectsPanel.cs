using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolworkOrganizerV2.Panels
{
    public partial class SubjectsPanel : Template
    {
        public SubjectsPanel()
        {
            InitializeComponent();
            table.SelectionChanged += table_SelectionChanged;

            table.BorderStyle = BorderStyle.FixedSingle;
            table.DefaultCellStyle.Font = new Font("Roboto Light", 8);
            table.DefaultCellStyle.BackColor = Color.FromArgb(65, 78, 101);
            table.DefaultCellStyle.ForeColor = Color.FromArgb(231, 231, 231);
            table.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 63, 82);
            table.DefaultCellStyle.SelectionForeColor = Color.FromArgb(95, 192, 170);

            table.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 78, 101);
            table.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(95, 192, 170);

            table.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 63, 82);
            table.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(95, 192, 170);

            table.EnableHeadersVisualStyles = false;
            table.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto Light", 10, FontStyle.Bold);
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 49, 65);
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(231, 231, 231);
            table.BackgroundColor = Color.FromArgb(65, 78, 101);

            table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 49, 65);
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(231, 231, 231);

            saveBtn.Paint += Utilities.customButtonPaint;
            addBtn.Paint += Utilities.customButtonPaint;
            deleteBtn.Paint += Utilities.customButtonPaint;
            cancelBtn.Paint += Utilities.customButtonPaint;

        }

        public new void Show()
        {
            base.Show();
            RefreshTable();
            Clear();
        }

        private void RefreshTable()
        {
            table.Rows.Clear();

            foreach (Subject subject in LoginPanel.currentUser.Subjects)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.Reviewers.Count });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.Activities.Count });

                table.Rows.Add(row);
            }

            foreach (DataGridViewColumn column in table.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void table_SelectionChanged(object sender, EventArgs e)
        {
            if (table.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = table.SelectedRows[0];
                if (selectedRow.Index > table.RowCount - 1)
                {
                    Clear();
                    return;
                }

                string itemName = selectedRow.Cells["Subject"].Value.ToString();

                subjectTxtBox.Text = itemName;

                addBtn.Enabled = false;
                saveBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string subjectName = subjectTxtBox.Text;
            if (subjectName == "")
            {
                MessageBox.Show("Please add subject name.", "Error");
                return;
            }

            LoginPanel.currentUser.Subjects.Add(new Subject(LoginPanel.currentUser.Username, subjectName));

            RefreshTable();
            Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject selectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == subjectName);

            if (selectedSubject == null)
            {
                MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedSubject.Name = subjectTxtBox.Text;
            RefreshTable();
            Clear();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject selectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == subjectName);

            if (selectedSubject == null)
            {
                MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the product '{selectedSubject.Name}'?",
                                                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                LoginPanel.currentUser.RemoveSubject(selectedSubject);
                RefreshTable();
                MessageBox.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            table.ClearSelection();
            subjectTxtBox.Text = "";

            addBtn.Enabled = true;
            saveBtn.Enabled = false;
            deleteBtn.Enabled = false;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoginPanel.currentUser.CheckForFiles();
            RefreshTable();
        }
    }
}
