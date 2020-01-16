using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaFechas.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PruebaFechas.Tests
{
	[TestClass()]
	public class LectorArchivosUTests
	{
		[TestMethod()]
		//[ExpectedException(typeof(FileNotFoundException))]
		public void LeerArchivoAListaEvento_ArchivoNoExistente_ExcepcionLanzada()
		{
			//Arrange
			var DOCIConvertidorAEvento = new Mock<IConvertidorAEvento>();
			var SUT = new LectorArchivos(DOCIConvertidorAEvento.Object);
			SUT.lectorArchivo = e => throw new FileNotFoundException();

			//Act
			Assert.ThrowsException<FileNotFoundException>(() => SUT.LeerArchivoAListaEvento("archivo no existente"));
		}

		[TestMethod()]
		public void LeerArchivoAListaEvento_ArchivoExistente_ListaConEvento()
		{
			//Arrange
			List<Evento> lstEventos = GenerarEventosPrueba(5);
			var DOCIConvertidorAEvento = new Mock<IConvertidorAEvento>();
			DOCIConvertidorAEvento.Setup(l => l.ConvertirEventos(It.IsAny<List<string>>())).Returns(lstEventos);
			var SUT = new LectorArchivos(DOCIConvertidorAEvento.Object);
			SUT.lectorArchivo = e => new string[] { "evento uno" };

			//Act
			List<Evento> lstEvento = SUT.LeerArchivoAListaEvento("");

			//Assert
			Assert.IsTrue(lstEvento.Any());
		}

		[TestMethod()]
		public void LeerArchivoAListaEvento_EjecucionConvertidorAEvento_EjecutaSoloUnaVez()
		{
			//Arrange
			var DOCIConvertidorAEvento = new Mock<IConvertidorAEvento>();
			var SUT = new LectorArchivos(DOCIConvertidorAEvento.Object);
			SUT.lectorArchivo = e => new string[] { "evento uno" };

			//Act
			List<Evento> lstEvento = SUT.LeerArchivoAListaEvento("");

			//Assert tipo spy
			DOCIConvertidorAEvento.Verify(l => l.ConvertirEventos(It.IsAny<List<string>>()), Times.Once);
		}

		private List<Evento> GenerarEventosPrueba(int v)
		{
			var fixture = new Fixture { RepeatCount = v };
			List<Evento> lstEventos = new List<Evento>();

			lstEventos = fixture.Repeat(fixture.Create<Evento>).ToList();

			return lstEventos;
		}
	}
}