using System;

namespace Parkinglot.AppWebMVC.RabbitMq
{
    public class RabbitMqSettings : IRabbitMqSettings
    {
        public string Uri { get; set; }
        public string QueueName { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }


        //public Uri Uri => new Uri($"amqp://{UserName}:{Password}@{Hostname}:{Port}");

    }

    public interface IRabbitMqSettings
    {
        string Uri { get; set; }
        string QueueName { get; set; }
        string Exchange { get; set; }
        string RoutingKey { get; set; }


        //public Uri Uri => new Uri($"amqp://{UserName}:{Password}@{Hostname}:{Port}");

    }
}
