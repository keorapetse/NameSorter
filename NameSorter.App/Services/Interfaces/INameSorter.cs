using NameSorter.App.Models;

namespace NameSorter.App.Services.Interfaces
{
    public interface INameSorter
    {
        List<PersonName> SortNames(List<PersonName> names);
    }
}
