using SchoolworkOrganizer.Design;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
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

            saveBtn.Paint += FormUtilities.customButtonPaint;
            addBtn.Paint += FormUtilities.customButtonPaint;
            deleteBtn.Paint += FormUtilities.customButtonPaint;
            cancelBtn.Paint += FormUtilities.customButtonPaint;

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

            foreach (Subject subject in User.currentUser.Subjects)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.SubjectName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.Reviewers.Count });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = subject.Activities.Count });

                table.Rows.Add(row);
            }

            foreach (DataGridViewColumn column in table.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void table_SelectionChanged(object? sender, EventArgs e)
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

            if(User.currentUser.Subjects.Any(subject => subject.SubjectName == subjectName))
            {
                MessageBox.Show("Subject already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Subject subject = new Subject(User.currentUser, subjectName);
            User.currentUser.Subjects.Add(subject);
            subject.AddToDatabase();

            RefreshTable();
            Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject selectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName);

            if (selectedSubject == null)
            {
                MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedSubject.SubjectName != subjectTxtBox.Text && User.currentUser.Subjects.Any(subject => subject.SubjectName == subjectTxtBox.Text))
            {
                MessageBox.Show("Subject already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Directory.Exists(User.currentUser.UserPath + "/Subjects/" + subjectName))
            {
                MessageBox.Show("Subject folder already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedSubject.SubjectName = subjectTxtBox.Text;
            selectedSubject.UpdateToDatabase();
            RefreshTable();
            Clear();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject selectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName);

            if (selectedSubject == null)
            {
                MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the product '{selectedSubject.SubjectName}'?",
                                                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                User.currentUser.RemoveSubject(selectedSubject);
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
            User.currentUser.CheckForFiles();
            RefreshTable();
        }
    }
}
