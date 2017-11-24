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
                        result.AddProperty(key, response[key].ToString().ToLower(), false);
                    }

                }
                else
                {
                    result.Success = Boolean.Parse(response[key].ToString());
                }
            }
            return result;
        }

        public static FormattedResponse FromDynamicJObject(JObject response)
        {
            try
            {
                FormattedResponse result = new FormattedResponse();
                foreach (var property in response)
                {
                    string key = property.Key;
                    JToken token = property.Value;
                    JTokenType type = token.Type;


                    if (key != "success")
                    {
                        if (type == JTokenType.Array)
                        {
                            result.AddProperty(key, token, true);
                        }
                        else
                        {
                            result.AddProperty(key, token.ToString(), false);
                        }
                    }
                    else
                    {
                        result.Success = Boolean.Parse(token.ToString());
                    }
                }


                return result;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }

        }
    }
}