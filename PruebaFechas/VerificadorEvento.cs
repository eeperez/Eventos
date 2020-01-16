using PruebaFechas.Interfaces;
using System;

namespace PruebaFechas
{
	public class VerificadorEvento : IVerificadorEvento
	{
		public string _cMensajePasado { get; set; }
		public string _cMensajeFuturo { get; set; }

		public string ObtenerNombreDiferenciaFechas(DateTime _dtActual, DateTime _dtEvento)
		{
			string cMensaje = string.Empty;
			_cMensajePasado = "ocurrió hace";
			_cMensajeFuturo = "ocurrirá dentro de";

			cMensaje = _cMensajeFuturo;
			if (_dtEvento < _dtActual)
				cMensaje = _cMensajePasado;
			else if (_dtEvento == _dtActual)
				cMensaje = "esta ocurriendo";

			return cMensaje;
		}
	}
}
