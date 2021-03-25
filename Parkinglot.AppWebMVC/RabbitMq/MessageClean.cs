namespace Parkinglot.AppWebMVC.RabbitMq
{
    public class MessageClean
    {
        public string Message { get; set; }
        public MessageClean()
        {
            
        }

        public MessageClean(string message)
        {
            Message = message;
        }
    }
}