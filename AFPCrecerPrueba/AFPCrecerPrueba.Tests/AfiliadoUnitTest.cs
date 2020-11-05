using AFPCrecerPruebaAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AFPCrecerPruebaAPI.Tests
{
    [TestClass]
    public class AfiliadoUnitTest
    {
        private ApiServices _apiServices;

        public AfiliadoUnitTest()
        {
            this._apiServices = new ApiServices();

        }

        [TestMethod]
        public async void TestMethodGetAfiliado()
        {
            var message = "";
            var response = await this._apiServices.GetUser("http://192.168.1.8", "/api", "/Afiliados", "luis@gmail.com");
            if (!response.IsSuccess)
                message = "Se guardo exitosamente";
            else
                message = "Error al obtener el afiliado";

        }
    }
}
