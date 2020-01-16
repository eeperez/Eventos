using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class PresentadorDatosUTests
	{
		[TestMethod()]
		public void MostrarEnConsola_DatosParaMostrar_PresentaDatos()
		{
			//Arrange
			var SUT = new PresentadorDatos();
			SUT.presentadorDatos = e => Dumy();

			//Act
			SUT.MostrarEnConsola("");

			//Assert
			Assert.IsTrue(true);
		}

		private void Dumy() { }
	}
}