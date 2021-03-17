using System;
using System.Globalization;

namespace ContextualTime.Demo {
	public class Program {
		public static void Main( string[] args ) {
			Parser parser = new();
			while ( true ) {
				Console.Write( "Type in a time phrase: " );
				string timePhraseString = Console.ReadLine();
				try {
					TimePhrase timePhrase = parser.Parse( timePhraseString );
					Console.WriteLine( $"┣ Current date/time:\t{DateTime.Now}" );
					Console.WriteLine( $"┣ Modified date/time:\t{timePhrase.GetAsDateTime().ToString( CultureInfo.InvariantCulture )}" );
					Console.WriteLine( $"┣ Tense: \t{timePhrase.Tense}\t| Preposition: \"{timePhrase.Preposition}\"" );
					Console.WriteLine( $"┗ Quantity: \t{timePhrase.Quantity:+0;-#}\t| Unit of time: {timePhrase.UnitOfTime}" );
				}
				catch ( Exception e ) {
					Console.WriteLine( "Time unable to be read." );
					Console.WriteLine( e.Message );
				}

				Console.WriteLine();
			}
		}
	}
}
