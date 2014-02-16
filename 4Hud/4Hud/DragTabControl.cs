using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4Hud
{
    public class DragTabControl : TabControl
    {
        private Point DragStartPosition = Point.Empty;

        public DragTabControl()
        {
            this.AllowDrop = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            DragStartPosition = new Point(e.X, e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button != MouseButtons.Left) return;

            Rectangle r = new Rectangle(DragStartPosition, Size.Empty);
            r.Inflate(SystemInformation.DragSize);

            TabPage tp = HoverTab();

            if (tp != null)
            {
                if (!r.Contains(e.X, e.Y))
                    this.DoDragDrop(tp, DragDropEffects.All);
            }
            DragStartPosition = Point.Empty;

        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            try
            {
                TabPage hover_Tab = HoverTab();
                if (hover_Tab == null)
                    e.Effect = DragDropEffects.None;
                else
                {
                    if (e.Data.GetDataPresent(typeof(TabPage)))
                    {
                        e.Effect = DragDropEffects.Move;
                        TabPage drag_tab = (TabPage)e.Data.GetData(typeof(TabPage));

                        if (hover_Tab == drag_tab) return;

                        if (this.GetTabRect(this.TabPages.IndexOf(hover_Tab)).Size.Width < this.GetTabRect(this.TabPages.IndexOf(drag_tab)).Size.Width)
                        {
                            Rectangle TabRect = this.GetTabRect(this.TabPages.IndexOf(hover_Tab));
                            TabRect.Inflate(-3, -3);
                            if (TabRect.Contains(this.PointToClient(new Point(e.X, e.Y))))
                            {
                                SwapTabPages(drag_tab, hover_Tab);
                                this.SelectedTab = drag_tab;
                            }
                        }
                        else
                        {
                            Rectangle TabRect = this.GetTabRect(this.TabPages.IndexOf(hover_Tab));
                            TabRect.Inflate(-3, -3);
                            TabRect.Inflate((this.GetTabRect(this.TabPages.IndexOf(drag_tab)).Width - TabRect.Width) / 2 - 1, 0);
                            if (TabRect.Contains(this.PointToClient(new Point(e.X, e.Y))))
                            {
                                SwapTabPages(drag_tab, hover_Tab);
                                this.SelectedTab = drag_tab;
                            }
                        }
                    }
                }
            }
            catch { }

        }

        private TabPage HoverTab()
        {
            for (int index = 0; index <= this.TabCount - 1; index++)
            {
                if (this.GetTabRect(index).Contains(this.PointToClient(Cursor.Position)))
                    return this.TabPages[index];
            }
            return null;
        }

        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {

            int Index1 = this.TabPages.IndexOf(tp1);
            int Index2 = this.TabPages.IndexOf(tp2);
            this.TabPages[Index1] = tp2;
            this.TabPages[Index2] = tp1;
        }
      
    }
}
