using System.Threading.Tasks;
using Telerik.JustMock;
using TestStack.BDDfy;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    public class PlatformTest
    {
        private Envio _sut;

        [Fact]
        public void TestCanRun()
        {
            this.Given(x => x.None())
                .When(x => x.CreateEnvio())
                .Then(x => x.EnvioShouldNotBeNull())
                .BDDfy();
        }

        #region Given

        private void None()
        {

        }

        #endregion

        #region When
        private void CreateEnvio()
        {
            _sut = new Envio();
        }
        #endregion

        #region Then
        private void EnvioShouldNotBeNull()
        {
            _sut.ShouldNotBeNull();
        }
        #endregion

    }
}