using Grpc.Net.Client;

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

using (var channel = GrpcChannel.ForAddress("http://127.0.0.1:5002/")) {
    await channel.ConnectAsync();
    var client = new Greeter.Rpc.Greeter.GreeterClient(channel);
    
    for (var i = 0; i < 100; i++){
        var reply = await client.SayHelloAsync(new Greeter.Rpc.HelloRequest { Name = "GreeterClient" });
        Console.WriteLine($"Greeting: {reply.Message}!");
    }

}