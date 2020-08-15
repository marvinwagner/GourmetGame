using GourmetGame;
using Xunit;

namespace Gourmetkinator.Tests
{
    public class GameLogicTest
    {
        [Fact]
        public void InitialGame_ChooseYes()
        {
            var game = new GameLogic("doce", "bolo", "arroz");
            Assert.Equal("doce", game.DishName);

            Assert.True(game.Choose(true));
            Assert.Equal("bolo", game.DishName);
        }

        [Fact]
        public void InitialGame_ChooseNo()
        {
            var game = new GameLogic("doce", "bolo", "arroz");
            Assert.Equal("doce", game.DishName);

            Assert.True(game.Choose(false));
            Assert.Equal("arroz", game.DishName);
        }


        [Fact]
        public void InsertDish()
        {
            var game = new GameLogic("doce", "bolo", "arroz");
            game.Choose(true);
            game.InsertDish("pequeno", "cookie");
            Assert.Equal("doce", game.DishName);

            game.Choose(true);
            Assert.Equal("pequeno", game.DishName);
            game.Choose(true);
            Assert.Equal("cookie", game.DishName);
            Assert.False(game.Success);
            game.Choose(true);
            Assert.True(game.Success);
        }
    }
}
