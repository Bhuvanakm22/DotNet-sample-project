namespace ClassLibraryCommon
{
    public class GenericMethod
    {
        public T FindMaxValue<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 0)
                throw new ArgumentException("Array cannot be empty");

            T max = array[0];

            foreach (T item in array)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }

            return max;
        }
    }
}
