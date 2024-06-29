using DevLibraryMads.Core.Entities;

namespace DevLibraryMads.UnitTests.Core
{
    public class ClientTests
    {
        [Fact]
        public void TestIfClientIsOk()
        {
            var client = new Client("Teste", "01/01/2005", "Teste");

            Assert.NotNull(client);

            client.Update("Teste 2", "02/01/2005", "Teste");
            Assert.NotNull(client);


        }
    }
   
}
