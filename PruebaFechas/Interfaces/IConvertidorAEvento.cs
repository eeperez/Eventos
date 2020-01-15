using System.Collections.Generic;

namespace PruebaFechas.Interfaces
{
	public interface IConvertidorAEvento
	{
		List<Evento> ConvertirEventos(List<string> _lstLineas);
	}
}
