using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenB.Radiation.Controls
{
    public class ModelDefinition : MoveableControl
    {
        public ModelDefinition()
        {
            members = new List<ModelMemberNode>();

            this.OnPropertyMouseClick += ModelDefinition_OnPropertyMouseClick;
            this.OnPropertyMouseMove += ModelDefinition_OnPropertyMouseMove;
            this.drawingInformation = new Dictionary<Rectangle, ModelMemberNode>();
        }

        public virtual void ModelDefinition_OnPropertyMouseMove(object sender, MouseEventArgs e)
        {
           
        }

        public virtual void ModelDefinition_OnPropertyMouseClick(object source, ProperyClickEventArgs e)
        {

        }

        private IList<ModelMemberNode> members;

        private ModelMemberNode MouseIsInsidePropertyArea(Point location)
        {
            if (drawingInformation.Any())
            {
                Func<Rectangle, bool> function = k => k.Left <= location.X && k.Right >= location.X && k.Top <= location.Y && k.Bottom >= location.Y;
                var anyKeys = drawingInformation.Keys.Any(function);

                if (anyKeys)
                {
                    return drawingInformation[drawingInformation.Keys.Where(function).Single()];
                }
            }
            return null;

        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            {
                var node = MouseIsInsidePropertyArea(e.Location);
                if (node != null)
                {
                    ProperyClickEventArgs eventArgs = new ProperyClickEventArgs(node);
                    OnPropertyMouseClick(this, eventArgs);
                }
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var node = MouseIsInsidePropertyArea(e.Location);
            if (node != null)
            {
                OnPropertyMouseMove(node, e);
            }

            base.OnMouseMove(e);
        }

      

        public string DefinitionName { get; set; }

        public ModelMemberNode AddMember(string name, string type)
        {
            ModelMemberNode member = new ModelMemberNode(name, type);
            members.Add(member);

            return member;
        }
        public Color BorderColor { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle borderRectangle = this.ClientRectangle;
            ControlPaint.DrawBorder(e.Graphics, borderRectangle, this.BorderColor, ButtonBorderStyle.Solid);

            Rectangle titleRectangle = new Rectangle(ClientRectangle.Left + 2, ClientRectangle.Top + 2, ClientRectangle.Width - 4, 20);
            Brush fillBrush = new SolidBrush(this.BorderColor);
            e.Graphics.FillRectangle(fillBrush, titleRectangle);

            Brush brush = Brushes.Aqua;
            e.Graphics.DrawString(this.DefinitionName, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, new PointF(ClientRectangle.Left + 3, ClientRectangle.Top + 3));

            int yPosition = titleRectangle.Bottom + 3;
            yPosition = RenderProperties(e, yPosition);

            //this.Height = this.Top + yPosition + 3;
            
        }

        private int RenderProperties(PaintEventArgs e, int yPosition)
        {
            drawingInformation = new Dictionary<Rectangle, ModelMemberNode>();

            foreach (ModelMemberNode data in members)
            {
                if (data.Icon != null)
                {
                    Rectangle iconRectangle = new Rectangle(new Point(ClientRectangle.Left + 2, yPosition), new Size(16, 16));
                    e.Graphics.DrawIcon(data.Icon, iconRectangle);
                }

                e.Graphics.DrawString(string.Join(" :: ", data.Name, data.MemberType), new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, new PointF(ClientRectangle.Left + 3, yPosition));

                var stringSize = e.Graphics.MeasureString(string.Join(" :: ", data.Name, data.MemberType), new Font(FontFamily.GenericSansSerif, 8)).ToSize();


                Rectangle stringRectangle = new Rectangle(new Point(ClientRectangle.Left + 3, yPosition), stringSize);
                drawingInformation.Add(stringRectangle, data);

                yPosition += stringSize.Height + 2;
            }

            return yPosition;
        }

        private IDictionary<Rectangle, ModelMemberNode> drawingInformation;

        public event ModelDefinitionPropertyClickEventHandler OnPropertyMouseClick;
        public event ModelDefinitionPropertyMoveEventHandler OnPropertyMouseMove;

        public delegate void ModelDefinitionPropertyMoveEventHandler(object sender, MouseEventArgs e);
        public delegate void ModelDefinitionPropertyClickEventHandler(object sender, ProperyClickEventArgs e);


    }

    public class ProperyClickEventArgs
    {
        public ModelMemberNode MemberNode { get; private set; }

        public ProperyClickEventArgs(ModelMemberNode modelMemberNode)
        {
            this.MemberNode = modelMemberNode;
        }
    }

    public enum ModelMemberType
    {
    }

    public class ModelMemberNode
    {
        public string MemberType { get; private set; }
        public string Name { get; private set; }
        public Icon Icon { get; set; }

        internal ModelMemberNode(string name, string memberType)
        {
            this.Name = name;
            this.MemberType = memberType;
        }
    }

    public class PropertyData
    {
        public string Name { get; set; }

    }
}
