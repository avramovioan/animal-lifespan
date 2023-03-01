using AnimalLifespan.Enums;

namespace AnimalLifespan.Models
{
    public interface IAnimal
    {
        bool IsAlive { get; }
        void Feed(FoodType foodType);
    }
}