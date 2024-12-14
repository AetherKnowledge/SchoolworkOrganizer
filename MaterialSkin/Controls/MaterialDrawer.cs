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
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class MaterialDrawer : Control, IMaterialControl
    {
        // TODO: Invalidate when changing custom properties
        private Rectangle _logoutImageRect;
        private readonly Panel LogoPanel = new Panel();
        private readonly PictureBox BigLogoPictureBox = new PictureBox();
        private readonly PictureBox SmallLogoPictureBox = new PictureBox();
        private readonly PictureBox picBox = new PictureBox();
        private readonly Label picLabel = new Label();
        private readonly AnimationManager _logoutImageAnimManager;

        private int _imagePadding = 100;
        private int ImagePadding { 
            get {
                if (!DisplayImage) return LogoPanel.Height;
                return IsOpen ? _imagePadding : LogoPanel.Height; 
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
        public int LogoPanelHeight { get; set; } = 100;

        [Category("Logo")]
        public Image BigLogo
        {
            get { return BigLogoPictureBox.Image; }
            set { BigLogoPictureBox.Image = value; }
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
        private Dictionary<string, TextureBrush> iconsBrushes;

        private Dictionary<string, TextureBrush> iconsSelectedBrushes;
        private Dictionary<string, Rectangle> iconsSize;
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
            if (_baseTabControl == null || _baseTabControl.TabCount == 0 || _baseTabControl.ImageList == null || _drawerItemRects == null || _drawerItemRects.Count == 0)
                return;

            // Calculate lightness and color
            float l = UseColors ? SkinManager.ColorScheme.TextColor.R / 255 : SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? 0f : 1f;
            float r = (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor.R : SkinManager.ColorScheme.PrimaryColor.R) / 255f;
            float g = (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor.G : SkinManager.ColorScheme.PrimaryColor.G) / 255f;
            float b = (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor.B : SkinManager.ColorScheme.PrimaryColor.B) / 255f;

            // Create matrices
            float[][] matrixGray = {
                    new float[] {   0,   0,   0,   0,  0}, // Red scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Green scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Blue scale factor
                    new float[] {   0,   0,   0, .7f,  0}, // alpha scale factor
                    new float[] {   l,   l,   l,   0,  1}};// offset

            float[][] matrixColor = {
                    new float[] {   0,   0,   0,   0,  0}, // Red scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Green scale factor
                    new float[] {   0,   0,   0,   0,  0}, // Blue scale factor
                    new float[] {   0,   0,   0,   1,  0}, // alpha scale factor
                    new float[] {   r,   g,   b,   0,  1}};// offset

            ColorMatrix colorMatrixGray = new ColorMatrix(matrixGray);
            ColorMatrix colorMatrixColor = new ColorMatrix(matrixColor);

            ImageAttributes grayImageAttributes = new ImageAttributes();
            ImageAttributes colorImageAttributes = new ImageAttributes();

            // Set color matrices
            grayImageAttributes.SetColorMatrix(colorMatrixGray, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            colorImageAttributes.SetColorMatrix(colorMatrixColor, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // Create brushes
            iconsBrushes = new Dictionary<string, TextureBrush>(_baseTabControl.TabPages.Count);
            iconsSelectedBrushes = new Dictionary<string, TextureBrush>(_baseTabControl.TabPages.Count);
            iconsSize = new Dictionary<string, Rectangle>(_baseTabControl.TabPages.Count);

            foreach (TabPage tabPage in _baseTabControl.TabPages)
            {
                // skip items without image
                if (String.IsNullOrEmpty(tabPage.ImageKey) || _drawerItemRects == null)
                    continue;

                // Image Rect
                Rectangle destRect = new Rectangle(0, 0, _baseTabControl.ImageList.Images[tabPage.ImageKey].Width, _baseTabControl.ImageList.Images[tabPage.ImageKey].Height);

                // Create a pre-processed copy of the image (GRAY)
                Bitmap bgray = new Bitmap(destRect.Width, destRect.Height);
                using (Graphics gGray = Graphics.FromImage(bgray))
                {
                    gGray.DrawImage(_baseTabControl.ImageList.Images[tabPage.ImageKey],
                        new Point[] {
                                new Point(0, 0),
                                new Point(destRect.Width, 0),
                                new Point(0, destRect.Height),
                        },
                        destRect, GraphicsUnit.Pixel, grayImageAttributes);
                }

                // Create a pre-processed copy of the image (PRIMARY COLOR)
                Bitmap bcolor = new Bitmap(destRect.Width, destRect.Height);
                using (Graphics gColor = Graphics.FromImage(bcolor))
                {
                    gColor.DrawImage(_baseTabControl.ImageList.Images[tabPage.ImageKey],
                        new Point[] {
                                new Point(0, 0),
                                new Point(destRect.Width, 0),
                                new Point(0, destRect.Height),
                        },
                        destRect, GraphicsUnit.Pixel, colorImageAttributes);
                }

                // added processed image to brush for drawing
                TextureBrush textureBrushGray = new TextureBrush(bgray);
                TextureBrush textureBrushColor = new TextureBrush(bcolor);

                textureBrushGray.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
                textureBrushColor.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;

                // Translate the brushes to the correct positions
                var currentTabIndex = _baseTabControl.TabPages.IndexOf(tabPage);

                Rectangle iconRect = new Rectangle(
                   _drawerItemRects[currentTabIndex].X + (drawerItemHeight / 2) - (_baseTabControl.ImageList.Images[tabPage.ImageKey].Width / 2),
                   _drawerItemRects[currentTabIndex].Y + (drawerItemHeight / 2) - (_baseTabControl.ImageList.Images[tabPage.ImageKey].Height / 2),
                   _baseTabControl.ImageList.Images[tabPage.ImageKey].Width, _baseTabControl.ImageList.Images[tabPage.ImageKey].Height);

                textureBrushGray.TranslateTransform(iconRect.X + iconRect.Width / 2 - _baseTabControl.ImageList.Images[tabPage.ImageKey].Width / 2,
                                                    iconRect.Y + iconRect.Height / 2 - _baseTabControl.ImageList.Images[tabPage.ImageKey].Height / 2);
                textureBrushColor.TranslateTransform(iconRect.X + iconRect.Width / 2 - _baseTabControl.ImageList.Images[tabPage.ImageKey].Width / 2,
                                                     iconRect.Y + iconRect.Height / 2 - _baseTabControl.ImageList.Images[tabPage.ImageKey].Height / 2);

                // add to dictionary
                var ik = string.Concat(tabPage.ImageKey, "_", tabPage.Name);
                iconsBrushes.Add(ik, textureBrushGray);
                iconsSelectedBrushes.Add(ik, textureBrushColor);
                iconsSize.Add(ik, new Rectangle(0, 0, iconRect.Width, iconRect.Height));
            }
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

            BigLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            BigLogoPictureBox.Dock = DockStyle.Fill;
            SmallLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SmallLogoPictureBox.Dock = DockStyle.Fill;
            LogoPanel.Dock = DockStyle.Top;
            LogoPanel.Height = 30;
            LogoPanel.Controls.Add(BigLogoPictureBox);
            LogoPanel.Controls.Add(SmallLogoPictureBox);

            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.BackColor = SkinManager.ColorScheme.PrimaryColor;
            picBox.ForeColor = SkinManager.ColorScheme.TextColor;
            picBox.TabStop = false;
            picBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            picBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            LogoPanel.TabStop = false;
            LogoPanel.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            LogoPanel.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect
            BigLogoPictureBox.TabStop = false;
            BigLogoPictureBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            BigLogoPictureBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect
            SmallLogoPictureBox.TabStop = false;
            SmallLogoPictureBox.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            SmallLogoPictureBox.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            picLabel.TextAlign = ContentAlignment.MiddleCenter;
            picLabel.BackColor = SkinManager.ColorScheme.PrimaryColor;
            picLabel.ForeColor = SkinManager.ColorScheme.TextColor;
            picLabel.Font = SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1);
            picLabel.AutoSize = false;
            picLabel.TabStop = false;
            picLabel.MouseEnter += (s, e) => OnMouseEnter(e); // Prevent hover effect
            picLabel.MouseLeave += (s, e) => OnMouseLeave(e); // Prevent hover effect

            Controls.Add(picBox);
            Controls.Add(picLabel);
            Controls.Add(LogoPanel);

            _logoutImageAnimManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseOut,
                Increment = 0.04
            };
            _logoutImageAnimManager.OnAnimationProgress += sender => Invalidate();
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
            if (UseBackColor)
                PaintOwnColors(e);
            else
                PaintNormal(e);

            if (LogoPanel.BackColor != LogoPanelBackColor) LogoPanel.BackColor = LogoPanelBackColor;
        }

        private void PaintNormal(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // redraw stuff
            g.Clear(UseColors ? SkinManager.ColorScheme.PrimaryColor : SkinManager.BackdropColor);

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
                var rippleBrush = new SolidBrush(Color.FromArgb((int)(70 - (clickAnimProgress * 70)),
                    UseColors ? SkinManager.ColorScheme.AccentColor : // Using colors
                    SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.PrimaryColor : // light theme
                    SkinManager.ColorScheme.LightPrimaryColor)); // dark theme

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
                Brush bgBrush = new SolidBrush(Color.FromArgb(CalculateAlpha(60, 0, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress),
                    UseColors ? _backgroundWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.LightPrimaryColor : // using colors
                    _backgroundWithAccent ? SkinManager.ColorScheme.AccentColor : // default accent
                    SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.PrimaryColor : // default light
                    SkinManager.ColorScheme.LightPrimaryColor)); // default dark
                g.FillPath(bgBrush, _drawerItemPaths[currentTabIndex]);
                bgBrush.Dispose();

                // Text
                Color textColor = Color.FromArgb(CalculateAlphaZeroWhenClosed(SkinManager.TextHighEmphasisColor.A, UseColors ? SkinManager.TextMediumEmphasisColor.A : 255, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress), // alpha
                    UseColors ? (currentTabIndex == _baseTabControl.SelectedIndex ? (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.PrimaryColor) // Use colors - selected
                    : SkinManager.ColorScheme.TextColor) :  // Use colors - not selected
                    (currentTabIndex == _baseTabControl.SelectedIndex ? (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.PrimaryColor) : // selected
                    SkinManager.TextHighEmphasisColor));

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
                    Rectangle iconRect = new Rectangle(
                        _drawerItemRects[currentTabIndex].X + (drawerItemHeight >> 1) - (iconsSize[ik].Width >> 1),
                        _drawerItemRects[currentTabIndex].Y + (drawerItemHeight >> 1) - (iconsSize[ik].Height >> 1), // Add topPadding to the icon rectangle
                        iconsSize[ik].Width, iconsSize[ik].Height);

                    if (ShowIconsWhenHidden)
                    {
                        iconsBrushes[ik].TranslateTransform(dx, 0);
                        iconsSelectedBrushes[ik].TranslateTransform(dx, 0);
                    }

                    g.FillRectangle(currentTabIndex == _baseTabControl.SelectedIndex ? iconsSelectedBrushes[ik] : iconsBrushes[ik], iconRect);
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
        }
        private void PaintOwnColors(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // redraw stuff
            if (UseBackColor) g.Clear(BackColor);
            Color accent = BackColor.Darken(0.8f);

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
                var rippleBrush = new SolidBrush(Color.FromArgb((int)(70 - (clickAnimProgress * 70)),
                    UseColors ? SkinManager.ColorScheme.AccentColor : // Using colors
                    SkinManager.Theme == MaterialSkinManager.Themes.LIGHT ? SkinManager.ColorScheme.PrimaryColor : // light theme
                    SkinManager.ColorScheme.LightPrimaryColor)); // dark theme

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
                Brush bgBrush = new SolidBrush(Color.FromArgb(CalculateAlpha(60, 0, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress),
                    accent)); // default dark
                g.FillPath(bgBrush, _drawerItemPaths[currentTabIndex]);
                bgBrush.Dispose();

                // Text
                Color textColor = Color.FromArgb(CalculateAlphaZeroWhenClosed(SkinManager.TextHighEmphasisColor.A, UseColors ? SkinManager.TextMediumEmphasisColor.A : 255, currentTabIndex, clickAnimProgress, 1 - showHideAnimProgress), // alpha
                    UseColors ? (currentTabIndex == _baseTabControl.SelectedIndex ? (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.TextColor) // Use colors - selected
                    : SkinManager.ColorScheme.TextColor) :  // Use colors - not selected
                    (currentTabIndex == _baseTabControl.SelectedIndex ? (_highlightWithAccent ? SkinManager.ColorScheme.AccentColor : SkinManager.ColorScheme.PrimaryColor) : // selected
                    SkinManager.TextHighEmphasisColor));

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
                    Rectangle iconRect = new Rectangle(
                        _drawerItemRects[currentTabIndex].X + (drawerItemHeight >> 1) - (iconsSize[ik].Width >> 1),
                        _drawerItemRects[currentTabIndex].Y + (drawerItemHeight >> 1) - (iconsSize[ik].Height >> 1), // Add topPadding to the icon rectangle
                        iconsSize[ik].Width, iconsSize[ik].Height);

                    if (ShowIconsWhenHidden)
                    {
                        iconsBrushes[ik].TranslateTransform(dx, 0);
                        iconsSelectedBrushes[ik].TranslateTransform(dx, 0);
                    }

                    //g.FillRectangle(currentTabIndex == _baseTabControl.SelectedIndex ? iconsSelectedBrushes[ik] : iconsBrushes[ik], iconRect);
                    g.DrawImage(_baseTabControl.ImageList.Images[tabPage.ImageKey], iconRect);
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

            if (LogoutImage != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int logoutImageSize = 30; // Set the size of the logout image
                _logoutImageRect = new Rectangle(Width - logoutImageSize - 14, Height - logoutImageSize - 12, logoutImageSize, logoutImageSize);

                // Draw the logout image with animation

                var logoutAnimProgress = _logoutImageAnimManager.GetProgress();
                using (GraphicsPath rectPath = DrawHelper.CreateRoundRect(_logoutImageRect.X - 5, _logoutImageRect.Y -5, _logoutImageRect.Width + 10, _logoutImageRect.Height + 10, 4))
                {
                    // Fill the rectangle
                    using (Brush brush = new SolidBrush(Color.FromArgb(CalculateAlpha(60, 0, _logoutImageAnimManager), accent)))
                    {
                        e.Graphics.FillPath(brush, rectPath);
                    }
                }

                g.DrawImage(LogoutImage, _logoutImageRect);
            }
        }

        private int CalculateAlpha(int primaryA, int secondaryA, AnimationManager manager)
        {
            if (!manager.IsAnimating()) return (int)(primaryA);
            return secondaryA + (int)((primaryA - secondaryA) * manager.GetProgress());
        }

        public new void Show()
        {
            _isOpen = true;
            if (BigLogo == null) 
            { 
                LogoPanel.Visible = false; 
                LogoPanel.Height = 0;
            }
            else 
            {
                LogoPanel.Visible = true;
                LogoPanel.Height = LogoPanelHeight;
                SmallLogoPictureBox.Visible = false;
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
                // Handle logout image click
                OnLogoutImageClick(EventArgs.Empty);
                _logoutImageAnimManager.SetProgress(0);
                _logoutImageAnimManager.StartNewAnimation(AnimationDirection.In);
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
            base.OnMouseDown(e);
            if (DesignMode)
                return;
            MouseState = MouseState.DOWN;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (DesignMode)
                return;
            MouseState = MouseState.OUT;
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

        private void ShowImage()
        {
            if (!DisplayImage || !IsOpen)
            {
                return;
            }
            picBox.Location = new Point(Width/2 - picBox.Width/2, LogoPanel.Height + 10);

            using (Graphics g = CreateGraphics())
            {
                SizeF textSize = g.MeasureString(picLabel.Text, picLabel.Font, Width);
                picLabel.Size = new Size(Width, (int)textSize.Height);
            }

            int picLabelX = Width/2 - (picLabel.Width/2);

            picLabel.Location = new Point(0, picBox.Bottom + 2);

            picBox.Visible = true;
            picLabel.Visible = true;
            ImagePadding = picBox.Bottom + picLabel.Height;
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
                _drawerItemRects[i] = (new Rectangle(
                    (int)(SkinManager.FORM_PADDING * 0.75) - (ShowIconsWhenHidden ? Location.X : 0),
                    (TAB_HEADER_PADDING * 2) * i + (int)(SkinManager.FORM_PADDING >> 1) + ImagePadding,
                    (Width + (ShowIconsWhenHidden ? Location.X : 0)) - (int)(SkinManager.FORM_PADDING * 1.5) - 1,
                    drawerItemHeight));

                _drawerItemPaths[i] = DrawHelper.CreateRoundRect(new RectangleF(_drawerItemRects[i].X - 0.5f, _drawerItemRects[i].Y - 0.5f, _drawerItemRects[i].Width, _drawerItemRects[i].Height), 4);
            }
            
        }
    }
}
