using NumberDetector.Controllers;

namespace NumberDetector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBitmapAndGraphics();

            _definer = new DefinerController();
        }
        private DefinerController _definer;

        private bool IsDrawing = false;
        private Point _previousPoint;
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Pen _pen = new Pen(Color.Black, 40);
        private void InitializeBitmapAndGraphics()
        {
            _bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);

            _graphics = Graphics.FromImage(_bitmap);
            _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _graphics.Clear(Color.White);
            panel1.Invalidate();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrawing = true;
            _previousPoint = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                _graphics.DrawLine(_pen, _previousPoint, e.Location);
                _previousPoint = e.Location;
                _graphics.DrawLine(_pen, _previousPoint, e.Location);
                _previousPoint = e.Location;
                _graphics.DrawLine(_pen, _previousPoint, e.Location);
                _previousPoint = e.Location;
                _graphics.DrawLine(_pen, _previousPoint, e.Location);
                _previousPoint = e.Location;

                panel1.Invalidate();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_bitmap, Point.Empty);
        }

        private void defineButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "-";

            var number = _definer.DefineNumber(_bitmap);

            outputLabel.Text = number;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            panel1.Invalidate();
        }
    }
}
