using System;
using System.Collections.Generic;

namespace PruebaFechas.Interfaces
{
	public interface ILectorArchivo
	{
		Func<string, string[]> lectorArchivo { get; set; }

		List<Evento> LeerArchivoAListaEvento(string _cRuta);
	}
}
