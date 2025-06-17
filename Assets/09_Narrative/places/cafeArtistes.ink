=== cafeArtistes ===
Oh, a café...
* Why is it closed[?] on a weekend at this time of day?
-> closed
* What a beatutiful front[.]... I wonder how it is on the inside.
-> front
* [It's so quiet.]
-> quiet

= closed
* [No one visited.] Maybe they had to close because no one visited...
~lower(fun)
* [It's a pub...] Forget it, it's a pub! What a funny name for a place like this.
~elevate(fun)
~its_a_pub = true
- -> conclussion

= front 
* [<i>Peek.</i>] <i>They try to peek inside.</i> Oh... I can't see anything!
~lower(reflective)
* [<i>Stare at the plant.</i>] I bet the inside is full of plants, too. 
~raise(cheerful)
- -> conclussion

= quiet
<i>They stay still for a few seconds. Deep breaths, taking everything in...</i> This street is so quiet. Even if it's in the middle of the city.
~elevate(reflective)
* [What about hanging out here?] This must be a nice place to hang out, seeing its surroundings. I must first find someone to come with, though.
~lower(cheerful)
* [Do I have anyone to come here with?] This must be a cool place to find someone to hang out with, right?
~raise(fun)
- -> conclussion

= conclussion
I should come sometime and grab a drink. -> next
