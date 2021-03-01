using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_Lab3
{

    public class Object
    {
        const double dt = 0.01;
        const double g = 9.81;
        const double C = 0.15;
        const double ro = 1.29;

        public double ang;
        public double v0;
        public double h0;
        public double square;
        public double weight;

        public double x;
        public double y;
        public double t;

        double k;
        double vx;
        double vy;

        public Object(double angle, double starting_speed, double starting_height, double weight, double square)
        {
            ang = angle;
            v0 = starting_speed;
            h0 = starting_height;
            this.weight = weight;
            this.square = square;

            k = 0.5 * C * square * ro / weight;
            vx = v0 * Math.Cos(ang * Math.PI / 180);
            vy = v0 * Math.Sin(ang * Math.PI / 180);

            t = 0;
            x = 0;
            y = h0;
        }

        public void nextstep()
        {
            t += dt;
            vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            vy = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

            x = x + vx * dt;
            y = y + vy * dt;
        }

        public int[] find_max_xy() 
        {
            reset_variables();
            double max_y = 0;
            double max_x = 0;

            while (y >= 0)
            {
                t += dt;
                vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
                vy = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

                x = x + vx * dt;
                y = y + vy * dt;

                if (max_y < y) max_y = y;
                if (max_x < x) max_x = x;
            }
            reset_variables();
            return new[] { (int)max_x + 1, (int)max_y + 1 };
        }

        public void reset_variables() 
        {
            k = 0.5 * C * square * ro / weight;
            vx = v0 * Math.Cos(ang * Math.PI / 180);
            vy = v0 * Math.Sin(ang * Math.PI / 180);

            t = 0;
            x = 0;
            y = h0;
        }

    }
}
