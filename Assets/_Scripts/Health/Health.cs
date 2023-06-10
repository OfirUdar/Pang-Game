using System;

namespace Game
{
    public class Health : IDamageable
    {
        private readonly int _initalizeHp;
        private int _currentHp;

        private readonly IDiedCommand _diedCommand;


        public Health(int initalizeHealthData, IDiedCommand diedCommand)
        {
            _initalizeHp = initalizeHealthData;
            _currentHp = _initalizeHp;

            _diedCommand = diedCommand;
        }

        public void TakeDamage(int amount)
        {
            _currentHp = Math.Max(0, _currentHp - amount);

            if (_currentHp == 0)
                _diedCommand.Execute();
        }

        public void TakeFullDamage()
        {
            _currentHp = 0;
            _diedCommand.Execute();
        }
    }

}
