using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using Newtonsoft.Json;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }
        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }
        public LoginViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio,page)
        {
            _usuario=new UsuarioModel();
            CmdLogin=new Command(RunLogin);
            CmdAlta=new Command(RunAlta);
        }

        private async void RunLogin()
        {
            try
            {
                IsBusy = true;
                var us=await _servicio.ValidarUsuario(Usuario);
                if (us != null)
                {
                    var txt = JsonConvert.SerializeObject(us);
                    DependencyService.Get<IServicioFicheros>().GuardarTexto(txt,Cadenas.FicheroSettings);

                    Cadenas.Session["usuario"] = us;
                  await  _navigator.PushAsync<PrincipalViewModel>(
                      viewModel =>
                    {
                        viewModel.Titulo = "Tus contactos";
                        
                    });
                }
                else
                {
                   await _page.MostrarAlerta("Error", "Error en el login", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void RunAlta()
        {
            await _navigator.PushAsync<AltaViewModel>(viewModel =>
            {
                Titulo = "Nuevo usuario";
            });
        }


       
    }
}