namespace MaterialSkin.Controls
{
    using MaterialSkin.Animations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using Timer = System.Windows.Forms.Timer;

    public class MaterialDrawer : Control, IMaterialControl
    {
        // TODO: Invalidate when changing custom properties
        private Rectangle _logoutImageRect;
        private readonly Panel LogoPanel = new Panel();
        private readonly PictureBox BigLogoPictureBox = new PictureBox();
        private readonly PictureBox SmallLogoPictureBox = new PictureBox();
        private readonly PictureBox picBox = new PictureBox();
        private readonly Label picLabel = new Label();
        private Timer animationTimer = new Timer();
        private bool logoutBtnHovered = false;
        private bool logoutBtnPressed = false;
        private bool logoutBtnHasLeft = true;
        private AnimationManager _logoutClickManager;

        private int _imagePadding = 100;
        private int ImagePadding { 
            get {
                if (!DisplayImage) return LogoPanel.Height;
                return _imagePadding;

                //return IsOpen ? _imagePadding : LogoPanel.Height; 
            }
            set => _imagePadding = value;
        }
        private bool _showIconsWhenHidden;

        [Category("Logo")]
        public Color LogoPanelBackColor
        {
            get;
            set;
        }

        [Category("Drawer")]
        public Image LogoutImage
        {
            get;
            set;
        }

        [Category("Logo")]
        public int LogoPanelHeight 
        { 
            get; set; 
        } = 100;

        private Image _BigLogo;
        [Category("Logo")]
        public Image BigLogo
        {
            get { return _BigLogo; }
            set 
            {
                _BigLogo = value;
                BigLogoPictureBox.Image = value; 
            }
        }
        [Category("Logo")]
        public Image SmallLogo
        {
            get { return SmallLogoPictureBox.Image; }
            set { SmallLogoPictureBox.Image = value; }
        }

        [Category("Logo")]
        public PictureBoxSizeMode BigLogoSizeMode
        {
            get { return BigLogoPictureBox.SizeMode; }
            set { BigLogoPictureBox.SizeMode = value; }
        }
        [Category("Logo")]
        public Rectangle BigLogoBounds
        {
            get { return BigLogoPictureBox.Bounds; }
            set { BigLogoPictureBox.Bounds = value; }
        }
        [Category("Logo")]
        public DockStyle BigLogoDockStyle
        {
            get { return BigLogoPictureBox.Dock; }
            set { BigLogoPictureBox.Dock = value; }
        }

        [Category("Drawer")]
        public Image Image
        {
            get { return picBox.Image; }
            set { picBox.Image = value; }
        }
        [Category("Drawer")]
        public string LabelText
        {
            get { return picLabel.Text; }
            set { picLabel.Text = value; }
        }
        [Category("Drawer")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get { return picBox.SizeMode; }
            set { picBox.SizeMode = value; }
        }
        [Category("Drawer")]
        public Size ImageSize
        {
            get { return picBox.Size; }
            set 
            { 
                picBox.Size = value;
                UpdateTabRects();
            }
        }
        private bool _displayImage = false;
        [Category("Drawer")]
        public bool DisplayImage
        {
            get { return _displayImage; }
            set
            {
                _displayImage = value;
                picBox.Visible = value;
                picLabel.Visible = value;
                UpdateTabRects();
            }
        }
        private bool _useBackColor = false;
        [Category("Drawer")]
        public bool UseBackColor {
            get => _useBackColor;
            set
            {
                _useBackColor = value;
                if (_useBackColor)
                {
                    picBox.BackColor = BackColor;
                    picLabel.BackColor = BackColor;
                    LogoPanel.BackColor = BackColor;
                }
                else
                {
                    LogoPanel.BackColor = UseColors ? SkinManager.ColorScheme.PrimaryColor : SkinManager.BackdropColor;
                    picBox.BackColor = UseColors ? SkinManager.ColorScheme.PrimaryColor : SkinManager.BackdropColor;
                    picLabel.BackColor = UseColors ? SkinManager.ColorScheme.PrimaryColor : SkinManager.BackdropColor;
                }
                Invalidate();
            }
        }

        [Category("Drawer")]
        public bool ShowIconsWhenHidden
        {
            get
            {
                return _showIconsWhenHidden;
            }
            set
            {
                if (_showIconsWhenHidden != value)
                {
                    _showIconsWhenHidden = value;
                    UpdateTabRects();
                    preProcessIcons();
                    showHideAnimation();
                    Paint(new PaintEventArgs(CreateGraphics(), ClientRectangle));
                    DrawerShowIconsWhenHiddenChanged?.Invoke(this);
                }
            }
        }

        private bool _isOpen;

        [Category("Drawer")]
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                if (value)
                    Show();
                else
                    Hide();
            }
        }

        [Category("Drawer")]
        public bool AutoHide { get; set; }

        [Category("Drawer")]
        public bool AutoShow { get; set; }

        [Category("Drawer")]
        private bool _useColors;

        public bool UseColors
        {
            get
            {
                return _useColors;
            }
            set
            {
                _useColors = value;
                preProcessIcons();
                Invalidate();
            }
        }

        [Category("Drawer")]
        private bool _highlightWithAccent;

        public bool HighlightWithAccent
        {
            get
            {
                return _highlightWithAccent;
            }
            set
            {
                _highlightWithAccent = value;
                preProcessIcons();
                Invalidate();
            }
        }

        [Category("Drawer")]
        private bool _backgroundWithAccent;

        public bool BackgroundWithAccent
        {
            get
            {
                return _backgroundWithAccent;
            }
            set
            {
                _backgroundWithAccent = value;
                Invalidate();
            }
        }

        [Category("Drawer")]
        public int IndicatorWidth { get; set; }

        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;

        [Browsable(false)]
        public MouseState MouseState { get; set; }

        public delegate void DrawerStateHandler(object sender);

        public event DrawerStateHandler DrawerStateChanged;

        public event DrawerStateHandler DrawerBeginOpen;

        public event DrawerStateHandler DrawerEndOpen;

        public event DrawerStateHandler DrawerBeginClose;

        public event DrawerStateHandler DrawerEndClose;

        public event DrawerStateHandler DrawerShowIconsWhenHiddenChanged;

        public event EventHandler<Cursor> CursorUpdate;

        public event EventHandler LogoutImageClick;

        // icons
        private int prevLocation;

        private int rippleSize = 0;

        private MaterialTabControl _baseTabControl;

        [Category("Behavior")]
        public MaterialTabControl BaseTabControl
        {
            get { return _baseTabControl; }
            set
            {
                _baseTabControl = value;
                if (_baseTabControl == null)
                    return;

                UpdateTabRects();
                preProcessIcons();

                // Other helpers

                _previousSelectedTabIndex = _baseTabControl.SelectedIndex;
                _baseTabControl.Deselected += (sender, args) =>
                {
                    _previousSelectedTabIndex = _baseTabControl.SelectedIndex;
                };
                _baseTabControl.SelectedIndexChanged += (sender, args) =>
                {
                    _clickAnimManager.SetProgress(0);
                    _clickAnimManager.StartNewAnimation(AnimationDirection.In);
                };
                _baseTabControl.ControlAdded += delegate
                {
                    Invalidate();
                };
                _baseTabControl.ControlRemoved += delegate
                {
                    Invalidate();
                };
            }
        }

        private void preProcessIcons()
        {
            // pre-process and pre-allocate texture brushes (icons)
            //if (_baseTabControl == null || _baseTabControl.TabCount == 0 || _baseTabControl.ImageList == null || _drawerItemRects == null || _drawerItemRects.Count == 0)
            //    return;

            //for (int i = 0; i < _baseTabControl.ImageList.Images.Count; i++)
            //{
            //    Image image = _baseTabControl.ImageList.Images[i];
            //    image = ChangeColor(image, SkinManager.ColorScheme.TextColor);
            //}
        }

        private int _previousSelectedTabIndex;

        private Point _animationSource;

        private readonly AnimationManager _clickAnimManager;

        private readonly AnimationManager _showHideAnimManager;

        private List<Rectangle> _drawerItemRects;
        private List<GraphicsPath> _drawerItemPaths;

        private const int TAB_HEADER_PADDING = 24;
        private const int BORDER_WIDTH = 7;

        private int drawerItemHeight;

        public int MinWidth;
        private int _lastMouseY;
        private int _lastLocationY;

        public MaterialDrawer()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            Height = 120;
            Width = 250;
            IndicatorWidth = 0;
            _isOpen = false;
            ShowIconsWhenHidden = false;
            AutoHide = false;
            AutoShow = false;
            HighlightWithAccent = true;
            BackgroundWithAccent = false;

            _showHideAnimManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseInOut,
                Increment = 0.04
            };
            _showHideAnimManager.OnAnimationProgress += sender =>
            {
                Invalidate();
                showHideAnimation();
            };
            _showHideAnimManager.OnAnimationFinished += sender =>
            {
                if (_baseTabControl != null && _drawerItemRects.Count > 0)
                    rippleSize = _drawerItemRects[_baseTabControl.SelectedIndex].Width;
                if (_isOpen)
                {
                    DrawerEndOpen?.Invoke(this);
                }
                else
                {
                    DrawerEndClose?.Invoke(this);
                }

                if (!_isOpen)
                {
                    LogoPanel.Visible = true;
                    SmallLogoPictureBox.Visible = true;
                    BigLogoPictureBox.Visible = false;

                    picBox.Visible = false;
                    picLabel.Visible = false;
                }
            };

            SkinManager.ColorSchemeChanged += sender =>
            {
                preProcessIcons();
            };

            SkinManager.ThemeChanged += sender =>
            {
                preProcessIcons();
            };

            _clickAnimManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseOut,
                Increment = 0.04
            };
            _clickAnimManager.OnAnimationProgress += sender => Invalidate();

            MouseWheel += MaterialDrawer_MouseWheel;

            LogoPanel.Dock = DockStyle.Top;
            LogoPanel.Height = 30;
            LogoPanel.Controls.Add(SmallLogoPictureBox);
            LogoPanel.Controls.Add(BigLogoPictureBox);
            
            LogoPanel.TabStop = false;
            LogoPanel.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            LogoPanel.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            SmallLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SmallLogoPictureBox.Dock = DockStyle.None;
            SmallLogoPictureBox.Size = new Size(LogoPanelHeight, LogoPanelHeight);
            SmallLogoPictureBox.Location = new Point(0, 0);
            SmallLogoPictureBox.TabStop = false;
            SmallLogoPictureBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            SmallLogoPictureBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            BigLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            BigLogoPictureBox.Dock = DockStyle.Right;
            BigLogoPictureBox.Size = new Size(Width - LogoPanelHeight, Width - LogoPanelHeight);
            BigLogoPictureBox.TabStop = false;
            BigLogoPictureBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            BigLogoPictureBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.BackColor = SkinManager.ColorScheme.PrimaryColor;
            picBox.ForeColor = SkinManager.ColorScheme.TextColor;
            picBox.TabStop = false;
            picBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            picBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            picLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            picLabel.BackColor = SkinManager.ColorScheme.PrimaryColor;
            picLabel.ForeColor = SkinManager.ColorScheme.TextColor;
            picLabel.Font = SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1);
            picLabel.AutoSize = false;
            picLabel.TabStop = false;
            picLabel.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            picLabel.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            Controls.Add(LogoPanel);
            Controls.Add(picBox);
            Controls.Add(picLabel);

            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            _logoutClickManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseOut,
                Increment = 0.04
            };
            _logoutClickManager.OnAnimationProgress += sender => Invalidate();

            if (_baseTabControl != null && _baseTabControl.ImageList != null && _baseTabControl.ImageList.Images.Count > 0)
            {

                for (int i = 0; i < _baseTabControl.ImageList.Images.Count; i++)
                {
                    Image image = _baseTabControl.ImageList.Images[i];
                    image = Utilities.ChangeColor(image, SkinManager.ColorScheme.TextColor);
                }
            }
        }

        private void MaterialDrawer_MouseWheel(object sender, MouseEventArgs e)
        {
            int step = 20;
            if (e.Delta > 0)
            {
                if (Location.Y < 0)
                {
                    Location = new Point(Location.X, Location.Y + step > 0 ? 0 : Location.Y + step);
                    Height = Location.Y + step > 0 ? Parent.Height : Height - step;
                }
            }
            else
            {
                if (Height < (8 + drawerItemHeight) * _drawerItemRects.Count)
                {
                    Location = new Point(Location.X, Location.Y - step);
                    Height += step;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void InitLayout()
        {
            drawerItemHeight = TAB_HEADER_PADDING * 2 - SkinManager.FORM_PADDING / 2;
            MinWidth = (int)(SkinManager.FORM_PADDING * 1.5 + drawerItemHeight);
            _showHideAnimManager.SetProgress(_isOpen ? 0 : 1);
            showHideAnimation();
            Invalidate();

            base.InitLayout();
        }

        private void showHideAnimation()
        {
            var showHideAnimProgress = _showHideAnimManager.GetProgress();
            if (_showHideAnimManager.IsAnimating())
            {
                if (ShowIconsWhenHidden)
                {
                    Location = new Point((int)((-Width + MinWidth) * showHideAnimProgress), Location.Y);
                }
                else
                {
                    Location = new Point((int)(-Width * showHideAnimProgress), Location.Y);
                }
            }
            else
            {
                if (_isOpen)
                {
                    Location = new Point(0, Location.Y);
                }
                else
                {
                    if (ShowIconsWhenHidden)
                    {
                        Location = new Point((int)(-Width + MinWidth), Location.Y);
                    }
                    else
                    {
                        Location = new Point(-Width, Location.Y);
                    }
                }
            }
            UpdateTabRects();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Paint(e);
        }

        private new void Paint(PaintEventArgs e)
        {
            PaintNormal(e);

            if (LogoPanel.BackColor != LogoPanelBackColor) LogoPanel.BackColor = LogoPanelBackColor;
        }

        private void PaintNormal(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color drawerBackColor;
            if (UseBackColor) drawerBackColor = BackColor;
            else drawerBackColor = SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.LightPrimaryColor : SkinManager.ColorScheme.PrimaryColor;

            Color btnBackColor;
            if (UseBackColor) btnBackColor = BackColor.Darken(0.8f);
            else btnBackColor = UseColors? _backgroundWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.LightPrimaryColor : // using colors
                _backgroundWithAccent? SkinManager.ColorScheme.AccentColor : // default accent
                SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.PrimaryColor : // default light
                SkinManager.ColorScheme.LightPrimaryColor; // default dark

            Color defaultBtnTextColor = UseColors ? SkinManager.ColorScheme.TextColor : SkinManager.TextHighEmphasisColor;

            Color selectedBtnTextColor = UseColors ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.PrimaryColor; // Use colors - selected

            Color rippleColor = UseColors ? SkinManager.ColorScheme.AccentColor : // Using colors
                    SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.PrimaryColor : // light theme
                    SkinManager.ColorScheme.LightPrimaryColor; // dark theme

            // redraw stuff
            g.Clear(drawerBackColor);

            if (_baseTabControl == null)
                return;

            if (!_clickAnimManager.IsAnimating() || _drawerItemRects == null || _drawerItemRects.Count != _baseTabControl.TabCount)
                UpdateTabRects();

            if (_drawerItemRects == null || _drawerItemRects.Count != _baseTabControl.TabCount)
                return;

            // Click Animation
            var clickAnimProgress = _clickAnimManager.GetProgress();
            // Show/Hide Drawer Animation
            var showHideAnimProgress = _showHideAnimManager.GetProgress();
            var rSize = (int)(clickAnimProgress * rippleSize * 1.75);

            int dx = prevLocation - Location.X;
            prevLocation = Location.X;

            // Ripple
            if (_clickAnimManager.IsAnimating())
            {
                var rippleBrush = new SolidBrush(Color.FromArgb((int)(70 - (clickAnimProgress * 70)),rippleColor)); 

                g.SetClip(_drawerItemPaths[_baseTabControl.SelectedIndex]);
                g.FillEllipse(rippleBrush, new Rectangle(_animationSource.X + dx - (rSize / 2), _animationSource.Y - rSize / 2, rSize, rSize));
                g.ResetClip();
                rippleBrush.Dispose();
            }

            // Draw menu items
            foreach (TabPage tabPage in _baseTabControl.TabPages)
            {
                var currentTabIndex = _baseTabControl.TabPages.IndexOf(tabPage);

                // Background
                Brush bgBrush = new SolidBrush(Color.FromArgb(CalculateAlpha(60, 0, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress), btnBackColor));
                g.FillPath(bgBrush, _drawerItemPaths[currentTabIndex]);
                bgBrush.Dispose();

                // Text
                Color textColor = Color.FromArgb(CalculateAlphaZeroWhenClosed(SkinManager.TextHighEmphasisColor.A, UseColors ? SkinManager.TextMediumEmphasisColor.A : 255, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress), // alpha
                    currentTabIndex == _baseTabControl.SelectedIndex ? selectedBtnTextColor : defaultBtnTextColor); // color

                IntPtr textFont = SkinManager.getLogFontByType(MaterialSkinManager.fontType.Subtitle2);

                Rectangle textRect = _drawerItemRects[currentTabIndex];
                textRect.X += _baseTabControl.ImageList != null ? drawerItemHeight : (int)(SkinManager.FORM_PADDING * 0.75);
                textRect.Width -= SkinManager.FORM_PADDING << 2;

                using (NativeTextRenderer NativeText = new NativeTextRenderer(g))
                {
                    NativeText.DrawTransparentText(tabPage.Text, textFont, textColor, textRect.Location, textRect.Size, NativeTextRenderer.TextAlignFlags.Left | NativeTextRenderer.TextAlignFlags.Middle);
                }
                // Icons
                if (_baseTabControl.ImageList != null && !String.IsNullOrEmpty(tabPage.ImageKey))
                {
                    var ik = string.Concat(tabPage.ImageKey, "_", tabPage.Name);
                    int size = 32;
                    Rectangle iconRect = new Rectangle(
                        _drawerItemRects[currentTabIndex].X + (drawerItemHeight >> 1) - (size >> 1),
                        _drawerItemRects[currentTabIndex].Y + (drawerItemHeight >> 1) - (size >> 1), // Add topPadding to the icon rectangle
                        size, size);

                    if (currentTabIndex == _baseTabControl.SelectedIndex)
                    {
                        Color btnColor = Utilities.BlendColors(defaultBtnTextColor, selectedBtnTextColor, (float)clickAnimProgress);
                        using (Image btnImage = Utilities.ChangeColor(_baseTabControl.ImageList.Images[tabPage.ImageKey], btnColor, true))
                        {
                            g.DrawImage(btnImage, iconRect);
                        }
                    }
                    else g.DrawImage(Utilities.ChangeColor(_baseTabControl.ImageList.Images[tabPage.ImageKey], textColor, true), iconRect);

                    //g.FillRectangle(currentTabIndex == _baseTabControl.SelectedIndex ? iconsSelectedBrushes[ik] : iconsBrushes[ik], iconRect);
                }
            }

            // Draw divider if not using colors
            if (!UseColors)
            {
                using (Pen dividerPen = new Pen(SkinManager.DividersColor, 1))
                {
                    g.DrawLine(dividerPen, Width - 1, 0, Width - 1, Height);
                }
            }

            // Animate tab indicator
            var previousSelectedTabIndexIfHasOne = _previousSelectedTabIndex == -1 ? _baseTabControl.SelectedIndex : _previousSelectedTabIndex;
            var previousActiveTabRect = _drawerItemRects[previousSelectedTabIndexIfHasOne];
            var activeTabPageRect = _drawerItemRects[_baseTabControl.SelectedIndex];

            var y = previousActiveTabRect.Y + (int)((activeTabPageRect.Y - previousActiveTabRect.Y) * clickAnimProgress); // Add topPadding to the indicator
            var x = ShowIconsWhenHidden ? -Location.X : 0;
            var height = drawerItemHeight;

            g.FillRectangle(SkinManager.ColorScheme.AccentBrush, x, y, IndicatorWidth, height);

            if (LogoutImage != null) DrawLogoutBtn(e, btnBackColor, defaultBtnTextColor, selectedBtnTextColor, rippleColor);

            int alpha = 255 - (int)(showHideAnimProgress * 255);

            BigLogoPictureBox.Image = Utilities.ChangeAlpha(BigLogo, alpha);
            //if (BigLogo != BigLogoPictureBox.Image) BigLogoPictureBox.Image = BigLogo;
        }

        private void DrawLogoutBtn(PaintEventArgs e, Color btnColor, Color btnTextColor, Color btnSelectedTextColor, Color rippleColor)
        {
            var g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int logoutImageSize = 30; // Set the size of the logout image
            _logoutImageRect = new Rectangle(Width - logoutImageSize - 14, Height - logoutImageSize - 12, logoutImageSize, logoutImageSize);

            // Draw the logout image with animation
            var logoutAnimProgress = progress;
            

            using (GraphicsPath rectPath = DrawHelper.CreateRoundRect(_logoutImageRect.X - 5, _logoutImageRect.Y - 5, _logoutImageRect.Width + 10, _logoutImageRect.Height + 10, 4))
            {
                // Fill the rectangle
                using (Brush brush = new SolidBrush(Color.FromArgb(CalculateAlpha(150, 0, progress), btnColor)))
                {
                    g.FillPath(brush, rectPath);
                }

                if (logoutBtnPressed)
                {
                    var rSize = (int)(logoutAnimProgress * (_logoutImageRect.Width + 10) * 1.75);
                    int dx = prevLocation - Location.X;
                    prevLocation = Location.X;

                    var rippleBrush = new SolidBrush(Color.FromArgb((int)(70 - (_logoutClickManager.GetProgress() * 70)), rippleColor));

                    g.SetClip(rectPath);
                    g.FillEllipse(rippleBrush, new Rectangle(_animationSource.X + dx - (rSize / 2), _animationSource.Y - rSize / 2, rSize, rSize));
                    g.ResetClip();
                    rippleBrush.Dispose();
                }
            }
            Color logoutBtnColor = Utilities.BlendColors(btnTextColor, btnSelectedTextColor, progress);
            using (Image btnImage = Utilities.ChangeColor(LogoutImage, logoutBtnColor, true))
            {
                g.DrawImage(btnImage, _logoutImageRect);
            }
            
        }

        private float progress = 0;
        private float target = 0;
        private int CalculateAlpha(int primaryA, int secondaryA, double progress)
        {
            double pressedAlpha = secondaryA + (primaryA - secondaryA);
            double hoverAlpha = secondaryA + (primaryA - secondaryA) * .8;

            if (logoutBtnPressed) return (int)(pressedAlpha * progress);
            if (logoutBtnHovered && !logoutBtnHasLeft) return (int)(hoverAlpha * progress);
            if (!logoutBtnHasLeft) return (int)((hoverAlpha + pressedAlpha - hoverAlpha) * progress );
            return secondaryA + (int)((primaryA - secondaryA) * progress);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Adjust hover progress gradually
            if (logoutBtnPressed) target = 1;
            else if (logoutBtnHovered && !logoutBtnHasLeft) target = 0.5f;
            else target = 0;

            progress += (target - progress) * 0.2f; // Smooth transition

            if (Math.Abs(target - progress) < 0.01f)
            {
                progress = target;
                animationTimer.Stop();
            }

            Invalidate();
        }

        public new void Show()
        {
            _isOpen = true;
            SmallLogoPictureBox.Size = new Size(LogoPanelHeight, LogoPanelHeight);
            

            if (BigLogo == null) 
            { 
                LogoPanel.Visible = false; 
                LogoPanel.Height = 0;
            }
            else 
            {
                LogoPanel.Visible = true;
                LogoPanel.Height = LogoPanelHeight;
                //SmallLogoPictureBox.Visible = false;

                BigLogoPictureBox.Visible = true;
            }

            DrawerStateChanged?.Invoke(this);
            DrawerBeginOpen?.Invoke(this);
            _showHideAnimManager.StartNewAnimation(AnimationDirection.Out);
            ShowImage();
        }

        public new void Hide()
        {
            _isOpen = false;
            SmallLogoPictureBox.Size = new Size(LogoPanelHeight, LogoPanelHeight);
            DrawerStateChanged?.Invoke(this);
            DrawerBeginClose?.Invoke(this);
            _showHideAnimManager.StartNewAnimation(AnimationDirection.In);

        }

        public void Toggle()
        {
            if (_isOpen)
                Hide();
            else
                Show();
        }

        private int CalculateAlphaZeroWhenClosed(int primaryA, int secondaryA, int tabIndex, double clickAnimProgress, double showHideAnimProgress)
        {
            // Drawer is closed
            if (!_isOpen && !_showHideAnimManager.IsAnimating())
            {
                return 0;
            }
            // Active menu (no change)
            if (tabIndex == _baseTabControl.SelectedIndex && (!_clickAnimManager.IsAnimating() || _showHideAnimManager.IsAnimating()))
            {
                return (int)(primaryA * showHideAnimProgress);
            }
            // Previous menu (changing)
            if (tabIndex == _previousSelectedTabIndex && !_showHideAnimManager.IsAnimating())
            {
                return primaryA - (int)((primaryA - secondaryA) * clickAnimProgress);
            }
            // Inactive menu (no change)
            if (tabIndex != _baseTabControl.SelectedIndex)
            {
                return (int)(secondaryA * showHideAnimProgress);
            }
            // Active menu (changing)
            return secondaryA + (int)((primaryA - secondaryA) * clickAnimProgress);
        }

        private int CalculateAlpha(int primaryA, int secondaryA, int tabIndex, double clickAnimProgress, double showHideAnimProgress)
        {
            if (tabIndex == _baseTabControl.SelectedIndex && !_clickAnimManager.IsAnimating())
            {
                return (int)(primaryA);
            }
            if (tabIndex != _previousSelectedTabIndex && tabIndex != _baseTabControl.SelectedIndex)
            {
                return secondaryA;
            }
            if (tabIndex == _previousSelectedTabIndex)
            {
                return primaryA - (int)((primaryA - secondaryA) * clickAnimProgress);
            }
            return secondaryA + (int)((primaryA - secondaryA) * clickAnimProgress);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (_drawerItemRects == null)
                UpdateTabRects();
            for (var i = 0; i < _drawerItemRects.Count; i++)
            {
                // Adjust the click position to account for topPadding
                var adjustedClickPosition = new Point(e.X, e.Y);
                if (_drawerItemRects[i].Contains(adjustedClickPosition) && _lastLocationY == Location.Y)
                {
                    _baseTabControl.SelectedIndex = i;
                    if (AutoHide && !AutoShow)
                        Hide();
                }
            }

            // Check if the logout image was clicked
            if (_logoutImageRect.Contains(e.Location))
            {
                logoutBtnPressed = true;
                OnLogoutImageClick(EventArgs.Empty);
                animationTimer.Start();
            }

            _animationSource = e.Location;
        }

        protected virtual void OnLogoutImageClick(EventArgs e)
        {
            LogoutImageClick?.Invoke(this, e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _lastMouseY = e.Y;
            _lastLocationY = Location.Y; // memorize Y location of drawer
            if (_logoutImageRect.Contains(e.Location))
            {
                _animationSource = e.Location;
                logoutBtnPressed = true;
                OnLogoutImageClick(EventArgs.Empty);
                animationTimer.Start();
                _logoutClickManager.SetProgress(0);
                _logoutClickManager.StartNewAnimation(AnimationDirection.In);
            }

            base.OnMouseDown(e);
            if (DesignMode)
                return;
            MouseState = MouseState.DOWN;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!logoutBtnPressed) logoutBtnPressed = false;

            if (DesignMode)
                return;
            MouseState = MouseState.OUT;

            if (logoutBtnPressed) { 
                logoutBtnPressed = false;
                animationTimer.Start();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (DesignMode)
                return;

            if (e.Button == MouseButtons.Left && e.Y != _lastMouseY && (Location.Y < 0 || Height < (8 + drawerItemHeight) * _drawerItemRects.Count))
            {
                int diff = e.Y - _lastMouseY;
                if (diff > 0)
                {
                    if (Location.Y < 0)
                    {
                        Location = new Point(Location.X, Location.Y + diff > 0 ? 0 : Location.Y + diff);
                        Height = Parent.Height + Math.Abs(Location.Y);
                    }
                }
                else
                {
                    if (Height < (8 + drawerItemHeight) * _drawerItemRects.Count)
                    {
                        Location = new Point(Location.X, Location.Y + diff);
                        Height = Parent.Height + Math.Abs(Location.Y);
                    }
                }
            }

            if (_logoutImageRect.Contains(e.Location))
            {
                if (!logoutBtnHovered)
                {
                    logoutBtnHovered = true;
                    animationTimer.Start();
                }
                if (logoutBtnHasLeft) logoutBtnHasLeft = false;
            }
            else
            {
                if (logoutBtnHovered)
                {
                    logoutBtnHovered = false;
                    animationTimer.Start();
                }
                if (!logoutBtnHasLeft) logoutBtnHasLeft = true;
                if (logoutBtnPressed) logoutBtnPressed = false;
            }

            base.OnMouseMove(e);

            if (_drawerItemRects == null)
                UpdateTabRects();

            Cursor previousCursor = Cursor;

            // Adjust the cursor position to account for topPadding
            var adjustedCursorPosition = new Point(e.X, e.Y);

            if (adjustedCursorPosition.X + this.Location.X < BORDER_WIDTH)
            {
                if (adjustedCursorPosition.Y > this.Height - BORDER_WIDTH)
                    Cursor = Cursors.SizeNESW;                  // Bottom Left
                else
                    Cursor = Cursors.SizeWE;                    // Left
            }
            else if (_logoutImageRect.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else if (adjustedCursorPosition.Y > this.Height - BORDER_WIDTH)
            {
                Cursor = Cursors.SizeNS;                        // Bottom
            }
            else
            {
                if (adjustedCursorPosition.Y < _drawerItemRects[_drawerItemRects.Count - 1].Bottom && (adjustedCursorPosition.X + this.Location.X) >= BORDER_WIDTH)
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Default;
            }

            if (previousCursor != Cursor) CursorUpdate?.Invoke(this, Cursor);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (AutoShow && _isOpen==false)
            {
                Show();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            // Get the current mouse position relative to the control
            Point mousePosition = PointToClient(MousePosition);

            // Check if the mouse is still within the bounds of the control or its child controls
            if (ClientRectangle.Contains(mousePosition) || picBox.Bounds.Contains(mousePosition) || picLabel.Bounds.Contains(mousePosition))
            {
                Cursor = Cursors.Default;
                return; // Do not call the base OnMouseLeave method
            }

            base.OnMouseLeave(e);

            if (MouseState != MouseState.DOWN)
            {
                Cursor = Cursors.Default;
                CursorUpdate?.Invoke(this, Cursor);
            }

            if (AutoShow)
            {
                Hide();
            }

        }
        private Image imageLogo;

        private void ShowImage()
        {
            if (!DisplayImage)
            {
                picBox.Visible = false;
                picLabel.Visible = false;
                return;
            }

            int x = ((Width - picBox.Width) / 2) - Location.X;
            int y = (int)((LogoPanel.Height + 10 - (_showHideAnimManager.GetProgress()) * picBox.Height * 2 + 10));


            picBox.Location = new Point(x, y);

            using (Graphics g = CreateGraphics())
            {
                SizeF textSize = g.MeasureString(picLabel.Text, picLabel.Font, Width);
                picLabel.Size = new Size(Width, (int)textSize.Height);
            }

            int picLabelX = ((Width - picLabel.Width) / 2) - Location.X;

            picLabel.Location = new Point(picLabelX, picBox.Bottom + 2);

            picBox.Visible = true;
            picLabel.Visible = true;
            ImagePadding = picBox.Bottom + picLabel.Height;

            if (SmallLogoPictureBox.Image == null) return;
            int smallLogoX = -Location.X;
            SmallLogoPictureBox.Location = new Point(smallLogoX, 0);
        }

        private void UpdateTabRects()
        {
            ShowImage();
            //If there isn't a base tab control, the rects shouldn't be calculated
            //or if there aren't tab pages in the base tab control, the list should just be empty
            if (_baseTabControl == null || _baseTabControl.TabCount == 0 || SkinManager == null || _drawerItemRects == null)
            {
                _drawerItemRects = new List<Rectangle>();
                _drawerItemPaths = new List<GraphicsPath>();
                return;
            }

            if (_drawerItemRects.Count != _baseTabControl.TabCount)
            {
                _drawerItemRects = new List<Rectangle>(_baseTabControl.TabCount);
                _drawerItemPaths = new List<GraphicsPath>(_baseTabControl.TabCount);

                for (var i = 0; i < _baseTabControl.TabCount; i++)
                {
                    _drawerItemRects.Add(new Rectangle());
                    _drawerItemPaths.Add(new GraphicsPath());
                }
            }

            //Calculate the bounds of each tab header specified in the base tab control
            
            for (int i = 0; i < _baseTabControl.TabPages.Count; i++)
            {
                int y = (TAB_HEADER_PADDING * 2) * i + (int)(SkinManager.FORM_PADDING >> 1);
                //y += IsOpen ? Math.Max(picBox.Top, (ImagePadding - (int)(_showHideAnimManager.GetProgress() * ImagePadding))) : picBox.Top + (int)((1 - _showHideAnimManager.GetProgress()) * (ImagePadding + picBox.Top - TAB_HEADER_PADDING ));
                y += Math.Max(LogoPanel.Height + 10, ImagePadding);

                _drawerItemRects[i] = (new Rectangle(
                    (int)(SkinManager.FORM_PADDING * 0.75) - (ShowIconsWhenHidden ? Location.X : 0),
                    y,
                    (Width + (ShowIconsWhenHidden ? Location.X : 0)) - (int)(SkinManager.FORM_PADDING * 1.5) - 1,
                    drawerItemHeight));

                _drawerItemPaths[i] = DrawHelper.CreateRoundRect(new RectangleF(_drawerItemRects[i].X - 0.5f, _drawerItemRects[i].Y - 0.5f, _drawerItemRects[i].Width, _drawerItemRects[i].Height), 4);
            }
            
        }
    }
}
