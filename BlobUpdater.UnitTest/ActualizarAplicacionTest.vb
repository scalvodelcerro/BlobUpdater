Imports System.Text
Imports BlobUpdater.Model
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ActualizarAplicacionTest

  <TestMethod()> Public Sub GivenNoHayActualizacionWhenActualizarThenMostrarMensaje()
    'Given
    Dim repo As ActualizacionRepositoryNoActualizacionMock = New ActualizacionRepositoryNoActualizacionMock()
    Dim log As LoggingServiceMock = New LoggingServiceMock()
    Dim tested As ActualizacionManager =
      New ActualizacionManager(repo, log)
    'When
    tested.ActualizarAplicacion("whatever", "whatever")

    'Then
    Assert.AreEqual(1, log.Messages.Count)
    Assert.AreEqual("No hay actualizaciones", log.Messages.First())
  End Sub

End Class