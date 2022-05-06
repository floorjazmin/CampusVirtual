using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Persona
    {
        #region Atributos
        private string Nombre { get; set; }
        private int Edad { get; set; }
        private int DNI { get; set; }

        private const string sexo = "H";
        private float Peso { get; set; }
        private float Altura { get; set; }

        #endregion

        public Persona() {}

        public Persona(char sexo)

        {
            comprobarSexo(sexo);


        }
        public Persona(string nombre, int edad, string sexo)
        {
            Nombre = nombre;
            Edad = edad;
            sexo = sexo;
        }

        public Persona(string nombre, int edad, int dni, string sexo, float peso, float altura)
        {
            Nombre = nombre;
            Edad = edad;
            DNI = dni;
            sexo = sexo;
            Peso = peso;
            Altura = altura;
        }
        private void comprobarSexo(char sexo)
        {
            if (sexo != 'H' || sexo != 'M')
            {
                sexo = 'H';
            }
            Console.WriteLine(sexo);
        }

        private void Validar() { }
        private void Agregar() { }
        private void Modificar() { }




    }
}
