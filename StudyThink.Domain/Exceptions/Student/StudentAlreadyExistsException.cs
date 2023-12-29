namespace StudyThink.Domain.Exceptions.Student
{
    public class StudentAlreadyExistsException : NotFoundException
    {
        public StudentAlreadyExistsException()
        {
            TitleMessage = "Student Already exists!";
        }
    }
}
