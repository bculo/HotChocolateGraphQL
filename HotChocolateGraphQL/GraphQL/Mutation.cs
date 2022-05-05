using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolateGraphQL.Data;
using HotChocolateGraphQL.GraphQL.Commands;
using HotChocolateGraphQL.GraphQL.Platforms;
using HotChocolateGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateGraphQL.GraphQL
{
    public class Mutation
    {
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, 
            AppDbContext context, 
            [Service] ITopicEventSender eventSender, 
            CancellationToken token)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync(token);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, token);

            return new AddPlatformPayload(platform);
        }

        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, AppDbContext context)
        {
            var command = new Command
            {
                CommandLine = input.CommandLine,
                HowTo = input.HowTo,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}
