namespace StudyThink.Domain.Exceptions.Category;

public class CategoryAlreadyExistsException : NotFoundException
{
    public CategoryAlreadyExistsException()
    {
        TitleMessage = "Category already exists!";
    }
}
