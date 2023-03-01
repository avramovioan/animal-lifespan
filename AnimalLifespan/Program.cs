using AnimalLifespan.Models;
using AnimalLifespan.Somulations;
using AnimalLifespan.Managers;

IFoodManager foodManager = new FoodManager();

IAnimalManager animalManager = new AnimalManager(foodManager);
animalManager.PopulateTheJungle(5);

Simulation simulation = new Simulation(foodManager);
ICollection<Statistic> stats = simulation.StartSimulation(animalManager.GetAnimalGroups());

foreach (Statistic stat in stats)
{
    System.Console.WriteLine($"Animal species: {stat.AnimalType.ToString()}");
    System.Console.WriteLine($"Animal count: {stat.AnimalCount.ToString()}");
    System.Console.WriteLine($"Minimum lifespan: {stat.MinimumLifespan.ToString()}");
    System.Console.WriteLine($"Maximum lifespan: {stat.MaximumLifespan.ToString()}");
    System.Console.WriteLine($"Average lifespan: {stat.AverageLifespan.ToString()}");
    System.Console.WriteLine("==================================");
}