using Newtonsoft.Json;

namespace Scms.ToolHelp
{
    public static class JsonHelp
    {

        public static string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T GetFromJson<T>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr?.Trim()))
                return default(T);

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
