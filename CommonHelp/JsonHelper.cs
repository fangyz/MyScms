using Newtonsoft.Json;

namespace CommonHelp
{
    public static class JsonHelper
    {

        public static string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T GetFromJson<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
