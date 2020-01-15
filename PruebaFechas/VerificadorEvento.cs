using PruebaFechas.Interfaces;
using System;

namespace PruebaFechas
{
	public class VerificadorEvento : IVerificadorEvento
	{
		public string _cMensajePasado { get; set; }
		public string _cMensajeFuturo { get; set; }

		public string ObtenerNombreEstadoEvento(Evento _evento)
		{
			string cMensaje = string.Empty;
			_cMensajePasado = "ocurrio hace";
			_cMensajeFuturo = "ocurrirá dentro de";

			if (_evento != null)
			{
				cMensaje = _cMensajeFuturo;
				if (_evento.dtFecha < DateTime.Now)
					cMensaje = _cMensajePasado;
			}

			return cMensaje;
		}

		public string ObtenerNombreDiferenciaFechas(DateTime _dtActual, DateTime _dtEvento)
		{
			string cMensaje = string.Empty;
			_cMensajePasado = "ocurrio hace";
			_cMensajeFuturo = "ocurrirá dentro de";

			cMensaje = _cMensajeFuturo;
			if (_dtEvento < _dtActual)
				cMensaje = _cMensajePasado;

			return cMensaje;
		}
	}
}
