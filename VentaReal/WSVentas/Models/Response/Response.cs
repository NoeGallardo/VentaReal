namespace WSVentas.Models.Response
{
    public class Response
    {
        public Response() 
        {
            this.success = 0;               
        }
        public int success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}