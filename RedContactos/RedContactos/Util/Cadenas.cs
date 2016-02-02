using System;
using System.Collections.Generic;

namespace RedContactos.Util
{
   public static class Cadenas
    {
        // <ActivityIndicator IsVisible = "{Binding IsBusy,Mode=TwoWay}"
        //             IsRunning="{Binding IsBusy,Mode=TwoWay}"
        //             VerticalOptions="CenterAndExpand"
        //RelativeLayout.XConstraint="{ConstraintExpression 
        //             Type=RelativeToParent,
        //             Property=Height,Factor=0.20}"
        //RelativeLayout.YConstraint="{ConstraintExpression 
        //             Type=RelativeToParent,Property=Height,
        //             Factor=0.40}"
        //             />
       public static string Url = "http://adamacontactos.azurewebsites.net/api";

       public static string FicheroSettings = "contact.dat";
       public static Dictionary<string, object> Session=
            new Dictionary<string,object>();

    }
}
