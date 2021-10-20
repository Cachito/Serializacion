using System;
using System.Text;

namespace DataSerializacion
{
    public class Producto
    {
        public string Nombre { set; get; }
        public DateTime Vencimiento { set; get; }
        public double Precio { set; get; }
        public string[] Calidades { set; get; }

        public string GetDatos()
        {
            var datos = new StringBuilder();

            datos.Append($"Nombre: {Nombre}{Environment.NewLine}");
            datos.Append($"Vencimiento: {Vencimiento:d}{Environment.NewLine}");
            datos.Append($"Precio: {Precio:F}{Environment.NewLine}");
            datos.Append($"Calidades: {string.Join(",", Calidades)}{Environment.NewLine}");

            return datos.ToString();
        }
    }
}