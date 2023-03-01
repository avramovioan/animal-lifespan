using AnimalLifespan.Models;
using AnimalLifespan.Enums;

namespace AnimalLifespan.Somulations
{
    public interface ISimulation
    {
        ICollection<Statistic> StartSimulation(IDictionary<AnimalType, ICollection<IAnimal>> animalGroups);
    }

}