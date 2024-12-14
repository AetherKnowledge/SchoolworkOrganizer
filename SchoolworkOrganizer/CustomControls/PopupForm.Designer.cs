namespace SchoolworkOrganizer.Popup
{
    partial class PopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            textLabel = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            bottomPanel = new Panel();
            noBtn = new CustomControls.RoundedButton();
            yesBtn = new CustomControls.RoundedButton();
            okBtn = new CustomControls.RoundedButton();
            topPanel = new Panel();
            titleLabel = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            bottomPanel.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // textLabel
            // 
            textLabel.Dock = DockStyle.Fill;
            textLabel.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textLabel.Location = new Point(30, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(572, 232);
            textLabel.TabIndex = 0;
            textLabel.Text = "TEST";
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(bottomPanel);
            panel1.Controls.Add(topPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(632, 350);
            panel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(textLabel);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 55);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(30, 0, 30, 0);
            panel4.Size = new Size(632, 232);
            panel4.TabIndex = 3;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(noBtn);
            bottomPanel.Controls.Add(yesBtn);
            bottomPanel.Controls.Add(okBtn);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 287);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(632, 63);
            bottomPanel.TabIndex = 4;
            // 
            // noBtn
            // 
            noBtn.BackImageSize = new Size(0, 0);
            noBtn.BorderColor = Color.Black;
            noBtn.BorderRadius = 10;
            noBtn.BorderThickness = 1;
            noBtn.ButtonColor = Color.IndianRed;
            noBtn.FlatAppearance.BorderSize = 0;
            noBtn.FlatStyle = FlatStyle.Flat;
            noBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noBtn.ForeColor = Color.White;
            noBtn.HoverColor = Color.FromArgb(143, 64, 64);
            noBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            noBtn.Image = null;
            noBtn.ImageSize = new Size(0, 0);
            noBtn.Location = new Point(503, 13);
            noBtn.Name = "noBtn";
            noBtn.PressedColor = Color.FromArgb(100, 44, 44);
            noBtn.Size = new Size(99, 36);
            noBtn.TabIndex = 4;
            noBtn.Text = "NO";
            noBtn.UseVisualStyleBackColor = true;
            noBtn.Click += noBtn_Click;
            // 
            // yesBtn
            // 
            yesBtn.BackImageSize = new Size(0, 0);
            yesBtn.BorderColor = Color.Black;
            yesBtn.BorderRadius = 10;
            yesBtn.BorderThickness = 1;
            yesBtn.ButtonColor = Color.FromArgb(128, 175, 129);
            yesBtn.FlatAppearance.BorderSize = 0;
            yesBtn.FlatStyle = FlatStyle.Flat;
            yesBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yesBtn.ForeColor = Color.White;
            yesBtn.HoverColor = Color.FromArgb(89, 122, 90);
            yesBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            yesBtn.Image = null;
            yesBtn.ImageSize = new Size(0, 0);
            yesBtn.Location = new Point(30, 13);
            yesBtn.Name = "yesBtn";
            yesBtn.PressedColor = Color.FromArgb(62, 85, 62);
            yesBtn.Size = new Size(99, 36);
            yesBtn.TabIndex = 3;
            yesBtn.Text = "YES";
            yesBtn.UseVisualStyleBackColor = true;
            yesBtn.Click += yesBtn_Click;
            // 
            // okBtn
            // 
            okBtn.BackImageSize = new Size(0, 0);
            okBtn.BorderColor = Color.Black;
            okBtn.BorderRadius = 10;
            okBtn.BorderThickness = 1;
            okBtn.ButtonColor = Color.FromArgb(65, 78, 101);
            okBtn.FlatAppearance.BorderSize = 0;
            okBtn.FlatStyle = FlatStyle.Flat;
            okBtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            okBtn.ForeColor = Color.White;
            okBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            okBtn.Image = null;
            okBtn.ImageSize = new Size(0, 0);
            okBtn.Location = new Point(266, 13);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(99, 36);
            okBtn.TabIndex = 2;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(128, 175, 129);
            topPanel.Controls.Add(titleLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(632, 55);
            topPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(43, 49, 65);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(632, 55);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "TEST";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PopupForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(634, 352);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PopupForm";
            Padding = new Padding(1);
            StartPosition = FormStartPosition.CenterParent;
            Text = "PopupForm";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label textLabel;
        private Panel panel1;
        private CustomControls.RoundedButton okBtn;
        private Panel panel4;
        private Panel bottomPanel;
        private Panel topPanel;
        private Label titleLabel;
        private CustomControls.RoundedButton noBtn;
        private CustomControls.RoundedButton yesBtn;
    }
}