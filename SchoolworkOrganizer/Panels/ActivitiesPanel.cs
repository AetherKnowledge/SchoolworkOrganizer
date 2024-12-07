using SchoolworkOrganizer.Design;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class ActivitiesPanel : Template
    {
        string selectedFilePath = string.Empty;
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

            saveBtn.Paint += FormUtilities.customButtonPaint;
            addBtn.Paint += FormUtilities.customButtonPaint;
            deleteBtn.Paint += FormUtilities.customButtonPaint;
            cancelBtn.Paint += FormUtilities.customButtonPaint;

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
            if (User.currentUser == null) return;

            subjectCBox.Items.Clear();
            editSubjectCBox.Items.Clear();

            foreach (Subject subject in User.currentUser.Subjects)
            {
                subjectCBox.Items.Add(subject.SubjectName);
                editSubjectCBox.Items.Add(subject.SubjectName);
            }

            if (subjectCBox.Items.Count > 0) subjectCBox.SelectedIndex = 0;

            RefreshTable();
        }

        private void RefreshTable()
        {
            if (User.currentUser == null) return;

            table.Rows.Clear();

            string subjectName = subjectCBox.Text;
            if (subjectName == null) return;

            Subject? selectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName);
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
                row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Subject.SubjectName });
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
            if (User.currentUser == null) return;

            string reviewerName = reviewerTxtBox.Text;
            string subjectName = editSubjectCBox.Text;
            Subject? selectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName);
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

            Activity activities = new Activity(reviewerName, selectedSubject, selectedFilePath, dueDate, status);
            selectedSubject.Activities.Add(activities);
            activities.AddToDatabase();

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

            Subject oldSelectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == oldSubjectName);
            Activity selectedActivity = oldSelectedSubject.Activities.FirstOrDefault(activity => activity.FilePath == oldFilePath);

            string newSubjectName = editSubjectCBox.Text;
            Subject newSelectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == newSubjectName);


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

            string oldName = selectedActivity.Name;
            selectedActivity.Name = newActivityName;
            selectedActivity.Subject = newSelectedSubject;
            selectedActivity.ChangeFile(selectedFilePath);
            selectedActivity.DueDate = newDueDate;
            selectedActivity.Status = newStatus;
            selectedActivity.UpdateToDatabase(oldName);

            RefreshTable();

            Clear();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (User.currentUser == null) return;

            string filePath = selectedFilePath;
            string? subjectName = table.SelectedRows[0].Cells["Subject"].Value.ToString();
            Subject? selectedSubject = User.currentUser.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName);

            if (selectedSubject == null)
            {
                MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Activity? selectedActivity = selectedSubject.Activities.FirstOrDefault(activity => activity.FilePath == filePath);

            if (selectedActivity == null)
            {
                MessageBox.Show("Activity not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the reviewer '{selectedSubject.SubjectName}'?",
                                                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                selectedActivity.DeleteFromDatabase();
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
            selectedFilePath = string.Empty;
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
            if (User.currentUser == null) return;

            User.currentUser.CheckForUpdates();
            RefreshTable();
        }
    }
}
