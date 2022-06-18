using Greeter.Rpc;

using Grpc.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(x => {
        x.UseKestrel((ctx, options) => {
            options.ListenAnyIP(5000, opts => {
                opts.Protocols = HttpProtocols.Http2;
            });
        });
        x.ConfigureServices((ctx, services) => {
            services.AddGrpc();
        });
        x.Configure((ctx, app) => {
            app.UseRouting();
            app.UseEndpoints(ep => {
                ep.MapGrpcService<GreeterService>();
            });
        });
    })
    .Build();

await builder.RunAsync();

class GreeterService : Greeter.Rpc.Greeter.GreeterBase {
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context) {
        return Task.FromResult(new HelloReply{ Message = $"Hello, {request.Name}"});
    }
}