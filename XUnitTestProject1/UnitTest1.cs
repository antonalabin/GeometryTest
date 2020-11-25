using GeometryTest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GetPoints_ValidInput_ExpectedResult()
        {
            int n = 6;
            int l = 12;
            int h = 2;
            int alpha = 45;
            List<Point> expected = new List<Point>(8)
            {
                new Point(2,0), new Point(6,0), new Point(10, 0),
                new Point(12, 2), new Point(8, 6), new Point(6,8), new Point(4,6), new Point(0, 2)
            };
            Point center = new Point(l / 2, h / 2);
            expected = expected.OrderBy(point => Math.Atan2(point.Y - center.Y, point.X - center.X)).ToList();

            List<Point> actual = Algo.GetPoints(l, h, alpha, n);
            actual = actual.OrderBy(point => Math.Atan2(point.Y - center.Y, point.X - center.X)).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
