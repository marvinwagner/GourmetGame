namespace GourmetGame.Model
{
    public class DishComponent
    {
        public DishComponent Correct { get; set; }
        public DishComponent Wrong { get; set; }
        public string Name { get; set; }

        public DishComponent(string name)
        {
            Name = name;
        }

        public void CreateDish(DishComponent current, string categoryName, string dishName, bool answer)
        {
            var newCategory = new DishComponent(categoryName);
            newCategory.Correct = new DishComponent(dishName);
            newCategory.Wrong = current;

            if (answer)
                Correct = newCategory;
            else
                Wrong = newCategory;
        }

        public DishComponent FindDish(bool answer)
        {
            if (IsLastOption()) return this;

            return answer ? Correct : Wrong;
        }   

        public bool IsLastOption()
        {
            return Correct == null || Wrong == null;
        }
    }
}
