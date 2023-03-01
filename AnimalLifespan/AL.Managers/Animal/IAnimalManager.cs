using AnimalLifespan.Enums;
using AnimalLifespan.Models;

namespace AnimalLifespan.Managers
{
    public interface IAnimalManager
    {
        IDictionary<AnimalType, ICollection<IAnimal>> GetAnimalGroups();
        void PopulateTheJungle(int animalCountPerType);
    }
}