using HotChocolate;
using HotChocolate.Data;
using HotChocolateGraphQL.Data;
using HotChocolateGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGraphQL.GraphQL
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform(AppDbContext context)
        {
            return context.Platforms;
        }

        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand(AppDbContext context)
        {
            return context.Commands;
        }
    }
}
