using System;

namespace PruebaFechas.Interfaces
{
	public interface IDiferenciadorEvento
	{
		string ObtenerDiferenciaFechas(DateTime _dtActual, DateTime _dtFecha);
	}
}
