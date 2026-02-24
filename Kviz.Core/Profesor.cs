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

		public List<Ispit> Ispiti
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
			// TODO: SQLite - Dohvati sve ispite koje je kreiranio ovaj profesor
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "SELECT * FROM Ispiti WHERE ProfesorId = @profesorId";
			//     command.Parameters.AddWithValue("@profesorId", this.Username);
			//     var reader = command.ExecuteReader();
			//     // Popuniti listu ispita iz baze
			// }
		}

		public void StvoriIspit()
		{
			// TODO: SQLite - Spremi novi ispit u bazu podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = @"INSERT INTO Ispiti (Naziv, Opis, ProfesorId) 
			//                              VALUES (@naziv, @opis, @profesorId)";
			//     command.Parameters.AddWithValue("@naziv", naziv);
			//     command.Parameters.AddWithValue("@opis", opis);
			//     command.Parameters.AddWithValue("@profesorId", this.Username);
			//     command.ExecuteNonQuery();
			// }
		}

		public void UrediIspit()
		{
			// TODO: SQLite - Ažuriraj postojeći ispit u bazi podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = @"UPDATE Ispiti SET Naziv = @naziv, Opis = @opis 
			//                              WHERE IspitId = @ispitId AND ProfesorId = @profesorId";
			//     command.Parameters.AddWithValue("@naziv", naziv);
			//     command.Parameters.AddWithValue("@opis", opis);
			//     command.Parameters.AddWithValue("@ispitId", ispitId);
			//     command.Parameters.AddWithValue("@profesorId", this.Username);
			//     command.ExecuteNonQuery();
			// }
		}

		public void IzbrisiIspit()
		{
			// TODO: SQLite - Obriši ispit iz baze podataka
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "DELETE FROM Ispiti WHERE IspitId = @ispitId ANDProfesorId = @profesorId";
			//     command.Parameters.AddWithValue("@ispitId", ispitId);
			//     command.Parameters.AddWithValue("@profesorId", this.Username);
			//     command.ExecuteNonQuery();
			// }
		}
	}
}