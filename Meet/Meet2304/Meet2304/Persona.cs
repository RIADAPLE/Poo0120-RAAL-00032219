﻿using System;

namespace Meet2304
{
    public class Persona
    {
        private String nombre, apellido;
        private int edad;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido => apellido;

        public int Edad => edad;

        public Persona(String nombre = "sin nombre",
            String apellido = "sin apellido",
            int edad = 0)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public override string ToString()
        {
            return $"{nameof(nombre)}: {nombre}, {nameof(apellido)}: {apellido}, {nameof(edad)}: {edad}";
        }

        public String saludar(String saludoP)
        {
            return nombre +" " + saludoP;
        }
    }
}