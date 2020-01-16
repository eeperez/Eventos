using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class ConvertidorAEventoUTests
	{
		[TestMethod()]
		public void ConvertirEventos_SinLineasParaConvertir_ListaEventosVacia()
		{
			//Arrange
			List<string> lstEntrada = new List<string>();
			var SUT = new ConvertidorAEvento();

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(0, lstEventos.Count);
		}

		[TestMethod()]
		public void ConvertirEventos_ConUnaCadenaParaConvertir_ListaEventosConUnElemento()
		{
			//Arrange
			List<string> lstEntrada = new List<string> { "prueba evento, 10/05/2020" };
			var SUT = new ConvertidorAEvento();

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(1, lstEventos.Count);
		}

		[TestMethod()]
		public void ConvertirEventos_ConVariasCadenaParaConvertir_ListaEventosConVariosElementos()
		{
			//Arrange
			List<string> lstEntrada = new List<string> { "prueba evento, 10/05/2020", "evento 2, 01/02/2020", "evento 3, 12/12/2020" };
			var SUT = new ConvertidorAEvento();

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(lstEntrada.Count, lstEventos.Count);
		}

		[TestMethod()]
		[DataRow("evento uno", "10/05/2020")]
		[DataRow("nuevo evento", "01/05/2019")]
		public void ConvertirEventos_VerificarUnTituloEvento_ListaElementosConElTitulo(string _cEvento, string _cFecha)
		{
			//Arrange
			List<string> lstEntrada = new List<string> { $"{_cEvento}, {_cFecha}" };
			var SUT = new ConvertidorAEvento();

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(_cEvento, lstEventos.FirstOrDefault().cTitulo);
		}

		[TestMethod()]
		[DataRow("evento uno", "10/05/2020")]
		[DataRow("nuevo evento", "01/05/2019")]
		public void ConvertirEventos_VerificarUnaFechaEvento_ListaElementosConFechaEnviada(string _cEvento, string _cFecha)
		{
			//Arrange
			List<string> lstEntrada = new List<string> { $"{_cEvento}, {_cFecha}" };
			var SUT = new ConvertidorAEvento();
			DateTime dtEsperada = Convert.ToDateTime(_cFecha);

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(dtEsperada, lstEventos.FirstOrDefault().dtFecha);
		}

		[TestMethod()]
		[DataRow("evento uno")]
		[DataRow("cadena sin formato")]
		public void ConvertirEventos_CadenaEntradaSinFormatoEventoComaFecha_ListaEventosVacia(string _cEvento)
		{
			//Arrange
			List<string> lstEntrada = new List<string> { $"{_cEvento}" };
			var SUT = new ConvertidorAEvento();

			//Act
			List<Evento> lstEventos = SUT.ConvertirEventos(lstEntrada);

			//Assert
			Assert.AreEqual(0, lstEventos.Count);
		}

		[TestMethod()]
		[DataRow("evento uno", "fecha mal")]
		[DataRow("nuevo evento", "0101/2525/2525")]
		public void ConvertirEventos_DatosEntradaConEventosSinForamtoDeFecha_LanzarExcepcionFormato(string _cEvento, string _cFecha)
		{
			//Arrange
			List<string> lstEntrada = new List<string> { $"{_cEvento}, {_cFecha}" };
			var SUT = new ConvertidorAEvento();

			//Assert
			Assert.ThrowsException<FormatException>(() => SUT.ConvertirEventos(lstEntrada));
		}
	}
}