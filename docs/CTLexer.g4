lexer grammar CTLexer;

// Prepositions
AT:        'at';
IN:        'in';
ON:        'on';
THIS:      'this';
FROM:      'from';
LAST:      'last';
YESTERDAY: 'yesterday';
TOMORROW:  'tomorrow';
TODAY:     'today';
NOW:       'now';
AFTER:     'after';
BEFORE:    'before';
UNTIL:     'until';
TILL:      'till';
LAST:      'last';
NEXT:      'next';

// Days
MONDAY:    'Monday';
TUESDAY:   'Tuesday';
WEDNESDAY: 'Wednesday';
THURSDAY:  'Thursday';
FRIDAY:    'Friday';
SATURDAY:  'Saturday';
SUNDAY:    'Sunday';

DAYOFWEEK
	: MONDAY
	| TUESDAY
	| WEDNESDAY
	| THURSDAY
	| FRIDAY
	| SATURDAY
	| SUNDAY
	;

// Months
JANUARY:   'January';
FEBRUARY:  'February';
MARCH:     'March';
APRIL:     'April';
MAY:       'May';
JUNE:      'June';
JULY:      'July';
AUGUST:    'August';
SEPTEMBER: 'September';
OCTOBER:   'October';
NOVEMBER:  'November';
DECEMBER:  'December';

MONTH
	: JANUARY
	| FEBRUARY
	| MARCH
	| APRIL
	| MAY
	| JUNE
	| JULY
	| AUGUST
	| SEPTEMBER
	| OCTOBER
	| NOVEMBER
	| DECEMBER
	;

// Seasons
WINTER:   'winter';
SPRING:   'spring';
AUTUMN:   'autumn' | 'fall';
SUMMER:   'summer';

SEASON
	: WINTER
	| SPRING
	| AUTUMN
	| SUMMER
	;

// Time
AM: 'ante meridium' | 'AM' | 'A.M' | 'a.m';
PM: 'post meridiem' | 'PM' | 'P.M' | 'p.m';
PERIOD: AM | PM;
