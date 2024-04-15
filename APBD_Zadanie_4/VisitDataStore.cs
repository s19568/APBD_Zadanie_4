
namespace APBD_Zadanie_4
{
    public class VisitDataStore
    {
        private static VisitDataStore _current;

        public static VisitDataStore Current { get; } = new VisitDataStore();
            

        private List<Visit> _visits;

        private VisitDataStore()
        {
            _visits = new List<Visit>()
            {
                new Visit
                {
                    visit_ID = 1,
                    Date = DateTime.Now.AddDays(5),
                    Animal = AnimalsDataStore.Current.GetAnimalById(3), // Get animal by ID
                    Description = "Odrobaczanie",
                    Price = 80
                },
                new Visit
                {
                    visit_ID = 2,
                    Date = DateTime.Now.AddDays(3),
                    Animal = AnimalsDataStore.Current.GetAnimalById(2), // Get animal by ID
                    Description = "Szczepienie",
                    Price = 80
                },
                new Visit
                {
                    visit_ID = 3,
                    Date = DateTime.Now.AddDays(7),
                    Animal = AnimalsDataStore.Current.GetAnimalById(3), // Get animal by ID
                    Description = "Nocna Wizyta",
                    Price = 450
                }
            };
        }

        public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
        {
            return _visits.Where(v => v.Animal.Id == animalId);
        }

        public void AddVisit(Visit visit)
        {
            visit.visit_ID = _visits.Count + 1;
            _visits.Add(visit);
        }
        
        //Testing purposes
        public IEnumerable<Visit> GetAllVisits()
        {
            return _visits;
        }
    }

}