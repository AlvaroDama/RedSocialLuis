using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class EnviarMensajeViewModel:GeneralViewModel
    {
        private ContactoModel _contacto;
        private MensajeModel _mensaje;
        public ContactoModel Contacto
        {
            get { return _contacto; }
            set
            {
                SetProperty(ref _contacto,value);
            }
        }

        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set
            {
                SetProperty(ref _mensaje , value);
            }
        }

        public ICommand CmdEnviar { get; set; }

        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdEnviar=new Command(RunEnviarMensaje);
        }

        private async void RunEnviarMensaje()
        {
            try
            {
                IsBusy = true;
                Mensaje.IdOrigen = Contacto.IdOrigen;
                Mensaje.Fecha=DateTime.Now;
                Mensaje.IdDestino = Contacto.IdDestino;
                Mensaje.Leido = false;
                var r= await _servicio.AddMensaje(Mensaje);
                if (r != null)
                {
                    await _page.MostrarAlerta("Exito", "Mensaje enviado", "Aceptar");
                }
                else
                {
                    await _page.MostrarAlerta("Error", "No se pudo enviar", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
      
    }
}