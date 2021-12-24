using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new GreeterClientTest.GreeterClientTestClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "测试我的grpc~" });
            Console.WriteLine("Greeting回复: " + reply.Message);
            Console.ReadKey();
        }
    }
}
