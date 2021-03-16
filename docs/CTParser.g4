parser grammar CTParser;

options { tokenVocab=CTLexer };

phrase_on
	: ON ' ' DAYOFWEEK
	;

phrase_in
	: MONTH
	;

