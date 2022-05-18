namespace WebAPI.Models
{
    public class Manager
    {
        public List<Point> GeneratePoints(Fractale fractale)
        {
            double defaultPosition = 100;

            var pointList = new List<Point>() { };
            pointList.Add(new Point() { X = defaultPosition, Y = defaultPosition + 50 });
            pointList.Add(new Point() { X = defaultPosition + fractale.SegmentSize, Y = defaultPosition + 50 });
            pointList.Add(new Point() { X = defaultPosition + fractale.SegmentSize * Math.Cos(Math.PI * 5 / 3), Y = -fractale.SegmentSize * Math.Sin(Math.PI * 5 / 3) + defaultPosition + 50 });
            
            for (int l = 0; l < fractale.Degre; l++)
            {
                var pointList2 = new List<Point>() { };

                var m = pointList.Count;

                for (int i = 0; i < m; i++)
                {
                    var middlePoints = new List<Point>() { };
                    if (i == m - 1)
                    {
                        middlePoints = GenerateIntermediatePoint(pointList[i], pointList[0]);
                    }
                    else
                        middlePoints = GenerateIntermediatePoint(pointList[i], pointList[i + 1]);

                    pointList2.Add(pointList[i]);
                    pointList2.Add(middlePoints[0]);
                    pointList2.Add(middlePoints[2]);
                    pointList2.Add(middlePoints[1]);

                }
                pointList = pointList2;

            }
            return pointList;
        }

        // vérifier dans quel cas on ce trouve.
        // couper le segment en 3 
        // Trouver l'angle et le point e  
        // relier les points 
        public List<Point> GenerateIntermediatePoint(Point A, Point B)
        {
            var c = new Point() { X = A.X + (1.0 / 3.0) * (B.X - A.X), Y = A.Y + (1.0/ 3.0) * (B.Y - A.Y)};

            var d = new Point() { X = A.X + (2.0 / 3.0) * (B.X - A.X), Y = A.Y + (2.0/ 3.0) * (B.Y - A.Y)};

            var e = new Point() { X = 0, Y = 0 };

            var L = Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));

            var o = Math.Acos(Math.Abs(B.X - A.X) / L);


            //1 
            if(-B.Y >= -A.Y && B.X > A.X)
                RetoursPoints(c, e, o, L);
            //2
            else if(B.Y <= A.Y && B.X < A.X)
            {
                o = Math.Asin(Math.Abs(B.X - A.X) / L);
                var oP = o + Math.PI / 2;
                RetoursPoints(c, e, oP, L);
            }
            //3
            else if(B.Y >= A.Y && B.X < A.X)
            {
                o = Math.Acos(Math.Abs(B.X - A.X) / L);
                var oPP = o + Math.PI;
                RetoursPoints(c, e, oPP, L);
            }
            //
            else
            {
                o = Math.Asin(Math.Abs(B.X - A.X) / L);
                var oPPP = o + 3 * Math.PI / 2;
                RetoursPoints(c, e, oPPP, L);
            }
            return new List<Point>() { c, d, e};
        }
        static List<Point> RetoursPoints( Point c,Point e, double o, double L)
        {
            e.X = c.X + L / 3 * Math.Cos(o + Math.PI / 3); // X 
            e.Y = c.Y - L / 3 * Math.Sin(o + Math.PI / 3); // Y

            return new List<Point> { e };
        }
       
    }
}
