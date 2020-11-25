using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6;
            Console.Write("Введите l: ");
            int l = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите h: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите alpha: ");
            int alpha = Convert.ToInt32(Console.ReadLine());

            List<Point> points = Algo.GetPoints(l, h, alpha, n);

            points.Add(new Point(0, 0));
            Point center = new Point(l / 2, h / 2);
            points = points.OrderBy(point => Math.Atan2(point.Y - center.Y, point.X - center.X)).ToList();

            foreach (Point point in points)
                Console.WriteLine(point.ToString());
        }
    }

    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                double difference = 0.000001;
                Point p = (Point)obj;
                return ((Math.Abs(X - p.X) <= difference) && (Math.Abs(Y - p.Y) <= difference));
            }
        }
    }

    public static class Algo
    {
        public static List<Point> GetPoints(int l, int h, int alpha, int n)
        {
            if (l <= 0)
                throw new ArgumentOutOfRangeException("l");
            if (h <= 0)
                throw new ArgumentOutOfRangeException("h");
            if ((alpha <= 0) || (alpha >= 90))
                throw new ArgumentOutOfRangeException("alpha");
            if ((n < 6) || ((n - 2) % 4 != 0))
                throw new ArgumentOutOfRangeException("n");

            List<Point> points = new List<Point>(n + 2);

            double t = Math.Tan(alpha * Math.PI / 180);
            for (int i = 0; i <= n / 2; i++)
            {
                double x = l * i / n;
                double y = (i % 2 == 0) ? (h + t * x) : 0;
                points.Add(new Point(x, y));
                points.Add((i != n / 2) ? new Point(l - x, y) : new Point(x, h + t * x));
            }

            return points;
        }
    }
}
