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

namespace textanim_alpha
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRect
            (
                int leftRect,
                int topRect,
                int rightRect,
                int bottomRect,
                int widthEllipse,
                int heightEllipse
                );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 7, 7));
        }

        int counter = 0;
        int len = 0;
        string text;

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = text.Substring(0, counter);
            ++counter;
            if (counter > len)
            {
                label2.Show();
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Hide();
            text = label1.Text;
            len = text.Length;
            label1.Text = "";
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
