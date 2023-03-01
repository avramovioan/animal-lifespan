using AnimalLifespan.Enums;

namespace AnimalLifespan.Managers
{
    public class FoodManager : IFoodManager
    {
        private readonly int _foodTypesCount = Enum.GetNames(typeof(FoodType)).Length; //the count of food types
        public FoodType GetRandomFood()
        {
            return (FoodType)Random.Shared.Next(_foodTypesCount);
        }

        public ICollection<FoodType> GenerateAnimalDiet()
        {
            //an animal type can eat at least one and no more than half of the food types
            int edibleFoodsCount = Random.Shared.Next(1, (_foodTypesCount / 2) + 1);
            ICollection<FoodType> edibleFoods = new List<FoodType>();

            FoodType edibleFood;
            for (int i = 0; i < edibleFoodsCount; i++)
            {
                do
                {
                    edibleFood = GetRandomFood();

                } while (edibleFoods.Contains(edibleFood)); //making sure we won't have duplicate food types
                edibleFoods.Add(edibleFood);
            }
            return edibleFoods;
        }
    }
}