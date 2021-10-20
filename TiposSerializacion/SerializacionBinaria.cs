using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DataSerializacion;

namespace TiposSerializacion
{
    public class SerializacionBinaria
    {
        public void Serializar(Persona p, string archivo)
        {
            var format = new BinaryFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                format.Serialize(fs, p);
            }
        }

        public void SerializarComposicion(Empleado e, string archivo)
        {
            var format = new BinaryFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                format.Serialize(fs, e);
            }
        }

        public Persona Deserializar(string archivo)
        {
            var format = new BinaryFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Persona p = (Persona)format.Deserialize(fs);

                return p;
            }
        }

        public Empleado DeserializarComposicion(string archivo)
        {
            var format = new BinaryFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Empleado e = (Empleado)format.Deserialize(fs);

                return e;
            }
        }
    }
}
