namespace APBD_Zadanie_4
{
    public class AnimalsDataStore
    {

        public List<Animal> Animals { get; set; }

        public static AnimalsDataStore Current { get; } = new AnimalsDataStore();
        
        public AnimalsDataStore()
        {
            Animals = new List<Animal>()
            {
                 new Animal
                 {
                   Id=1 ,
                   Name ="Fifek",
                   Category="Dog",
                   Color="White",
                   Weight=12,
                 },
                 new Animal
                 {
                     Id=2 ,
                     Name ="Miauczek",
                     Category="Cat",
                     Color="Orange",
                     Weight=7,

                 },
                 new Animal
                 {
                     Id=3 ,
                     Name ="Owca",
                     Category="Sheep",
                     Color="Black",
                     Weight=9,

                 },
            };
        }
        
        public IEnumerable<Animal> GetAnimals()
        {
            return Animals;
        }
        
        public Animal GetAnimalById(int id)
        {
            return Animals.FirstOrDefault(a => a.Id == id);
        }

        public void AddAnimal(Animal animal)
        {
            animal.Id = Animals.Count + 1;
            Animals.Add(animal);
        }

        public bool UpdateAnimal(int id, Animal updatedAnimal)
        {
            var animal = Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return false;
            }
            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Color = updatedAnimal.Color;
            animal.Weight = updatedAnimal.Weight;

            return true;
        }

        public bool DeleteAnimal(int id)
        {
            var animal = Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return false;

            Animals.Remove(animal);
            return true;
        }


        
    }
}
