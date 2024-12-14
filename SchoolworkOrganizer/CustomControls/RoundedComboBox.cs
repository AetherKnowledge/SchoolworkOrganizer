using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;
using static SchoolworkOrganizer.CustomControls.CustomControlUtilities;

namespace SchoolworkOrganizer.CustomControls
{
    public class RoundedComboBox : Control
    {
        private static readonly object EVENT_SELECTEDINDEXCHANGED = new object();
        private ListBox dropdownListBox = new ListBox();
        private NonFocusableForm dropdownForm;
        private bool parentFound = false;

        private Color dropdownBackgroundColor = Color.White;
        private Color dropdownBorderColor = Color.Gray;

        private int borderRadius = 15;
        private Color borderColor = Color.Gray;
        private int borderThickness = 2;

        private Color textBoxColor = Color.White;
        
        private bool isHovering = false;
        private bool isClicked = false;
        private bool isDropdownShown
        {
            get => dropdownListBox.Visible;
        }

        private bool dropShadow = false;
        private Color shadowColor = Color.FromArgb(128, 0, 0, 0); // Semi-transparent black
        private int shadowOffsetX = 3;
        private int shadowOffsetY = 3;

        private GraphicsPath _controlPath;
        private GraphicsPath _innerPath;
        private Region _region;
        private Region _shadowRegion;
        private GraphicsPath _parentShadowPath;
        private GraphicsPath _dropdownPath;
        private Point[] _trianglePoints;
        private bool _pathsNeedUpdate = true;
        private Direction textDirection = Direction.Right;

        private Timer animationTimer = new Timer();
        private float hoverProgress = 0;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the text direction.")]
        private Color defaultColor { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the text direction.")]
        private Color hoverColor { get; set; } = Color.Empty;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the text direction.")]
        private Color clickColor { get; set; } = Color.Empty;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the text direction.")]
        public Direction TextDirection
        {
            get => textDirection;
            set
            {
                textDirection = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Change Items")]
        [Editor($"System.Windows.Forms.Design.StringArrayEditor", typeof(UITypeEditor))]
        public ListBox.ObjectCollection Items
        {
            get => dropdownListBox.Items;
            set
            {
                if (dropdownListBox != null)
                {
                    dropdownListBox.Items.Clear();
                    dropdownListBox.Items.AddRange(value);
                }
                Invalidate();
            }
        }

        public int SelectedIndex
        {
            get => dropdownListBox.SelectedIndex;
            set
            {
                dropdownListBox.SelectedIndex = value;
                Invalidate();
            }
        }
        public object SelectedItem
        {
            get => dropdownListBox.SelectedItem;
            set
            {
                dropdownListBox.SelectedItem = value;
                Invalidate();
            }
        }

        public bool hasBorder
        {
            get;
            private set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the radius of the border's corners.")]
        public new Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        public Color DropdownBackgroundColor
        {
            get => dropdownBackgroundColor;
            set
            {
                dropdownBackgroundColor = value;
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the color of the dropdown border.")]
        public Color DropdownBorderColor
        {
            get => dropdownBorderColor;
            set
            {
                dropdownBorderColor = value;
            }
        }


        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the radius of the border's corners.")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the color of the border.")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the thickness of the border.")]
        public int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = Math.Max(0, value);
                if (borderThickness == 0) hasBorder = false;
                else hasBorder = true;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the button's color.")]
        public Color TextBoxColor
        {
            get => textBoxColor;
            set
            {
                textBoxColor = value;
                Invalidate(); // Redraw the control when the property changes
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the color of the shadow.")]
        public bool DropShadow
        {
            get => dropShadow;
            set
            {
                dropShadow = value;
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the color of the shadow.")]
        public Color ShadowColor
        {
            get => shadowColor;
            set
            {
                shadowColor = value;
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the horizontal offset of the shadow.")]
        public int ShadowOffsetX
        {
            get => shadowOffsetX;
            set
            {
                shadowOffsetX = value;
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies the vertical offset of the shadow.")]
        public int ShadowOffsetY
        {
            get => shadowOffsetY;
            set
            {
                shadowOffsetY = value;
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        public RoundedComboBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true); // Enable custom painting
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            hasBorder = true;
            this.Size = new Size(200, 30);

            if (Parent == null) this.BackColor = Color.White;
            else this.BackColor = Parent.BackColor;

            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;
            InitializeDropdown();

            dropdownListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            hoverColor = Darker(defaultColor);
            clickColor = Darker(hoverColor);

            UpdatePaths();

        }

        private void Parent_Click(object sender, EventArgs e)
        {
            if (!isClicked) CloseDropdown();
        }

        private void OpenDropdown()
        {
            if (isDropdownShown) return;

            dropdownListBox.Size = new Size(Width - 2 * borderThickness, Math.Min(200, dropdownListBox.PreferredHeight));
            dropdownForm.Size = dropdownListBox.Size;
            dropdownForm.Location = this.PointToScreen(new Point(0, Height));
            dropdownForm.Show();
            Console.WriteLine(dropdownForm.Size);
            
            dropdownForm.Owner = this.FindForm();
        }

        private void CloseDropdown()
        {
            if (!isDropdownShown) return;
            dropdownForm.Hide();
        }

        private void InitializeDropdown()
        {
            dropdownListBox = new ListBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = dropdownBackgroundColor,
                ForeColor = this.ForeColor
            };

            dropdownListBox.Click += (s, e) =>
            {
                if (dropdownListBox.SelectedIndex >= 0)
                {
                    SelectedIndex = dropdownListBox.SelectedIndex;
                }
                CloseDropdown();
            };

            dropdownForm = new NonFocusableForm
            {
                BackColor = dropdownBackgroundColor
            };

            dropdownForm.Controls.Add(dropdownListBox);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Adjust hover progress gradually
            float target = isDropdownShown ? 1 : isClicked ? 1 : isHovering ? 1 : 0;
            hoverProgress += (target - hoverProgress) * 0.2f; // Smooth transition

            if (Math.Abs(target - hoverProgress) < 0.01f)
            {
                hoverProgress = target; // Snap to the target value
                animationTimer.Stop();
            }

            Invalidate(); // Repaint the control
        }

        private void UpdatePaths()
        {
            _controlPath?.Dispose();
            _shadowRegion?.Dispose();
            _innerPath?.Dispose();
            _region?.Dispose();
            _dropdownPath?.Dispose();

            int radius = BorderRadius * 2;

            Rectangle outerRect = new Rectangle(0, 0, Width, Height);
            _controlPath = CreateRoundedPath(outerRect, radius);

            Rectangle innerRect = new Rectangle(1, 1, Width - 2, Height - 2);
            _innerPath = CreateRoundedPath(innerRect, radius);

            int xMidPoint = this.Width - Math.Max(15, radius / 2);
            int yMidPoint = this.Height / 2;

            _trianglePoints = new Point[]
            {
                new Point(xMidPoint + 5, yMidPoint - 3), // Left of the "V"
                new Point(xMidPoint, yMidPoint + 3), // Bottom point of the "V"
                new Point(xMidPoint - 5, yMidPoint - 3)   // Right of the "V"
            };

            int triangleWidth = Math.Abs(_trianglePoints[0].X - _trianglePoints[2].X);

            Rectangle dropDownButtonRect = new Rectangle(xMidPoint - triangleWidth, outerRect.Y + BorderThickness, innerRect.Width - (xMidPoint - triangleWidth), outerRect.Height - (BorderThickness * 2));
            _dropdownPath = CreateDropDownPath(dropDownButtonRect, radius);

            base.Region = new Region(_controlPath);

            if (DropShadow)
            {
                Rectangle shadowRect = new Rectangle(shadowOffsetX + 1, shadowOffsetY + 1, Width, Height);
                _shadowRegion = new Region(shadowRect);
                _shadowRegion.Exclude(_innerPath);

                UpdateParentShadow();
            }

            _pathsNeedUpdate = false;
        }

        private void DrawShadow(Graphics g)
        {
            if (_shadowRegion == null) return;

            using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
            {
                g.FillRegion(shadowBrush, _shadowRegion);
            }
        }

        private void UpdateParentShadow()
        {
            if (!dropShadow) return;

            _parentShadowPath?.Dispose();

            int radius = BorderRadius * 2;

            Rectangle parentShadowRect = new Rectangle(this.Left + ShadowOffsetX, this.Top + ShadowOffsetY, this.Width, this.Height);
            _parentShadowPath = CreateRoundedPath(parentShadowRect, radius);

            if (Parent != null) this.Parent.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (!parentFound && this.FindForm() != null )
            {
                this.FindForm().MouseClick += Parent_Click;
                parentFound = true;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Parent != null && Parent.BackColor != BackColor) BackColor = Parent.BackColor;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_pathsNeedUpdate)
            {
                UpdatePaths();
            }

            using (SolidBrush fillBrush = new SolidBrush(textBoxColor))
            {
                e.Graphics.FillPath(fillBrush, _innerPath);
            }

            Color fillColor;
            //= isClicked
            //? BlendColors(defaultColor, clickColor, hoverProgress)
            //: BlendColors(defaultColor, hoverColor, hoverProgress);

            if (isDropdownShown) fillColor = clickColor;
            else if (isClicked) fillColor = BlendColors(defaultColor, clickColor, hoverProgress);
            else fillColor = BlendColors(defaultColor, hoverColor, hoverProgress);

            int dropdownWidth = 0;

            using (Brush buttonBrush = new SolidBrush(fillColor))
            {
                e.Graphics.FillPath(buttonBrush, _dropdownPath);
            }

            if (hasBorder)
            {
                using (Pen iconPen = new Pen(Color.Black))
                {
                    dropdownWidth = _trianglePoints[2].X - _trianglePoints[1].X;
                    e.Graphics.DrawLines(iconPen, _trianglePoints);
                }
            }

            if (DropShadow && _shadowRegion != null)
            {
                DrawShadow(e.Graphics);
            }

            // Draw the border
            using (Pen borderPen = new Pen(BorderColor, borderThickness))
            {
                e.Graphics.DrawPath(borderPen, _innerPath);
            }

            Rectangle textRect = new Rectangle(BorderRadius, (BorderThickness * 2), Width - (dropdownWidth * 3) - (BorderRadius * 2), Height - (BorderThickness * 4));
            TextFormatFlags textFormat;
            if (TextDirection == Direction.Right) textFormat = TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
            else if (TextDirection == Direction.Left) textFormat = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            else textFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            // Optionally, draw the text (if needed, or it will be drawn by default)

            string displayText = "Select...";
            if(SelectedItem != null) displayText = SelectedItem.ToString();


            TextRenderer.DrawText(
                e.Graphics,
                displayText,
                Font,
                new Rectangle(borderThickness, borderThickness, Width - Height, Height - 2 * borderThickness),
                this.ForeColor,
                textFormat);

        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent != null && Parent.BackColor != BackColor) BackColor = Parent.BackColor;
            if (this.Parent != null && dropShadow)
            {
                // Attach relevant event handlers
                this.Parent.Paint += Parent_Paint;
                this.Parent.SizeChanged += Parent_SizeOrLayoutChanged;
                this.Parent.Layout += Parent_SizeOrLayoutChanged;
            }
        }

        private void Parent_SizeOrLayoutChanged(object sender, EventArgs e)
        {
            if (this.Parent != null && dropShadow)
            {
                UpdateParentShadow();
                this.Parent.Invalidate();
            }
        }

        private void Parent_Paint(object sender, PaintEventArgs e)
        {
            if (this.Parent == null || !dropShadow || _parentShadowPath == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
            {
                e.Graphics.FillPath(shadowBrush, _parentShadowPath);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _pathsNeedUpdate = true;
            UpdatePaths();

            Invalidate();

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_dropdownPath.IsVisible(e.Location))
            {
                if (!isHovering)
                {
                    isHovering = true;
                    this.Invalidate(); // Redraw the form
                }
            }
            else
            {
                if (isHovering)
                {
                    isHovering = false;
                    this.Invalidate(); // Redraw the form
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (isHovering)
            {
                isClicked = true;
                if (isDropdownShown) CloseDropdown();
                else OpenDropdown();

                this.Invalidate(); // Redraw the form
            }

            animationTimer.Start();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isClicked)
            {
                isClicked = false;
                this.Invalidate(); // Redraw the form
            }

            animationTimer.Start();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!isHovering)
            {
                isHovering = true;
                this.Invalidate(); // Redraw the form
            }
            
            animationTimer.Start();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (isHovering)
            {
                isHovering = false;
                this.Invalidate(); // Redraw the form
            }
            animationTimer.Start();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            animationTimer.Start();
        }

        private EventHandlerList events = new EventHandlerList();
        public event EventHandler? SelectedIndexChanged
        {
            add => events.AddHandler(EVENT_SELECTEDINDEXCHANGED, value);
            remove => events.RemoveHandler(EVENT_SELECTEDINDEXCHANGED, value);
        }

        private void ListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Raise the custom SelectedIndexChanged event
            if (events[EVENT_SELECTEDINDEXCHANGED] is EventHandler handler)
            {
                handler(this, e);
            }
        }

        // Add a method to populate the ListBox
        public void AddItem(object item)
        {
            dropdownListBox.Items.Add(item);
        }

    }

}


