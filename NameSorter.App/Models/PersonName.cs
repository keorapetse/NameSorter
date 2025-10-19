namespace NameSorter.App.Models
{
    public class PersonName
    {
        public string LastName { get; set; }
        public List<string> GivenNames { get; set; }

        public override string ToString()
        {
            return string.Join(" ",GivenNames.Append(LastName));
        }
    }
}
