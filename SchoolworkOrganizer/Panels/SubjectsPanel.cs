using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class SubjectsPanel : Template2
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

        public new void RefreshData()
        {
            Clear();
            RefreshTable();
        }

        private void RefreshTable()
        {
            try
            {
                if (Program.user == null) return;

                table.Rows.Clear();

                foreach (Subject subject in Program.user.Subjects)
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

                    string itemName = selectedRow.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");

                    subjectTxtBox.Text = itemName;

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
                if (Program.user == null) throw new ArgumentNullException("Current user is null");

                string subjectName = subjectTxtBox.Text;
                if (subjectName == "")
                {
                    PopupForm.Show("Please add subject name.", "Error");
                    return;
                }

                if (Program.user.Subjects.Any(subject => subject.SubjectName == subjectName))
                {
                    PopupForm.Show("Subject already exists.", "Error", MessageBoxButtons.OK);
                    return;
                }

                Subject subject = new Subject(Program.user, subjectName);
                if (await subject.AddSubject()) PopupForm.Show("Subject added successfully.", "Success", MessageBoxButtons.OK);
                else PopupForm.Show("Failed to add subject.", "Error", MessageBoxButtons.OK);

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

                Subject selectedSubject = Program.user?.Subjects.FirstOrDefault(subject => subject.SubjectName == oldSubjectName) ?? throw new ArgumentNullException("Current user is null");

                string newSubjectName = subjectTxtBox.Text;

                if (newSubjectName == "")
                {
                    PopupForm.Show("Please add subject name.", "Error");
                    return;
                }
                else if (newSubjectName != oldSubjectName && Program.user.Subjects.Any(subject => subject.SubjectName == newSubjectName))
                {
                    PopupForm.Show("Subject already exists.", "Error", MessageBoxButtons.OK);
                    return;
                }

                Subject newSubject = new Subject(Program.user, newSubjectName);
                bool success = await selectedSubject.UpdateSubject(newSubject);

                if (success) PopupForm.Show("Subject updated successfully.", "Success", MessageBoxButtons.OK);
                else PopupForm.Show("Failed to update subject.", "Error", MessageBoxButtons.OK);

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
            try
            {
                string subjectName = table.SelectedRows[0]?.Cells["Subject"]?.Value?.ToString() ?? throw new ArgumentNullException("Invalid row subject cannot be found");

                Subject selectedSubject = Program.user?.Subjects.FirstOrDefault(subject => subject.SubjectName == subjectName) ?? throw new ArgumentNullException("Current user is null");

                if (selectedSubject == null)
                {
                    PopupForm.Show("Subject not found.", "Error", MessageBoxButtons.OK);
                    return;
                }

                var confirmResult = PopupForm.Show($"Are you sure you want to delete the subject '{selectedSubject.SubjectName}'?",
                                                    "Delete Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await selectedSubject.DeleteSubject();

                    if (success) PopupForm.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK);
                    else PopupForm.Show("Failed to delete subject.", "Error", MessageBoxButtons.OK);
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
            if (Program.user != null) return;

            Program.client.CheckForUpdates();
            RefreshTable();
        }
    }
}
