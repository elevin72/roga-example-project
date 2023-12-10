using CsvHelper;
using System.Globalization;

public class Generate {
    static Random rand = new Random();

    public static void Main() {

        using (var reader1 = new StreamReader("raw-data/firstname-gender.csv"))
        using (var csv1 = new CsvReader(reader1, CultureInfo.InvariantCulture))
        using (var reader2 = new StreamReader("raw-data/lastname.csv"))
        using (var csv2 = new CsvReader(reader2, CultureInfo.InvariantCulture))
        using (var writer = new StreamWriter("dataset.csv"))
        using (var csvOutput = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var firstnameGenderRecords = csv1.GetRecords<NameGender>().ToList();
            var lastnameRecords = csv2.GetRecords<LastName>().ToList();

            csvOutput.WriteHeader<Row>();
            csvOutput.NextRecord();
            foreach (var r in firstnameGenderRecords) {
                string lastname = lastnameRecords[rand.Next(lastnameRecords.Count)].Lastname;
                var weight = rand.Next(150) + 100; // gets weights between 100 and 250 (lbs)
                var age = rand.Next(52) + 18; // gets ages between 18 and 70 
                csvOutput.WriteRecord(new Row(r.Name,lastname,age,weight,r.Gender));
                csvOutput.NextRecord();
            }
        }
    }
}

