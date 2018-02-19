using TestStack.BDDfy;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    [Story(AsA = "a user",IWant ="Search envio by id", SoThat ="'cause yo lo valgo")]
    public class PlatformTest
    {
        private Envio _sut;

        [Fact]
        public void TestCanRun()
        {
            this.Given(x => x.EnvioIsNull())
                .When(x => x.CreateEnvio())
                .Then(x => x.EnvioShouldNotBeNull())
                .BDDfy();
        }

        [Fact]
        public void TestCanRun2()
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

        private void EnvioIsNull()
        {
            _sut = null;
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
            
            //Assert.NotNull(_sut);
            
        }
        #endregion

    }
}