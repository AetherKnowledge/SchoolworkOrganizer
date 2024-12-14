using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
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
            if (Program.user == null) return;

            subjectCBox.Items.Clear();
            editSubjectCBox.Items.Clear();

            foreach (Subject subject in Program.user.Subjects)
            {
                subjectCBox.Items.Add(subject.SubjectName);
                editSubjectCBox.Items.Add(subject.SubjectName);
            }

            if (subjectCBox.Items.Count > 0) subjectCBox.SelectedIndex = 0;

            RefreshTable();
        }

        private void RefreshTable()
        {
            try
            {
                if (Program.user == null) return;

                table.Rows.Clear();

                string subjectName = subjectCBox.Text;
                if (subjectName == null) return;

                Subject selectedSubject = Program.user?.Subjects.First(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current User is null");
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
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }

        }

        private void table_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                if (table.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = table.SelectedRows[0];
                    if (selectedRow.Index > table.RowCount - 1)
                    {
                        Clear();
                        return;
                    }

                    string name = selectedRow.Cells["ActivityName"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row activity name cannot be found");
                    string subject = selectedRow.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                    string path = selectedRow.Cells["FilePath"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row file path cannot be found");
                    string dueDateStr = selectedRow.Cells["DueDate"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row due date cannot be found");
                    string status = selectedRow.Cells["Status"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row status cannot be found");

                    string format = "MM/dd/yyyy hh:mm tt";
                    DateTime dueDate = DateTime.ParseExact(dueDateStr, format, System.Globalization.CultureInfo.InvariantCulture);
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
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                if (Program.user != null) return;

                string reviewerName = reviewerTxtBox.Text;
                string subjectName = editSubjectCBox.Text;
                Subject selectedSubject = Program.user?.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current User is null");
                string filePath = selectedFilePath;
                DateTime dueDate = dueDatePicker.Value;
                string status = statusCBox.Text;

                if (subjectName == "")
                {
                    PopupForm.Show("Please add subject name.", "Error");
                    return;
                }
                else if (selectedSubject == null)
                {
                    PopupForm.Show("Please select subject.", "Error", MessageBoxButtons.OK);
                    return;
                }
                else if (selectedFilePath == null)
                {
                    PopupForm.Show("Please select file.", "Error", MessageBoxButtons.OK);
                    return;
                }

                Activity activity = new Activity(reviewerName, selectedSubject, selectedFilePath, dueDate, status);
                if (await activity.AddActivity()) PopupForm.Show(Text = "Activity added successfully.", "Success", MessageBoxButtons.OK);
                else PopupForm.Show("Failed to add activity.", "Error", MessageBoxButtons.OK);

                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string oldSubjectName = table.SelectedRows[0]?.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                string oldFilePath = table.SelectedRows[0]?.Cells["FilePath"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row file path cannot be found");

                string newActivityName = reviewerTxtBox.Text;
                DateTime newDueDate = dueDatePicker.Value;
                string newStatus = statusCBox.Text;

                Subject oldSelectedSubject = Program.user?.Subjects.First(subject => subject.SubjectName == oldSubjectName) ?? throw new ArgumentNullException("Current user is null");
                Activity selectedActivity = oldSelectedSubject.Activities.First(activity => activity.FilePath == oldFilePath);

                string newSubjectName = editSubjectCBox.Text;
                Subject newSelectedSubject = Program.user.Subjects.First(subject => subject.SubjectName == newSubjectName);


                if (newActivityName == "")
                {
                    PopupForm.Show("Please add activity name.", "Error");
                    return;
                }
                else if (newSelectedSubject == null)
                {
                    PopupForm.Show("Please select subject.", "Error", MessageBoxButtons.OK);
                    return;
                }
                else if (selectedFilePath == null)
                {
                    PopupForm.Show("Please select file.", "Error", MessageBoxButtons.OK);
                    return;
                }
                else if (selectedActivity == null)
                {
                    PopupForm.Show("Activity not found.", "Error", MessageBoxButtons.OK);
                    return;
                }

                Activity activity = new Activity(newActivityName, newSelectedSubject, selectedFilePath, newDueDate, newStatus);
                bool success = await selectedActivity.UpdateActivity(activity);

                if (success) PopupForm.Show("Activity updated successfully.", "Success", MessageBoxButtons.OK);
                else PopupForm.Show("Failed to update activity.", "Error", MessageBoxButtons.OK); 

                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            try {
                if (Program.user != null) return;

                string filePath = selectedFilePath;
                string subjectName = table.SelectedRows[0]?.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                Subject selectedSubject = Program.user?.Subjects.First(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current user is null");

                if (selectedSubject == null)
                {
                    PopupForm.Show("Subject not found.", "Error", MessageBoxButtons.OK);
                    return;
                }

                Activity selectedActivity = selectedSubject.Activities.First(activity => activity.FilePath == filePath);

                if (selectedActivity == null)
                {
                    PopupForm.Show("Activity not found.", "Error", MessageBoxButtons.OK);
                    return;
                }

                var confirmResult = PopupForm.Show($"Are you sure you want to delete the reviewer '{selectedSubject.SubjectName}'?",
                                                    "Delete Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await selectedActivity.DeleteActivity();

                    if (success) PopupForm.Show("Activity deleted successfully.", "Success", MessageBoxButtons.OK);
                    else PopupForm.Show("Failed to delete activity.", "Error", MessageBoxButtons.OK);
                }
                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }
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
                PopupForm.Show("Please select a file.", "Error");
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
            if (Program.user != null) return;

            Program.client.CheckForUpdates();
            RefreshTable();
        }
    }
}
