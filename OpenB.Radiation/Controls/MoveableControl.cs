using System.Drawing;
using System.Windows.Forms;

namespace OpenB.Radiation.Controls
{


    public abstract class MoveableControl : Control
    {

        private MouseButtons moveControlWith = MouseButtons.Left;
        private bool dragging = false;
        private Point mouseDownLocation;

        public bool AllowMove { get; set; }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == moveControlWith && AllowMove)
            {
                dragging = true;
                Cursor = Cursors.Hand;
                Capture = true;
                mouseDownLocation = e.Location;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            if (e.Button == moveControlWith && dragging == true && AllowMove)
            {
                Capture = false;
                dragging = false;
                Cursor = Cursors.Arrow;
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (dragging)
            {
                this.Left = e.X + this.Left - mouseDownLocation.X;
                this.Top = e.Y + this.Top - mouseDownLocation.Y;
            }

            base.OnMouseMove(e);
        }
    }
}
