=== terrat_plantes ===
Oh, look at this terrace... Beautiful.
* [<i>Focus on the plants.</i> #green] It's full of plants, so much green!
-> green
* [<i>Focus on the terrace.</i>#unkept] The place looks a little unkept, though.
-> unkept


= green
* [Oh, to be a plant...#green_0] I wish I could grow without a care, too.
Just basking in the sun...
Well. Maybe not looking <i>into</i> the sun. But, to enjoy the soft wathm... Not a thought...
~raise(reflective)
~lower(fun)
* [And to keep them so beautiful, too...#green_1] I wish I could keep plants that lush.
The last one I owned drowned, the poor thing...
~dead_plant = true
I can barely keep myself alive and goind.
Why am I acting so surprised?
~lower(cheerful)
- -> conclussion

= unkept
* [But the plants look nice...#unkept_0] Wait, is that why the plants grew like that?
They look way too good to not be cared of.
~lower(reflective)
* [Maybe there's not enough time for it.#unkept_1] It must be that house's terrace.
It's quite unkept, yes, but the plants look good.
I get it. In survival mode, being alive comes before keeping appearances.
~raise(reflective)
~lower(cheerful)
- -> conclussion

= conclussion
I should take care of myself, too...
At least I'm seeing some sun.
-> DONE
