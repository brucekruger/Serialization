using System;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(SingletonSerializationTest));
            SingletonSerializationTest();
        }

        private static void SingletonSerializationTest()
        {
            // Create an array with multiple elements referring to the one Singleton object
            Singleton[] a1 = { Singleton.GetSingleton(), Singleton.GetSingleton() };
            Console.WriteLine($"Do both elements refer to the same object? {a1[0] == a1[1]}"); // "True"

            Singleton[] a2 = SerializationHelper.DeepClone(a1);

            // Prove that it worked as expected:
            Console.WriteLine($"Do both elements refer to the same object? {a2[0] == a2[1]}"); // "True"
            Console.WriteLine($"Do all elements refer to the same object? {a1[0] == a2[0]}"); // "True"
        }
    }
}
