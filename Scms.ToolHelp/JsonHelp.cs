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
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
