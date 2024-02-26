using GMap.NET.WindowsForms;
using GMap.NET;
using System.Runtime.Serialization;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;
using System;
using System.Data.SQLite;
using System.DirectoryServices;

namespace pract1bmm
{
    public partial class Form1 : Form
    {
        public GMapMarkerDirection planemarker;
        public GMapMarkerDirection radiomarker;
        public GMapMarker temp;
        private bool isLeftButtonDown = false;
        private GMapOverlay objects = new GMapOverlay("objects");
        public Form1() => InitializeComponent();

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
            //gmap initialization
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 14;
            gMapControl1.Position = new GMap.NET.PointLatLng(55.97260, 37.41460);
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.ShowCenter = false;
            gMapControl1.ShowTileGridLines = false;

            gMapControl1.MouseClick += new MouseEventHandler(mapControl_MouseClick);
            gMapControl1.MouseDown += new MouseEventHandler(mapControl_MouseDown);
            gMapControl1.MouseUp += new MouseEventHandler(mapControl_MouseUp);
            gMapControl1.MouseMove += new MouseEventHandler(mapControl_MouseMove);
            gMapControl1.OnMarkerEnter += new MarkerEnter(mapControl_OnMarkerEnter);
            this.gMapControl1.Overlays.Add(objects);
        }
        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && isLeftButtonDown)
            {
                if (planemarker != null || radiomarker != null)
                {
                    if (temp != null) { 
                        PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                        temp.Position = point;
                        temp.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);
                        switch (temp.Tag)
                        {
                            case 0:
                                textBox1.Text = planemarker.Position.Lat.ToString();
                                textBox2.Text = planemarker.Position.Lng.ToString();
                                textBox3.Text = planemarker._ang.ToString();
                                break;
                            case 1:
                                textBox5.Text = radiomarker.Position.Lat.ToString();
                                textBox4.Text = radiomarker.Position.Lng.ToString();
                                break;
                        }
                    }
                }
            }
        }

        void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = false;
                temp = null;
            }
        }

        void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = true;
            }
        }

        void mapControl_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarkerDirection)
            {
                temp = item as GMapMarkerDirection;
            }
        }

        void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (planemarker == null)
                {
                    PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    Bitmap planeimg = (Bitmap)Bitmap.FromFile("./arrow.png");
                    planemarker = new GMapMarkerDirection(point, planeimg, 0);
                    planemarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    planemarker.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);
                    planemarker.Tag = 0;
                    textBox1.Text = planemarker.Position.Lat.ToString();
                    textBox2.Text = planemarker.Position.Lng.ToString();
                    textBox3.Text = planemarker._ang.ToString();
                    objects.Markers.Add(planemarker);
                }
                else if (radiomarker == null)
                {
                    PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    Bitmap planeimg = (Bitmap)Bitmap.FromFile("./arrow.png");
                    radiomarker = new GMapMarkerDirection(point, planeimg, 0);
                    radiomarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    radiomarker.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);
                    radiomarker.Tag = 1;
                    textBox5.Text = radiomarker.Position.Lat.ToString();
                    textBox4.Text = radiomarker.Position.Lng.ToString();
                    objects.Markers.Add(radiomarker);
                }
            }
        }

    }
    [Serializable]
    public class GMapMarkerDirection : GMapMarker, ISerializable
    {
        public float _ang = 0f;
        private Image _image = null;

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                if (_image != null)
                {
                    this.Size = new Size(_image.Width, _image.Height);
                }
            }
        }

        public GMapMarkerDirection(PointLatLng pointLatLng, Image image, float angle)
            : base(pointLatLng)
        {
            this._image = image;
            this._ang = angle;
            if (this._image != null)
                this.Size = new Size(_image.Width, _image.Height);
            this.Offset = new Point(-this.Size.Width / 2, -this.Size.Height);
        }

        public override void OnRender(Graphics g)
        {

            g.DrawImageUnscaled(RotateImage(this._image, this._ang), LocalPosition.X, LocalPosition.Y);
        }

        //http://www.codeproject.com/KB/graphics/rotateimage.aspx
        //Author : James T. Johnson
        private static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            const double pi2 = Math.PI / 2.0;

            // Why can't C# allow these to be const, or at least readonly
            // *sigh*  I'm starting to talk like Christian Graus :omg:
            double oldWidth = (double)image.Width;
            double oldHeight = (double)image.Height;

            // Convert degrees to radians
            double theta = ((double)angle - 77) * Math.PI / 180.0;
            double locked_theta = theta;

            // Ensure theta is now [0, 2pi)
            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight; // The newWidth/newHeight expressed as ints

            #region Explaination of the calculations
            /*
             * The trig involved in calculating the new width and height
             * is fairly simple; the hard part was remembering that when 
             * PI/2 <= theta <= PI and 3PI/2 <= theta < 2PI the width and 
             * height are switched.
             * 
             * When you rotate a rectangle, r, the bounding box surrounding r
             * contains for right-triangles of empty space.  Each of the 
             * triangles hypotenuse's are a known length, either the width or
             * the height of r.  Because we know the length of the hypotenuse
             * and we have a known angle of rotation, we can use the trig
             * function identities to find the length of the other two sides.
             * 
             * sine = opposite/hypotenuse
             * cosine = adjacent/hypotenuse
             * 
             * solving for the unknown we get
             * 
             * opposite = sine * hypotenuse
             * adjacent = cosine * hypotenuse
             * 
             * Another interesting point about these triangles is that there
             * are only two different triangles. The proof for which is easy
             * to see, but its been too long since I've written a proof that
             * I can't explain it well enough to want to publish it.  
             * 
             * Just trust me when I say the triangles formed by the lengths 
             * width are always the same (for a given theta) and the same 
             * goes for the height of r.
             * 
             * Rather than associate the opposite/adjacent sides with the
             * width and height of the original bitmap, I'll associate them
             * based on their position.
             * 
             * adjacent/oppositeTop will refer to the triangles making up the 
             * upper right and lower left corners
             * 
             * adjacent/oppositeBottom will refer to the triangles making up 
             * the upper left and lower right corners
             * 
             * The names are based on the right side corners, because thats 
             * where I did my work on paper (the right side).
             * 
             * Now if you draw this out, you will see that the width of the 
             * bounding box is calculated by adding together adjacentTop and 
             * oppositeBottom while the height is calculate by adding 
             * together adjacentBottom and oppositeTop.
             */
            #endregion

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            // We need to calculate the sides of the triangles based
            // on how much rotation is being done to the bitmap.
            //   Refer to the first paragraph in the explaination above for 
            //   reasons why.
            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int)Math.Ceiling(newWidth);
            nHeight = (int)Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // This array will be used to pass in the three points that 
                // make up the rotated image
                Point[] points;


                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[] {
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( 0, (int) adjacentBottom )
                                         };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[] {
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( (int) oppositeBottom, 0 )
                                         };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[] {
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( nWidth, (int) oppositeTop )
                                         };
                }
                else
                {
                    points = new Point[] {
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( (int) adjacentTop, nHeight )
                                         };
                }

                g.DrawImage(image, points);
            }

            return rotatedBmp;
        }
    }
}