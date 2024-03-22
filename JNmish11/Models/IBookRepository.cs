namespace JNmish11.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
