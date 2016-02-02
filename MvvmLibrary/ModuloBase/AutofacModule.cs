using Autofac;
using MvvmLibrary.Factorias;

namespace MvvmLibrary.ModuloBase
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().
                As<IViewFactory>().
                SingleInstance();

            builder.RegisterType<Navigator>().
                As<INavigator>().SingleInstance();

           

        }
    }
}