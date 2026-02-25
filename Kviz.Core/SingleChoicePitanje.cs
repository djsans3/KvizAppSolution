namespace Kviz.Core
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Text;

	public class SingleChoicePitanje : Pitanje
	{
		private char odgovorTocan;
		private char odgovorUneseni;
		private string[] ponudeniOdg;

		public SingleChoicePitanje()
		{
			ponudeniOdg = Array.Empty<string>();
		}

		public char OdgovorTocan
		{
			get { return odgovorTocan; }
			set { odgovorTocan = value; OnPropertyChanged(); }
		}

		public char OdgovorUneseni
		{
			get { return odgovorUneseni; }
			set { odgovorUneseni = value; OnPropertyChanged(); }
		}

		[NotMapped]
		public string[] PonudeniOdg
		{
			get { return ponudeniOdg; }
			set { ponudeniOdg = value; OnPropertyChanged(); }
		}

		public string PonudeniOdgJson
		{
			get { return string.Join("|||", ponudeniOdg); }
			set { ponudeniOdg = value?.Split("|||", StringSplitOptions.None) ?? Array.Empty<string>(); }
		}

		public override void PrintPitanje()
		{
		}
	}
}