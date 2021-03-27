using System;
using Spectre.Console;

namespace ContextualTime.Demo {
	public class Program {
		public static void Main() {
			Parser parser = new();
			while ( true ) {
				Console.Write( "Type in a time phrase: " );
				string timePhraseString = Console.ReadLine();
				try {
					TimePhrase timePhrase = parser.Parse( timePhraseString );
					DateTime timePhraseDt = timePhrase.GetAsDateTime();
					GetDetails( timePhrase, timePhraseDt );
					GetCalendar( timePhraseDt );
				}
				catch ( Exception e ) {
					Console.WriteLine( "Time unable to be read." );
					Console.WriteLine( e.Message );
				}

				Console.WriteLine();
			}
		}

		private static void GetDetails( TimePhrase timePhrase, DateTime timePhraseDt ) {
			Console.WriteLine( $"┣ Today: {DateTime.Now:f}" );
			Console.WriteLine( $"┣ Then:  {timePhraseDt:f}" );
			AnsiConsole.MarkupLine( $"┣ This date happens in the [bold]{timePhrase.Tense.ToString().ToLowerInvariant()}[/]." );
			Console.WriteLine( $"┣ Quantity: \t{timePhrase.Quantity:+0;-#}" );
			Console.WriteLine( $"┗ Unit of time: {timePhrase.UnitOfTime}" );
			Console.WriteLine();
		}

		private static void GetCalendar( DateTime timePhraseDt ) {
			var calendar = new Calendar( timePhraseDt.Year, timePhraseDt.Month );
			calendar.AddCalendarEvent( timePhraseDt.Year, timePhraseDt.Month, timePhraseDt.Day );

			calendar.HighlightStyle( Style.Parse( "turquoise2 bold" ) );
			calendar.HeaderStyle( Style.Parse( "turquoise2 bold" ) );
			calendar.Border = TableBorder.Rounded;
			calendar.BorderStyle( Style.Parse( "turquoise2" ) );
			calendar.Alignment = Justify.Center;

			AnsiConsole.Render( calendar );
		}
	}
}
