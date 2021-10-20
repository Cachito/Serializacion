using System;
using System.Text;

namespace DataSerializacion
{
    [Serializable]
    public class Domicilio
    {
        public string Calle { set; get; }
        public int Numero { set; get; }
        public string Ciudad { set; get; }

        public Domicilio()
        {
            
        }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"-> Calle: {Calle}{Environment.NewLine}");
            datos.Append($"-> Número: {Numero}{Environment.NewLine}");
            datos.Append($"-> Ciudad: {Ciudad}{Environment.NewLine}");

            return datos.ToString();
        }
    }
}
