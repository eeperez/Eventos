using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaFechas;
using PruebaFechas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class DiferenciadorEventoUTests
	{
		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoAnteriorActual_DiferenciaDiezDiasPasado()
		{
			//Arrange
			string cDiferenciaRegreso = "pasado";
			string cEsperado = $"{cDiferenciaRegreso} 10 Días";
			DateTime dtActual = new DateTime(2020, 01, 05);
			DateTime dtEvento = new DateTime(2020, 01, 15);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoPosteriorActual_DiferenciaCuatroDiasFuturo()
		{
			//Arrange
			string cDiferenciaRegreso = "futuro";
			string cEsperado = $"{cDiferenciaRegreso} 4 Días";
			DateTime dtActual = new DateTime(2020, 01, 05);
			DateTime dtEvento = new DateTime(2020, 01, 01);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoDiferenteEnMeses_DiferenciaDosMeses()
		{
			//Arrange
			string cDiferenciaRegreso = "diferencia";
			string cEsperado = $"{cDiferenciaRegreso} 2 Meses";
			DateTime dtActual = new DateTime(2020, 01, 05);
			DateTime dtEvento = new DateTime(2020, 03, 05);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoDiferenteEnHoras_DiferenciaSeisHoras()
		{
			//Arrange
			string cDiferenciaRegreso = "diferencia";
			string cEsperado = $"{cDiferenciaRegreso} 6 Horas";
			DateTime dtActual = new DateTime(2020, 01, 05, 10, 00, 00);
			DateTime dtEvento = new DateTime(2020, 01, 05, 16, 00, 00);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoDiferenteEnMinutos_DiferenciaDosMinutos()
		{
			//Arrange
			string cDiferenciaRegreso = "diferencia";
			string cEsperado = $"{cDiferenciaRegreso} 2 Minutos";
			DateTime dtActual = new DateTime(2020, 01, 05, 10, 26, 00);
			DateTime dtEvento = new DateTime(2020, 01, 05, 10, 28, 00);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_FechaEventoIgualActual_DiferenciaVacia()
		{
			//Arrange
			string cDiferenciaRegreso = "esta ocurriendo";
			string cEsperado = $"{cDiferenciaRegreso}";
			DateTime dtActual = new DateTime(2020, 01, 05, 10, 26, 00);
			DateTime dtEvento = new DateTime(2020, 01, 05, 10, 26, 00);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			DOCVerificadorEvento.Setup(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(cDiferenciaRegreso);
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert
			Assert.AreEqual(cEsperado, cDiferenciaObtenida);
		}

		[TestMethod()]
		public void ObtenerDiferenciaFechas_EjecucionObtenerDiferenciaFechas_SoloUnavez()
		{
			//Arrange
			string cDiferenciaRegreso = "esta ocurriendo";
			string cEsperado = $"{cDiferenciaRegreso}";
			DateTime dtActual = new DateTime(2020, 01, 05, 10, 26, 00);
			DateTime dtEvento = new DateTime(2020, 01, 05, 10, 26, 00);
			var DOCVerificadorEvento = new Mock<IVerificadorEvento>();
			var SUT = new DiferenciadorEvento(DOCVerificadorEvento.Object);

			//Act
			string cDiferenciaObtenida = SUT.ObtenerDiferenciaFechas(dtActual, dtEvento);

			//Assert spy
			DOCVerificadorEvento.Verify(m => m.ObtenerNombreDiferenciaFechas(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
		}
	}
}