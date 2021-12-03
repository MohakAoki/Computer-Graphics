using System.Collections.Generic;
using System.Drawing;

namespace MohakAoki
{
    public class Transform
    {
        public enum TransType
        {
            Pos,
            Rot,
            Sca
        }
        public struct Trans
        {
            public TransType type;
            public Vector2 data;
            public override string ToString()
            {
                return string.Format("{0} ({1}, {2})", type, data.X, data.Y);
            }
        }

        public DrawItem baseItem;
        public List<Trans> transforms = new List<Trans>();
    }
}
