using System;
using System.Runtime.Serialization;
using System.Text;

namespace DataSerializacion
{
    [Serializable]
    public class Persona
    {
        private string nombre;
        private string pais;
        private DateTime fechaNacimiento;
        [NonSerialized]
        private int edad;

        private DateTime FechaNacimiento
        {
            get => fechaNacimiento;
            set
            {
                fechaNacimiento = value;
                edad = DateTime.Now.Year - fechaNacimiento.Year;
            }
        }

        private int Edad
        {
            get => edad;
            set => edad = value;
        }

        public Persona(DateTime fechaNacimiento, string nombre, string pais)
        {
            FechaNacimiento = fechaNacimiento;
            this.nombre = nombre;
            this.pais = pais;
        }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"Nombre: {nombre}{Environment.NewLine}");
            datos.Append($"Fecha Nacimiento: {FechaNacimiento:d}{Environment.NewLine}");
            datos.Append($"Edad: {Edad}{Environment.NewLine}");
            datos.Append($"País: {pais}{Environment.NewLine}");

            return datos.ToString();
        }

        [OnDeserialized]
        private void SetEdad(StreamingContext context)
        {
            Edad =  DateTime.Now.Year - fechaNacimiento.Year;
        }
    }
}
