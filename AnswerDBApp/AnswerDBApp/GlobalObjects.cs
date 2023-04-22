using AnswerDBApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Essentials.Permissions;

namespace AnswerDBApp
{
    public class GlobalObjects
    {
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";


        public static UserDTO LocalUser = new UserDTO();

    }
}
