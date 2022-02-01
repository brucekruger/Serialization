using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public static class SerializationHelper
    {
        public static T DeepClone<T>([NotNull] T original)
        {
            if(original == null)
            {
                throw new ArgumentNullException(nameof(original));
            }

            // Construct a temporary memory stream
            using var stream = new MemoryStream();
            // Construct a serialization formatter that does all the hard work
            var formatter = new BinaryFormatter
            {
                // This line is explained in this chapter's "Streaming Contexts" section
                Context = new StreamingContext(StreamingContextStates.Clone)
            };
            // Serialize the object graph into the memory stream
            formatter.Serialize(stream, original);
            // Seek back to the start of the memory stream before deserializing
            stream.Position = 0;
            // Deserialize the graph into a new set of objects and
            // return the root of the graph (deep copy) to the caller
            return (T)formatter.Deserialize(stream);
        }
    }
}
