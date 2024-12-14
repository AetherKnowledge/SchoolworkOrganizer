using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolworkOrganizer.CustomControls.CustomControlUtilities;

namespace SchoolworkOrganizer.CustomControls
{
    public class RoundedTextBox : UserControl
    {

        public readonly TextBox innerTextBox = new TextBox();
        private bool roundedBorder = true;
        private int borderRadius = 10;
        private Color borderColor = Color.Black;
        private int borderThickness = 1;
        private Color textBoxColor = Color.White;
        private bool dropShadow = false;
        private Color shadowColor = Color.FromArgb(128, 0, 0, 0); // Semi-transparent black
        private int shadowOffsetX = 3;
        private int shadowOffsetY = 3;
        private GraphicsPath _controlPath;
        private GraphicsPath _innerPath;
        private Region _region;
        private Region _shadowRegion;
        private GraphicsPath _parentShadowPath;
        private bool _pathsNeedUpdate = true;
        private string placeholderText = "Placeholder";
        public bool hasBorder
        {
            get;
            private set;
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change Text")]
        [Browsable(true)]
        public override string Text
        {
            get => innerTextBox.Text;
            set
            {
                //if (WithPlaceHolder && value == "") value = "Placeholder";
                innerTextBox.Text = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change Text Allignment")]
        public HorizontalAlignment TextAlign
        {
            get => innerTextBox.TextAlign;
            set
            {
                //if (WithPlaceHolder && value == "") value = "Placeholder";
                innerTextBox.TextAlign = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change if use password char")]
        public bool UseSystemPasswordChar
        {
            get => innerTextBox.UseSystemPasswordChar;
            set
            {
                //if (WithPlaceHolder && value == "") value = "Placeholder";
                innerTextBox.UseSystemPasswordChar = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                innerTextBox.Font = value;

                int height = innerTextBox.Height + borderRadius;
                if (!Multiline) this.Height = height;

                Invalidate();
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                innerTextBox.ForeColor = value;
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
                innerTextBox.BackColor = textBoxColor;
                Invalidate(); // Redraw the control when the property changes
            }
        }

        [Category("Appearance")]
        [AllowNull]
        [Description("Change Lines")]
        [Editor($"System.Windows.Forms.Design.StringArrayEditor", typeof(UITypeEditor))]
        public string[] Lines
        {
            get => innerTextBox.Lines;
            set
            {
                //if (WithPlaceHolder && (value == null || value.Length == 0)) value = new string[] { "Placeholder" };
                innerTextBox.Lines = value;
                Invalidate();
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
                _pathsNeedUpdate = true;

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
                _pathsNeedUpdate = true;

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
                UpdateInnerTextBoxPosition();
                _pathsNeedUpdate = true;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies if multiline")]
        public bool Multiline
        {
            get => innerTextBox.Multiline;
            set
            {
                innerTextBox.Multiline = value;
                if (!value) this.Height = innerTextBox.Height + borderRadius;
                UpdateInnerTextBoxPosition();
                Invalidate();
            }
        }

        private bool _withPlaceHolder;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies if it should have a placeholder text that will be replaced when clicked")]
        public bool WithPlaceHolder
        {
            get { return _withPlaceHolder; }
            set
            {
                _withPlaceHolder = value;
                if (WithPlaceHolder)
                {
                    if (PlaceHolderText == "") PlaceHolderText = "Placeholder";
                }
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Specifies placeholder text")]
        public string PlaceHolderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                if (PlaceHolderText == "") PlaceHolderText = "Placeholder";
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

        public RoundedTextBox()
        {
            // Configure the inner TextBox
            this.SetStyle(ControlStyles.UserPaint, true); // Enable custom painting
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            hasBorder = true;

            innerTextBox.BorderStyle = BorderStyle.None;
            innerTextBox.Font = this.Font;
            innerTextBox.BackColor = textBoxColor;
            innerTextBox.ForeColor = this.ForeColor;
            UpdateInnerTextBoxPosition();
            innerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            innerTextBox.Multiline = true;

            this.Controls.Add(innerTextBox);

            this.Padding = new Padding(borderThickness);
            this.Size = new Size(200, 30);

            if (Parent == null) this.BackColor = Color.White;
            else this.BackColor = Parent.BackColor;

            UpdatePaths();
            AddPlaceholder();
            this.Text = PlaceHolderText;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!Multiline)
            {
                int gap = ((borderRadius / 2) + BorderThickness * 2);
                height = innerTextBox.Height + gap + 1;
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void UpdateInnerTextBoxPosition()
        {
            int gap = (borderRadius + (BorderThickness * 2)) ;
            int width = this.Width - gap * 2;
            int height = this.Height - BorderThickness * 4;

            innerTextBox.Location = new Point(gap, BorderThickness * 2);
            innerTextBox.Width = width;
            innerTextBox.Height = height;


        }

        private void UpdatePaths()
        {
            _controlPath?.Dispose();
            _shadowRegion?.Dispose();
            _innerPath?.Dispose();
            _region?.Dispose();

            int radius = BorderRadius * 2;

            Rectangle outerRect = new Rectangle(0, 0, Width, Height);
            Rectangle innerRect = new Rectangle(1, 1, Width - 2, Height - 2);

            if (radius > 0) 
            { 
                _controlPath = CreateRoundedPath(outerRect, radius);
                _innerPath = CreateRoundedPath(innerRect, radius);
            }
            else
            {
                _controlPath = CreateRectanglePath(outerRect);
                _innerPath = CreateRectanglePath(innerRect);
            }
            

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
            // Ensure the background color matches the parent (if applicable)
            if (Parent != null && Parent.BackColor != BackColor) BackColor = Parent.BackColor;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_pathsNeedUpdate)
            {
                UpdatePaths();

            }

            
            if (DropShadow && _shadowRegion != null)
            {
                DrawShadow(e.Graphics);
            }
            //Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            //if (BorderRadius > 0) DrawRoundedRect(e, rect, borderRadius, borderThickness, textBoxColor, borderColor);
            //else
            //{
            //    DrawRect(e, rect, borderThickness, textBoxColor, borderColor);
            //}

            using (SolidBrush fillBrush = new SolidBrush(textBoxColor))
            {
                e.Graphics.FillPath(fillBrush, _innerPath);
            }

            if (hasBorder)
            {
                using (Pen borderPen = new Pen(BorderColor, borderThickness))
                {
                    e.Graphics.DrawPath(borderPen, _innerPath);
                }

            }
        }

        private void DrawShadow(Graphics g)
        {
            if (_shadowRegion == null) return;

            using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
            {
                g.FillRegion(shadowBrush, _shadowRegion);
            }
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

            UpdateInnerTextBoxPosition();
            Invalidate();

        }

        private void AddPlaceholder()
        {
            
            innerTextBox.ForeColor = Color.Gray;

            innerTextBox.Enter += (sender, e) =>
            {
                if (!WithPlaceHolder) return;
                if (innerTextBox.Text == PlaceHolderText)
                {
                    innerTextBox.Text = "";
                    innerTextBox.ForeColor = Color.Black;
                }
            };

            innerTextBox.Leave += (sender, e) =>
            {
                if (!WithPlaceHolder) return;
                if (string.IsNullOrWhiteSpace(innerTextBox.Text))
                {
                    innerTextBox.Text = PlaceHolderText;
                    innerTextBox.ForeColor = Color.Gray;
                }
            };

        }


    }
}
