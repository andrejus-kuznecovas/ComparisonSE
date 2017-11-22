using Newtonsoft.Json.Linq;
using System;
using System.Json;

namespace Login.Source.Controllers.Auth
{
    public class FormattedResponseFactory
    {
        public static FormattedResponse FromJsonObject(JsonObject response)
        {
            FormattedResponse result = new FormattedResponse();
            foreach (string key in response.Keys)
            {
                if (key != "success")
                {
                    if (response[key].Count > 1)
                    {
                        result.AddProperty(key, response[key], true);
                    }
                    else
                    {
                        result.AddProperty(key, response[key].ToString(), false);
                    }
                    
                }
                else
                {
                    result.Success = Boolean.Parse(response[key].ToString());
                }
            }
            return result;
        }

        public static FormattedResponse FromJsonObject(JObject response)
        {
            FormattedResponse result = new FormattedResponse();
            foreach (var property in response)
            {
                string key = property.Key;
                JToken value = property.Value;
                JTokenType type = value.Type;

                if (key != "success")
                {
                    if (type == JTokenType.Array)
                    {
                        result.AddProperty(key, value, true);
                    }
                    else
                    {
                        result.AddProperty(key, value.ToString(), false);
                    }
                }
                else
                {
                    result.Success = Boolean.Parse(value.ToString());
                }
            }


            return result;
        }
    }
}