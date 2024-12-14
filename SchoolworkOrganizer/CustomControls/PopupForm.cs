

namespace SchoolworkOrganizer.Popup
{
    public partial class PopupForm : Form
    {
        private bool hitYes = false;

        public PopupForm(string? text, string title = "", MessageBoxButtons type = MessageBoxButtons.OK)
        {
            InitializeComponent();
            if (this.Parent == null) this.StartPosition = FormStartPosition.CenterScreen;
            else this.StartPosition = FormStartPosition.CenterParent;
            textLabel.Text = text;
            if (string.IsNullOrWhiteSpace(title)) topPanel.Visible = false;
            else titleLabel.Text = title;

            if (type == MessageBoxButtons.YesNo)
            {
                yesBtn.Visible = true;
                okBtn.Visible = false;
                noBtn.Visible = true;
            }
            else
            {
                yesBtn.Visible = false;
                okBtn.Visible = true;
                noBtn.Visible = false;
            }

        }
        public static DialogResult Show(string? text, string title = "", MessageBoxButtons type = MessageBoxButtons.OK)
        {
            PopupForm form = new PopupForm(text, title, type);
            form.ShowDialog();

            if (type is MessageBoxButtons.OK) return DialogResult.OK;
            else if (form.hitYes) return DialogResult.Yes;
            else return DialogResult.No;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            hitYes = true;
            this.Close();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            hitYes = false;
            this.Close();
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
    }
}
