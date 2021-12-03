namespace MohakAoki
{
    public class Matrix
    {
        private float[,] matrix;
        private int row, column;
        public Matrix(int row, int column)
        {
            row = (row < 1) ? 1 : row;
            column = (column < 1) ? 1 : column;
            matrix = new float[row, column];
            this.row = row;
            this.column = column;
        }
        public Matrix(float[,] mat)
        {
            SetMatrix(mat);
        }
        public static Matrix Identity(int size)
        {
            float[,] m = new float[size, size];
            for (int i = 0; i < size; i++)
            {
                m[i, i] = 1;
            }
            Matrix ma = new Matrix(m);
            return ma;
        }
        public void SetMatrix(float[,] mat)
        {
            matrix = mat;
            row = mat.GetLength(0);
            column = mat.GetLength(1);
        }
        public float GetItem(int x, int y)
        {
            if (x > Rows || y > Columns || x < 0 || y < 0)
            {
                return 0;
            }
            return matrix[x, y];
        }
        public void SetItem(int x, int y, float data)
        {
            if (x > Rows || y > Columns || x < 0 || y < 0)
            {
                return;
            }
            matrix[x, y] = data;
        }
        public int Rows => row;
        public int Columns => column;

        public Matrix Multiply(Matrix op)
        {
            if (Columns != op.Rows)
            {
                return null;
            }
            Matrix res = new Matrix(Rows, op.Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < op.Columns; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < Columns; k++)
                    {
                        sum += matrix[i, k] * op.matrix[k, j];
                    }
                    res.matrix[i, j] = sum;
                }
            }
            return res;
        }
        public override string ToString()
        {
            string t = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    t += matrix[i, j] + "|";
                }
                t += "\n";
            }
            return t;
        }
    }
}
