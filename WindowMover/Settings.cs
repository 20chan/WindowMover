using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public delegate void d1();
    public partial class Settings : Form
    {
        public event d1 Finished;
        public Settings()
        {
            this.InitializeComponent();
        
            string gap = Form1.i.GetSetting("set", "gap");
            
            Keys left = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "left")));
            Keys right = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "right")));
            Keys up = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "up")));
            Keys down = (Keys)Enum.Parse(typeof(Keys), (Form1.i.GetSetting("key", "down")));

            this.keySet1.Key = left;
            this.keySet2.Key = right;
            this.keySet3.Key = up;
            this.keySet4.Key = down;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.i.WriteSetting("key", "left", this.keySet1.Key.ToString());
            Form1.i.WriteSetting("key", "right", this.keySet2.Key.ToString());
            Form1.i.WriteSetting("key", "up", this.keySet3.Key.ToString());
            Form1.i.WriteSetting("key", "down", this.keySet4.Key.ToString());

            Form1.i.WriteSetting("set", "gap", this.textBox1.Text);

            Finished();
            this.Close();
        }
    }
}
