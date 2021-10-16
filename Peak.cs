using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MathematicsLib
{
    public static class  PeakFinder
    {
        public static double FindPeak(double[] arr)
        { 
            int length = arr.Length;
            double peak;
            if (length == 0) return double.NaN;
            if (length == 1) return arr[0];
            int mid = length / 2 ;
            if (arr[mid] < arr[mid + 1])
            {
                double[] a = new double[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i + mid];
                }
                peak=FindPeak(a);
            }
            else if (arr[mid] < arr[mid - 1])
            {
                double[] a = new double[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i];
                }
                peak=FindPeak(a);
            }
            else peak= arr[mid] ;
            return peak;
        }

        public static int FindPeak(int[] arr) 
        {
            int length = arr.Length;
            int peak;
            if (length == 0)
            {
                throw new Exception("Length of array is zero!");
            }
            if (length == 1) return arr[0];
            int mid = length / 2;
            if (arr[mid] < arr[mid + 1])
            {
                int[] a = new int[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i + mid];
                }
                peak = FindPeak(a);
            }
            else if (arr[mid] < arr[mid - 1])
            {
                int[] a = new int[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i];
                }
                peak = FindPeak(a);
            }
            else peak = arr[mid];
            return peak;
        }
        public static double FindPeak( List<double> list)
        {
            int length = list.Count;
            double peak;
            if (length == 0) return double.NaN;
            if (length == 1) return peak = list.First();
            int mid = length / 2;
            if (list[mid] < list[mid + 1])
            {
                List<double> a = new List<double>();
                for (int i = mid; i < mid; i++)
                {
                    a.Add(list[i]);
                }
                peak = FindPeak(a);
            }
            else if (list[mid] < list[mid - 1])
            {
                List<double> a = new List<double>();
                for (int i = 0; i < mid; i++)
                {
                    a.Add(list[i]);
                }
                peak = FindPeak(a);
            }
            else peak = list[mid];
            return peak;
        }

        public static double FindPeak(Vectors arr)
        {
            int length = arr.GetVectorSize;
            double peak;
            if (length == 0) return double.NaN;
            if (length == 1) return arr[0];
            int mid = length / 2;
            if (arr[mid] < arr[mid + 1])
            {
                double[] a = new double[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i + mid];
                }
                peak = FindPeak(a);
            }
            else if (arr[mid] < arr[mid - 1])
            {
                double[] a = new double[mid];
                for (int i = 0; i < mid; i++)
                {
                    a[i] = arr[i];
                }
                peak = FindPeak(a);
            }
            else peak = arr[mid];
            return peak;
        }
         
        public static double Find2DPeak(double[,] array)
        {
            double peak;
            int[] maxIndex = FindMidColumnMaxIndex(array);
            int i = maxIndex[0], j = maxIndex[1];
            if (array[i, j] < array[i, j - 1])
            {
                int row = array.GetLength(0);
                int col = j;
                double[,] halfArray = new double[row, col];
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        halfArray[r, c] = array[r, c];
                    }
                }
                return peak = Find2DPeak(halfArray);
            }
            else if (array[i, j] < array[i, j + 1])
            {
                int row = array.GetLength(0);
                int col = j;
                double[,] halfArray = new double[row, col];
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        halfArray[r, c] = array[r, c + col];
                    }
                }
                return peak = Find2DPeak(halfArray);
            }
            else return array[i, j];
        }

        public static int[] FindMidColumnMaxIndex(double[,] mat)
        {
            int[] index=new int[2];
            double max = double.MinValue;
            int midCol = mat.GetLength(1) / 2;
            int row = mat.GetLength(0);
            if (midCol==0||row==0)
            {
                throw new Exception("Invalid matrix!");
            }
            for (int i = 0; i < row; i++)
            {
                if (max<mat[i,midCol])
                {
                    index[0] = i;max = mat[i, midCol];
                }
            }
            index[1] = midCol;
            return index;
        }
    }
}