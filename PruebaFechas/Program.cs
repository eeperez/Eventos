using System;
using System.Collections.Generic;
using PruebaFechas.Interfaces;

namespace PruebaFechas
{
	class Program
	{
		static void Main(string[] args)
		{
			string cResultadoEvento = string.Empty;
			string cDiferencia = string.Empty;
			string cRuta = @"F:\CursoSOLID\PruebaFechas\Eventos.txt";

			IConvertidorAEvento convertidorEvento = new ConvertidorAEvento();
			ILectorArchivo lectorArchivo = new LectorArchivos(convertidorEvento);
			IVerificadorEvento verificadorEvento = new VerificadorEvento();
			IDiferenciadorEvento diferenciaEvento = new DiferenciadorEvento(verificadorEvento);
			IPresentadorDatos presentador = new PresentadorDatos();

			List<Evento> lstEventos = lectorArchivo.LeerArchivoAListaEvento(cRuta);

			foreach (var evento in lstEventos)
			{
				cDiferencia = diferenciaEvento.ObtenerDiferenciaFechas(DateTime.Now, evento.dtFecha);
				cResultadoEvento = $" {evento.cTitulo} {cDiferencia}";
				presentador.MostrarDatos(cResultadoEvento);
			}

			Console.ReadLine();
		}
	}
}

