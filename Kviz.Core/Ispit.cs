using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kviz.Core
{
	public class Ispit : INotifyPropertyChanged
	{
		private int sifra;
		private string naziv;
		private List<Pitanje> skupPitanja;
		private int trenBrojTocnihOdg;
		private string profesorUsername;

		public Ispit()
		{
			naziv = "";
			profesorUsername = "";
			skupPitanja = new List<Pitanje>();
			trenBrojTocnihOdg = 0;
		}

		[Key]
		public int Sifra
		{
			get { return sifra; }
			set { sifra = value; OnPropertyChanged(); }
		}

		public string Naziv
		{
			get { return naziv; }
			set { naziv = value; OnPropertyChanged(); }
		}

		public string ProfesorUsername
		{
			get { return profesorUsername; }
			set { profesorUsername = value; OnPropertyChanged(); }
		}

		[ForeignKey("ProfesorUsername")]
		public virtual Profesor? Profesor { get; set; }

		public virtual List<Pitanje> SkupPitanja
		{
			get { return skupPitanja; }
			set { skupPitanja = value; OnPropertyChanged(); }
		}

		[NotMapped]
		public int TrenBrojTocnihOdg
		{
			get { return trenBrojTocnihOdg; }
			set { trenBrojTocnihOdg = value; OnPropertyChanged(); }
		}

		public int BrojBodovaMax()
		{
			return skupPitanja.Count;
		}

		public void PrintRezultat()
		{
		}

		public void SpremiRezultat()
		{
		}

		public void PrintRangLista()
		{
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
