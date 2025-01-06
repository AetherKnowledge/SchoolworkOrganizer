using MaterialSkin.Controls;
using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popups;
using Timer = System.Windows.Forms.Timer;


namespace SchoolworkOrganizer
{
    public partial class LoginPanel : MaterialForm
    {
        private Timer animationTimer = new Timer();
        private float animationProgress = 0;
        private bool login = true;
        private int panelGap;
        private Image loginDefaultImage;
        private Image registerDefaultImage;

        public event EventHandler? WindowStateChanged;

        public LoginPanel()
        {
            InitializeComponent();
            panelGap = mainPanel.Location.X + panel1.Location.X;
            mainPanel.Location = new Point(panelGap, mainPanel.Location.Y);
            mainPanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            changePanel.Height = mainPanel.Height;

            loginImagePanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            loginImagePanel.Width = (this.Width - mainPanel.Width - ((panelGap + 7) * 2));
            loginDefaultImage = loginImageBox.Image;

            registerImagePanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            registerImagePanel.Width = (this.Width - mainPanel.Width - ((panelGap + 7) * 2));
            registerDefaultImage = registerImageBox.Image;

            this.FormClosing += MyFormClosing;
            WindowStateChanged += RefreshPanel;

            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;

            OpenPanels.loginPage = this;
            animationTimer.Interval = 8; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            loginInput.Switch += switchLabel_Click;
            registerInput.Switch += switchLabel_Click;

            loginInput.LoginSuccess += (sender, e) =>
            {
                this.Hide();
                OpenPanels.adminPage.Show();
            };

        }

        public new void Show()
        {
            base.Show();
            Program.Logout();
            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;

            Clear();
        }

        public new void Hide()
        {
            OpenPanels.size = this.Size;
            OpenPanels.location = this.Location;
            OpenPanels.windowState = this.WindowState;
            base.Hide();

            Clear();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            // Adjust hover progress gradually
            float target = login ? 0 : 1;

            animationProgress += (target - animationProgress) * 0.1f; // Smooth transition

            if (Math.Abs(target - animationProgress) < 0.0001f)
            {
                if (loginImageBox.Image != loginDefaultImage) loginImageBox.Image = loginDefaultImage;
                if (registerImageBox.Image != registerDefaultImage) registerImageBox.Image = registerDefaultImage;
                animationProgress = target;
                animationTimer.Stop();
            }

            int min = panelGap - 2;
            int max = Width - mainPanel.Width - (panelGap * 2);
            int progress = min + (int)(animationProgress * (Width - mainPanel.Width - (min * 2)));

            //prevents stutter at the end
            progress = Math.Max(panelGap, progress);
            progress = Math.Min(max, progress);

            int mainPanelX = progress;
            int topPanelX = (-mainPanel.Width - 100) + (int)(animationProgress * ((mainPanel.Width + 100) * 2));

            mainPanel.Location = new Point(mainPanelX, mainPanel.Location.Y);
            loginImagePanel.Location = new Point(mainPanel.Right + 7, loginImagePanel.Location.Y);
            registerImagePanel.Location = new Point((mainPanel.Left - 7) - registerImagePanel.Width, loginImagePanel.Location.Y);
            changePanel.Location = new Point(topPanelX, changePanel.Location.Y);

            if (login)
            {
                if (animationProgress < 0.5 && topLabel.Text != "Login")
                {
                    topLabel.Text = "Login";
                    registerInput.Visible = false;
                    loginInput.Visible = true;
                }
            }
            else
            {
                if (animationProgress > 0.5 && topLabel.Text != "Register")
                {
                    topLabel.Text = "Register";
                    registerInput.Visible = true;
                    loginInput.Visible = false;
                }

            }



            Invalidate();
        }

        public static void MyFormClosing(object? sender, FormClosingEventArgs e)
        {
            Program.client.Disconnect();
        }

        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();

        }

        private void switchLabel_Click(object? sender, EventArgs e)
        {
            login = !login;

            int width = 800;
            int originalWidth = loginDefaultImage.Width;
            int originalHeight = loginDefaultImage.Height;
            // Calculate the new height to maintain the aspect ratio
            int height = (int)((float)originalHeight / originalWidth * width);

            loginImageBox.Image = FormUtilities.ResizeImage(loginDefaultImage, width, height);
            registerImageBox.Image = FormUtilities.ResizeImage(registerDefaultImage, width, height);

            animationTimer.Start();

        }

        private void Clear()
        {
            loginInput.Clear();
            registerInput.Clear();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            OpenPanels.adminPage.Show();
        }

        private void RefreshPanel(object? sender, EventArgs e)
        {
            //if (animationProgress != 0 || animationProgress != 1) return;
            mainPanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            changePanel.Height = mainPanel.Height;

            loginImagePanel.Width = (this.Width - mainPanel.Width - ((panelGap + 7) * 2));
            loginImagePanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            loginImagePanel.Location = new Point(mainPanel.Right + 7, loginImagePanel.Location.Y);

            registerImagePanel.Width = (this.Width - mainPanel.Width - ((panelGap + 7) * 2));
            registerImagePanel.Height = this.Height - this.Padding.Top - this.Padding.Bottom - (panelGap * 4);
            registerImagePanel.Location = new Point((mainPanel.Left - 7) - registerImagePanel.Width, loginImagePanel.Location.Y);

            if (login)
            {
                mainPanel.Location = new Point(panelGap, mainPanel.Location.Y);
            }
            else
            {
                mainPanel.Location = new Point(Width - mainPanel.Width - (panelGap * 2), mainPanel.Location.Y);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color borderColor = Color.Black; // Change to your preferred color
            int borderThickness = 2;

            // Draw the border
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                Rectangle rect = new Rectangle(1, 1, this.ClientSize.Width - 2, this.ClientSize.Height - 2);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected virtual void OnWindowStateChanged(EventArgs e)
        {
            WindowStateChanged?.Invoke(this, e);
        }

        private void loginInput_Load(object sender, EventArgs e)
        {

        }
    }

}
