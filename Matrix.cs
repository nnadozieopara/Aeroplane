using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicsLib
{
    public struct Matrix
    {
        private int nRows;
        private int nCols;
        private double[,] matrix;
        
        public Matrix (int rows, int columns)
        {
            nRows = rows;
            nCols = columns;
            matrix = new double[nRows, nCols];
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public Matrix(Vectors v)
        {
            nRows = 1;
            nCols = v.GetVectorSize;
            double[,] matrix = new double[nRows, nCols];
            for (int i = 0; i < nCols; i++)
            {
                matrix[1, i] = v[i];
            }
            this.matrix = matrix;
        }

        public Matrix(double[,] matrix)
        {
            nRows = matrix.GetLength(0);
            nCols = matrix.GetLength(1);
            this.matrix = matrix;
        }

        public Matrix(Matrix m)
        {
            nRows = m.GetnRows;
            nCols = m.GetnRows;
            matrix = m.matrix;
        }

        public Matrix IdentityMatrix()
        {
             if (nRows!=nCols)
            {
                throw new Exception("Identity matrix must be square!");
            }
            Matrix m = new Matrix(nRows, nCols);
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    if (i==j)
                    {
                        m.matrix[i, j] = 1;
                    }
                }
            }
            return m;
        }
        //
        public double this[int m, int n]
        {
            get
            {
                if (m < 0 || m > nRows)
                {
                    throw new Exception("m-th row is out of range!");
                }
                if (n < 0 || n > nCols)
                {
                    throw new Exception("n-th col is out of range!");
                }
                return matrix[m, n];
            }
            set { matrix[m, n] = value; }
        }

        public int GetnRows
        {
            get { return nRows; }
        }

        public int GetnCols
        {
            get { return nCols; }
        }

        //public Matrix Clone()
        //{
        //    Matrix m = new Matrix(matrix);
        //    m.matrix = (double[,])matrix.Clone();
        //    return m;
        //}
        public override string ToString()
        {
            string strMatrix = "(";
            for (int i = 0; i < nRows; i++)
            {
                string str = "";
                for (int j = 0; j < nCols-1; j++)
                {
                    str += matrix[i, j].ToString() + ",";
                }
                str += matrix[i, nCols - 1].ToString();
                if (i != nRows - 1 && i == 0) strMatrix += str + "\n";
                else if (i != nRows - 1 && i != 0) strMatrix += "" + str + "\n";
                else strMatrix += "" + str + ")";
            }
            return strMatrix;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj is Matrix) && this.Equals((Matrix)obj);
        }

        public bool Equals(Matrix m)
        {
            return matrix == m.matrix;
        }
        public override int GetHashCode()
        {
            return matrix.GetHashCode();
        }

        public static bool operator == (Matrix m1, Matrix m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !m1.Equals(m2);
        }
        
        public static Matrix operator +(Matrix m)
        {
            return m;
        }
        public static bool CompareMatixDimension(Matrix m1, Matrix m2)
        {
            if (m1.GetnCols == m2.GetnCols && m1.GetnRows == m2.GetnRows) return true;
            else return false;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (!CompareMatixDimension(m1,m2))
            {
                throw new Exception("The dimension of the matrices must be equal");
            }
            int row = m1.GetnRows, col = m1.GetnCols;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m)
        {
            int row = m.GetnRows, col = m.GetnCols;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    m[i, j] = -m[i, j];
                }
            }
            return m;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (!CompareMatixDimension(m1,m2))
            {
                throw new Exception("Dimensions must be thesame!");
            }
            int row = m1.GetnRows, col = m1.GetnCols;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m, double d)
        {
            int row = m.GetnRows, col = m.GetnCols;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m[i, j] * d;
                }
            }
            return result;
        }

        public static Matrix operator *(double d, Matrix m)
        {
            int row = m.GetnRows, col = m.GetnCols;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m[i, j] * d;
                }
            }
            return result;
        }

        public static Matrix operator /(double d, Matrix m)
        {
            int row = m.GetnRows, col = m.GetnRows;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m[i, j] / d;
                }
            }
            return result;
        }

        public static Matrix operator /(Matrix m, double d)
        {
            int row = m.GetnRows, col = m.GetnRows;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = m[i, j] / d;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            int row = m1.GetnRows, col = m2.GetnCols;
            if (row!=col)
            {
                throw new Exception("The number of columns of the first matrix must equal" +
                                    "the number of rows of the second matrix");
            }
            double tmp;
            Matrix result = new Matrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp = result[i, j];
                    for (int k = 0; k < row; k++)
                    {
                        tmp += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = tmp;
                }
            }
            return result;
        }

        public void Transpose()
        {
            Matrix m = new Matrix(nCols, nRows);
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    m[j, i] = matrix[i, j];
                }
            }
            this = m;
        }

        public Matrix GetTranspose()
        {
            Matrix m = this;
            m.Transpose();
            return m;
        }

        public double GetTrace()
        {
            double sumOfDiagonal = 0;
            for (int i = 0; i < nRows; i++)
            {
                if (i<nCols)
                {
                    sumOfDiagonal += matrix[i, i];
                }
            }
            return sumOfDiagonal;
        }

        public bool IsSquared()
        {
            if (nRows == nCols) return true;
            else return false;
        }

        public Vectors GetRowVector(int m)
        {
            if (m < 0 || m > nRows)
            {
                throw new Exception("m-th row is out of range!");
            }
            int col = nCols;
            Vectors rowVector = new Vectors(col);
            for (int i = 0; i < col; i++)
            {
                rowVector[i] = matrix[m, i];
            }
            return rowVector;
        }

        public Vectors GetColVector(int n)
        {
            if (n < 0 || n > nCols)
            {
                throw new Exception("n-th col is out of range!");
            }
            int row = nRows;
            Vectors colVector = new Vectors(row);
            for (int i = 0; i < row; i++)
            {
                colVector[i] = matrix[i, n];
            }
            return colVector;
        }

        public Matrix ReplaceRow(Vectors vec, int m)
        {
            if (m < 0 || m > nRows)
            {
                throw new Exception("m-th row is out of range");
            }
            int col = nCols;
            if (vec.GetVectorSize != col)
            {
                throw new Exception("Vector dimension is out of range!");
            }
            for (int i = 0; i < col; i++)
            {
                matrix[m, i] = vec[i];
            }
            return new Matrix(matrix);
        }

        public Matrix ReplaceCol(Vectors vec, int n)
        {
            if (n < 0 || n > nCols)
            {
                throw new Exception("n-th col is out of range!");
            }
            int row = nRows;
            if (vec.GetVectorSize != row)
            {
                throw new Exception("Vector dimension is out of range!");
            }
            for (int i = 0; i < row; i++)
            {
                matrix[i, n] = vec[i];
            }
            return new Matrix(matrix);
        }

        public Matrix SwapMatrixRow(int m, int n)
        {
            double temp = 0;
            int col = nCols;
            for (int i = 0; i < col; i++)
            {
                temp = matrix[m, i];
                matrix[m, i] = matrix[n, i];
                matrix[n, i] = temp;
            }
            return new Matrix(matrix);
        }

        public Matrix SwapMatrixColumn(int m, int n)
        {
            double temp = 0;
            int row = nRows;
            for (int i = 0; i < row; i++)
            {
                temp = matrix[i, m];
                matrix[i, m] = matrix[i, n];
                matrix[i, n] = temp;
            }
            return new Matrix(matrix);
        }

        public static Vectors Transform(Matrix mat, Vectors vec)
        {
            Vectors result = new Vectors(vec.GetVectorSize);
            if (!mat.IsSquared())
            {
                throw new Exception("The matrix must be squared!");
            }
            if (mat.GetnCols !=vec.GetVectorSize)
            {
                throw new Exception("the dimension of the vector must be equal to the " +
                                    "number of columns of the matrix!");
            }
            for (int i = 0; i < mat.GetnRows; i++)
            {
                result[i] = 0;
                for (int j = 0; j < mat.GetnCols; j++)
                {
                    result[i] += mat[i, j] * vec[j];
                }
            }
            return result;
        }

        public static Vectors Transform(Vectors vec, Matrix mat)
        {
            Vectors result = new Vectors(vec.GetVectorSize);
            if (!mat.IsSquared())
            {
                throw new Exception("The matrix must be squared!");
            }
            if (mat.GetnRows != vec.GetVectorSize)
            {
                throw new Exception("The ndim of the vector must be equal"
                + " to the number of rows of the matrix!");
            }
            for (int i = 0; i < mat.GetnRows; i++)
            {
                result[i] = 0.0;
                for (int j = 0; j < mat.GetnCols; j++)
                {
                    result[i] += vec[j] * mat[j, i];
                }
            }
            return result;
        }

        public static Matrix Transform(Vectors v1, Vectors v2)
        {
            int dimension = v1.GetVectorSize;
            if (dimension != v2.GetVectorSize)
            {
                throw new Exception("The vectors must have the same dimension");
            }
            Matrix result = new Matrix(dimension, dimension);
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    result[j, i] = v1[i] * v2[j];
                }
            }
            return result;
        }

        public static double Determinant(Matrix mat)
        {

            if (!mat.IsSquared())
            {
                throw new Exception("matrix must be squared!");
            }
            double result = 0;
            int row = mat.GetnRows;
            if (row == 1) result = mat[0, 0];
            else
            {
                for (int i = 0; i < row; i++)
                {
                    result += Math.Pow(-1, i) * mat[0, i] * Determinant(Matrix.Minor(mat, 0, i));
                }
            }
            return result;
        }

        public static Matrix Minor(Matrix mat, int row, int col)
        {
            int matRow = mat.GetnRows, matCol = mat.GetnCols;
            Matrix mm = new Matrix(matRow - 1, matCol - 1);
            int ii = 0, jj = 0;
            for (int i = 0; i < matRow; i++)
            {
                if (i == row) continue;
                jj = 0;
                for (int j = 0; j < matCol; j++)
                {
                    if (j == col) continue;
                    mm[ii, jj] = mat[i, j];
                    jj++;
                }
                ii++;
            }
            return mm;
        }

        public static Matrix Adjoint(Matrix mat)
        {
            if (!mat.IsSquared())
            {
                throw new Exception("Matrix must be squared!");
            }
            int matRow = mat.GetnRows, matCol = mat.GetnCols;
            Matrix ma = new Matrix(matRow, matCol);
            for (int i = 0; i < matRow; i++)
            {
                for (int j = 0; j < matCol; j++)
                {
                    mat[i, j] = Math.Pow(-1, i) * Determinant(Minor(mat, i, j));
                }
            }
            return ma.GetTranspose();
        }

        public static Matrix Inverse(Matrix mat)
        {
            if (Determinant(mat) == 0)
            {
                throw new Exception("Cannot inverse a matrix with a zero determinant!");
            }
            return (Adjoint(mat) / Determinant(mat));
        }
    }
}
