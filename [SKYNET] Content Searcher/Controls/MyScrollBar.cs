using System;
using System.Drawing;
using System.Windows.Forms;
public class MyScrollBar : Control
{
    private int value;

    private int maximum = 100;

    private int thumbSize = 10;

    private Color thumbColor = Color.Gray;

    private Color borderColor = Color.Silver;

    private ScrollOrientation orientation;

    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            if (this.value != value)
            {
                this.value = value;
                Invalidate();
                OnScroll();
            }
        }
    }

    public int Maximum
    {
        get
        {
            return maximum;
        }
        set
        {
            maximum = value;
            Invalidate();
        }
    }

    public int ThumbSize
    {
        get
        {
            return thumbSize;
        }
        set
        {
            thumbSize = value;
            Invalidate();
        }
    }

    public Color ThumbColor
    {
        get
        {
            return thumbColor;
        }
        set
        {
            thumbColor = value;
            Invalidate();
        }
    }

    public Color BorderColor
    {
        get
        {
            return borderColor;
        }
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    public ScrollOrientation Orientation
    {
        get
        {
            return orientation;
        }
        set
        {
            orientation = value;
            Invalidate();
        }
    }

    public event ScrollEventHandler Scroll;

    public MyScrollBar()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            MouseScroll(e);
        }
        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            MouseScroll(e);
        }
        base.OnMouseMove(e);
    }

    private void MouseScroll(MouseEventArgs e)
    {
        int val = 0;
        switch (Orientation)
        {
            case ScrollOrientation.VerticalScroll:
                val = Maximum * (e.Y - thumbSize / 2) / (base.Height - thumbSize);
                break;
            case ScrollOrientation.HorizontalScroll:
                val = Maximum * (e.X - thumbSize / 2) / (base.Width - thumbSize);
                break;
        }
        Value = Math.Max(0, Math.Min(Maximum, val));
    }

    public virtual void OnScroll(ScrollEventType type = ScrollEventType.ThumbPosition)
    {
        if (this.Scroll != null)
        {
            this.Scroll(this, new ScrollEventArgs(type, Value, Orientation));
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Maximum > 0)
        {
            Rectangle rect = Rectangle.Empty;
            switch (Orientation)
            {
                case ScrollOrientation.HorizontalScroll:
                    rect = new Rectangle(value * (base.Width - thumbSize) / Maximum, 2, thumbSize, base.Height - 4);
                    break;
                case ScrollOrientation.VerticalScroll:
                    rect = new Rectangle(2, value * (base.Height - thumbSize) / Maximum, base.Width - 4, thumbSize);
                    break;
            }
            using (SolidBrush brush = new SolidBrush(thumbColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
            using (Pen pen = new Pen(borderColor))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            }
        }
    }
}

