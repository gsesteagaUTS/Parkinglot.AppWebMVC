using System;

namespace Parkinglot.AppWebMVC.RabbitMq
{
    public class RabbitMqSettings : IRabbitMqSettings
    {
        public string UriString { get; set; }
        public string QueueName { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }

        public Uri Uri => new Uri(this.UriString);

        //public Uri Uri => new Uri($"amqp://{UserName}:{Password}@{Hostname}:{Port}");

    }

    public interface IRabbitMqSettings
    {
        string UriString { get; set; }
        string QueueName { get; set; }
        string Exchange { get; set; }
        string RoutingKey { get; set; }

        Uri Uri { get; }
        //public Uri Uri => new Uri($"amqp://{UserName}:{Password}@{Hostname}:{Port}");

    }
}
