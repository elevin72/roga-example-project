
public class Row {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Gender { get; set; }

    public Row(string firstname, string lastname, int age, int weight, string gender) {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Age = age;
        this.Weight = weight;
        this.Gender = gender;
    }
}
