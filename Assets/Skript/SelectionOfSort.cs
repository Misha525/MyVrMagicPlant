
    using System.Linq;
    using UnityEngine;

    public class SelectionOfSort : MonoBehaviour
    {
        /// <summary>
        /// Метод обработки события OnClick кнопки "Сортировка выбором"
        /// </summary>
        public void OnSelectionSort()
        {
            int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", originalArray) + "]");

            int[] sortedArray = SelectionSort((int[])originalArray.Clone());
            Debug.LogFormat("Результат сортировки {0}", "[" + string.Join(",", sortedArray) + "]");

            int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
            Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
        }

        /// <summary>
        /// Метод сортируем массив методом выбора
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <returns>Отсортированный массив</returns>
        private int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
            return array;
        }
    }