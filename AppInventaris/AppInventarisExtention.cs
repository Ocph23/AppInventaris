using System.Text.RegularExpressions;
using BlazorStrap;

public static class ToasterExtention{
    public static Task ShowMessage (this Toaster toaster, string title, string message, BSColor color){
        toaster.Add(title, message,o=>
        {
            o.Color = color;
            o.Toast = Toast.TopRight;
            o.CloseAfter=2000;
            o.HasIcon=true;
        }
        );
        return Task.CompletedTask;
    }
}



public static class EnumExtention
{
    public static string EnumToTitleCase(this object x)
    {
        return Regex.Replace(x.ToString(), @"(?<=[a-z])([A-Z])", @" $1");
    }
}
