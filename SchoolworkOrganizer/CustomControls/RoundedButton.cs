using System.ComponentModel;
using System.Drawing.Drawing2D;
using static SchoolworkOrganizer.CustomControls.CustomControlUtilities;
using Timer = System.Windows.Forms.Timer;

namespace SchoolworkOrganizer.CustomControls
{
    public class RoundedButton : Button
    {
        private int borderRadius = 20;
        private Color borderColor = Color.Black;
        private int borderThickness = 2;
        private Color buttonColor = Color.White;

        private Color originalButtonColor = Color.Empty;
        private Color hoverColor = Color.Empty;
        private Color pressedColor = Color.Empty;

        private Timer animationTimer = new Timer();
        private float progress = 0;
        private bool hovering = false;
        private bool pressed = false;
        private bool hasLeft = false;
        private bool stop = false;

        private ImageLocation iconLocation = ImageLocation.Center;
        private Size imageSize = Size.Empty; 

        [Browsable(true)]
        [Category("Colors")]
        [Description("Specifies the button's color.")]
        public Color ButtonColor
        {
            get => buttonColor;
            set
            {
                buttonColor = value;
                if (originalButtonColor == Color.Empty) originalButtonColor = buttonColor;
                if (hoverColor == Color.Empty) hoverColor = Darker(ButtonColor);
                if (pressedColor == Color.Empty) pressedColor = Darker(hoverColor);

                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Image")]
        [Description("Specifies the button's Image.")]
        public new Image? Image
        {
            get => base.Image;
            set 
            {
                base.Image = value; 
                if(value != null && imageSize == Size.Empty)
                {
                    imageSize.Width = value.Width;
                    imageSize.Height = value.Height;
                }

                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Image")]
        [Description("Specifies the Image Size.")]
        public Size ImageSize 
        { 
            get => imageSize;
            set 
            { 
                imageSize = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Image")]
        [Description("Specifies the Background button's Image.")]
        public new Image? BackgroundImage
        {
            get => base.BackgroundImage;
            set
            {
                base.BackgroundImage = value;
                if (value != null && imageSize == Size.Empty)
                {
                    imageSize.Width = value.Width;
                    imageSize.Height = value.Height;
                }

                Invalidate();
            }
        }

        private Size backImageSize = Size.Empty;
        [Browsable(true)]
        [Category("Image")]
        [Description("Specifies the Background Image Size.")]
        public Size BackImageSize
        {
            get => backImageSize;
            set
            {
                backImageSize = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Colors")]
        [Description("Specifies the button's hover color.")]
        public Color HoverColor
        {
            get => hoverColor;
            set
            {
                hoverColor = value;
                Invalidate();
            }
        }


        [Browsable(true)]
        [Category("Colors")]
        [Description("Specifies the button's pressed color.")]
        public Color PressedColor
        {
            get => pressedColor;
            set 
            { 
                pressedColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Image")]
        [Description("Specifies the images location.")]
        public ImageLocation IconLocation 
        { 
            get => iconLocation;
            set 
            {
                iconLocation = value;
                Invalidate();
            } 
        }

        [Browsable(true)]
        [Category("Border")]
        [Description("Specifies the radius of the button's rounded corners.")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Max(0, value); // Ensure non-negative value
                Invalidate(); // Redraw the control when the property changes
            }
        }

        [Browsable(true)]
        [Category("Border")]
        [Description("Specifies the color of the button's border.")]
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
        [Category("Border")]
        [Description("Specifies the thickness of the button's border.")]
        public int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = Math.Max(0, value); // Ensure non-negative value
                Invalidate();
            }

        }

        public RoundedButton()
        {
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint,
                true
            );
            this.UpdateStyles();

            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 0;

            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            if (Image != null)
            {
                imageSize.Width = Image.Width;
                imageSize.Height = Image.Height;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);

            // Enable high-quality rendering

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle fullRect = new Rectangle(0 - 2, 0 - 2, Width + 3, Height + 3);
            DrawRect(pevent, fullRect, borderThickness, BackColor, borderColor);

            // Define the button's rectangle
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            if (BorderRadius > 0) DrawRoundedRect(pevent, rect, borderRadius, borderThickness, buttonColor, borderColor);
            else
            {
                DrawRect(pevent, rect, borderThickness, buttonColor, borderColor);
            }

            Rectangle contentRect = new Rectangle(rect.X + Padding.Left, rect.Y + Padding.Top, rect.Width - (Padding.Right + Padding.Left), rect.Height - (Padding.Top + Padding.Bottom));

            if (BackgroundImage != null)
            {
                // Calculate image bounds
                int imageX = contentRect.X + (contentRect.Width - imageSize.Width) / 2;
                int imageY = contentRect.Y + (contentRect.Height - imageSize.Height) / 2;

                Rectangle imageRect = new Rectangle(
                    imageX,
                    imageY,
                    imageSize.Width,
                    imageSize.Height
                );

                // Draw the image
                pevent.Graphics.DrawImage(BackgroundImage, imageRect);

                if (ButtonColor != originalButtonColor)
                {
                    Color color = Color.FromArgb(125, ButtonColor.R, ButtonColor.G, ButtonColor.B);
                    if (BorderRadius > 0) DrawRoundedRect(pevent, rect, borderRadius, borderThickness, color, borderColor);
                    else
                    {
                        DrawRect(pevent, rect, borderThickness, color, borderColor);
                    }
                }

            }

            if (Image != null)
            {
                // Calculate image bounds
                int imageX;
                int imageY = contentRect.Y + (contentRect.Height - imageSize.Height) / 2;

                if (IconLocation == ImageLocation.Left) imageX = Padding.Left;
                else if (IconLocation == ImageLocation.Right) imageX = rect.Width - imageSize.Width - Padding.Right;
                else imageX = contentRect.X + (contentRect.Width - imageSize.Width) / 2;

                Rectangle imageRect = new Rectangle(
                    imageX,
                    imageY,
                    imageSize.Width,
                    imageSize.Height
                );

                if (IconLocation == ImageLocation.Left) 
                {
                    contentRect.X += imageSize.Width;
                    contentRect.Width -= imageSize.Height;
                }
                else if (IconLocation == ImageLocation.Right) contentRect.Width -= imageSize.Width;

                // Draw the image
                pevent.Graphics.DrawImage(Image, imageRect);
            }

            

            TextRenderer.DrawText(
                pevent.Graphics,
                Text,
                Font,
                contentRect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak
            );

        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (stop) return;
            // Adjust hover progress gradually
            float target;
            if (pressed) target = 1;
            else if (hovering && !hasLeft) target = 0.5f;
            else target = 0;

            progress += (target - progress) * 0.2f; // Smooth transition

            if (Math.Abs(target - progress) < 0.01f)
            {
                progress = target;
                animationTimer.Stop();
            }

            ButtonColor = BlendColors(originalButtonColor, pressedColor, progress);
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate(); // Redraw the control when it gains focus
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate(); // Redraw the control when it loses focus
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            pressed = true;
            animationTimer.Start();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            pressed = false;
            hovering = true;
            
            animationTimer.Start();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            pressed = false;
            hovering = true;
            hasLeft = false;

            animationTimer.Start();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            pressed = false;
            hovering = false;
            hasLeft = true;

            animationTimer.Start();
        }

        public void Reset()
        {
            stop = true;
            animationTimer.Stop();
            this.pressed = false;
            this.hovering = false;
            this.hasLeft = true;
            this.progress = 0;
            this.buttonColor = originalButtonColor;
            
            Invalidate();
            stop = false;

            this.Focus();
            OnMouseLeave(EventArgs.Empty);
            Invalidate();
        }

        public enum ImageLocation
        {
            Left,
            Center,
            Right
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }


    }
}
