using GourmetGame.Model;

namespace GourmetGame
{
    public class GameLogic
    {
        private readonly DishComponent _tree;
        private DishComponent _parent;
        private DishComponent _current;
        private bool _lastChoice;
        public bool Success { get; private set; }
        public string QuestionText { get { return $"O prato que você pensou é {_current.Name}?"; } }
        public string DishName { get { return _current.Name; } }

        public GameLogic(string categoryName, string correctDishName, string wrongDishName)
        {
            _current = new DishComponent(categoryName);
            _current.Correct = new DishComponent(correctDishName);
            _current.Wrong = new DishComponent(wrongDishName);

            _tree = _current;
        }
        
        public bool Choose(bool answer)
        {
            if (_current.IsLastOption())
            {
                if (answer)
                {
                    ResetGame();
                    Success = true;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                _parent = _current;
                _current = _current.FindDish(answer);
                _lastChoice = answer;
            }

            return true;
        }

        public void InsertDish(string categoryName, string dishName)
        {
            _parent.CreateDish(_current, categoryName, dishName, _lastChoice);
            ResetGame();
        }

        private void ResetGame()
        {
            _current = _tree;
        }

        public void Restart()
        {
            Success = false;
        }
    }
}
