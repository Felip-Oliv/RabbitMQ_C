// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

string fila_A = ("fila A");

Console.WriteLine("Testes!");

ConnectionFactory factory = new ConnectionFactory()
{
    HostName="localhost"

};

using (IConnection connection = factory.CreateConnection()){
    IModel channel = SetupExchangeDirect(connection);
        SendMessage(channel);
}



void SendMessage(IModel channel){
    while (true){
        string texto = DateTime.Now.ToString("hh:mm:ss.ffff");
        byte[] mensagem = Encoding.UTF8.GetBytes(texto);

        

    }
}
IModel SetupExchangeDirect(IConnection connection){
    IModel channel = connection.CreateModel();

    channel.QueueDeclare(
            queue: "fila_A", 
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null

        );

    channel.QueueDeclare(
            queue: "fila_B", 
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null

        );

    channel.QueueDeclare(
            queue: "fila_c", 
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null

        );
    
    channel.QueueBind(
        queue: fila_A,
        exchange: exchange

    );

    return channel;

}

/*using(IConnection connection = factory.CreateConnection())
{
    using(IModel channel = connection.CreateModel())
    {
        

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
}*/