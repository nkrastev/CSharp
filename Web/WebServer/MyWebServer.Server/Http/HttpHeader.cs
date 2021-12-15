namespace MyWebServer.Server.Http
{
    public class HttpHeader
    {
        //init equal to private set, once the value is set it cannot be changed
        public string Name { get; init; }

        public string Value { get; init; }
    }
}
