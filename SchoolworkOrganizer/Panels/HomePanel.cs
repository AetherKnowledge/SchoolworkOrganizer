using SchoolworkOrganizer.Panels;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer
{
    public partial class HomePanel : Template
    {
        public HomePanel()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
            Clear();
            RefreshTodayTable();
            RefreshNextWeekTable();
        }

        private void RefreshTodayTable()
        {
            try
            {
                if (Program.user == null) return;

                todayTable.Rows.Clear();
                foreach(Subject subject in Program.user.Subjects)
                {
                    foreach (Activity activity in subject.Activities)
                    {
                        if (activity.DueDate.Date != DateTime.Today.Date) continue;

                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Name });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Subject.SubjectName });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.DueDate.ToString("hh:mm tt") });

                        todayTable.Rows.Add(row);
                    }
                }

            }
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }

        }

        private void RefreshNextWeekTable()
        {
            try
            {
                if (Program.user == null) return;

                nextWeekTable.Rows.Clear();
                DateTime today = DateTime.Today;
                DateTime nextWeek = today.AddDays(7);

                foreach (Subject subject in Program.user.Subjects)
                {
                    foreach (Activity activity in subject.Activities)
                    {
                        if (activity.DueDate.Date <= today || activity.DueDate.Date > nextWeek) continue;

                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Name });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.Subject.SubjectName });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = activity.DueDate.ToString("MM/dd/yyyy hh:mm tt") });

                        nextWeekTable.Rows.Add(row);
                    }
                }

            }
            catch (Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.Message}");
                if (Utilities.Debug) PopupForm.Show(ex.StackTrace);
            }
        }

        public void Clear()
        {
            todayTable.ClearSelection();
            nextWeekTable.ClearSelection();
        }

    }
}
