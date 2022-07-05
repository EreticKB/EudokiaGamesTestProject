using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerializedStructContainer
{
    public static class Serializator
    {
        public static string SerializeObject(object o)
        {
            if (!o.GetType().IsSerializable)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, o);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}

