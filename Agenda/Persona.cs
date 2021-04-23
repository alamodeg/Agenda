using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Persona
    {
        string nombre;
        string apellido;
        int edad;
        int telefono;

        public Persona(string _nombre, string _apellido, int _edad, int _telefono)
        {
            this.Nombre = _nombre;
            this.Apellido = _apellido;
            this.Edad = _edad;
            this.Telefono = _telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Telefono { get => telefono; set => telefono = value; }
    }
}
