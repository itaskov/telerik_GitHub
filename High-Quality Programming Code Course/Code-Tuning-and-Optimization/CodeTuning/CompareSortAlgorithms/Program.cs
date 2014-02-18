using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CompareSortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            SortIntArray();

            SortDoubleArray();

            SortStringArray();
        }

        private static void SortStringArray()
        {
            string[] stringArr = new string[10000];
            Random random = new Random();
            for (int i = 0; i < stringArr.GetLength(0); i++)
            {
                int stringArrIndexLen = 5;
                StringBuilder element = new StringBuilder();
                for (int j = 0; j < stringArrIndexLen; j++)
                {
                    element.Append((char)random.Next('a', 'z' + 1)); 
                }

                stringArr[i] = element.ToString();
            }
            //Console.WriteLine("stringArr = [{0}]", string.Join(", ", stringArr));

            string[] stringArrCopy = new string[stringArr.GetLength(0)];
            Array.Copy(stringArr, stringArrCopy, stringArr.GetLength(0));

            Console.WriteLine("string");
            Console.Write("InsertionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(stringArrCopy);
            });

            Array.Copy(stringArr, stringArrCopy, stringArr.GetLength(0));

            Console.Write("SelectionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(stringArrCopy);
            });

            Array.Copy(stringArr, stringArrCopy, stringArr.GetLength(0));

            QuickList<string> quickSort = new QuickList<string>(stringArrCopy);
            Console.Write("QuickSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                quickSort.QSort((f, s) => f.CompareTo(s));
            });
            Console.WriteLine();
        }

        private static void SortIntArray()
        {
            Random random = new Random();
            int[] intArr = new int[10000];
            for (int i = 0; i < intArr.GetLength(0); i++)
            {
                intArr[i] = random.Next(0, 10001);
            }

            int[] intArrCopy = new int[intArr.GetLength(0)];
            Array.Copy(intArr, intArrCopy, intArr.GetLength(0));

            Console.WriteLine("int");
            Console.Write("InsertionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(intArrCopy);
            });

            Array.Copy(intArr, intArrCopy, intArr.GetLength(0));

            Console.Write("SelectionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(intArrCopy);
            });

            Array.Copy(intArr, intArrCopy, intArr.GetLength(0));

            QuickList<int> quickSort = new QuickList<int>(intArrCopy);
            Console.Write("QuickSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                quickSort.QSort((f, s) => f.CompareTo(s));
            });
            Console.WriteLine();
        }

        private static void SortDoubleArray()
        {
            Random random = new Random();
            double[] doubleArr = new double[10000];
            for (int i = 0; i < doubleArr.GetLength(0); i++)
            {
                doubleArr[i] = random.Next(0, 10001);
            }

            double[] doubleArrCopy = new double[doubleArr.GetLength(0)];
            Array.Copy(doubleArr, doubleArrCopy, doubleArr.GetLength(0));

            Console.WriteLine("double");
            Console.Write("InsertionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(doubleArrCopy);
            });

            Array.Copy(doubleArr, doubleArrCopy, doubleArr.GetLength(0));

            Console.Write("SelectionSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(doubleArrCopy);
            });

            Array.Copy(doubleArr, doubleArrCopy, doubleArr.GetLength(0));

            QuickList<double> quickSort = new QuickList<double>(doubleArrCopy);
            Console.Write("QuickSort:\t\t\t");
            DisplayExecutionTime(() =>
            {
                quickSort.QSort((f, s) => f.CompareTo(s));
            });
            Console.WriteLine();
        }

        private static void InsertionSort<T>(T[] arr) where T : IConvertible, IComparable
        {
            int i;
            int j;
            T index;

            for (i = 1; i < arr.Length; i++)
            {
                index = arr[i];
                j = i;

                while ((j > 0) && (arr[j - 1].CompareTo(index) == 1))
                {
                    arr[j] = arr[j - 1];
                    j = j - 1;
                }

                arr[j] = index;
            }
        }
        
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Parameter arr cannot be  null!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

    }

    /// <summary>
    /// Generic List for quick sorting by a custom comparison function
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickList<T> : List<T>
    {
        private T[] arr;

        public QuickList(T[] arr)
        {
            this.arr = arr;
        }
        
        /// <summary>
        /// The quicksort is considered to be very efficient,  with its "divide and conquer" 
        /// algorithm.  This sort starts by dividing the original array into two sections 
        /// (partitions) based upon the value of the first element in the array.
        /// This algorithm uses recursion to complete the sorting.
        /// See : http://mathbits.com/mathbits/compsci/arrays/Quick.htm
        /// Best case - O(n log n)
        /// Average case - O(n log n)
        /// Worst case - O(n^2)
        /// </summary>
        /// <param name="_comparison">Custom comparor used for type T</param>
        public void QSort(Comparison<T> _comparison)
        {
            if (_comparison == null) throw new Exception("Comparison cannot be null.");
            if (this.arr.GetLength(0) < 2) return;
            this._comparor = _comparison;
            this.quicksort(0, this.arr.GetLength(0) - 1);
            this._comparor = null;
        }

        #region Quick Sort recursive with Comparison function

        private Comparison<T> _comparor = null;
        private void quicksort(int top, int bottom)
        {
            if (top < bottom)
            {
                int middle = partition(top, bottom);
                quicksort(top, middle);   // sort first section
                quicksort(middle + 1, bottom);    // sort second section
            }
        }

        private int partition(int top, int bottom)
        {
            T x = this.arr[top];
            int i = top - 1;
            int j = bottom + 1;

            do
            {
                do
                {
                    j--;
                } while (_comparor(x, this.arr[j]) < 0);

                do
                {
                    i++;
                } while (_comparor(x, this.arr[i]) > 0);

                if (i < j)
                {
                    T temp = this.arr[i];
                    this.arr[i] = this.arr[j];
                    this.arr[j] = temp;
                }
            } while (i < j);
            return j;           // returns middle subscript  
        }

        #endregion
    }

}
