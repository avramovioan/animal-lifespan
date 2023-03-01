using AnimalLifespan.Enums;

namespace AnimalLifespan.Models
{
    public class Animal : IAnimal
    {
        private int _maximumEnergy;
        private int _currentEnergy;
        private ICollection<FoodType> _diet;
        public bool IsAlive { get; private set; }

        public Animal(int maximumEnergy, ICollection<FoodType> diet)
        {
            _maximumEnergy = maximumEnergy;
            _diet = diet;
            _currentEnergy = _maximumEnergy;
            IsAlive = true;
        }

        public void Feed(FoodType foodType)
        {
            if (!IsAlive)
            {
                return;
            }
            if (_diet.Contains(foodType))
            {
                IncreaseEnergy();
            }
            DecreaseEnergy();
        }

        private void IncreaseEnergy()
        {
            if (_currentEnergy < _maximumEnergy)
            {
                _currentEnergy++;
            }
        }

        private void DecreaseEnergy()
        {
            _currentEnergy = _currentEnergy - 1;
            if (_currentEnergy == 0)
            {
                IsAlive = false;
            }
        }
    }
}