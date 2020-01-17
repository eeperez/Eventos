using PruebaFechas.Interfaces;
using System;

namespace PruebaFechas
{
	public class PresentadorDatos : IPresentadorDatos
	{
		public Action<string> presentadorDatos { get; set; }

		public PresentadorDatos()
		{
			presentadorDatos = cMensaje => Console.WriteLine(cMensaje);
		}

		public void MostrarDatos(string _cMensaje)
		{
			presentadorDatos(_cMensaje);
		}
	}
}
