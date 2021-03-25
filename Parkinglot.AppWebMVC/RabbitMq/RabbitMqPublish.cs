using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Parkinglot.AppWebMVC.RabbitMq
{
    public interface IRabbitMqPublish
    {
        bool Publish<T>(T message);

    }

    public class RabbitMqPublish : IRabbitMqPublish
    {

        private readonly IRabbitMqSettings rabbitMqSettings;

        public RabbitMqPublish(IRabbitMqSettings rabbitMqSettings)
        {
            this.rabbitMqSettings = rabbitMqSettings;
            this.rabbitMqSettings.QueueName+= "_"+Guid.NewGuid();
        }

        public bool Publish<T>(T message)
        {
            try
            {
                string json = JsonSerializer.Serialize(message).Replace(" ", "");

                var factory = new ConnectionFactory
                {
                    Uri = rabbitMqSettings.Uri//new Uri("amqp://guest:guest@localhost:5672")
                };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                var queueName = rabbitMqSettings.QueueName;
                //Parkinglot.AppWebMVC_s2d1f3-ss23d-sd212s132d3f1s-1sd3-321sdf
                //Declaramos la cola a la que nos conectaremos para enviar la información al RoutingKey amq.topic
                channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: true, arguments: null);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "amq.topic", routingKey: "DataFromAspNetCore", basicProperties: null, body: body);

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        void metodo<T>()
        {
            //[TipoDato]    [NombreDevariable]
            int numero;//1354302180
            string palabra;//jh fqsd f32106 g5e40h 5r14ht0 654tyik5780op54eq6w54r2354465648765'78017
            bool pregunta;//true, false

            T mivariable;

            this.metodo<int>();

            this.metodo<string>();

            this.metodo<bool>();

            this.metodo<RabbitMqSettings>();


        }

        // public static void Publish(IModel channel, string message)
        // {
        //     var queueName = rabbitMqConfigs.QueueName;
        //     //Declaramos la cola a la que nos conectaremos para enviar la información al RoutingKey amq.topic
        //     //channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: true, arguments: null);

        //     var body = Encoding.UTF8.GetBytes(message);//Convertimos el mensaje en arreglo de bytes, solo así se puede enviar a RabbitMq
        //     channel.BasicPublish(exchange: "amq.topic", routingKey: "DataFromAspNetCore", basicProperties: null, body: body);//Publicamos en RabbirMq al exchange amq.topic, con el tema (routingKey) DataFromArduino

        //     //Thread.Sleep(500);

        // }
    }


}
