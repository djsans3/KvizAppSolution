using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz.Core
{
	public class Student : Korisnik
	{
		private List<Rezultat> rezultati;

		public Student()
		{
			rezultati = new List<Rezultat>();
		}

		public virtual List<Rezultat> Rezultati
		{
			get { return rezultati; }
			set { rezultati = value; }
		}

		public override TipKorisnika Prijava()
		{
			return TipKorisnika.Student;
		}

		public void RijesiIspit()
		{
		}

		public override void PregledIspita()
		{
		}
	}
}