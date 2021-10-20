using System;
using System.Text;

namespace DataSerializacion
{
    [Serializable]
    public class Animal
    {
        public string Especie { set; get; }
        public int Edad { set; get; }
        public string Raza{ set; get; }

        public Animal()
        {
            
        }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"Especie: {Especie}{Environment.NewLine}");
            datos.Append($"Edad: {Edad}{Environment.NewLine}");
            datos.Append($"Raza: {Raza}{Environment.NewLine}");

            return datos.ToString();
        }
    }
}
