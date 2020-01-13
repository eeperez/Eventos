using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFechas
{
	class Program
	{
		static void Main(string[] args)
		{
			string cResultadoEvento = string.Empty;
			string cEstado = string.Empty;
			string cDiferencia = string.Empty;
			Program prg = new Program();

			List<string> lstLineas = prg.LeerArchivo(@"F:\CursoSOLID\PruebaFechas\Eventos.txt");
			var lstEventos = prg.ObtenerEventos(lstLineas);

			foreach (var evento in lstEventos)
			{
				cEstado = prg.ObtenerEstadoEvento(evento, "ocurrio hace", "ocurrirá dentro de");
				cDiferencia = prg.ObtenerDiferenciaFechas(DateTime.Now, evento.dtFecha);
				cResultadoEvento = $" {evento.cTitulo} {cEstado} {cDiferencia}";
				Console.WriteLine(cResultadoEvento);
			}

			Console.ReadLine();
		}

		public List<string> LeerArchivo(string _cRuta)
		{
			List<string> lstLineas = new List<string>();

			string[] aLineas = System.IO.File.ReadAllLines(_cRuta);

			lstLineas = aLineas.ToList();

			return lstLineas;
		}

		public List<Evento> ObtenerEventos(List<string> _lstLineas)
		{
			List<Evento> lstEventos = null;

			lstEventos = (from l in _lstLineas
						  let datos = l.Split(',')
						  select new Evento
						  {
							  cTitulo = datos[0],
							  dtFecha = Convert.ToDateTime(datos[1])
						  }).ToList();

			return lstEventos;
		}

		public string ObtenerEstadoEvento(Evento _evento, string _cMensajePaso, string _cMensajePorPasar)
		{
			string cMensaje = string.Empty;

			if (_evento != null)
			{
				cMensaje = _cMensajePorPasar;
				if (_evento.dtFecha < DateTime.Now)
					cMensaje = _cMensajePaso;
			}

			return cMensaje;
		}

		public string ObtenerDiferenciaFechas(DateTime _dtActual, DateTime _dtFecha)
		{
			string cRango = string.Empty;

			var diferencia = _dtFecha - _dtActual;

			if (diferencia.Days > 30)
			{
				int idif = diferencia.Days / 30;
				cRango = $"{Math.Abs(idif)} Meses";
			}
			else if (diferencia.Hours > 24)
				cRango = $"{Math.Abs(diferencia.Days)} Días";
			else if (diferencia.Minutes > 60)
				cRango = $"{Math.Abs(diferencia.Hours)} Horas";
			else
				cRango = $"{Math.Abs(diferencia.Minutes)} Minutos";

			return cRango;
		}
	}

	public class Evento
	{
		public string cTitulo { get; set; }

		public DateTime dtFecha { get; set; }
	}
}

