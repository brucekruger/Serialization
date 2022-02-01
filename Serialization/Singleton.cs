using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Serialization
{
    [Serializable]
    public sealed class Singleton : ISerializable
    {
        // This is the one instance of this type
        private static readonly Singleton s_theOneObject = new Singleton();
        // Here are the instance fields
        public string Name = "Andrei";
        public DateTime Date = DateTime.Now;
        // Private constructor allowing this type to construct the singleton
        private Singleton() { }
        // Method returning a reference to the singleton
        public static Singleton GetSingleton() { return s_theOneObject; }
        // Method called when serializing a Singleton
        // I recommend using an Explicit Interface Method Impl. Here
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.SetType(typeof(SingletonSerializationHelper));// No other values need to be added

        [Serializable]
        private sealed class SingletonSerializationHelper : IObjectReference
        {
            // Method called after this object (which has no fields) is deserialized
            public object GetRealObject(StreamingContext context) => GetSingleton();
        }
        // NOTE: The special constructor is NOT necessary because it's never called
    }
}
