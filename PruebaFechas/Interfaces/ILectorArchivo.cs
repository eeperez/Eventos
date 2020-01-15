using System.Collections.Generic;

namespace PruebaFechas.Interfaces
{
	public interface ILectorArchivo
	{
		List<Evento> LeerArchivoAListaEvento(string _cRuta);
	}
}
