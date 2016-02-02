﻿using System;
using System.IO;
using RedContactos.iOS.Servicios;
using RedContactos.Service;
using Xamarin.Forms;

[assembly: Dependency(typeof(ServicioFicheros))]

namespace RedContactos.iOS.Servicios
{
    public class ServicioFicheros : IServicioFicheros
    {
        public void GuardarTexto(string texto, string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            File.WriteAllText(rutafinal, texto);
        }

        public string RecuperarTexto(string fichero)
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
           
                return File.ReadAllText(rutafinal);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}