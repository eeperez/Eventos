using PruebaFechas.Interfaces;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFechas
{
	public class LectorArchivos : ILectorArchivo
	{
		private IConvertidorAEvento IconvertidorAEvento { get; set; }

		public LectorArchivos(IConvertidorAEvento _IconvertidorAEvento)
		{
			IconvertidorAEvento = _IconvertidorAEvento;
		}

		public List<Evento> LeerArchivoAListaEvento(string _cRuta)
		{
			List<Evento> lstEventos = null;
			List<string> lstLineas = new List<string>();

			string[] aLineas = File.ReadAllLines(_cRuta);

			lstLineas = aLineas.ToList();

			lstEventos = IconvertidorAEvento.ConvertirEventos(lstLineas);

			return lstEventos;
		}
	}
}
