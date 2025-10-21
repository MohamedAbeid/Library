namespace Library.Models
{
    public class AuthorsBL
    {
        StoryShelf context = new StoryShelf();

        public List<Authors> GetAllAuthors()
        {
            return context.Authors.ToList();
        }

        public Authors GetAuthorsById(int id)
        {
            return context.Authors.FirstOrDefault(c => c.Id == id);
        }

        public void AddAuthors(Authors authors)
        {
            context.Authors.Add(authors);
            context.SaveChanges();
        }

        public void UpdateAuthors(Authors authors)
        {
            context.Authors.Update(authors);
            context.SaveChanges();
        }

        public void DeleteAuthors(int id)
        {
            var authors = context.Authors.FirstOrDefault(c => c.Id == id);
            if (authors != null)
            {
                context.Authors.Remove(authors);
                context.SaveChanges();
            }
        }
    }
}
