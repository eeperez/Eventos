using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class PresentadorDatosUTests
	{
		[TestMethod()]
		public void MostrarDatos_DatosParaMostrar_EjecutoElMetodo()
		{
			//Arrange
			string cMensaje = "AntesMetodo";
			string cEsperado = "entró";
			var SUT = new PresentadorDatos();
			SUT.presentadorDatos = e => Dumy(ref cMensaje);

			//Act
			SUT.MostrarDatos("");

			//Assert
			Assert.AreEqual(cEsperado, cMensaje);
		}

		private void Dumy(ref string _cMensaje) 
		{
			_cMensaje = "entró";
		}
	}
}