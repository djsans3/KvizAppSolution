using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Kviz.Core
{
	public class Rezultat : INotifyPropertyChanged
	{
		private int rezultatId;
		private int ispitId;
		private string studentUsername;
		private int brojTocnihOdgovora;
		private DateTime datum;

		public Rezultat()
		{
			studentUsername = "";
			datum = DateTime.Now;
		}

		[Key]
		public int RezultatId
		{
			get { return rezultatId; }
			set { rezultatId = value; OnPropertyChanged(); }
		}

		public int IspitId
		{
			get { return ispitId; }
			set { ispitId = value; OnPropertyChanged(); }
		}

		[ForeignKey("IspitId")]
		public virtual Ispit? Ispit { get; set; }

		public string StudentUsername
		{
			get { return studentUsername; }
			set { studentUsername = value; OnPropertyChanged(); }
		}

		[ForeignKey("StudentUsername")]
		public virtual Student? Student { get; set; }

		public int BrojTocnihOdgovora
		{
			get { return brojTocnihOdgovora; }
			set { brojTocnihOdgovora = value; OnPropertyChanged(); }
		}

		public DateTime Datum
		{
			get { return datum; }
			set { datum = value; OnPropertyChanged(); }
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
