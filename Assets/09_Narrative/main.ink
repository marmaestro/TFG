INCLUDE functions/swing.ink

INCLUDE places/A - carrer-sant-blai.ink
INCLUDE places/B - terrat-casetes.ink
INCLUDE places/C - cafe-artistes.ink
INCLUDE places/D - fruiteria.ink

INCLUDE places/K - carrer-ample.ink





VAR fun = INITIAL_SWING // sad
VAR cheerful = INITIAL_SWING // depressed
VAR reflective = INITIAL_SWING // it's own thing

VAR its_a_pub = false
VAR visited_carrer_ample = false

Something, something, something...
-> terrat_casetes

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
