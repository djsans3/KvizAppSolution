using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kviz.Core
{
	public enum TipKorisnika
	{
		Student,
		Profesor,
		Nepoznato
	}

	public abstract class Korisnik : INotifyPropertyChanged
	{
		private string username;
		private string password;

		public Korisnik()
		{
			username = "";
			password = "";
		}

		[Key]
		public string Username
		{
			get { return username; }
			set { username = value; OnPropertyChanged(); }
		}

		public string Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged(); }
		}

		public abstract TipKorisnika Prijava();

		public virtual void Odjava()
		{
		}

		public virtual void PregledIspita()
		{
		}

		public static Korisnik? ProvjeriKorisnika(string korisnickoIme, string lozinka)
		{
			if (korisnickoIme == "profesor" && lozinka == "87654321")
			{
				Profesor profesor = new Profesor();
				profesor.Username = korisnickoIme;
				profesor.Password = lozinka;
				return profesor;
			}
			else if (korisnickoIme == "student" && lozinka == "12345678")
			{
				Student student = new Student();
				student.Username = korisnickoIme;
				student.Password = lozinka;
				return student;
			}
			else
			{
				return null;
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}