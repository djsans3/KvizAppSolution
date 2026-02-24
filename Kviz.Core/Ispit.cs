using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz.Core
{
	public class Ispit
	{
		private int sifra;
		private List<Pitanje> skupPitanja;
		private int trenBrojTocnihOdg;

		public Ispit()
		{
			skupPitanja = new List<Pitanje>();
			trenBrojTocnihOdg = 0;
		}

		public int Sifra
		{
			get { return sifra; }
			set { sifra = value; }
		}

		public List<Pitanje> SkupPitanja
		{
			get { return skupPitanja; }
			set { skupPitanja = value; }
		}

		public int TrenBrojTocnihOdg
		{
			get { return trenBrojTocnihOdg; }
			set { trenBrojTocnihOdg = value; }
		}

		public int BrojBodovaMax()
		{
			return skupPitanja.Count;
		}

		public void PrintRezultat()
		{
			// TODO: SQLite - Dohvati rezultat iz baze i prikaži ga
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "SELECT * FROM Rezultati WHERE IspitId = @ispitId";
			//     command.Parameters.AddWithValue("@ispitId", this.Sifra);
			//     var reader = command.ExecuteReader();
			//     // Prikaži rezultate
			// }
		}

		public void SpremiRezultat()
		{
			// TODO: SQLite - Spremi rezultat u bazu podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = @"INSERT INTO Rezultati (IspitId, StudentId, BrojTocnihOdgovora, Datum) 
			//                              VALUES (@ispitId, @studentId, @brojTocnih, @datum)";
			//     command.Parameters.AddWithValue("@ispitId", this.Sifra);
			//     command.Parameters.AddWithValue("@studentId", studentId);
			//     command.Parameters.AddWithValue("@brojTocnih", this.TrenBrojTocnihOdg);
			//     command.Parameters.AddWithValue("@datum", DateTime.Now);
			//     command.ExecuteNonQuery();
			// }
		}

		public void PrintRangLista()
		{
			// TODO: SQLite - Dohvati rang listu iz baze podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = @"SELECT StudentId, BrojTocnihOdgovora FROM Rezultati 
			//                              WHERE IspitId = @ispitId 
			//                              ORDER BY BrojTocnihOdgovora DESC";
			//     command.Parameters.AddWithValue("@ispitId", this.Sifra);
			//     var reader = command.ExecuteReader();
			//     // Prikaži rang listu
			// }
		}
	}
}
