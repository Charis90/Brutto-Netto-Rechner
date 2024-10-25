using System;
using System.IO;
using System.Text; // Für Dateizugriff

// Interface für den Steuerrechner
public interface ISteuerRechner
{
	// Methode zur Berechnung des Netto-Gehalts
	double BerechneNetto(double brutto, int steuerklasse);
}

// Klasse für den deutschen Steuerrechner, implementiert das Interface
public class DeutscherSteuerRechner : ISteuerRechner
{
	// Methode zur Berechnung des Netto-Gehalts basierend auf dem Brutto-Gehalt und der Steuerklasse
	public double BerechneNetto(double brutto, int steuerklasse)
	{
		double steuern = 0;
		double steuersatz = 0;
		double versicherungsbeitrag = BerechneVersicherung(brutto); // Berechnung des Versicherungsbeitrags

		// Logik zur Berechnung der Steuern basierend auf der Steuerklasse
		switch (steuerklasse)
		{
			case 1:
				steuersatz = 0.25;
				steuern = brutto * steuersatz;
				break;
			case 2:
				steuersatz = 0.22;
				steuern = brutto * steuersatz;
				break;
			case 3:
				steuersatz = 0.15;
				steuern = brutto * steuersatz;
				break;
			case 4:
				steuersatz = 0.18;
				steuern = brutto * steuersatz;
				break;
			case 5:
				steuersatz = 0.30;
				steuern = brutto * steuersatz;
				break;
			case 6:
				steuersatz = 0.35;
				steuern = brutto * steuersatz;
				break;
			default:
				Console.WriteLine("Ungültige Steuerklasse. Standardmäßig wird Steuerklasse 1 verwendet.");
				steuersatz = 0.25;
				steuern = brutto * steuersatz;
				break;
		}

		Console.WriteLine("Für Steuerklasse " + steuerklasse + " wurde ein Steuersatz von " + (steuersatz * 100) + "% angewendet.");
		Console.WriteLine("Es wurde ein Versicherungsbeitrag von " + versicherungsbeitrag + " Euro abgezogen.");

		// Netto-Gehalt ist das Brutto-Gehalt minus Steuern und Versicherungsbeitrag
		return brutto - steuern - versicherungsbeitrag;
	}

	// Methode zur Berechnung des Versicherungsbeitrags basierend auf dem Brutto-Gehalt
	private double BerechneVersicherung(double brutto)
	{
		double versicherungssatz = 0.081;
		return brutto * versicherungssatz;
	}
}

// Hauptprogramm zur Verwendung des Rechners
public class BruttoNettoRechner
{
	// Methode zum Speichern der Ergebnisse in eine Datei
	public static void SpeichereErgebnis(double brutto, double netto, int steuerklasse)
	{
		string dateiname = "steuerberechnung.txt";
		string inhalt = "Brutto-Gehalt: " + brutto + " Euro\n" +
						"Steuerklasse: " + steuerklasse + "\n" +
						"Netto-Gehalt: " + netto + " Euro\n" +
						"----------------------------\n";

		// Ergebnisse in die Datei schreiben
		File.AppendAllText(dateiname, inhalt);
		Console.WriteLine("Ergebnis erfolgreich in der Datei '" + dateiname + "' gespeichert.");
	}

	// Main-Methode: Hier beginnt das Programm
	
	public static void Main(string[] args)
	{
		//Console.OutputEncoding = Encoding.UTF8;
		double brutto;
		ISteuerRechner steuerRechner = new DeutscherSteuerRechner();

		Console.Write("Bitte geben Sie Ihr Brutto-Gehalt ein: ");
		while (!double.TryParse(Console.ReadLine(), out brutto))
		{
			Console.WriteLine("Ungültige Eingabe");
			
		}
		//double brutto = Convert.ToDouble(Console.ReadLine());


		Console.WriteLine("Bitte waehlen Sie Ihre Steuerklasse (1 bis 6): ");
		Console.WriteLine("Steuerklasse 1: Ledig");
		Console.WriteLine("Steuerklasse 2: Alleinerziehend");
		Console.WriteLine("Steuerklasse 3: Verheiratet, Hauptverdiener");
		Console.WriteLine("Steuerklasse 4: Verheiratet, beide aehnlich verdienend");
		Console.WriteLine("Steuerklasse 5: Verheiratet, Zweitverdiener");
		Console.WriteLine("Steuerklasse 6: Zweitjob");
		int steuerklasse = Convert.ToInt32(Console.ReadLine());

		double netto = steuerRechner.BerechneNetto(brutto, steuerklasse);

		Console.WriteLine("Ihr Netto-Gehalt betraegt: " + netto + " Euro");

		// Ergebnis speichern
		SpeichereErgebnis(brutto, netto, steuerklasse);

		Console.WriteLine(" \"Wenn das Finanzamt dein Gehalt sieht, denkt es sich: 'Das ist ein schönes Stück Einkommen, aber lassen wir mal 40% für die Gemeinschaft übrig – schliesslich müssen wir die nächsten Büroklammern kaufen!'\" Willkommen in Deutschland! ");
	}
}
