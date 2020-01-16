using PruebaFechas.Interfaces;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PruebaFechas
{
	public class LectorArchivos : ILectorArchivo
	{
		private IConvertidorAEvento IconvertidorAEvento { get; set; }

		public Func<string, string[]> lectorArchivo { get; set; }

		public LectorArchivos(IConvertidorAEvento _IconvertidorAEvento)
		{
			IconvertidorAEvento = _IconvertidorAEvento;
			lectorArchivo = cRuta => File.ReadAllLines(cRuta);
		}

		public List<Evento> LeerArchivoAListaEvento(string _cRuta)
		{
			List<Evento> lstEventos = null;
			List<string> lstLineas = new List<string>();

			string[] aLineas = lectorArchivo(_cRuta);

			lstLineas = aLineas.ToList();

			lstEventos = IconvertidorAEvento.ConvertirEventos(lstLineas);

			return lstEventos;
		}
	}
}
