using System;

namespace MathematicsLib
{
    public struct Vectors 
    {
        private int dimension;
        private double[] vector;

        public Vectors(int dimensions)
        {
            dimension = dimensions;
            vector = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                vector[i] = 0.0;
            }
        }

        public Vectors(double[] inputArray)
        {
            dimension = inputArray.Length;
            vector = inputArray;
        }

        public double this[int i]
        {
            get
            {
                if (i<0||i>dimension)
                {
                    throw new Exception("Index out of range!");
                }
                return vector[i];
            }
            set
            {
                vector[i] = value;
            }
        }

        public int GetVectorSize
        {
            get { return dimension; }
        }

        public Vectors SwapVectorEntries(int m, int n)
        {
            double temp = vector[m];
            vector[m] = vector[n];
            vector[n] = temp;
            return new Vectors(vector);
        }

        public override string ToString()
        {
            string str = "(";
            for (int i = 0; i < dimension-1; i++)
            {
                str += vector[i].ToString() + ",";
            }
            str += vector[dimension - 1].ToString() + ")";
            return str;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vectors) && this.Equals((Vectors)obj);
        }

        public bool Equals(Vectors v)
        {
            return vector == v.vector;
        }

        public override int GetHashCode()
        {
            return vector.GetHashCode();
        }

        public static bool operator ==(Vectors v1, Vectors v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vectors v1, Vectors v2)
        {
            return !v1.Equals(v2);
        }
         public static Vectors operator +(Vectors v)
        {
            return v;
        }

        public static Vectors operator +(Vectors v1, Vectors v2)
        {
            if (v1.dimension!=v2.dimension)
            {
                throw new Exception("dimesions not equal");
            }
            Vectors result=new Vectors (v1.dimension);
            for (int i = 0; i < v1.dimension; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        public static Vectors operator -(Vectors v)
        {
            double[] result = new double[v.dimension];
            for (int i = 0; i < v.dimension; i++)
            {
                result[i] = -v[i];
            }
            return new Vectors(result);
        }

        public static Vectors operator -(Vectors v1, Vectors v2)
        {
            int vectorDimension = v1.dimension;

            if (vectorDimension != v2.dimension)
            {
                throw new Exception("dimesions not equal");
            }
            Vectors result = new Vectors(vectorDimension);
            for (int i = 0; i < vectorDimension; i++)
            {
                result[i] = v1[i] - v2[i];
            }
            return result;
        }

        public static Vectors operator *(Vectors v, double d)
        {
            int vectorDimension = v.dimension;
            Vectors result = new Vectors(vectorDimension);
            for (int i = 0; i < vectorDimension; i++)
            {
                result[i] = v[i] * d;
            }
            return result;
        }

        public static Vectors operator *(double d, Vectors v)
        {
            int vectorDimension = v.dimension;
            Vectors result = new Vectors(vectorDimension);
            for (int i = 0; i < vectorDimension; i++)
            {
                result[i] = v[i] * d;
            }
            return result;
        }

        public static Vectors operator /(Vectors v, double d)
        {
            int dimension = v.dimension;
            Vectors result = new Vectors(dimension);
            for (int i = 0; i < dimension; i++)
            {
                result[i] = v[i] / d;
            }
            return result;
        }

        public static Vectors operator /(double d, Vectors v)
        {
            int dimension = v.dimension;
            Vectors result = new Vectors(dimension);
            for (int i = 0; i < dimension; i++)
            {
                result[i] = v[i] / d;
            }
            return result;
        }

        public static double DotProduct(Vectors v1, Vectors v2)
        {
            int dimension = v1.dimension;
            double result = 0.0;
            for (int i = 0; i < dimension; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }

        public double GetNormSquare()
        {
            double result = 0.0;
            for (int i = 0; i < dimension; i++)
            {
                result += vector[i] * vector[i];
            }
            return result;
        }

        public double GetNorm()
        {
            return Math.Sqrt(GetNormSquare());
        }

        public void Normalise()
        {
            double norm = GetNorm();
            if (norm==0)
            {
                throw new Exception("can't normalise a vector with a norm of zero!");
            }
            for (int i = 0; i < dimension; i++)
            {
                vector[i] /= norm;
            }
        }

        public Vectors GetUnitVector()
        {
            Vectors result = new Vectors(vector);
            result.Normalise();
            return result;
        }

        public static Vectors CrossProduct(Vectors v1, Vectors v2)
        {
            if (v1.dimension!=3 && v1.dimension!=v2.dimension)
            {
                throw new Exception("Vectoes must be three dimesional");
            }
            Vectors result = new Vectors(3);
            result[0] = v1[1] * v2[2] - v1[2] * v2[1];
            result[1] = v1[2] * v2[0] - v1[0] * v2[2];
            result[2] = v1[0] * v2[1] - v1[1] * v2[0];
            return result;
        }

        public static double GetAngle(Vectors v1, Vectors v2)
        {
            Vectors A = CrossProduct(v1, v2);
            double B = DotProduct(v1, v2);
            double angle = Math.Atan2(A.GetNorm(), B);
            return angle;
        }
    }
}
