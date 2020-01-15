using System;

namespace PruebaFechas.Interfaces
{
	public interface IVerificadorEvento
	{
		string ObtenerNombreEstadoEvento(Evento _evento);
		string ObtenerNombreDiferenciaFechas(DateTime _dtActual, DateTime _dtEvento);
	}
}
