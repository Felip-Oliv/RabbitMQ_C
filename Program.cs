// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

Console.WriteLine("Testes!");

ConnectionFactory factory = new ConnectionFactory()
{
    HostName="localhost"

};


using(IConnection connection = factory.CreateConnection())
{
    using(IModel channel = connection.CreateModel())
    {
        channel.QueueDeclare(
            queue: "mensagens", 
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null

        );

        dynamic objeto = new 
        {
            Nome = "Pato",
            Sobrenome = "Donald"
        };
       
        while(true){
            Thread.Sleep(100);
    //      string texto = DateTime.Now.ToString();
            string texto = JsonConvert.SerializeObject(objeto);
            byte[] mensagem = Encoding.UTF8.GetBytes(texto);
            channel.BasicPublish(
            body: mensagem,
            routingKey: "mensagens",
            basicProperties: null,
            exchange: ""

        );
        Console.WriteLine("Mensagem enviada com sucessos");
        }

    }
}

Console.ReadKey();