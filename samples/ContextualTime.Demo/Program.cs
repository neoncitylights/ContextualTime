using System;
using System.Globalization;
using NodaTime;

namespace ContextualTime.Demo {
	public class Program {
		public static void Main( string[] args ) {
			Parser parser = new();
			while ( true ) {
				Console.WriteLine( "Type in a time phrase:" );
				string timePhraseString = Console.ReadLine();
				try {
					TimePhrase timePhrase = parser.Parse(timePhraseString);
					Console.WriteLine(
						timePhrase.GetAsDateTime().ToString(CultureInfo.InvariantCulture));
				}
				catch(Exception e) {
					Console.WriteLine("Time unable to be read.");
					Console.WriteLine(e.Message);
				}

				Console.WriteLine();
			}
		}
	}
}
