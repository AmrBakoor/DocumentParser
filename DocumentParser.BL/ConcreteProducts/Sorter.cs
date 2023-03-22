using System;
using DocumentParser.BL.AbstractProducts;

namespace DocumentParser.BL.ConcreteProducts
{
    public class Sorter : ISorter
    {
        #region Public Behaviour
        public Dictionary<string, int> Sort(Dictionary<string, int> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            var sortedDictionary = new Dictionary<string, int>();
            var keys = MergeSort(dictionary.Keys.ToArray());

            foreach (var key in keys)
            {
                sortedDictionary.Add(key, dictionary[key]);
            }

            return sortedDictionary;
        }

        #endregion

        #region Private Behaviour
        private string[] MergeSort(string[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int mid = array.Length / 2;
            string[] leftArray = new string[mid];
            string[] rightArray = new string[array.Length - mid];

            Array.Copy(array, 0, leftArray, 0, mid);
            Array.Copy(array, mid, rightArray, 0, array.Length - mid);

            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            return Merge(leftArray, rightArray);
        }

        private string[] Merge(string[] leftArray, string[] rightArray)
        {
            var result = new string[leftArray.Length + rightArray.Length];

            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                {
                    result[resultIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = rightArray[rightIndex++];
                }
            }

            while (leftIndex < leftArray.Length)
            {
                result[resultIndex++] = leftArray[leftIndex++];
            }

            while (rightIndex < rightArray.Length)
            {
                result[resultIndex++] = rightArray[rightIndex++];
            }

            return result;
        }

        #endregion


    }
}
