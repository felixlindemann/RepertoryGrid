using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LimeTree.Gui.Input
{


    public class RotatedTextLabel : System.Windows.Forms.Label
    {

        #region Variables

        private double rotationAngle;
        private string text;
        private Boolean isDebug = false;
        private Boolean isFitHeight = true;
        private Boolean isFitWidth = true;
        private Boolean demoModus = true;
        private ContentAlignment rotatedAlign = ContentAlignment.MiddleCenter;
        private SizeF sizeF = new SizeF(300, 200);

        #endregion

        #region Constructor

        public RotatedTextLabel()
        {
            //Setting the initial condition.
            rotationAngle = 0d;
            this.Size = new Size(105, 12);
            this.TextAlign = ContentAlignment.BottomRight;
            this.SizeChanged += new System.EventHandler(RotatedTextLabel_SizeChanged);
        }

        void RotatedTextLabel_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

        #region Properties

        [Description("Rotation Angle"), Category("Appearance")]
        public double RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {
                rotationAngle = value;
                this.Invalidate();
            }
        }

        [Description("DemoBoxSize"), Category("Appearance")]
        public SizeF DemoBoxSize
        {
            get
            {
                return sizeF;
            }
            set
            {
                sizeF = value;
                this.Invalidate();
            }
        }
        [Description("Debugging"), Category("Appearance")]
        public Boolean Debugging
        {
            get
            {
                return isDebug;
            }
            set
            {
                isDebug = value;
                this.Invalidate();
            }
        }


        [Description("FitHeight"), Category("Appearance")]
        public Boolean FitHeight
        {
            get
            {
                return isFitHeight;
            }
            set
            {
                isFitHeight = value;
                this.Invalidate();
            }
        }

        [Description("FitWidth"), Category("Appearance")]
        public Boolean FitWidth
        {
            get
            {
                return isFitWidth;
            }
            set
            {
                isFitWidth = value;
                this.Invalidate();
            }
        }
        [Description("DemoModus"), Category("Appearance")]
        public Boolean DemoModus
        {
            get
            {
                return demoModus;
            }
            set
            {
                demoModus = value;
                this.Invalidate();
            }
        }

        [Description("RotatedAlign"), Category("Appearance")]
        public ContentAlignment RotatedAlign
        {
            get
            {
                return rotatedAlign;
            }
            set
            {
                rotatedAlign = value;
                this.Invalidate();
            }
        }

        private double angle
        {
            get
            {  //For rotation, who about rotation?
                return (this.RotationAngle / 180) * Math.PI;
            }
        }

        [Description("Display Text"), Category("Appearance")]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Method

        private int[] abcd
        {
            get
            {
                return new int[] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 };
            }
        }

        private StringFormat SFormat
        {
            get
            {
                StringFormat sformat = new StringFormat();

                switch (this.TextAlign)
                {
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.TopLeft:
                        sformat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                        sformat.Alignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                        sformat.Alignment = StringAlignment.Center;
                        break;
                }
                switch (this.TextAlign)
                {
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopLeft:
                        sformat.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        sformat.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        sformat.LineAlignment = StringAlignment.Center;
                        break;
                }

                return sformat;
            }
        }

        private Brush TextBrush { get { return new SolidBrush(this.ForeColor); } }

        private String[] Points
        {
            get
            {
                List<String> p = new List<string>();
                foreach (int i in abcd)
                {
                    p.Add("" + Convert.ToChar(65 + i));
                }
                return p.ToArray();
            }
        }

        private Pen penDiagonal
        {
            get
            {
                Pen p = new Pen(Color.Red, 1f);
                p.DashStyle = DashStyle.DashDotDot;
                return p;
            }
        }

        private Pen penOuter
        {
            get
            {
                Pen p = new Pen(Color.Blue, 1f);
                p.DashStyle = DashStyle.DashDotDot;
                return p;
            }
        }

        private Pen penInner
        {
            get
            {
                Pen p = new Pen(Color.Green, 1f);
                p.DashStyle = DashStyle.Solid;
                return p;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Brush[] dots = { Brushes.Black, Brushes.Green, Brushes.Blue };

                float radius = 5;
                Graphics g = e.Graphics;
                GraphicsState state = g.Save();
                g.Clear(Color.White);

                double[,] a = new double[6, 2];


                RectangleF r = new RectangleF(this.Margin.Left, this.Margin.Top,
                    this.Width - this.Margin.Horizontal,
                    this.Height - this.Margin.Vertical);

                if (this.demoModus)
                {
                    r = new RectangleF(this.Margin.Left + (this.Width - this.Margin.Horizontal - sizeF.Width) / 2,
                                       this.Margin.Top + (this.Height - this.Margin.Vertical - sizeF.Height) / 2,
                                       sizeF.Width, sizeF.Height);

                }
                //  g.TranslateTransform(this.Margin.Left, this.Margin.Top);
                g.TranslateTransform(r.X, r.Y);
                r.X = 0;
                r.Y = 0;

                Double alpha = rotationAngle;
                while (alpha <= 0)
                {
                    alpha += 360;
                }
                while (alpha >= 360)
                {
                    alpha -= 360;
                }
                PointF[] ABCD = { new PointF(), new PointF(), new PointF(), new PointF() };
                PointF[] ABCD1 = { new PointF(), new PointF(), new PointF(), new PointF() }; // A', B', C', D'
                PointF[] ABCD2 = { new PointF(), new PointF(), new PointF(), new PointF(), new PointF(r.Width / 2, r.Height / 2) }; // A", B", C", D", M



                int rot = 0;

                if (alpha >= 0 && 
                    alpha < 90)
                {
                    rot = 0;
                }
                else if (alpha >= 90 &&
                    alpha < 180)
                {
                    rot = 1;
                }
                else if (alpha >= 180 &&
                    alpha < 270)
                {
                    rot = 2;
                }
                else
                {
                    rot = 3;
                }
                alpha = -alpha;
                double alphaRad = alpha * Math.PI / 180;
                alphaRad = alphaRad - rot * Math.PI / 2;

                ABCD[abcd[rot + 0]] = new PointF(r.X, r.Y);
                ABCD[abcd[rot + 1]] = new PointF(r.X + r.Width, r.Y);
                ABCD[abcd[rot + 2]] = new PointF(r.X + r.Width, r.Y + r.Height);
                ABCD[abcd[rot + 3]] = new PointF(r.X, r.Y + r.Height);

                // f(x) =  a * x + b
                // b    = f(x) - a*x  
                // x    = (f(x) - b) / a
                // m    = tan(alpha)
                // mS   = -1/m
                double m = Math.Tan(alphaRad);

                  if (alpha % 90 == 0)
                {
                    if (this.Width > this.Height)
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            ABCD1[abcd[rot + i]] = ABCD[abcd[rot + i]];
                            ABCD2[abcd[rot + i]] = ABCD[abcd[rot + i]];
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    double mS = -1 / Math.Tan(alphaRad);
                    // A"B"
                    a[0, 0] = m;
                    a[0, 1] = ABCD[abcd[rot + 0]].Y - a[0, 0] * ABCD[abcd[rot + 0]].X;

                    // B"C"
                    a[1, 0] = mS;
                    a[1, 1] = ABCD[abcd[rot + 1]].Y - a[1, 0] * ABCD[abcd[rot + 1]].X;

                    // C"D"
                    a[2, 0] = m;
                    a[2, 1] = ABCD[abcd[rot + 2]].Y - a[2, 0] * ABCD[abcd[rot + 2]].X;

                    // D"A"
                    a[3, 0] = mS;
                    a[3, 1] = ABCD[abcd[rot + 3]].Y - a[3, 0] * ABCD[abcd[rot + 3]].X;



                    // f(x1) = a1*x1 + b1
                    // f(x2) = a2*x2 + b2
                    // a1*x + b1  = a2*x + b2
                    // (a1-a2) * x = (b2 - b1)
                    //  x = (b2 - b1) / (a1-a2) 


                    // A"
                    ABCD2[abcd[rot + 0]] = new PointF();
                    ABCD2[abcd[rot + 0]].X = (float)((a[3, 1] - a[0, 1]) / (a[0, 0] - a[3, 0]));
                    ABCD2[abcd[rot + 0]].Y = (float)(a[0, 1] + a[0, 0] * ABCD2[abcd[rot + 0]].X);

                    // B"
                    ABCD2[abcd[rot + 1]] = new PointF();
                    ABCD2[abcd[rot + 1]].X = (float)((a[1, 1] - a[0, 1]) / (a[0, 0] - a[1, 0]));
                    ABCD2[abcd[rot + 1]].Y = (float)(a[0, 1] + a[0, 0] * ABCD2[abcd[rot + 1]].X);

                    // C"
                    ABCD2[abcd[rot + 2]] = new PointF();
                    ABCD2[abcd[rot + 2]].X = (float)((a[1, 1] - a[2, 1]) / (a[2, 0] - a[1, 0]));
                    ABCD2[abcd[rot + 2]].Y = (float)(a[2, 1] + a[2, 0] * ABCD2[abcd[rot + 2]].X);

                    // D"
                    ABCD2[abcd[rot + 3]] = new PointF();
                    ABCD2[abcd[rot + 3]].X = (float)((a[2, 1] - a[3, 1]) / (a[3, 0] - a[2, 0]));
                    ABCD2[abcd[rot + 3]].Y = (float)(a[3, 1] + a[3, 0] * ABCD2[abcd[rot + 3]].X);

                }
                // g(x) 
                double dx = ABCD2[abcd[rot + 2]].X - ABCD2[abcd[rot + 0]].X;
                double dy = ABCD2[abcd[rot + 2]].Y - ABCD2[abcd[rot + 0]].Y;

                if (dx != 0)
                {
                    a[4, 0] = (dy / dx);
                    a[4, 1] = ABCD2[abcd[rot + 0]].Y - a[4, 0] * ABCD2[abcd[rot + 0]].X;
                }
                else
                {
                    // no function (x);
                    a[4, 0] = Double.NaN;
                    a[4, 1] = Double.NaN;
                }

                // h(x)
                dx = ABCD2[abcd[rot + 1]].X - ABCD2[abcd[rot + 3]].X;
                dy = ABCD2[abcd[rot + 1]].Y - ABCD2[abcd[rot + 3]].Y;
                if (dx != 0)
                {
                    a[5, 0] = (dy / dx);
                    a[5, 1] = ABCD2[abcd[rot + 1]].Y - a[5, 0] * ABCD2[abcd[rot + 1]].X;
                }
                else
                {
                    // no function (x);
                    a[5, 0] = Double.NaN;
                    a[5, 1] = Double.NaN;
                }


                if (double.IsNaN(a[4, 0]))
                {
                    // rotation 0°
                    for (int i = 0; i <= 3; i++)
                    {
                        ABCD1[abcd[rot + i]] = ABCD[abcd[rot + i]];
                    }
                }
                else
                {
                    if (r.Width > r.Height)
                    {

                        ABCD1[abcd[rot + 1]].Y = 0;
                        ABCD1[abcd[rot + 3]].Y = r.Height;

                        if (double.IsNaN(a[5, 0]))
                        {
                            ABCD1[abcd[rot + 1]].X = ABCD2[4].X;
                            ABCD1[abcd[rot + 3]].X = ABCD2[4].X;
                        }
                        else
                        {
                            // x = (f(x) - b) / a
                            ABCD1[abcd[rot + 1]].X = (float)((ABCD1[abcd[rot + 1]].Y - a[5, 1]) / a[5, 0]);
                            ABCD1[abcd[rot + 3]].X = (float)((ABCD1[abcd[rot + 3]].Y - a[5, 1]) / a[5, 0]);
                        }
                        // b =  y - mx
                        double b = 0;
                        // t(x) = s(x)
                        // at * x + bt = as * x + bs
                        // (at - as) * x = (bs - bt)
                        // x = (bs - bt) / (at - as) 

                        // find A'
                        b = ABCD1[abcd[rot + 1]].Y - a[0, 0] * ABCD1[abcd[rot + 1]].X;
                        ABCD1[abcd[rot + 0]].X = (float)((a[4, 1] - b) / (a[0, 0] - a[4, 0]));
                        ABCD1[abcd[rot + 0]].Y = (float)(ABCD1[abcd[rot + 0]].X * a[0, 0] + b);


                        // find C'  
                        b = ABCD1[abcd[rot + 1]].Y - a[1, 0] * ABCD1[abcd[rot + 1]].X;
                        ABCD1[abcd[rot + 2]].X = (float)((a[4, 1] - b) / (a[1, 0] - a[4, 0]));
                        ABCD1[abcd[rot + 2]].Y = (float)(ABCD1[abcd[rot + 2]].X * a[1, 0] + b);



                    }
                    else
                    { 
                        ABCD1[abcd[rot + 0]].X = 0;
                        ABCD1[abcd[rot + 2]].X = r.Width;

                        ABCD1[abcd[rot + 0]].Y = (float)(a[4, 0] * ABCD1[abcd[rot + 0]].X + a[4, 1]);
                        ABCD1[abcd[rot + 2]].Y = (float)(a[4, 0] * ABCD1[abcd[rot + 2]].X + a[4, 1]);

                        double b = ABCD1[abcd[rot + 0]].Y - (a[0, 0] * ABCD1[abcd[rot + 0]].X + a[0, 1]);
                        if (double.IsNaN(a[5, 0])) // 45°
                        {
                            ABCD1[abcd[rot + 1]].X = ABCD2[4].X;
                            ABCD1[abcd[rot + 3]].X = ABCD2[4].X;
                        }
                        else
                        {

                            // t(x) = s(x)
                            // at * x + bt = as * x + bs
                            // (at - as) * x = (bs - bt)
                            // x = (bs - bt) / (at - as) 

                            // find B'
                            ABCD1[abcd[rot + 1]].X = (float)((a[5, 1] - b) / (a[0, 0] - a[5, 0]));


                            // find D'
                            ABCD1[abcd[rot + 3]].X = (float)((a[5, 1] - b) / (a[1, 0] - a[5, 0]));
                        }

                        // find B'
                        ABCD1[abcd[rot + 1]].Y = (float)(a[0, 0] * ABCD1[abcd[rot + 1]].X + b);


                        // find D'0
                        ABCD1[abcd[rot + 3]].Y = (float)(a[1, 0] * ABCD1[abcd[rot + 3]].X + b);

                    }

                }
                // alignment
                dx = 0;
                dy = 0;
                switch (this.RotatedAlign)
                {
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.TopLeft:
                        dx = (ABCD.Min(x => x.X) - ABCD1.Min(x => x.X));
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                        dx = (ABCD.Max(x => x.X) - ABCD1.Max(x => x.X));
                        break;
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                        dx = ABCD2[4].X - ((ABCD1.Max(x => x.X) + ABCD1.Min(x => x.X)) / 2);
                        break;
                }
                switch (this.RotatedAlign)
                {
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopLeft:
                        dy = (ABCD.Min(x => x.Y) - ABCD1.Min(x => x.Y));
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        dy = (ABCD.Max(x => x.Y) - ABCD1.Max(x => x.Y));
                        break;
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        dy = ABCD2[4].Y - (ABCD1.Min(x => x.Y) + ABCD1.Max(x => x.Y)) / 2;
                        break;
                }


                for (int i = 0; i < ABCD1.Length; i++)
                {
                    ABCD1[i].X = ABCD1[i].X + (float)dx;
                    ABCD1[i].Y = ABCD1[i].Y + (float)dy;
                }

                r.Width = (float)(Math.Sqrt(
                    Math.Pow(ABCD1[abcd[rot + 0]].X - ABCD1[abcd[rot + 1]].X, 2) +
                    Math.Pow(ABCD1[abcd[rot + 0]].Y - ABCD1[abcd[rot + 1]].Y, 2)));

                r.Height = (float)(Math.Sqrt(
                    Math.Pow(ABCD1[abcd[rot + 0]].X - ABCD1[abcd[rot + 3]].X, 2) +
                    Math.Pow(ABCD1[abcd[rot + 0]].Y - ABCD1[abcd[rot + 3]].Y, 2)));

                SizeF s = g.MeasureString(this.Text, this.Font);


                if (this.FitWidth)
                {
                    r.Width = s.Width;
                }
                if (this.FitHeight)
                {
                    r.Height = s.Height;
                }

                if (rot % 2 != 0)
                {
                    float tmp = r.Width;
                    r.Width = r.Height;
                    r.Height = tmp;
                }

                if (isDebug)
                {

                    for (int i = 0; i <= 3; i++)
                    {
                        PointF p;
                        p = ABCD[abcd[rot + i]];
                        g.FillEllipse(dots[0], p.X - radius, p.Y - radius, radius * 2, radius * 2);
                        g.DrawString(Points[abcd[rot + i]], this.Font, TextBrush, p.X + radius, p.Y + radius);

                        p = ABCD1[abcd[rot + i]];
                        g.FillEllipse(dots[1], p.X - radius, p.Y - radius, 2 * radius, 2 * radius);
                        g.DrawString(Points[abcd[rot + i]] + "'", this.Font, dots[2], p.X + radius, p.Y + radius);

                        p = ABCD2[abcd[rot + i]];
                        g.FillEllipse(dots[2], p.X - radius, p.Y - radius, radius * 2, radius * 2);
                        g.DrawString(Points[abcd[rot + i]] + "\"", this.Font, dots[2], p.X + radius, p.Y + radius);



                    }

                    g.DrawLines(new Pen(Color.Black), ABCD);
                    g.DrawLine(new Pen(Color.Black), ABCD[0], ABCD[3]);

                    g.DrawLines(penOuter, ABCD2);
                    g.DrawLine(penOuter, ABCD2[0], ABCD2[3]);

                    g.DrawLine(penDiagonal, ABCD2[abcd[rot + 0]], ABCD2[abcd[rot + 2]]);
                    g.DrawLine(penDiagonal, ABCD2[abcd[rot + 1]], ABCD2[abcd[rot + 3]]);

                    g.DrawLines(penInner, ABCD1);
                    g.DrawLine(penInner, ABCD1[0], ABCD1[3]);
                   
                    g.DrawString(string.Format("rotationAngle: {3}\nalpha: {2}\nalphaRad: {0}\nrot: {1}\nm: {4}\nTransformTo: {5}",
                   alphaRad, rot, alpha, RotationAngle, m, Points[abcd[rot]]),
                                       this.Font, TextBrush, ABCD.Max(x=> x.X) + 50, ABCD.Min(x=> x.Y));

             
                }

                
                g.TranslateTransform(
                    ABCD1[0].X,
                    ABCD1[0].Y);
                
                // Rotate.
                g.RotateTransform((float)-RotationAngle);

                if (isDebug || this.BorderStyle != System.Windows.Forms.BorderStyle.None)
                {
                      // g.FillRectangle(Brushes.Yellow, r.X, r.Y, r.Width, r.Height);
                    g.DrawRectangle(new Pen(Color.Black, 1), r.X, r.Y, r.Width, r.Height);
                }

                // Draw the text at the origin.
                g.DrawString(this.text, this.Font, TextBrush, r, SFormat); //, stringFormat);

                // Restore the graphics state.
                g.Restore(state);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        protected void OnPaintOld(PaintEventArgs e)
        {
            float radius = 5;
            Graphics graphics = e.Graphics;
            GraphicsState state = graphics.Save();
            Brush textBrush = new SolidBrush(this.ForeColor);


            RectangleF r = new RectangleF(0, 0, this.Width - this.Margin.Horizontal, this.Height - this.Margin.Vertical);

            Double alpha = rotationAngle;
            while (alpha < 0)
            {
                alpha += 360;
            }
            while (alpha >= 360)
            {
                alpha -= 360;
            }


            double alphaRad = alpha * Math.PI / 180;
            PointF[] ABCD = { new PointF(), new PointF(), new PointF(), new PointF() };
            int[] abcd = { 0, 1, 2, 3 };


            SizeF nSize = new SizeF(0, 0);

            if (alphaRad < Math.PI / 2)
            {
                abcd = new int[] { 0, 1, 2, 3 };
                alphaRad -= 0;
            }
            else if (alphaRad >= Math.PI / 2 && alphaRad < Math.PI)
            {

                abcd = new int[] { 1, 2, 3, 0 };
                alphaRad -= Math.PI / 2;
            }
            else if (alphaRad >= Math.PI && alphaRad < Math.PI * 3 / 2)
            {
                abcd = new int[] { 2, 3, 0, 1 };
                alphaRad -= Math.PI;
            }
            else if (alphaRad >= Math.PI * 3 / 2)
            {
                abcd = new int[] { 3, 0, 1, 2 };
                alphaRad -= Math.PI * 3 / 2;
            }


            ABCD[abcd[0]] = new PointF(0, 0);
            ABCD[abcd[1]] = new PointF(r.Width, 0);
            ABCD[abcd[2]] = new PointF(r.Width, r.Height);
            ABCD[abcd[3]] = new PointF(0, r.Height);

            ABCD[abcd[1]] = new PointF(
                (float)(r.Width * (1 - alphaRad / (Math.PI / 2))),
                (float)(0));

            nSize.Width = (float)(ABCD[abcd[1]].X / Math.Cos(alphaRad));
            nSize.Height = (float)Math.Min((r.Height - nSize.Width * Math.Sin(alphaRad)) / Math.Cos(alphaRad), r.Width);

            if (this.isFitHeight)
            {
                nSize.Height = graphics.MeasureString(this.Text, this.Font).Width;
            }
            if (this.isFitWidth)
            {
                nSize.Width = graphics.MeasureString(this.Text, this.Font).Height;
            }

            ABCD[abcd[0]] = new PointF(
                (float)(ABCD[abcd[1]].X - nSize.Width * Math.Cos(alphaRad)),
                (float)(ABCD[abcd[1]].Y + nSize.Width * Math.Sin(alphaRad)));

            ABCD[abcd[2]] = new PointF(
                (float)(ABCD[abcd[1]].X + nSize.Height * Math.Sin(alphaRad)),
                (float)(ABCD[abcd[1]].Y + nSize.Height * Math.Cos(alphaRad)));

            ABCD[abcd[3]] = new PointF(
                (float)(ABCD[abcd[0]].X + nSize.Height * Math.Sin(alphaRad)),
                (float)(ABCD[abcd[0]].Y + nSize.Height * Math.Cos(alphaRad)));

            if (abcd[0] == 0 || abcd[0] == 2)
            {
                r.Size = nSize;
            }
            else
            {
                r.Size = new SizeF(nSize.Height, nSize.Width);
            }
            StringFormat sformat = new StringFormat();
            switch (this.TextAlign)
            {

                case ContentAlignment.BottomCenter:
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    sformat.Alignment = StringAlignment.Near;
                    sformat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    sformat.Alignment = StringAlignment.Far;
                    sformat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    sformat.Alignment = StringAlignment.Near;
                    sformat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    sformat.Alignment = StringAlignment.Far;
                    sformat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopCenter:
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    sformat.Alignment = StringAlignment.Far;
                    sformat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopLeft:
                default:
                    sformat.Alignment = StringAlignment.Near;
                    sformat.LineAlignment = StringAlignment.Near;
                    break;
            }


            if (isDebug)
            {
                Brush[] c = { Brushes.Blue, Brushes.Red, Brushes.Yellow, Brushes.Green };
                int i = 0;

                graphics.TranslateTransform(this.Margin.Left, this.Margin.Top);
                foreach (PointF p in ABCD)
                {

                    graphics.FillEllipse(c[i], p.X - radius, p.Y - radius, 2 * radius, 2 * radius);

                    i++;
                }
            }
            graphics.TranslateTransform(this.Margin.Left, this.Margin.Top);
            if (isDebug)
            {
                graphics.DrawLines(new Pen(Color.Black), ABCD);
                graphics.DrawLine(new Pen(Color.Black), ABCD[0], ABCD[3]);
            }

            graphics.TranslateTransform(ABCD[0].X, ABCD[0].Y);


            // Rotate.
            graphics.RotateTransform((float)alpha);

            if (isDebug)
            {
                //graphics.TranslateTransform((float)dx, (float)dy, MatrixOrder.Append);
                graphics.DrawRectangle(new Pen(Color.Black, 4), r.X, r.Y, r.Width, r.Height);
            }

            // Draw the text at the origin.
            graphics.DrawString(this.text, this.Font, textBrush, r, sformat); //, stringFormat);

            // Restore the graphics state.
            graphics.Restore(state);

        }
        #endregion

    }
}

