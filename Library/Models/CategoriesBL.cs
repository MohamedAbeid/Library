using Library.ViewModel;

namespace Library.Models
{
    public class CategoriesBL
    {
        StoryShelf context = new StoryShelf();

        public List<Categories> GetAllCategory()
        {
            return context.Categories.ToList();
        }

        public Categories GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategory(Categories category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Categories category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

    }
}
