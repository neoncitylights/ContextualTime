using System;
using System.Globalization;

namespace ContextualTime.Demo {
	public class Program {
		public static void Main( string[] args ) {
			Parser parser = new();
			while ( true ) {
				Console.WriteLine( "Type in a time phrase:" );
				string timePhraseString = Console.ReadLine();
				try {
					TimePhrase timePhrase = parser.Parse( timePhraseString );
					Console.WriteLine( $"┣ Current date/time:\t{DateTime.Now}" );
					Console.WriteLine( $"┣ Modified date/time:\t{timePhrase.GetAsDateTime().ToString( CultureInfo.InvariantCulture )}" );
					Console.WriteLine( $"┣ Quantity:     {timePhrase.Quantity}" );
					Console.WriteLine( $"┗ Unit of time: {timePhrase.UnitOfTime}" );
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
