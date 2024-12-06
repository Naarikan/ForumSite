using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;

namespace Forum.MVCUI.ExtensionClasses
{
    public static class SessionExtension
    {
        //public static void SetObject<T>(this ISession session, string key, T value)
        //{
        //    session.SetString(key, JsonSerializer.Serialize(value));
        //}

        //public static void SetObject(this ISession session, string key, object value)
        //{
        //    string objectString = JsonConvert.SerializeObject(value);
        //    session.SetString(key, objectString);


        //}

        //public static T GetObject<T>(this ISession session, string key) where T : class
        //{
        //    string value = session.GetString(key);
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return null;
        //    }

        //    T deserializeobject = JsonConvert.DeserializeObject<T>(value);
        //    return deserializeobject;
        //}
    }
}
