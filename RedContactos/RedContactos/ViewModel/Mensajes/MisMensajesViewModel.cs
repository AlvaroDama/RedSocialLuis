using System.Collections.ObjectModel;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Service;

namespace RedContactos.ViewModel.Mensajes
{
    public class MisMensajesViewModel:GeneralViewModel
    {
        private ObservableCollection<MensajeModel> _mensajes;
        public ObservableCollection<MensajeModel> Mensajes
        {
            get { return _mensajes; }
            set { SetProperty(ref  _mensajes ,value); }
        }

        public MensajeModel MensajeSeleccionado
        {
            get { return _mensajeSeleccionado; }
            set
            {
                

                SetProperty(ref _mensajeSeleccionado, value);
                if (value != null)
                    VerDetalleMensaje();
            }
        }

        private MensajeModel _mensajeSeleccionado;


        public MisMensajesViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        private async void VerDetalleMensaje()
        {
            if (_mensajeSeleccionado != null)
            {
                if (!_mensajeSeleccionado.Leido)
                {
                    _mensajeSeleccionado.Leido = true;
                    await _servicio.UpdateMensaje(_mensajeSeleccionado);
                }

                await _navigator.PushAsync<DetalleMensajeViewModel>(viewModel =>
                {
                    viewModel.Mensaje = _mensajeSeleccionado;
                    viewModel.Titulo = _mensajeSeleccionado.Asunto;
                });
                MensajeSeleccionado = null;
            }
        }
       
    }
}