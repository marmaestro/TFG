INCLUDE functions/swing.ink


INCLUDE places/A - carrer-sant-blai.ink
INCLUDE places/B - terrat-casetes.ink
INCLUDE places/C - cafe-artistes.ink
INCLUDE places/D - fruiteria.ink
INCLUDE places/E - forn-tancat.ink
INCLUDE places/F - estatua.ink
INCLUDE places/G - terrat-plantes.ink
INCLUDE places/H - balco-verd.ink
INCLUDE places/I - antics-negocis.ink
INCLUDE places/J - terrat-nau.ink
INCLUDE places/K - carrer-ample.ink
INCLUDE places/L - estany.ink
INCLUDE places/M - fruiteria-mercat.ink











VAR fun = INITIAL_SWING // sad
VAR cheerful = INITIAL_SWING // depressed
VAR reflective = INITIAL_SWING // it's own thing

VAR its_a_pub = false
VAR visited_carrer_ample = false

Something, something, something...
-> estatua

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
