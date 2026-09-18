namespace A3_AdvancedDesignPatterns.RepositoryPattern
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }

        IRepository<Course> Courses { get; }

        void Save();
    }
}
