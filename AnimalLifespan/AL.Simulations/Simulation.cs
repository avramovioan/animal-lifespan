using AnimalLifespan.Enums;
using AnimalLifespan.Models;
using AnimalLifespan.Managers;

namespace AnimalLifespan.Somulations
{

    public class Simulation : ISimulation
    {
        private readonly IFoodManager _foodManager;
        public Simulation(IFoodManager foodManager)
        {
            _foodManager = foodManager;
        }
        public ICollection<Statistic> StartSimulation(IDictionary<AnimalType, ICollection<IAnimal>> animalGroups)
        {
            if (animalGroups == null || animalGroups.Count == 0)
            {
                return new List<Statistic>();
            }

            ICollection<Task<Statistic>> animalGroupSimulationTasks = new List<Task<Statistic>>();
            foreach (KeyValuePair<AnimalType, ICollection<IAnimal>> animalGroup in animalGroups)
            {
                animalGroupSimulationTasks.Add(AnimalGroupWorker(animalGroup));
            }
            return Task.WhenAll(animalGroupSimulationTasks).Result.ToList();
        }

        private async Task<Statistic> AnimalGroupWorker(KeyValuePair<AnimalType, ICollection<IAnimal>> animalGroup)
        {
            List<Task<int>> feedingSimulationTasks = new List<Task<int>>();
            foreach (Animal animal in animalGroup.Value)
            {
                feedingSimulationTasks.Add(Task.Run(() => AnimalFeedWorker(animal)));
            }
            int[] lifespanCounter = await Task.WhenAll(feedingSimulationTasks);
            return new Statistic
            {
                AnimalCount = animalGroup.Value.Count(),
                AnimalType = animalGroup.Key,
                AverageLifespan = lifespanCounter.Average(),
                MaximumLifespan = lifespanCounter.Max(),
                MinimumLifespan = lifespanCounter.Min()
            };
        }

        private int AnimalFeedWorker(IAnimal animal)
        {
            int lifespan = 0;
            while (animal.IsAlive)
            {
                animal.Feed(_foodManager.GetRandomFood());
                lifespan++;
            }
            return lifespan;
        }

    }
}