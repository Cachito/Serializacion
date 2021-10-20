using System;
using System.Text;

namespace DataSerializacion
{
    [Serializable]
    public class Persona
    {
        private string nombre;
        private int edad;
        private string pais;

        public Persona(int edad, string nombre, string pais)
        {
            this.edad = edad;
            this.nombre = nombre;
            this.pais = pais;
        }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"Nombre: {nombre}{Environment.NewLine}");
            datos.Append($"Edad: {edad}{Environment.NewLine}");
            datos.Append($"País: {pais}{Environment.NewLine}");

            return datos.ToString();
        }
    }
}
