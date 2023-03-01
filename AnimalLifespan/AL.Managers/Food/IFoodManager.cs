using AnimalLifespan.Enums;

namespace AnimalLifespan.Managers
{
    public interface IFoodManager
    {
        ICollection<FoodType> GenerateAnimalDiet();
        FoodType GetRandomFood();
    }
}