using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class VerificadorEventoUTests
	{
		[TestMethod()]
		public void ObtenerNombreDiferenciaFechas_FechaAnterior_ObtieneEtiquetaPasado()
		{
			//Arrange
			string cEtiquetaEsperada = "ocurrió hace";
			DateTime dtActual = new DateTime(2020, 01, 10);
			DateTime dtEvaluar = new DateTime(2020, 01, 05);
			var SUT = new VerificadorEvento();

			//Act
			string cEtiquetaObtenida = SUT.ObtenerNombreDiferenciaFechas(dtActual, dtEvaluar);

			//Assert
			Assert.AreEqual(cEtiquetaEsperada, cEtiquetaObtenida);
		}

		[TestMethod()]
		public void ObtenerNombreDiferenciaFechas_FechaPosterior_ObtieneEtiquetaFuturo()
		{
			//Arrange
			string cEtiquetaEsperada = "ocurrirá dentro de";
			DateTime dtActual = new DateTime(2020, 01, 10);
			DateTime dtEvaluar = new DateTime(2020, 01, 15);
			var SUT = new VerificadorEvento();

			//Act
			string cEtiquetaObtenida = SUT.ObtenerNombreDiferenciaFechas(dtActual, dtEvaluar);

			//Assert
			Assert.AreEqual(cEtiquetaEsperada, cEtiquetaObtenida);
		}

		[TestMethod()]
		public void ObtenerNombreDiferenciaFechas_FechaAnteriorConHora_ObtieneEtiquetaPasado()
		{
			//Arrange
			string cEtiquetaEsperada = "ocurrió hace";
			DateTime dtActual = new DateTime(2020, 01, 10, 10, 05, 00);
			DateTime dtEvaluar = new DateTime(2020, 01, 10, 08, 05, 00);
			var SUT = new VerificadorEvento();

			//Act
			string cEtiquetaObtenida = SUT.ObtenerNombreDiferenciaFechas(dtActual, dtEvaluar);

			//Assert
			Assert.AreEqual(cEtiquetaEsperada, cEtiquetaObtenida);
		}

		[TestMethod()]
		public void ObtenerNombreDiferenciaFechas_FechaPosteriorConHora_ObtieneEtiquetaFuturo()
		{
			//Arrange
			string cEtiquetaEsperada = "ocurrirá dentro de";
			DateTime dtActual = new DateTime(2020, 01, 15, 11,05,00 );
			DateTime dtEvaluar = new DateTime(2020, 01, 15, 12, 05, 00);
			var SUT = new VerificadorEvento();

			//Act
			string cEtiquetaObtenida = SUT.ObtenerNombreDiferenciaFechas(dtActual, dtEvaluar);

			//Assert
			Assert.AreEqual(cEtiquetaEsperada, cEtiquetaObtenida);
		}

		[TestMethod()]
		public void ObtenerNombreDiferenciaFechas_FechasIguales_ObtieneEtiquetaEstaOcurriendo()
		{
			//Arrange
			string cEtiquetaEsperada = "esta ocurriendo";
			DateTime dtActual = new DateTime(2020, 01, 15);
			DateTime dtEvaluar = new DateTime(2020, 01, 15);
			var SUT = new VerificadorEvento();

			//Act
			string cEtiquetaObtenida = SUT.ObtenerNombreDiferenciaFechas(dtActual, dtEvaluar);

			//Assert
			Assert.AreEqual(cEtiquetaEsperada, cEtiquetaObtenida);
		}
	}
}