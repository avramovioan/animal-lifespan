using System.Globalization;
using AnimalLifespan.Enums;
using AnimalLifespan.Models;

namespace AnimalLifespan.Managers
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IDictionary<AnimalType, ICollection<IAnimal>> _animalGroups;
        private readonly int _animalTypesCount; //the count of animal types
        private readonly IFoodManager _foodManager;
        public AnimalManager(IFoodManager foodManager)
        {
            _animalGroups = new Dictionary<AnimalType, ICollection<IAnimal>>();
            _animalTypesCount = Enum.GetNames(typeof(AnimalType)).Length;
            _foodManager = foodManager;
        }

        public IDictionary<AnimalType, ICollection<IAnimal>> GetAnimalGroups()
        {
            return _animalGroups;
        }

        public void PopulateTheJungle(int animalCountPerType)
        {
            _animalGroups.Clear(); //reset the dictionary and re-populate
            for (int i = 0; i < _animalTypesCount; i++)
            {
                AnimalType animalType = (AnimalType)i;
                _animalGroups.Add(
                    animalType,
                    GenerateAnimals(animalCountPerType)
                );
            }
        }

        private ICollection<IAnimal> GenerateAnimals(int animalCountPerType)
        {
            ICollection<IAnimal> animals = new List<IAnimal>();
            for (int i = 0; i < animalCountPerType; i++)
            {
                animals.Add(
                    new Animal(
                        Random.Shared.Next(1, 11), //at least one and no more than 10 energy 
                        _foodManager.GenerateAnimalDiet() //assuming that each animal of a type has a different taste
                    )
                );
            }
            return animals;
        }



    }
}