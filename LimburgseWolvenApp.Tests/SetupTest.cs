using LimburgseWolvenApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimburgseWolvenApp.Tests
{
    [TestClass]
    public class SetupTest
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        [TestInitialize]
        public void TestInitializer()
        {
            context.Personen.Delete();
            context.Reservaties.Delete();
            context.Groepen.Delete();
            context.Bewoners.Delete();
            context.Gestorvenen.Delete();
            context.UserDorpen.Delete();
            context.Zwervers.Delete();

        }

        [TestMethod]
        public void AlsEr0InschrijvingenZijnErGeenBewoners()
        {
            // Arrange
            

            // Act
            

            // Assert
            
        }
    }
}
