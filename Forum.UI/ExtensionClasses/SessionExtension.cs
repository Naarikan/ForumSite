using Newtonsoft.Json;

namespace Forum.UI.ExtensionClasses
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            var value = session.GetString(key);
            if (value == null)
                throw new Exception("Lütfen Giriş Yapınız");
            return value == null ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
