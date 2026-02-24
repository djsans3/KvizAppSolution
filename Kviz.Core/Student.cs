using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz.Core
{
	public class Student : Korisnik
	{
		private List<Ispit> rijeseniIspiti;

		public Student()
		{
			rijeseniIspiti = new List<Ispit>();
		}

		public List<Ispit> RijeseniIspiti
		{
			get { return rijeseniIspiti; }
			set { rijeseniIspiti = value; }
		}

		public override TipKorisnika Prijava()
		{
			return TipKorisnika.Student;
		}

		public void RijesiIspit()
		{
			// TODO: SQLite - Učitaj ispit iz baze podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "SELECT * FROM Ispiti WHERE IspitId = @ispitId";
			//     command.Parameters.AddWithValue("@ispitId", ispitId);
			//     var reader = command.ExecuteReader();
			//     // Popuniti ispit sa podacima iz baze
			// }
		}

		public override void PregledIspita()
		{
			// TODO: SQLite - Dohvati sve dostupne ispite iz baze podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "SELECT * FROM Ispiti WHERE Dostupan = 1";
			//     var reader = command.ExecuteReader();
			//     // Popuniti listu dostupnih ispita iz baze
			// }
		}
	}
}