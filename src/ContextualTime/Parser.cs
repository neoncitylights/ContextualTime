using System;

namespace ContextualTime {
	public class Parser {
		private const string TokenYesterday = "yesterday";
		private const string TokenTomorrow = "tomorrow";
		private const string TokenToday = "today";
		private const string TokenOn = "on";
		private const string TokenNext = "next";
		private const string TokenLast = "last";

		public TimePhrase Parse( string input ) {
			string[] words = input.Trim().Split(' ');
			return words[0].ToLowerInvariant() switch {
				TokenTomorrow => new TomorrowPhrase(),
				TokenYesterday => new YesterdayPhrase(),
				TokenToday => new TodayPhrase(),
				TokenOn => new OnPhrase( Enum.Parse<DayOfWeek>(words[1],true) ),
				TokenNext => GetNewPhrase(words),
				TokenLast => GetLastPhrase(words),
				_ => new TodayPhrase()
			};
		}

		private string NormalizeEnPluralUnit(string unit) =>
			unit switch {
				"centuries" => "century",
				"millennia" => "millennium",
				_ => unit[^1] == 's' ? unit[..^1] : unit
			};

		private NextPhrase GetNewPhrase(string[] words) {
			return words.Length == 3
				? new NextPhrase(
					Int32.Parse(words[1]),
					Enum.Parse<UnitOfTime>(NormalizeEnPluralUnit(words[2]), true))
				: new NextPhrase(Enum.Parse<UnitOfTime>(NormalizeEnPluralUnit(words[1]), true));
		}
		
		private LastPhrase GetLastPhrase(string[] words) {
			return words.Length == 3
				? new LastPhrase(
					Int32.Parse(words[1]),
					Enum.Parse<UnitOfTime>(NormalizeEnPluralUnit(words[2]), true))
				: new LastPhrase(Enum.Parse<UnitOfTime>(NormalizeEnPluralUnit(words[1]), true));
		}
	}
}
