using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kviz.Core
{
	public enum TipKorisnika
	{
		Student,
		Profesor,
		Nepoznato
	}

	public abstract class Korisnik
	{
		private string username;
		private string password;

		public Korisnik()
		{
			username = "";
			password = "";
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public abstract TipKorisnika Prijava();

		public virtual void Odjava()
		{
		}

		public virtual void PregledIspita()
		{
			// TODO: SQLite - Dohvati ispite iz baze podataka za ovog korisnika
			// Primjer:
			// using (var connection = new SqliteConnection("Data Source=kviz.db"))
			// {
			//     connection.Open();
			//     var command = connection.CreateCommand();
			//     command.CommandText = "SELECT * FROM Ispiti WHERE KorisnikId = @korisnikId";
			//     command.Parameters.AddWithValue("@korisnikId", this.Username);
			//     // Izvrsiti upit and popuniti listu ispita
			// }
		}

		/// <summary>
		/// Factory metoda za provjeru korisnika i vracanje odgovarajuce instance
		/// </summary>
		public static Korisnik ProvjeriKorisnika(string korisnickoIme, string lozinka)
		{
			// Profesor
			if (korisnickoIme == "profesor" && lozinka == "87654321")
			{
				Profesor profesor = new Profesor();
				profesor.Username = korisnickoIme;
				profesor.Password = lozinka;
				return profesor;
			}
			// Student
			else if (korisnickoIme == "student" && lozinka == "12345678")
			{
				Student student = new Student();
				student.Username = korisnickoIme;
				student.Password = lozinka;
				return student;
			}
			// Neuspjesna prijava
			else
			{
				return null;
			}
		}
	}
}