namespace Game.Player
{
    public class PlayerDiedCommand : IDiedCommand
    {
        private readonly ILevelsManager _levelsManager;

        public PlayerDiedCommand (ILevelsManager levelsManager)
        {
            _levelsManager = levelsManager;
        }
        public void Execute()
        {
            _levelsManager.RestartCurrent();
        }
    }
}
