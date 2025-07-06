=== balco_verd ===
Green on green? Bold choice.
* [<i>Look at the plants.</i>] These plants look beautiful. They're thriving!
-> thriving
* [<i>Look at the building.</i>] The houses are quite cute.
-> cute_house

= thriving
* {terrat_plantes} [Like the terrace...] There's not as much space as that terrace I saw, but they look great. Even potted!
~raise(cheerful)
* {not dead_plant} [Could be a place for advice.] I should get this person's advice to keep plants as lush as theirs. I don't want to kill one again.
~lower(fun)
* [They seem cherished.] They must be so well taken care of... I could use some of that care, too.
~raise(reflective)
~lower(cheerful)
~lower(fun)
* [It's a long terrace...] So cute, they're in a row one after the other. Like friends! Adorable...
~raise(fun)
- -> conclussion

= cute_house
But these colours...
* [They're too much.] Why so much colour? I could never live in a house that bold. "Look at me!" No, thanks.
~lower(fun)
* [They're nice.] Actually, I'd love to have a green house. It looks great even after the sun degrades it.
~raise(fun)
- -> conclussion

= conclussion
I should stop staring at this person's balcony, tho. It's starting to get weird.
-> DONE
