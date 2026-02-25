using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Kviz.Core
{
	public class InputPitanje : Pitanje
	{
		private string[] odgovorTocan;
		private string odgovorUnesen;

		public InputPitanje()
		{
			odgovorTocan = Array.Empty<string>();
			odgovorUnesen = "";
		}

		[NotMapped]
		public string[] OdgovorTocan
		{
			get { return odgovorTocan; }
			set { odgovorTocan = value; OnPropertyChanged(); }
		}

		public string OdgovorTocanJson
		{
			get { return string.Join("|||", odgovorTocan); }
			set { odgovorTocan = value?.Split("|||", StringSplitOptions.None) ?? Array.Empty<string>(); }
		}

		public string OdgovorUnesen
		{
			get { return odgovorUnesen; }
			set { odgovorUnesen = value; OnPropertyChanged(); }
		}
	}
}