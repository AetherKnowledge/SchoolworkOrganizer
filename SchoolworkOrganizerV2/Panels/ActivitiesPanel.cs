using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SchoolworkOrganizerV2.Panels
{
    public partial class ActivitiesPanel : Template
    {
        string selectedFilePath = null;
        public ActivitiesPanel()
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

            dueDatePicker.CalendarFont = new Font("Roboto Light", 8);
            dueDatePicker.CalendarForeColor = Color.FromArgb(65, 78, 101);
        }

        public new void Show()
        {
            base.Show();
            Clear();
            RefreshData();
        }

        private void RefreshData()
        {
            subjectCBox.Items.Clear();
            editSubjectCBox.Items.Clear();

            foreach (Subject subject in LoginPanel.currentUser.Subjects)
            {
                subjectCBox.Items.Add(subject.Name);
                editSubjectCBox.Items.Add(subject.Name);
            }

            if (subjectCBox.Items.Count > 0) subjectCBox.SelectedIndex = 0;

            RefreshTable();
        }

        private void RefreshTable()
        {
            table.Rows.Clear();

            string subjectName = subjectCBox.Text;
            if (subjectName == null) return;

            Subject selectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == subjectName);
            if (selectedSubject == null) return;

            foreach (Activity activity in selectedSubject.Activities)
            {
                DataGridViewRow row = new DataGridViewRow();

                String status = activity.Status;
                int daysUntilDue = Convert.ToInt32(activity.DueDate.Subtract(DateTime.Now).TotalDays);
                if (daysUntilDue <= 0) 
                {
                    if (status == "Incomplete") status = "Work is Due";
                    daysUntilDue = 0; 
                }
                
                row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Subject.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.FilePath });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.DueDate.ToString("MM/dd/yyyy hh:mm tt") });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = daysUntilDue });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = status });

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

                string name = selectedRow.Cells["ActivityName"].Value.ToString();
                string subject = selectedRow.Cells["Subject"].Value.ToString();
                string path = selectedRow.Cells["FilePath"].Value.ToString();
                string dueDateStr = selectedRow.Cells["DueDate"].Value.ToString();
                string format = "MM/dd/yyyy hh:mm tt";
                DateTime dueDate = DateTime.ParseExact(dueDateStr, format, System.Globalization.CultureInfo.InvariantCulture);
                string status = selectedRow.Cells["Status"].Value.ToString();
                if (status == "Work is Due") status = "Incomplete";

                reviewerTxtBox.Text = name;
                editSubjectCBox.Text = subject;
                dueDatePicker.Value = dueDate;
                statusCBox.Text = status;

                selectedFileLabel.Text = path;
                selectedFilePath = path;

                addBtn.Enabled = false;
                saveBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string reviewerName = reviewerTxtBox.Text;
            string subjectName = editSubjectCBox.Text;
            Subject selectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == subjectName);
            string filePath = selectedFilePath;
            DateTime dueDate = dueDatePicker.Value;
            string status = statusCBox.Text;

            if (subjectName == "")
            {
                MessageBox.Show("Please add subject name.", "Error");
                return;
            }
            else if (selectedSubject == null)
            {
                MessageBox.Show("Please select subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectedFilePath == null)
            {
                MessageBox.Show("Please select file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new Activity(reviewerName, selectedSubject, selectedFilePath, dueDate, status);

            RefreshTable();
            Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string oldSubjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            string oldFilePath = table.SelectedRows[0].Cells["FilePath"].Value.ToString();

            string newActivityName = reviewerTxtBox.Text;
            DateTime newDueDate = dueDatePicker.Value;
            string newStatus = statusCBox.Text;

            Subject oldSelectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == oldSubjectName);
            Activity selectedActivity = oldSelectedSubject.Activities.FirstOrDefault(activity => activity.FilePath == oldFilePath);

            string newSubjectName = editSubjectCBox.Text;
            Subject newSelectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == newSubjectName);


            if (newActivityName == "")
            {
                MessageBox.Show("Please add activity name.", "Error");
                return;
            }
            else if (newSelectedSubject == null)
            {
                MessageBox.Show("Please select subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectedFilePath == null)
            {
                MessageBox.Show("Please select file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedActivity.Name = newActivityName;
            selectedActivity.Subject = newSelectedSubject;
            selectedActivity.ChangeFile(selectedFilePath);
            selectedActivity.DueDate = newDueDate;
            selectedActivity.Status = newStatus;

            RefreshTable();

            Clear();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string filePath = selectedFilePath;
            string subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject selectedSubject = LoginPanel.currentUser.Subjects.FirstOrDefault(subject => subject.Name == subjectName);
            Activity selectedActivity = selectedSubject.Activities.FirstOrDefault(activity => activity.FilePath == filePath);

            if (selectedActivity == null)
            {
                MessageBox.Show("Activity not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the reviewer '{selectedSubject.Name}'?",
                                                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                selectedSubject.RemoveActivity(selectedActivity);
                RefreshTable();
                MessageBox.Show("Activity deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Clear();
        }

        private void editFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                selectedFileLabel.Text = selectedFilePath;
            }
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (selectedFilePath == null)
            {
                MessageBox.Show("Please select a file.", "Error");
                return;
            }
            Utilities.OpenFile(selectedFilePath);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            table.ClearSelection();
            editSubjectCBox.Text = "";
            reviewerTxtBox.Text = "";
            selectedFilePath = null;
            selectedFileLabel.Text = "";

            saveBtn.Enabled = false;
            deleteBtn.Enabled = false;
            addBtn.Enabled = true;
        }

        private void subjectCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoginPanel.currentUser.CheckForFiles();
            RefreshTable();
        }
    }
}
