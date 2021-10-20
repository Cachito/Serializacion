using System;
using System.Xml.Serialization;
using System.IO;
using DataSerializacion;

namespace TiposSerializacion
{
    public class SerializacionXml
    {
        public void Serializar(Animal a, string archivo)
        {
            var format = new XmlSerializer(typeof(Animal));

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                format.Serialize(fs, a);
            }
        }

        public Animal Deserializar(string archivo)
        {
            var format = new XmlSerializer(typeof(Animal));

            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Animal a = (Animal)format.Deserialize(fs);

                return a;
            }
        }

        public void SerializarComposicion(Empleado e, string archivo)
        {
            var format = new XmlSerializer(typeof(Empleado), new[] {typeof(Domicilio)});

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                format.Serialize(fs, e);
            }
        }

        public Empleado DeserializarComposicion(string archivo)
        {
            var format = new XmlSerializer(typeof(Empleado), new[] { typeof(Domicilio) });

            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Empleado e = (Empleado)format.Deserialize(fs);

                return e;
            }
        }
    }
}
