using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class CustomScrollBars
{
    private static TextBox fctb;

    private static MyScrollBar vMyScrollBar;
    private static MyScrollBar hMyScrollBar;
    private static VScrollBar vScrollBar;
    private static HScrollBar hScrollBar;

    public static void SetScroll(TextBox ff, VScrollBar VScrollBar, HScrollBar HScrollBar, MyScrollBar HMyScrollBar,  MyScrollBar VMyScrollBar)
    {
        fctb = ff;
        vMyScrollBar = VMyScrollBar;
        hMyScrollBar = HMyScrollBar;
        vScrollBar = VScrollBar;
        hScrollBar = HScrollBar;
        vMyScrollBar.Visible = true;
        hMyScrollBar.Visible = true;

        vScrollBar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        vScrollBar.Name = "vScrollBar";
        vScrollBar.Size = new System.Drawing.Size(17, 181);
        vScrollBar.TabIndex = 8;
        vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(ScrollBar_Scroll);
        hScrollBar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
        hScrollBar.Location = new System.Drawing.Point(41, 330);
        hScrollBar.Name = "hScrollBar";
        hScrollBar.Size = new System.Drawing.Size(227, 17);
        hScrollBar.TabIndex = 9;
        hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(ScrollBar_Scroll);

        hMyScrollBar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
        hMyScrollBar.BackColor = System.Drawing.Color.Gold;
        hMyScrollBar.BorderColor = System.Drawing.Color.Gray;
        hMyScrollBar.Maximum = 100;
        hMyScrollBar.Name = "hMyScrollBar";
        hMyScrollBar.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
        hMyScrollBar.TabIndex = 7;
        hMyScrollBar.Text = "myScrollBar2";
        hMyScrollBar.ThumbColor = System.Drawing.Color.Red;
        hMyScrollBar.ThumbSize = 10;
        hMyScrollBar.Value = 0;
        hMyScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(ScrollBar_Scroll);

        vMyScrollBar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        vMyScrollBar.BackColor = System.Drawing.Color.Gold;
        vMyScrollBar.BorderColor = System.Drawing.Color.Gray;
        vMyScrollBar.Maximum = 100;
        vMyScrollBar.Name = "vMyScrollBar";
        vMyScrollBar.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
        vMyScrollBar.TabIndex = 6;
        vMyScrollBar.Text = "myScrollBar1";
        vMyScrollBar.ThumbColor = System.Drawing.Color.Red;
        vMyScrollBar.ThumbSize = 10;
        vMyScrollBar.Value = 0;
        vMyScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(ScrollBar_Scroll);
    }
    private static void AdjustScrollbars()
    {
        /*
        AdjustScrollbar(vMyScrollBar, fctb.VerticalScroll.Maximum, fctb.VerticalScroll.Value, fctb.ClientSize.Height);
        AdjustScrollbar(hMyScrollBar, fctb.HorizontalScroll.Maximum, fctb.HorizontalScroll.Value, fctb.ClientSize.Width);
        AdjustScrollbar(vScrollBar, fctb.VerticalScroll.Maximum, fctb.VerticalScroll.Value, fctb.ClientSize.Height);
        AdjustScrollbar(hScrollBar, fctb.HorizontalScroll.Maximum, fctb.HorizontalScroll.Value, fctb.ClientSize.Width);
    */
    }

    private static void AdjustScrollbar(MyScrollBar scrollBar, int max, int value, int clientSize)
    {
        scrollBar.Maximum = max;
        scrollBar.Visible = (max > 0);
        scrollBar.Value = Math.Min(scrollBar.Maximum, value);
    }

    private static void AdjustScrollbar(ScrollBar scrollBar, int max, int value, int clientSize)
    {
        scrollBar.LargeChange = clientSize / 3;
        scrollBar.SmallChange = clientSize / 11;
        scrollBar.Maximum = max + scrollBar.LargeChange;
        scrollBar.Visible = (max > 0);
        scrollBar.Value = Math.Min(scrollBar.Maximum, value);
    }

    public static void fctb_ScrollbarsUpdated(object sender, EventArgs e)
    {
        AdjustScrollbars();
    }

    private static void ScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        //fctb.OnScroll(e, e.Type != ScrollEventType.ThumbTrack && e.Type != ScrollEventType.ThumbPosition);
    }
}

