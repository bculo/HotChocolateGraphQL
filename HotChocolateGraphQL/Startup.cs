using GraphQL.Server.Ui.Voyager;
using HotChocolateGraphQL.Data;
using HotChocolateGraphQL.GraphQL;
using HotChocolateGraphQL.GraphQL.Commands;
using HotChocolateGraphQL.GraphQL.Platforms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotChocolateGraphQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddMutationType<Mutation>()
                .AddType<CommandType>()
                .RegisterDbContext<AppDbContext>()
                .AddFiltering()
                .AddSorting();

            /*
            services.AddPooledDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CommandConStr"));
            });
            */

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CommandConStr"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/graphql");
            });

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
            });
        }
    }
}
