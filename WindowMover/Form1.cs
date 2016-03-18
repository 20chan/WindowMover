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
                    SetWindowPos(hWnd, 0, r.Left - 10, r.Top, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.RIGHT:
                    SetWindowPos(hWnd, 0, r.Left +10, r.Top, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.UP:
                    SetWindowPos(hWnd, 0, r.Left, r.Top + 10, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
                case ARROW.DOWN:
                    SetWindowPos(hWnd, 0, r.Left, r.Top - 10, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                    break;
            }
        }

        private void KeyboardHook_KeyEvented(Keys key, KeyEventType type)
        {
            if(type == KeyEventType.DOWN && ((Control.ModifierKeys & Keys.Control) == Keys.Control))
            {
                switch(key)
                {
                    case Keys.H:
                        MoveWindow(ARROW.LEFT);
                        break;
                    case Keys.J:
                        MoveWindow(ARROW.DOWN);
                        break;
                    case Keys.K:
                        MoveWindow(ARROW.UP);
                        break;
                    case Keys.L:
                        MoveWindow(ARROW.RIGHT);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }
    }
}
