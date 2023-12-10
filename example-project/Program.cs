using System.Globalization;
using CsvHelper;

public class Row 
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Gender { get; set; }

    public Row(string Firstname, string Lastname, int Age, int Weight, string Gender) 
    {
        this.Firstname = Firstname;
        this.Lastname = Lastname;
        this.Age = Age;
        this.Weight = Weight;
        this.Gender = Gender;
    }
}


public class Example {
    public static int Main(string[] argv) {
        var csvPath = "dataset.csv";
        if (argv.Length == 1 ) {
            csvPath = argv[0];
        }

        try {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // convert to list (in memory) since CsvHelper has lazy property and running multiple queries would require reading the same file multiple times
                var records = csv.GetRecords<Row>().ToList(); 

                var averageTotalAge = records
                    .Select(row => row.Age)
                    .Average();

                var filterByWeight = records.Where(row => row.Weight >= 120 && row.Weight <= 140);

                var countCentralWeights = filterByWeight.Count();

                var averageAgeOfCentralWeights = filterByWeight
                    .Select(row => row.Age)
                    .Average();

                Console.WriteLine($"Overall average age: {averageTotalAge}");
                Console.WriteLine($"How many with weight between 120 and 140 lbs: {countCentralWeights}");
                Console.WriteLine($"Average age of those with weight between 120 and 140 lbs: {averageAgeOfCentralWeights}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fatal exception has occured");
            Console.WriteLine("Please ensure that the csv file exists and has headers of the following format:");
            Console.WriteLine("\nFirstname,Lastname,Age,Weight,Gender");
            Console.WriteLine("\nPlease note that Age and Weight are integers and the rest of the attributes are strings");

            Console.Write(ex.ToString());
            return 1;
        }
        return 0;
    }
}
