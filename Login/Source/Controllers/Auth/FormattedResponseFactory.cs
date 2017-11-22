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
                    result.AddProperty(key, response[key]);
                }
                else
                {
                    result.Success = Boolean.Parse(response[key]);
                }
            }
            return result;
        }
    }
}