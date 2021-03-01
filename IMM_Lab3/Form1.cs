using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Flyght
{
    public partial class Form1 : Form
    {
        Object obj;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj = new Object((double)angle.Value, (double)speed.Value, (double)height.Value, (double)weight.Value, (double)square.Value);
            chart1.Series[0].Points.Clear();

            int[] mas_xy = obj.find_max_xy();
            
            chart1.ChartAreas[0].AxisX.Maximum = mas_xy[0];
            chart1.ChartAreas[0].AxisY.Maximum = mas_xy[1];

            int c = (int)(100 / (int)obj.v0);
            timer1.Interval = c != 0 ? c : 1;

            obj.reset_variables();
            chart1.Series[0].Points.AddXY(obj.x, obj.y);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            obj.nextstep();
            chart1.Series[0].Points.AddXY(obj.x, obj.y);
            if (obj.y <= 0) timer1.Stop();
            timelab.Text = "" + obj.t;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button2.Text = "|>";
            }
            else
            {
                timer1.Enabled = true;
                button2.Text = "| |";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart1.Series[0].Points.Clear();
            angle.Value = 45;
            speed.Value = 10;
            height.Value = 0;
            square.Value = 1;
            weight.Value = 20;
            timelab.Text = ""+0;
        }
    }
}
