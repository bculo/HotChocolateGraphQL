using HotChocolate;
using HotChocolate.Types;
using HotChocolateGraphQL.Data;
using HotChocolateGraphQL.Models;
using System.Linq;

namespace HotChocolateGraphQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor.Ignore(p => p.LicenseKey);

            
            descriptor.Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .Description("This is the list of available commands for this platform");         
        }
         

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}
