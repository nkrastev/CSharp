namespace Uptime
{
    using Newtonsoft.Json.Linq;
    using RestSharp;
    public class UptimeRobot
    {
        public UptimeRobot()
        {

        }
        public string GetUptimeRatio(string apiKey)
        {
            string result;

            try
            {
                var client = new RestClient("https://api.uptimerobot.com/v2/getMonitors");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", $"api_key={apiKey}&format=json&all_time_uptime_ratio=1", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                dynamic data = JObject.Parse(response.Content);
                result = data.monitors[0].all_time_uptime_ratio;                
            }
            catch (System.Exception)
            {
                result = "External Api Error";
            }                                   
            return result;
        }
    }
}
