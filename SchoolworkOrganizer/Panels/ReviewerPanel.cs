using SchoolworkOrganizer.Design;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class ReviewerPanel : Template
    {
        string selectedFilePath = string.Empty;
        public ReviewerPanel()
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

                foreach (Reviewer reviewer in selectedSubject.Reviewers)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell { Value = reviewer.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = reviewer.Subject.SubjectName });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = reviewer.FilePath });

                    table.Rows.Add(row);
                }

                foreach (DataGridViewColumn column in table.Columns)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) MessageBox.Show(ex.StackTrace);
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

                    string name = selectedRow.Cells["ReviewerName"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row reviewer name cannot be found");
                    string subject = selectedRow.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                    string path = selectedRow.Cells["FilePath"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row file path cannot be found");

                    reviewerTxtBox.Text = name;
                    editSubjectCBox.Text = subject;
                    selectedFileLabel.Text = path;
                    selectedFilePath = path;

                    addBtn.Enabled = false;
                    saveBtn.Enabled = true;
                    deleteBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) MessageBox.Show(ex.StackTrace);
            }
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.client.IsLoggedIn) return;

                string reviewerName = reviewerTxtBox.Text;
                string subjectName = editSubjectCBox.Text;
                Subject selectedSubject = Program.user?.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current User is null");
                string filePath = selectedFilePath;

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

                Reviewer reviewer = new Reviewer(reviewerName, selectedSubject, selectedFilePath);
                if (await reviewer.AddReviewer()) MessageBox.Show("Reviewer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Failed to add reviewer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) MessageBox.Show(ex.StackTrace);
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string oldSubjectName = table.SelectedRows[0]?.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                string oldFilePath = table.SelectedRows[0]?.Cells["FilePath"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row file path cannot be found");

                string newReviewerName = reviewerTxtBox.Text;

                Subject oldSelectedSubject = Program.user?.Subjects.First(subject => subject.SubjectName == oldSubjectName) ?? throw new ArgumentNullException("Current user is null");
                Reviewer selectedReviewer = oldSelectedSubject.Reviewers.First(reviewer => reviewer.FilePath == oldFilePath);

                string newSubjectName = editSubjectCBox.Text;
                Subject newSelectedSubject = Program.user.Subjects.First(subject => subject.SubjectName == newSubjectName);

                if (newReviewerName == "")
                {
                    MessageBox.Show("Please add reviewer name.", "Error");
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
                else if (selectedReviewer == null)
                {
                    MessageBox.Show("Reviewer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Reviewer reviewer = new Reviewer(newReviewerName, newSelectedSubject, selectedFilePath);
                bool success = await selectedReviewer.UpdateReviewer(reviewer.Name);

                if (success) MessageBox.Show("Reviewer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Failed to update reviewer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) MessageBox.Show(ex.StackTrace);
            }
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.client.IsLoggedIn) return;

                string filePath = selectedFilePath;
                string subjectName = table.SelectedRows[0]?.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");
                Subject selectedSubject = Program.user?.Subjects.First(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current user is null");

                if (selectedSubject == null)
                {
                    MessageBox.Show("Subject not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Reviewer selectedReviewer = selectedSubject.Reviewers.First(reviewer => reviewer.FilePath == filePath);

                if (selectedReviewer == null)
                {
                    MessageBox.Show("Reviewer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show($"Are you sure you want to delete the reviewer '{selectedSubject.SubjectName}'?",
                                                    "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await selectedReviewer.DeleteReviewer();

                    if (success) MessageBox.Show("Reviewer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Failed to delete reviewer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) MessageBox.Show(ex.StackTrace);
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
            if (Program.client.IsLoggedIn) return;

            Program.client.CheckForUpdates();
            RefreshTable();
        }
    }
}
