using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DbToJSON.Application.FeatureSet.Categories.Commands.CreateCategory
{
    internal class CreateCateogoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string? Name { get; set; }
    }
}
