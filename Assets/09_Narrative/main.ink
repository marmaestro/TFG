INCLUDE places/cafeArtistes.ink
INCLUDE functions/swing.ink
INCLUDE places/fruiteria.ink


VAR fun = INITIAL_SWING // sad
VAR cheerful = INITIAL_SWING // depressed
VAR reflective = INITIAL_SWING // it's own thing

VAR its_a_pub = false

Something, something, something...
-> fruiteria

=== next ===
I'm <>
	{ 
	- up(fun):
		funny 
	- down(fun):
		sad 
	- else: 
		undecided 
	} 
	<>, <>
	{ 
	- up(cheerful):
		cheerful 
	- down(cheerful):
		depressed 
	- else: 
		undecided 
	} 
	<>, and <>
	{ 
	- up(reflective):
		reflective 
	- down(reflective):
		plain 
	- else: 
		undecided 
	} 
	<>.

-> END
