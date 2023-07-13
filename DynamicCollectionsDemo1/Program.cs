namespace DynamicCollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dynamic Collections
            // store n number of ints and display
            //DynamicArray<int> numbers = new DynamicArray<int>();
            DynamicArray<string> numbers = new DynamicArray<string>();
            //DynamicDoubleArray dnumbers = new DynamicDoubleArray();
            numbers.Add("1.34");
            numbers.Add("2.23");
            numbers.Add("3.54");

            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add(1);
            //numbers.Add(2);
            numbers.Add("100");


            for (int i = 0; i < numbers.Count; i++)
            {
                string n = numbers.GetValue(i);
                Console.WriteLine(n);
            }
        }


        // Generic class
        class DynamicArray<T>
        {
            private T[] data = new T[10];
            private int index = 0;
            public void Add(T v)
            {
                // if empty
                if (index < data.Length)
                {
                    data[index++] = v;
                }
                else // if not empty
                {
                    T[] temp = new T[data.Length * 2];
                    for (int i = 0; i < data.Length; i++)
                    {
                        temp[i] = data[i];

                    }
                    data = temp;
                    data[index++] = v;
                }

            }

            public int Count
            {
                get { return index; }
            }

            public T GetValue(int i)
            {
                return data[i];
            }
        }

    }
}