using System;
using Autofac;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using MvvmLibrary.ModuloBase;
using Newtonsoft.Json;
using RedContactos.Service;
using RedContactos.Util;
using RedContactos.View;
using RedContactos.View.Contactos;
using RedContactos.View.Mensajes;
using RedContactos.ViewModel;
using RedContactos.ViewModel.Contactos;
using RedContactos.ViewModel.Mensajes;
using Xamarin.Forms;

namespace RedContactos.Module
{
    public class Startup:AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<ContactosModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, LoginView>();
            viewFactory.Register<AltaViewModel, Alta>();
            viewFactory.Register<ContactosViewModel, ContactosView>();                viewFactory.Register<PrincipalViewModel,PrincipalView>();
            viewFactory.Register <AddContactoViewModel,AddContactoView> ();
            viewFactory.Register <EnviarMensajeViewModel,EnviarMensajeView> ();
            viewFactory.Register <MisMensajesViewModel,MisMensajesView> ();
            viewFactory.Register <DetalleMensajeViewModel,DetalleMensajeView> ();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();

            var txt = DependencyService.Get<IServicioFicheros>().RecuperarTexto(Cadenas.FicheroSettings);
            if (String.IsNullOrEmpty(txt))
            {
                var main = viewFactory.Resolve<LoginViewModel>();
                var np = new NavigationPage(main);
                _application.MainPage = np;

            }
            else
            {
              var data=  JsonConvert.DeserializeObject<UsuarioModel>(txt);

                Cadenas.Session["usuario"] = data;
                var main = viewFactory.Resolve<PrincipalViewModel>();
                var np = new NavigationPage(main);
                _application.MainPage = np;
                
            }


            
        }
    }
}