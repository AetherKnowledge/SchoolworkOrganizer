using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SchoolworkOrganizer.CustomControls
{
    public class RoundedTextBoxOld : TextBox
    {
        private int borderRadius = 15;
        private int borderThickness = 2;
        private Color textBoxColor = Color.White;
        private bool withPlaceHolder;
        private Color borderColor = Color.Black;
        private bool dropShadow = false;
        private Color shadowColor = Color.FromArgb(128, 0, 0, 0); // Semi-transparent black
        private int shadowOffsetX = 3;
        private int shadowOffsetY = 3;
        private GraphicsPath _controlPath;
        private GraphicsPath _innerPath;
        private Region _shadowRegion;
        private GraphicsPath _parentShadowPath;
        private bool _pathsNeedUpdate = true;

        [Browsable(false)]
        [Category("Appearance")]
        [Description("Specifies the color of the border.")]
        public new Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;

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
                this.Invalidate();
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
                borderThickness = Math.Max(1, value);
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
                base.BackColor = value;
                Invalidate(); // Redraw the control when the property changes
            }
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change Lines")]
        [Editor($"System.Windows.Forms.Design.StringArrayEditor", typeof(UITypeEditor))]
        public new string[] Lines
        {
            get => base.Lines;
            set
            {
                if (WithPlaceHolder && (value == null || value.Length == 0)) value = new string[] { "Placeholder" };
                base.Lines = value;
            }
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change Text")]
        public new string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (WithPlaceHolder && value == "") value = "Placeholder";

            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies if it should have a placeholder text that will be replaced when clicked")]
        public bool WithPlaceHolder
        {
            get { return withPlaceHolder; }
            set
            {
                withPlaceHolder = value;
                if (WithPlaceHolder)
                {
                    if (base.Text == "") base.Text = "Placeholder";
                    AddPlaceholder();
                }
                else this.ForeColor = Color.Black;
                Invalidate();
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
                Invalidate();
            }
        }

        public RoundedTextBoxOld()
        {
            this.SetStyle(ControlStyles.UserPaint, true); // Enable custom painting
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.Black;
            UpdatePaths();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _pathsNeedUpdate = true; // Mark paths for recalculation

        }

        private void UpdatePaths()
        {
            _controlPath?.Dispose(); // Dispose old path
            _shadowRegion?.Dispose();
            _innerPath?.Dispose();


            int radius = BorderRadius * 2;

            Rectangle outerRect = new Rectangle(0, 0, Width, Height);
            _controlPath = CreateRoundedPath(outerRect, radius);

            Rectangle innerRect = new Rectangle(1, 1, Width - 2, Height - 2);
            _innerPath = CreateRoundedPath(innerRect, radius);

            if (DropShadow)
            {
                UpdateParentShadow();

                Rectangle shadowRect = new Rectangle(shadowOffsetX + 1, shadowOffsetY + 1, Width, Height);
                _shadowRegion = new Region(shadowRect);
                _shadowRegion.Exclude(_innerPath); // Exclude the main control path
            }

            _pathsNeedUpdate = false; // Reset flag
        }

        private void UpdateParentShadow()
        {
            if (!dropShadow) return;

            _parentShadowPath?.Dispose();

            int radius = BorderRadius * 2;

            Rectangle parentShadowRect = new Rectangle(this.Left + ShadowOffsetX, this.Top + ShadowOffsetY, this.Width, this.Height);
            _parentShadowPath = CreateRoundedPath(parentShadowRect, radius);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Ensure the background color matches the parent (if applicable)
            if (Parent != null && Parent.BackColor != BackColor) BackColor = Parent.BackColor;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (_pathsNeedUpdate)
            {
                UpdatePaths();
                this.Region = new Region(_controlPath);
            }

            if (DropShadow && _shadowRegion != null)
            {
                DrawShadow(e.Graphics);
            }

            using (SolidBrush fillBrush = new SolidBrush(textBoxColor))
            {
                e.Graphics.FillPath(fillBrush, _innerPath);
            }

            // Draw the border
            using (Pen borderPen = new Pen(BorderColor, borderThickness))
            {
                e.Graphics.DrawPath(borderPen, _innerPath);
            }

            DrawAlignedText(e.Graphics);
        }

        private GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();
            return path;
        }

        private void DrawShadow(Graphics g)
        {
            if (_shadowRegion == null) return;

            using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
            {
                g.FillRegion(shadowBrush, _shadowRegion);
            }
        }
        private void DrawAlignedText(Graphics g)
        {
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = TextAlign switch
                {
                    HorizontalAlignment.Left => StringAlignment.Near,
                    HorizontalAlignment.Center => StringAlignment.Center,
                    HorizontalAlignment.Right => StringAlignment.Far,
                    _ => StringAlignment.Near
                };
                format.LineAlignment = StringAlignment.Near;

                Rectangle textRect = new Rectangle((BorderRadius / 2), BorderThickness, Width - BorderRadius, Height - (BorderThickness * 2));
                using (Brush textBrush = new SolidBrush(ForeColor))
                {
                    g.DrawString(Text, Font, textBrush, textRect, format);
                }
            }
        }

        private void AddPlaceholder()
        {
            string placeholder = this.Text;
            this.ForeColor = Color.Gray;

            this.Enter += (sender, e) =>
            {
                if (this.Text == placeholder)
                {
                    this.Text = "";
                    this.ForeColor = Color.Black;
                }
            };

            this.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                {
                    this.Text = placeholder;
                    this.ForeColor = Color.Gray;
                }
            };

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
                // Force the parent to repaint when size or layout changes
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


    }
}
