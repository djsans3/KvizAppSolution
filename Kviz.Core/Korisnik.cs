
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Korisnik
{
	public Korisnik()
	{
        username = "";
		password = "";
    }

	public string username;

	public string password;

	public enum TipKorisnika
	{
		Student,
		Profesor,
		Nepoznato
	}
	public TipKorisnika Prijava()
	{
		if (username == "student" && password == "student")
		{
            // pripremi stvari za studenta
			return TipKorisnika.Student;
		}
		else if (username == "profesor" && password == "profesor")
		{
			// pripremi stvari za profesora
			return TipKorisnika.Profesor;
        }
        else
		{
            // pogrešan unos
            return TipKorisnika.Nepoznato;
        }
    }

	public void Odjava()
	{
	}

	public void PregledIspita()
	{
	}
	
}