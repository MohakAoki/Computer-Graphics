using System;
using System.Collections.Generic;

namespace MohakAoki
{
    class DrawSystem
    {
        private static void LineAnalys(Vector2 _start, Vector2 _end, out float m, out LineType _type)
        {
            m = (float)(_end.Y - _start.Y) / (_end.X - _start.X);
            _type = (Math.Abs(m) <= 1) ? LineType.StepOnX : LineType.StepOnY;
        }
        public static LineShape DrawDDA(Vector2 _start, Vector2 _end)
        {
            float m = 0;
            LineType type = LineType.StepOnX;
            LineAnalys(_start, _end, out m, out type);

            //--------------------------------------------------------------------
            List<Vector2> points = new List<Vector2>();
            points.Add(_start);

            Vector2 _tPoint = _start;
            float _tAxis = 0;
            int _sign = 0;
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

            points.Add(_end);
            return new LineShape(points.ToArray());
        }
        public static VShape CreateArrow(Vector2 _from, Vector2 _to, int size)
        {
            VShape vShape = new VShape();

            Vector2 _temp = _to - _from;
            _temp = _temp.normal;
            _temp = _to - _temp * size;
            Vector2 a = Vector2.RotateAround(_temp, _to, 45);
            vShape.a = DrawDDA(_to, a);
            a = Vector2.RotateAround(_temp, _to, -45);
            vShape.b = DrawDDA(_to, a);
            return vShape;
        }
    }
}
