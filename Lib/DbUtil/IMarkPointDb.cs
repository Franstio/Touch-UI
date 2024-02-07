using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Model;

namespace TestTCP1.Lib.DbUtil
{
    public abstract class DrawMarkPointUtil
    {
        public virtual  PointF? DrawMark(PointF p,Color color, Image? img = null, PictureBox? frame = null)
        {
            if (img is null || frame is null)
                return null;
            const float sizeDot = 0.01f;
            Image originalImage = img ;
            Graphics graph = Graphics.FromImage(originalImage);
            float factorX = (float)frame.Width / originalImage.Width;
            float factorY = (float)frame.Height / originalImage.Height;
            Pen pen = new Pen(color, frame.Width * sizeDot);

            graph.DrawEllipse(pen, new RectangleF(p.X / factorX, p.Y / factorY, frame.Width * sizeDot, frame.Height * sizeDot));
            return new PointF(p.X / factorX, p.Y / factorY);
        }
        public virtual PointF CalibratePoint(MarkPointModel model,Image img  ,PictureBox frame)
        {
            return new PointF(
                x: model.X * ((float)frame.Width/img.Width),
                y: model.Y* ((float)frame.Height/img.Height)
            );
        }
    }
    public interface IMarkPointDb 
    {
        Task SaveMarkPoint(MarkPointModel model);
        Task RemoveMarkPoint(MarkPointModel model);
        Task ClearMarkPoint(string model);
        Task<IEnumerable<MarkPointModel>?> GetMarkPoint(string model);

        Task<IEnumerable<MarkPointModel>?> GetMarkPoint(string model,string area);
        PointF? DrawMark(PointF p,Color color, Image? img = null, PictureBox? frame = null);
        PointF CalibratePoint(MarkPointModel model, Image img, PictureBox frame);

    }
}
