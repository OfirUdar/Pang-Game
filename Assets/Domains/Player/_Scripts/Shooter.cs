using Zenject;

namespace Game.Player
{
    public class Shooter : IInitializable, ILateDisposable
    {
        private readonly IUserInput _userInput;
        private IWeapon _weapon;

        public Shooter(IUserInput userInput, IWeapon weapon)
        {
            _userInput = userInput;
            _weapon = weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Initialize()
        {
            _userInput.ShotPressed += OnShotPressed;
        }
        public void LateDispose()
        {
            _userInput.ShotPressed -= OnShotPressed;
        }

        private void OnShotPressed()
        {
            _weapon.Fire();
        }

    }

}
