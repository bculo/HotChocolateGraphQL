using HotChocolate;
using HotChocolate.Types;
using HotChocolateGraphQL.Data;
using HotChocolateGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represnets any executable command");

            descriptor.Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .Description("This is the platform to which the command belongs");
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command, AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
