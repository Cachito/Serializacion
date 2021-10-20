using System.IO;
using System.Text;
using DataSerializacion;
using Newtonsoft.Json;

namespace TiposSerializacion
{
    public class SerializacionJson
    {
        public void Serializar(Producto p, string archivo)
        {
            string ps = JsonConvert.SerializeObject(p);

            using (Stream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(ps);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public Producto Deserializar(string archivo)
        {
            using (Stream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (var sr = new StreamReader(fs))
                {
                    var data = sr.ReadToEnd();
                    Producto p = JsonConvert.DeserializeObject<Producto>(data);

                    return p;
                }
            }
        }
    }
}
