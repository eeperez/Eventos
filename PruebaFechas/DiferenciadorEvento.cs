using PruebaFechas.Interfaces;
using System;

namespace PruebaFechas
{
	public class DiferenciadorEvento : IDiferenciadorEvento
	{
		private IVerificadorEvento IverificadorEvento { get; set; }

		public DiferenciadorEvento(IVerificadorEvento _IverificadorEvento)
		{
			IverificadorEvento = _IverificadorEvento;
		}

		public string ObtenerDiferenciaFechas(DateTime _dtActual, DateTime _dtFecha)
		{
			string cRango = string.Empty;
			string cResultado = string.Empty;

			var diferencia = _dtFecha - _dtActual;

			if (Math.Abs(diferencia.Days) > 30)
			{
				int idif = diferencia.Days / 30;
				cRango = $"{Math.Abs(idif)} Meses";
			}
			else
			{
				int iDias = Math.Abs(diferencia.Days);
				int iHoras = Math.Abs(diferencia.Hours);
				int iMinutos = Math.Abs(diferencia.Minutes);
				if (iDias > 0)
					cRango = $"{iDias} Días";
				else if (iHoras > 0)
					cRango = $"{iHoras} Horas";
				else if(iMinutos > 0)
					cRango = $"{Math.Abs(diferencia.Minutes)} Minutos";
			}

			string cNombreDiferencia = IverificadorEvento.ObtenerNombreDiferenciaFechas(_dtActual, _dtFecha);
			cResultado = $"{cNombreDiferencia} {cRango}".Trim();

			return cResultado;
		}
	}
}
