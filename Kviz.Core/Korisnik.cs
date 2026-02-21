
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Korisnik
{
	public Korisnik()
	{
	}

	public string username = " ";

	public string password = " ";

	public void Prijava()
	{
		while (true)
		{
			if (username == "admin" && password == "admin")
			{
				// pripremi stvari za admina
				break;
			}
			else if (username == "korisnik" && password == "korisnik")
			{
				// pripremi stvari za korisnika
				break;
			}
			else
			{
				// pogrešan unos
				break;
			}
		}
	}

	public void Odjava() {
		// TODO implement here
	}

	public void PregledIspita() {
		// TODO implement here
	}
	
}