using System;
using System.Collections.Generic;

namespace MohakAoki
{
    /// <summary>
    /// The Draw System that draws different types of shapes.
    /// </summary>
    class DrawSystem
    {
        /// <summary>
        /// Analys a line for further usage
        /// </summary>
        /// <param name="_start">Start of a line <see cref="Vector2"/></param>
        /// <param name="_end">End of a line <see cref="Vector2"/></param>
        /// <param name="m">Step of line that will return by out</param>
        /// <param name="_type">Type of the line <see cref="LineType"/></param>
        private static void LineAnalys(Vector2 _start, Vector2 _end, out float m, out LineType _type)
        {
            m = (float)(_end.Y - _start.Y) / (_end.X - _start.X); // Calculating step of line = ∆y/∆x
            _type = (Math.Abs(m) <= 1) ? LineType.StepOnX : LineType.StepOnY; // step is on x or y. it's needed for DDA and Bresenham
        }

        /// <summary>
        /// Create a line with DDA(Digital Diffrential Analyzer) algorithm
        /// </summary>
        /// <param name="_start">Start of a Line of type <see cref="Vector2"/></param>
        /// <param name="_end">End of line of type <see cref="Vector2"/></param>
        /// <returns>Will return a <see cref="LineShape"/></returns>
        public static LineShape CreateDDALine(Vector2 _start, Vector2 _end)
        {
            // Check if the start and the end of line is same, then thats not line. thats a pixel only
            if (_start == _end)
            {
                return new LineShape(new Vector2[] { _start, _end });
            }
            // Defining m (slope of the line) and linetype that is needed for DDA algorithm.
            float m = 0;
            LineType type = LineType.StepOnX;
            LineAnalys(_start, _end, out m, out type);

            // Creating a collection for holding points of line and adding first point (start) to it.
            List<Vector2> points = new List<Vector2>();
            points.Add(_start);

            // Adding a point to move from start to end point by point
            Vector2 _tPoint = _start;
            float _tAxis = 0;
            int _sign = 0;

            //DDA main algorithm
            if (type.Equals(LineType.StepOnX))
            {
                _sign = Math.Sign(_end.X - _start.X);
                _tAxis = _tPoint.Y;
                do
                {
                    _tPoint.X += _sign;
                    _tAxis += m * _sign;
                    _tPoint.Y = (int)Math.Round(_tAxis);
                    points.Add(_tPoint);
                } while (_tPoint != _end);
            }
            else
            {
                _sign = Math.Sign(_end.Y - _start.Y);
                _tAxis = _tPoint.X;
                do
                {
                    _tPoint.Y += _sign;
                    _tAxis += _sign / m;
                    _tPoint.X = (int)Math.Round(_tAxis);
                    points.Add(_tPoint);
                } while (_tPoint != _end);
            }

            return new LineShape(points.ToArray());
        }

        /// <summary>
        /// Create a line from <paramref name="_start"/> to <paramref name="_end"/> with Bresenham algorithm.
        /// </summary>
        /// <param name="_start">Start point of line of type <seealso cref="Vector2"/></param>
        /// <param name="_end">End point of line of type <seealso cref="Vector2"/></param>
        /// <returns>Will return a <see cref="LineShape"/></returns>
        public static LineShape CreateBresenhamLine(Vector2 _start, Vector2 _end)
        {
            // Check if the start and the end of line is same, then thats not line. thats a pixel only
            if (_start == _end)
            {
                return new LineShape(new Vector2[] { _start, _end });
            }

            // Defining m (slope of the line) and linetype that is needed for Bresenham algorithm.
            float m = 0;
            LineType type;
            LineAnalys(_start, _end, out m, out type);

            // Creating a collection for holding points of line and adding first point (start) to it.
            List<Vector2> points = new List<Vector2>();
            points.Add(_start);

            // Adding a point to move from start to end point by point
            Vector2 _temp = _start;
            float dY = (_end.Y - _start.Y); //Delta Y
            float dX = (_end.X - _start.X); //Delta X
            float pk = 0; // Pk and Pk+1 at the same time
            int _signX = Math.Sign(dX);
            int _signY = Math.Sign(dY);
            //Bresenham Main algorithm
            if (type.Equals(LineType.StepOnX))
            {
                pk = (2 * dY * _signY) - dX * _signX;
                do
                {
                    //System.Windows.Forms.MessageBox.Show(pk.ToString());
                    if (pk >= 0)
                    {
                        pk += 2 * (dY * _signY - dX * _signX);
                        _temp += new Vector2(_signX, _signY);
                    }
                    else
                    {
                        pk += 2 * dY * _signY;
                        _temp += Vector2.right * _signX;
                    }
                    points.Add(_temp);
                } while (_temp != _end);
            }
            else
            {
                pk = 2 * dX * _signX - dY * _signY;
                do
                {
                    if (pk >= 0)
                    {
                        pk += 2 * (dX * _signX - dY * _signY);
                        _temp += new Vector2(_signX, _signY);
                    }
                    else
                    {
                        pk += 2 * dX * _signX;
                        _temp += Vector2.up * _signY;
                    }
                    points.Add(_temp);
                } while (_temp != _end);
            }
            return new LineShape(points.ToArray());
        }


        /// <summary>
        /// Create V shape (head of an arrow) at the <paramref name="_to"/> with the direction of <paramref name="_from"/> to <paramref name="_to"/> with the size if <paramref name="size"/>
        /// </summary>
        /// <param name="_from">A <seealso cref="Vector2"/> that is used only for finding the direction of shape</param>
        /// <param name="_to">A <seealso cref="Vector2"/> that is the head of arrow</param>
        /// <param name="size">An integer that defines the size (lenght) of arrow's lines</param>
        /// <returns>a <see cref="VShape"/> that contains lines if arrow</returns>
        public static VShape CreateArrow(Vector2 _from, Vector2 _to, int size)
        {
            // Creating object of V shape
            VShape vShape = new VShape();

            // Calculating direction of shape and size if it.
            Vector2 _temp = _to - _from;
            _temp = _temp.normal;
            _temp = _to - _temp * size;
            // Rotating the founded point around arrow head to get the 2 new point for arrow lines.
            Vector2 a = Vector2.RotateAround(_temp, _to, 45);
            vShape.a = CreateDDALine(_to, a);
            a = Vector2.RotateAround(_temp, _to, -45);
            vShape.b = CreateDDALine(_to, a);
            return vShape;
        }

        /// <summary>
        /// Creating a Circle around pivot with the radius of radious
        /// </summary>
        /// <param name="pivot">The center point of circle in <seealso cref="Vector2"/></param>
        /// <param name="radious">The radious of circle in pixel</param>
        /// <returns>Returns a <see cref="CircleShape"/></returns>
        public static CircleShape CreateCircle(Vector2 pivot, int radious)
        {
            // if the radious is 0 or less, than thats not a circle, thats a mere pixel 😁
            if (radious <= 0)
            {
                return new CircleShape(pivot, 0, new Vector2[] { pivot });
            }
            List<Vector2> points = new List<Vector2>();
            //Creating First Octant in center
            int x = 0;
            int y = radious;
            int pk = 1 - y;

            points.Add(pivot + new Vector2(x, y));
            //Adding other 3 main points
            points.Add(pivot + new Vector2(x, -y));
            points.Add(pivot + new Vector2(y, x));
            points.Add(pivot + new Vector2(-y, x));
            do
            {
                x++;
                if (pk < 0)
                {
                    pk += 2 * x + 1;
                }
                else
                {
                    y--;
                    pk += 2 * x - 2 * y + 1;
                }
                points.Add(pivot + new Vector2(x, y));
                // Adding other octant. 
                //If you know any math formula to put this 7 thing, please teach it to me 😁. i will appreciate it.
                points.Add(pivot + new Vector2(-x, y));
                points.Add(pivot + new Vector2(x, -y));
                points.Add(pivot + new Vector2(-x, -y));
                points.Add(pivot + new Vector2(y, x));
                points.Add(pivot + new Vector2(-y, x));
                points.Add(pivot + new Vector2(y, -x));
                points.Add(pivot + new Vector2(-y, -x));
            } while (x < y);
            return new CircleShape(pivot, radious, points.ToArray());
        }

        /// <summary>
        /// Creating an Eclipse by algorithm x²/a² + y²/b² = 1 on the <paramref name="pivot"/> position
        /// </summary>
        /// <param name="pivot">The center of eclipse. not eclipse 2 main pivots</param>
        /// <param name="ab">The a and b in formula</param>
        /// <returns></returns>
        public static Eclipse CreateEclipse(Vector2 pivot, Vector2 ab)
        {
            //Defigning variables
            List<Vector2> points = new List<Vector2>();

            int a = (int)Math.Sqrt(ab.X);
            int b = (int)Math.Sqrt(ab.Y);
            int pk = b * b + a * a / 4 - a * a * b; // b² + a²/4 - a²b
            Vector2 _point = Vector2.up * b;
            int con1 = 0; //2b² Xk+1
            int con2 = 0; //2a² Yk+1
            bool I2 = false; //if is in II position

            do
            {
                points.Add(_point + pivot); //Main Quarter
                points.Add(-_point + pivot); //Other Quarter
                points.Add(new Vector2(-_point.X, _point.Y) + pivot); //Other Quarter
                points.Add(new Vector2(_point.X, -_point.Y) + pivot); //Other Quarter
                if (!I2) // I position
                {
                    if (pk < 0)
                    {
                        _point += Vector2.right;
                        con1 = 2 * b * b * (_point.X);
                        con2 = 2 * a * a * (_point.Y);
                        pk += con1 + b * b;
                    }
                    else
                    {
                        _point += Vector2.right - Vector2.up;
                        con1 = 2 * b * b * (_point.X);
                        con2 = 2 * a * a * (_point.Y);
                        pk += con1 - con2 + b * b;
                    }
                    if (con1 >= con2)
                    {
                        I2 = true;
                        pk = (int)(b * b * ((_point.X + .5f) * (_point.X + .5f) - a * a) + a * a * (_point.Y - 1) * (_point.Y - 1)); //f(X, Y) = b²X² + a²Y² - a²b² => b²(X² - a²) + a²Y²
                    }
                }
                else //II position
                {
                    if (pk < 0)
                    {
                        _point += Vector2.right - Vector2.up;
                        con1 = 2 * b * b * (_point.X);
                        con2 = 2 * a * a * (_point.Y);
                        pk += con1 - con2 + a * a;
                    }
                    else
                    {
                        _point += -Vector2.up;
                        con1 = 2 * b * b * (_point.X);
                        con2 = 2 * a * a * (_point.Y);
                        pk += -con2 + a * a;
                    }
                }
            } while (_point != Vector2.right * a); //If is on the last point, then finish the loop

            points.Add(_point); // Adding two last points
            points.Add(-_point); // Adding two last points

            return new Eclipse(pivot, ab, points.ToArray());
        }
    }
}
