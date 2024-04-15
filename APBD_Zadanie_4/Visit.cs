namespace APBD_Zadanie_4;

public class Visit
{
    public int visit_ID { get; set; }
    public DateTime Date { get; set; }
    
    // public int Animal_ID { get; set; } 
    public Animal Animal { get; set; }

    public string Description { get; set; }
    public decimal Price { get; set; }
}