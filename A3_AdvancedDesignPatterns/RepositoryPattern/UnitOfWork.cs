namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Student> Students { get; }

        public IRepository<Course> Courses { get; }

        public UnitOfWork(IRepository<Student> studentRepository, IRepository<Course> courseRepository)
        {
            Students = studentRepository;
            Courses = courseRepository;
        }

        public void Save()
        {
            Console.WriteLine("\nUnitOfWork: Changes saved successfully.");
        }
    }
}
