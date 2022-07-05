using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace SerializedStructContainer
{
    [System.Serializable]
    public struct SerializableRecordList
    {
        public List<Record> Records;

        public SerializableRecordList(List<Record> list)
        {
            Records = list;
        }
        
        public List<Record> ReturnList()
        {
            return Records;
        }
        public SerializableRecordList(string str) => this = DeserialiseObjectToRecordList(str);
        public string Serialize()
        {
            return Serializator.SerializeObject(this);
        }
        public static SerializableRecordList DeserialiseObjectToRecordList(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return (SerializableRecordList)new BinaryFormatter().Deserialize(stream);
            }
        }

    }
    public struct Record
    {
        public string Points;
        public string Name;

        public Record(int points, string name)
        {
            Points = points.ToString();
            Name = name;
        }

        public override string ToString()
        {
            return $"({Points} : {Name})";
        }
    }
}