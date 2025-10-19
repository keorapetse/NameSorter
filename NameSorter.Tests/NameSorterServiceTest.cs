using NameSorter.App.Models;
using NameSorter.App.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NameSorter.Tests
{
    public class NameSorterServiceTest
    {
        [Fact]
        public void SortByLastNameThenGivenName()
        {
            var names = new List<PersonName>
            {
                new PersonName {GivenNames = new List<string> { "Adonis", "Julius" }, LastName = "Archer" },
                new PersonName {GivenNames = new List<string> { "Marin" }, LastName = "Alvarez" },
                new PersonName {GivenNames = new List<string> { "Janet" }, LastName = "Parsons" },
                new PersonName {GivenNames = new List<string> { "Vaughn" }, LastName = "Lewis" }
            };

            var sorter = new NameSorterService();

            // Act
            var sorted = sorter.SortNames(names);

            // Assert 
            Assert.Equal("Alvarez", sorted[0].LastName);
            Assert.Equal("Archer", sorted[1].LastName);
            Assert.Equal("Lewis", sorted[2].LastName);
            Assert.Equal("Parsons", sorted[3].LastName);
        }
    }
}
