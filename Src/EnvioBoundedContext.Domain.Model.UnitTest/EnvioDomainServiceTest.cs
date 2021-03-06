﻿namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    //public class EnvioDomainServiceTest
    //{
    //    private EnvioDomainService _sut;
    //    private Guid envioParameter;
    //    EnvioRepository _envioRepository;
    //    Envio response;
    //    public EnvioDomainServiceTest()
    //    {
    //        _envioRepository = Mock.Create<EnvioRepository>();
    //        _sut = new EnvioDomainService(_envioRepository);
    //    }

    //    [Fact]
    //    public void GivenExpectedEnvioThenReturnTheSame()
    //    {
    //        //Crear un envio
    //        Envio envio = new Envio(Guid.NewGuid());


    //        envio.AsignarDestinatario(new EnvioPersona("pepe", "apellido1", "apellido2"));

    //        this.Given(x => x.AssingNewId())
    //            .And(x => x.ExpectedEnvioIsFound(envio))
    //            .When(x => x.CallGetOneByEnvio())
    //            .Then(x => x.EnvioNotIsNull())
    //            .And(x => x.EnvioHasTheSameValues(envio))
    //            .BDDfy<PlatformTest>("escenario 3");
    //    }

    //    [Fact]
    //    public async Task GivenExpectedNullEnvioThenThrowApplicationException()
    //    {
    //        var envioId = System.Guid.NewGuid();

    //        //Crear instancia
    //        EnvioRepository envioRepository = Mock.Create<EnvioRepository>();
    //        _sut = new EnvioDomainService(envioRepository);

    //        //Simule que cuando llame al envioDomainService me devuelva el envio antes creado
    //        Mock.Arrange(() => envioRepository.GetEnvioBy(envioId)).Returns(Task.FromResult<Envio>(null));

    //        //LLamada y verificacion
    //        await Assert.ThrowsAsync<ApplicationException>(() => _sut.GetOneBy(envioId));

    //    }

    //    #region Given



    //    private void AssingNewId()
    //    {
    //        envioParameter = System.Guid.NewGuid();
    //    }

    //    private void ExpectedEnvioIsFound(Envio envio)
    //    {
    //        Mock.Arrange(() => _envioRepository.GetEnvioBy(envioParameter)).Returns(Task.FromResult(envio));
    //    }
    //    #endregion

    //    #region When
    //    private async Task CallGetOneByEnvio()
    //    {
    //        response = await _sut.GetOneBy(envioParameter);
    //    }
    //    #endregion

    //    #region Then
    //    private void EnvioNotIsNull()
    //    {
    //        response.ShouldNotBeNull();
    //    }

    //    private void EnvioHasTheSameValues(Envio envio)
    //    {
    //        // response.Destinatario.ShouldBeEqual(envio.Destinatario);
    //    }
    //    #endregion
    //}
}