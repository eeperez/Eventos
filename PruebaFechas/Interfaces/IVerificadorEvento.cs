using System;

namespace PruebaFechas.Interfaces
{
	public interface IVerificadorEvento
	{
		string ObtenerNombreDiferenciaFechas(DateTime _dtActual, DateTime _dtEvento);
	}
}
