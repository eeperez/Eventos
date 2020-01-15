using PruebaFechas.Interfaces;
using System;

namespace PruebaFechas
{
	public class PresentadorDatos : IPresentadorDatos
	{
		public void MostrarEnConsola(string _cMensaje)
		{
			Console.WriteLine(_cMensaje);
		}
	}
}
