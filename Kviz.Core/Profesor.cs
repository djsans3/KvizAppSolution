using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz.Core
{
	public class Profesor : Korisnik
	{
		private List<Ispit> ispiti;

		public Profesor()
		{
			ispiti = new List<Ispit>();
		}

		public virtual List<Ispit> Ispiti
		{
			get { return ispiti; }
			set { ispiti = value; }
		}

		public override TipKorisnika Prijava()
		{
			return TipKorisnika.Profesor;
		}

		public override void PregledIspita()
		{
		}

		public void StvoriIspit()
		{
		}

		public void UrediIspit()
		{
		}

		public void IzbrisiIspit()
		{
		}
	}
}