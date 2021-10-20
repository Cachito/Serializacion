using System;
using System.Text;

namespace DataSerializacion
{
    [Serializable]
    public class Empleado
    {
        public string Nombre { set; get; }
        public int Edad { set; get; }
        public string Legajo { set; get; }
        public Domicilio Domicilio { set; get; }

        public Empleado()
        {
        }

        public Empleado(string nombre, int edad, string legajo)
        {
            Nombre = nombre;
            Edad = edad;
            Legajo = legajo;
        }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"Nombre: {Nombre}{Environment.NewLine}");
            datos.Append($"Edad: {Edad}{Environment.NewLine}");
            datos.Append($"Legajo: {Legajo}{Environment.NewLine}");

            datos.Append(Domicilio.GetDatos());

            return datos.ToString();
        }
    }
}