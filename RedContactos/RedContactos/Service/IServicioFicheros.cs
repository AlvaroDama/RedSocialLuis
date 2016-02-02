using System;

namespace RedContactos.Service
{
    public interface IServicioFicheros
    {
        void GuardarTexto(String texto, String fichero);
        String RecuperarTexto(String fichero);
    }
}