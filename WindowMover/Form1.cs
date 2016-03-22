using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PHLMACR;

namespace WindowMover
{
    enum ARROW
    {
        LEFT, RIGHT, UP, DOWN
    }
    public partial class Form1 : Form
    {
         Keys left, right, up, down;
        int gap;
        public static INISAVE i = new INISAVE(Environment.CurrentDirectory + "\\settings.ini");
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        public Form1()
        {
            InitializeComponent();
            hWnd = IntPtr.Zero;
            KeyboardHook.KeyEvented += KeyboardHook_KeyEvented;
            KeyboardHook.HookStart();

            gap = Convert.ToInt32(Form1.i.GetSetting("set", "gap"));

            left = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "left")));
            right = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "right")));
            up = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "up")));
            down = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "down")));
        }
        ~Form1()
        {
            KeyboardHook.HookEnd();
        }
        private IntPtr GetActiveWindow()
        {
            IntPtr handle = GetForegroundWindow();
            return handle;
        }
        private IntPtr hWnd;
        
        private void MoveWindow(ARROW ar)
        {
            hWnd = GetActiveWindow();

            const short SWP_NOMOVE = 0X2;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;


            Rect r = new Rect();
            GetWindowRect(hWnd, ref r);

            Point p = new Point(r.Left, r.Top);
            switch (ar)
            {
                case ARROW.LEFT:
                    SetWindowPos(hWnd, 0, r.Left - gap, r.Top, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.RIGHT:
                    SetWindowPos(hWnd, 0, r.Left +gap, r.Top, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.UP:
                    SetWindowPos(hWnd, 0, r.Left, r.Top - gap, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.DOWN:
                    SetWindowPos(hWnd, 0, r.Left, r.Top + gap, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
            }
        }

        private void KeyboardHook_KeyEvented(Keys key, KeyEventType type)
        {
            if (key == Keys.LControlKey) return;
            Keys k = key;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                k |= Keys.Control;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                k |= Keys.Shift;
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                k |= Keys.Alt;
            if (type == KeyEventType.DOWN)
            {
                if (k == left)
                    MoveWindow(ARROW.LEFT);
                if (k == right)
                    MoveWindow(ARROW.RIGHT);
                if (k == up)
                    MoveWindow(ARROW.UP);
                if (k == down)
                    MoveWindow(ARROW.DOWN);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }

        private void 종ㄹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Finished += S_Finished;
            s.Show();
        }

        private void S_Finished()
        {
            gap = Convert.ToInt32(Form1.i.GetSetting("set", "gap"));

            left = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "left")));
            right = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "right")));
            up = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "up")));
            down = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "down")));
        }
    }
}
