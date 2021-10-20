using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using DataSerializacion;

namespace TiposSerializacion
{
    public class SerializacionSoap
    {
        public void Serializar(Persona p, string archivo)
        {
            var format = new SoapFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                format.Serialize(fs, p);
            }
        }

        public Persona Deserializar(string archivo)
        {
            var format = new SoapFormatter();

            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Persona p = (Persona)format.Deserialize(fs);

                return p;
            }
        }
    }
}
