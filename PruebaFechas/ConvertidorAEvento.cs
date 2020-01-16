using PruebaFechas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFechas
{
	public class ConvertidorAEvento : IConvertidorAEvento
	{
		public List<Evento> ConvertirEventos(List<string> _lstLineas)
		{
			List<Evento> lstEventos = null;

			lstEventos = (from l in _lstLineas
						  let datos = l.Split(',')
						  where datos.Count() == 2
						  select new Evento
						  {
							  cTitulo = datos[0],
							  dtFecha = Convert.ToDateTime(datos[1])
						  }).ToList();

			return lstEventos;
		}
	}
}
