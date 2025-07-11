===carrer_sant_blai===
Have I been here before? I don't quite remember.
* I love this kind of street[.#nice_street]...
Look at the houses, each its own thing. It's so nice here. 
-> nice_street
* Its colours[... #yellow], this yellow is everywhere, isn't it?
-> yellow
* [<i>Listen around.</i> #silence] It's so paceful, too. Not a noise.
-> silence

= nice_street
* [<i>Focus on the steet lamps.</i> #nice_street_0] How many are there?
One, two, three...
Thirteen!
They must look so cute with decorations hanging from them.
~raise(cheerful)
* [<i>Focus on the balconies.</i>#nice_street_1] And there's so much light!
Ah, I wish I had one of these to read outside and get some sun...
I wouldn't have to go out.
~lower(fun)
- ->conclussion

= yellow
* There are so many [colours... #yellow_0] subtle, warm colours in the streets of this city.
I guess this place is more welcoming that I make it out to be.
~lower(fun)
~raise(cheerful)
* [<i>Notice the light.</i> #yellow_1] The sun does a lot of the heavy lifting here.
It's like one of Sorolla's paintings.
~raise(fun)
* {not carrer_ample} It's so cozy[... #yellow_2]. So many places feel like a little town, it's so cute.
~raise(cheerful)
- ->conclussion

= silence
* [Living here... #silence_0] I wouldn't mind living in a quiet street like this.
I don't think I'd get any lonlier, anyway.
~lower(cheerful)
* [<i>Listen closer.</i> #silence_1] I can even hear sparrows.
Although I don't see any.
Where are they?
~lower(fun)
~raise(cheerful)
- ->conclussion

= conclussion
Well, the city isn't so bad after all, is it?
-> DONE