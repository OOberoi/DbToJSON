using DbToJSON.Application.Responses;
using DbToJSON.Application;

namespace DbToJSON.Application.FeatureSet.Categories.Commands.CreateCategory
{
  

    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryDto? CategoryDto { get; set; }

        public CreateCategoryCommandResponse() : base() 
        {

        }
    }
}