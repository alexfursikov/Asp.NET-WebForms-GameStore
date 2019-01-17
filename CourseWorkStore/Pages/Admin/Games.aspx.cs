using CourseWorkStore.Models;
using CourseWorkStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;

namespace CourseWorkStore.Pages.Admin
{
    public partial class Games : Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Game> GetGames()
        {
            return repository.Games;
        }

        public void UpdateGame(int GameID)
        {
            Game myGame = repository.Games
                .Where(p => p.GameId == GameID).FirstOrDefault();
            if (myGame != null && TryUpdateModel(myGame,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myGame);
            }
        }

        public void DeleteGame(int GameID)
        {
            Game myGame = repository.Games
                .Where(p => p.GameId == GameID).FirstOrDefault();
            if (myGame != null)
            {
                repository.DeleteGame(myGame);
            }
        }

        public void InsertGame()
        {
            Game myGame = new Game();
            if (TryUpdateModel(myGame,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myGame);
            }
        }
    }
}