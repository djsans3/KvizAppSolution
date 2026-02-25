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
	public abstract class Pitanje : INotifyPropertyChanged
	{
		private int pitanjeId;
		private string pitanjeTekst;
		private int ispitId;

		public Pitanje()
		{
			pitanjeTekst = "";
		}

		[Key]
		public int PitanjeId
		{
			get { return pitanjeId; }
			set { pitanjeId = value; OnPropertyChanged(); }
		}

		public string PitanjeTekst
		{
			get { return pitanjeTekst; }
			set { pitanjeTekst = value; OnPropertyChanged(); }
		}

		public int IspitId
		{
			get { return ispitId; }
			set { ispitId = value; OnPropertyChanged(); }
		}

		[ForeignKey("IspitId")]
		public virtual Ispit? Ispit { get; set; }

		public virtual void PrintPitanje()
		{
		}

		public void UnosOdg()
		{
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}