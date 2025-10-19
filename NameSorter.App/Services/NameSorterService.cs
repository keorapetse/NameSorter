using NameSorter.App.Models;
using NameSorter.App.Services.Interfaces;

namespace NameSorter.App.Services
{
    public class NameSorterService : INameSorter
    {
        public List<PersonName> SortNames(List<PersonName> names)
        {
            return names.OrderBy(n => n.LastName).ThenBy(n => string.Join(" ", n.GivenNames)).ToList();
        }
    }
}
