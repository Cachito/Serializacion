using System;
using System.IO;
using System.Xml;
using DataSerializacion;
using TiposSerializacion;

namespace ConsolaSerializacion
{
    class Program
    {
        private const string RUTA = @"C:\TMP\Serializacion";
        private const string BINARIA = "binaria.dat";
        private const string SOAP = "soap.dat";
        private const string XML = "xml.dat";
        private const string JSON = "json.dat";
        private const string BINARIA_COMPOSICION = "binaria-composicion.dat";
        private const string XML_COMPOSICION = "xml-composicion.dat";

        static void Main(string[] args)
        {
            if (!Directory.Exists(RUTA))
            {
                Directory.CreateDirectory(RUTA);
            }


            Console.WriteLine("SERIALIZACIÓN");
            Console.WriteLine("");
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("");
            Console.WriteLine(" 1- Crear Binaria.");
            Console.WriteLine(" 2- Leer Binaria.");
            Console.WriteLine("");
            Console.WriteLine(" 3- Crear SOAP.");
            Console.WriteLine(" 4- Leer SOAP.");
            Console.WriteLine("");
            Console.WriteLine(" 5- Crear XML.");
            Console.WriteLine(" 6- Leer XML.");
            Console.WriteLine("");
            Console.WriteLine(" 7- Crear Binaria (Composición).");
            Console.WriteLine(" 8- Leer Binaria (Composición).");
            Console.WriteLine("");
            Console.WriteLine(" 9- Crear XML (Composición).");
            Console.WriteLine("10- Leer XML (Composición).");
            Console.WriteLine("");
            Console.WriteLine("11- Crear JSON.");
            Console.WriteLine("12- Leer JSON.");
            Console.WriteLine("");
            Console.WriteLine(" 0- Fin.");

            var opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.WriteLine("");
                    Console.Write("Ingrese una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            CrearBinaria();
                            break;

                        case 2:
                            LeerBinaria();
                            break;

                        case 3:
                            CrearSoap();
                            break;

                        case 4:
                            LeerSoap();
                            break;

                        case 5:
                            CrearXml();
                            break;

                        case 6:
                            LeerXml();
                            break;

                        case 7:
                            CrearBinariaComposicion();
                            break;

                        case 8:
                            LeerBinariaComposicion();
                            break;

                        case 9:
                            CrearXmlComposicion();
                            break;

                        case 10:
                            LeerXmlComposicion();
                            break;

                        case 11:
                            CrearJson();
                            break;

                        case 12:
                            LeerJson();
                            break;

                        case 0:
                            Console.WriteLine("Terminado.");
                            Console.WriteLine("Presione cualquier tecla.");
                            break;

                        default:
                            Console.WriteLine($"opción {opcion} no vaida");
                            break;
                    }
                }
                catch //(Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    Console.WriteLine("A ver si prestamos un poquito de atención...");
                }
            }

            Console.ReadKey();
        }

        private static void CrearBinaria()
        {
            var fechaNacimiento = new DateTime(1961, 4, 4);
            const string nombre = "Cacho";
            const string pais = "Argentina";

            var p = new Persona(fechaNacimiento, nombre, pais);
            Console.Write(p.GetDatos());

            Console.WriteLine("Serialización Binaria...");

            var archivo = Path.Combine(RUTA, BINARIA);
            new SerializacionBinaria().Serializar(p, archivo);

            Console.WriteLine("Completado.");
        }

        private static void CrearSoap()
        {
            const string nombre = "Marcelo";
            var fechaNacimiento = new DateTime(1991, 8, 16);
            const string pais = "Argentina";

            var p = new Persona(fechaNacimiento, nombre, pais);
            Console.Write(p.GetDatos());

            Console.WriteLine("Serialización SOAP...");

            var archivo = Path.Combine(RUTA, SOAP);
            new SerializacionSoap().Serializar(p, archivo);

            Console.WriteLine("Completado.");
        }

        private static void CrearXml()
        {
            var a = new Animal
            {
                Especie = "Perro",
                Edad = 4,
                Raza = "Caniche Toy"
            };

            Console.Write(a.GetDatos());

            Console.WriteLine("Serialización XML...");

            var archivo = Path.Combine(RUTA, XML);
            new SerializacionXml().Serializar(a, archivo);

            Console.WriteLine("Completado.");
        }

        private static void CrearBinariaComposicion()
        {
            const string nombre = "Cacho";
            const int edad = 60;
            const string legajo = "LCC-1961";

            Domicilio d = new Domicilio
            {
                Calle = "Oscuridad",
                Numero = 0,
                Ciudad = "Oculta"
            };

            var e = new Empleado
            {
                Nombre = nombre,
                Edad = edad,
                Legajo = legajo,
                Domicilio = d
            };

            Console.Write(e.GetDatos());

            Console.WriteLine("Serialización Binaria (Composición)...");

            var archivo = Path.Combine(RUTA, BINARIA_COMPOSICION);
            new SerializacionBinaria().SerializarComposicion(e, archivo);

            Console.WriteLine("Completado.");
        }

        private static void CrearXmlComposicion()
        {
            const string nombre = "Marcelo";
            const int edad = 30;
            const string legajo = "MF-1991";

            Domicilio d = new Domicilio
            {
                Calle = "Churrinche",
                Numero = 1253,
                Ciudad = "Expuesta"
            };

            var e = new Empleado
            {
                Nombre = nombre,
                Edad = edad,
                Legajo = legajo,
                Domicilio = d
            };

            Console.Write(e.GetDatos());

            Console.WriteLine("Serialización XML (Composición)...");

            var archivo = Path.Combine(RUTA, XML_COMPOSICION);
            new SerializacionXml().SerializarComposicion(e, archivo);

            Console.WriteLine("Completado.");
        }

        private static void CrearJson()
        {
            var p = new Producto
            {
                Nombre = "Manzana",
                Vencimiento = new DateTime(2021, 12, 10),
                Precio = 52.25,
                Calidades = new []{"Regular", "Mala", "Pésima"}
            };

            Console.Write(p.GetDatos());

            Console.WriteLine("Serialización JSON...");

            var archivo = Path.Combine(RUTA, JSON);
            new SerializacionJson().Serializar(p, archivo);

            Console.WriteLine("Completado.");
        }

        private static void LeerBinaria()
        {
            var archivo = Path.Combine(RUTA, BINARIA);
            var p = new SerializacionBinaria().Deserializar(archivo);

            Console.WriteLine("Deserialización Binaria...");
            Console.Write(p.GetDatos());
        }

        private static void LeerSoap()
        {
            var archivo = Path.Combine(RUTA, SOAP);
            var p = new SerializacionSoap().Deserializar(archivo);

            Console.WriteLine("Deserialización SOAP...");
            Console.Write(p.GetDatos());
        }

        private static void LeerXml()
        {
            var archivo = Path.Combine(RUTA, XML);
            var a = new SerializacionXml().Deserializar(archivo);

            Console.WriteLine("Deserialización XML...");
            Console.Write(a.GetDatos());
        }

        private static void LeerBinariaComposicion()
        {
            var archivo = Path.Combine(RUTA, BINARIA_COMPOSICION);
            var e = new SerializacionBinaria().DeserializarComposicion(archivo);

            Console.WriteLine("Deserialización Binaria (Composicion)...");
            Console.Write(e.GetDatos());
        }

        private static void LeerXmlComposicion()
        {
            var archivo = Path.Combine(RUTA, XML_COMPOSICION);
            var e = new SerializacionXml().DeserializarComposicion(archivo);

            Console.WriteLine("Deserialización XML (Composición)...");
            Console.Write(e.GetDatos());
        }

        private static void LeerJson()
        {
            var archivo = Path.Combine(RUTA, JSON);
            var p = new SerializacionJson().Deserializar(archivo);

            Console.WriteLine("Deserialización JSON...");
            Console.Write(p.GetDatos());
        }
    }
}