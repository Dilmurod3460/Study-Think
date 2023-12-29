using System.Net;

namespace StudyThink.Domain.Exceptions.CategoryExceptions
{
    public class CategoryNotFound : NotFoundException
    {
        public CategoryNotFound()
        {
            TitleMessage = "Category not found" ;
        }
    }
}
