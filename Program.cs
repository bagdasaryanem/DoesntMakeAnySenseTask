using System;
using System.Collections.Generic;
using System.Linq;

namespace DoesntMakeAnySenseTask
{
    public static class ExtensionMethod
    {
        public static IEnumerable<TSource> ThisDoesntMakeAnySense<TSource>(this IEnumerable<TSource> inputData, Func<TSource, bool> predicate, Func<IEnumerable<TSource>> newData)
        {
            if (inputData == null)
                throw new ArgumentNullException(nameof(inputData));

            foreach (var value in inputData)
            {
                if (predicate(value))
                    return inputData;
            }

            return newData();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                //First Case
                Console.WriteLine("Enter comma separated numbers:");
                var input = Console.ReadLine();
                var data = Array.ConvertAll(input.Split(','), Convert.ToInt32);

                Console.WriteLine("First Case:");

                var firstCase = data.ThisDoesntMakeAnySense(i => true, () => new[] { 1, 2, 3 });

                foreach (var i in firstCase)
                {
                    Console.Write(i + " ");

                }


                //Second Case
                Console.WriteLine();
                Console.WriteLine("Second case:");

                var secondCase = data.ThisDoesntMakeAnySense(i => false, () => new[] { 1, 2, 3 });

                foreach (var i in secondCase)
                {
                    Console.Write(i + " ");

                }


                //Third Case
                Console.WriteLine();
                Console.WriteLine("Third case:");

                data = null;

                var thirdCase = data.ThisDoesntMakeAnySense(i => false, () => new[] { 1, 2, 3 });

                foreach (var i in thirdCase)
                {
                    Console.Write(i + " ");

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
