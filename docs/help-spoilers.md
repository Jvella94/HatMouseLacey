# THIS FILE CONTAINS SPOILERS

Read at your own risk.

Broadly, spoilers get more damaging as you scroll.

...

...

...

...


## I can't find Lacey. What is her schedule?

Most days, she is in her cabin or on the big island in the river nearby. (*If
Stardew Valley Expanded is installed, she stays on the west/northwest bank of
the river instead of using the big island, to avoid Andy's house*)

On Tuesdays, she goes shopping at Pierre's.

On Fridays, she visits town, then goes to the saloon.

If the Community Center is rebuilt, then on Wednesdays she goes there to use
the crafts room, then visits the saloon before going home.

On rainy days, or in winter, she stays in her cabin all morning, then goes to
the saloon for the evening.

She visits the Night Market on Winter 15 *and* Winter 17.

On Summer 20 (the first day of the Trout Derby), she watches near the stall
for a few hours, then returns to the area near her cabin.

During the Year 1 Green Rain event, she does not leave her cabin. This makes
her inaccessible for the day if you don't have 2 hearts with her.


## Something is wrong with the Forest map around Lacey's house.

This mod adds a SMAPI console command `hatmouselacey map_repair`. Try running
that in your SMAPI terminal and see if that helps (this function runs itself
automatically if needed, so it shouldn't be necessary to do this).

If it still looks wrong to you, please open a ticket so I can take a look at
the problem. Please provide your mod list and a screenshot if you do this.


## How do I trigger Lacey's heart events?

* *2 hearts*\
Enter her house when she's there.
* *4 hearts*\
Enter the saloon when she's there.
* *6 hearts*\
Enter the forest on a sunny day when she's there.
* *8 hearts*\
Enter town when she's there.
* *(the secret event)*\
After receiving a letter with instructions to this effect, enter town between
12 noon and 1 pm.
* *10 hearts*\
After receiving an invitation, enter her house after 8 pm when she's there
(not on a festival day).\
Unfortunately, this event is missable if you marry Lacey before seeing it; her
marriage schedule never takes her to the house at a suitable time. I plan to
address this in the future.
* *14 hearts*\
Enter the bus stop *from town* on a sunny day, not in winter, between 3 pm
and 6 pm.


## What about the crossover events?

* with *Mouse Friends in the Forest*\
After reaching 4 hearts with Lacey, enter the forest on a sunny day when she's
there and Bow Mouse is tending to her junk shop. Beanie Mouse is part of the
event, but does not have to be at the shop to trigger it.
* with *Fievel Goes East Scarp*\
After reaching 1 heart with Lacey and 1 heart with Fievel, enter town on a
sunny day when Lacey is there. **Not available after seeing Fievel's 10-heart
event**.


## What are Lacey's gift tastes?

* **Love**: Morel, Fiddlehead Fern, Radish, Artichoke, Coffee, Cheese
* **Like**: Wheat, Corn, Rice, Unmilled Rice, Hardwood, *Fruits*, *Vegetables*, *Edible Mushrooms*
* **Neutral**: *Gems*, *Seeds*
* **Dislike**: Juice, Rabbit's Foot, *Alcoholic Items*, *Milks*, *Animal Products*
* **Hate**: none

These are her specified tastes. Anything not listed uses the Universal taste
lists.


## Why isn't Lacey commenting on my hat?

You have to see her 2-heart event first, which enables the feature and gives
you a quest to try it out (it is safe to skip the event; you will get the flag
and the quest anyway).

If you have enabled "Mark Unseen Hats" in the mod config, hats you haven't
gotten commentary on yet will be displayed with a little icon of Lacey's face
(this works on hat items, but not with Fashion Sense). Once you show her a hat,
the icon will no longer be displayed.

Lacey will comment on each hat only once, but whenever the mod updates, she
will automatically forget any newly-supported hats, so don't worry about
permanently missing out on any lines; you will get another chance to see them.

You can examine the hat registry in Lacey's house (or in her spouse room, if
you have married her) to see which hats you have shown her and replay the
commentary she gave you.


## Help! I messed up my ChildPolicy and I got the wrong kids!

First, if your child has not yet arrived (it hasn't been born or dropped off),
it is not too late. The game will check again when the baby arrives to see
whether it's biological or adopted and (if necessary) who the mother is; so,
until then, you can safely change the ChildPolicy value to control whether your
children will be mice.

Second, **if you are using Unique Children**: that mod reimplements child
rendering, so if you want mouse children, you will have to find the baby and
toddler images in this mod's files and put them manually inside Unique
Children's folder so it can display them. See that mod's instructions for
details; I can't provide any more support than that.

Third, if it is indeed too late and you have the wrong species of child, this
mod includes a console command which you can use to change your kids. In the
SMAPI console window, type `hatmouselacey mousify_child <child's name>
<number>` and press Enter to run it. This will transform your child permanently
(but you can always run it again). This doesn't change the child's gender or
age, just its mouseness.

Specify the `<number>` for the child you want:

* `-1`: not a mouse (disable child sprite modification)
* `0`: gray mouse child
* `1`: brown mouse child

More colors may be added in the future.


## Is that a reference to...?

Here's a list of intentional references to other media:

* *"But how can we know for sure unless we try for ourselves?"*\
This is Maduin's line from Final Fantasy 6.
* *"Winter may be beautiful, but don't freeze!"*\
Toad (of *Frog and Toad*) says a line like this ("... but bed is much better.")
in *Frog and Toad All Year*.
* *"I wish I were a little bit taller."*\
[I wish I was a baller.](https://www.youtube.com/watch?v=cmXZOI7cM0M)
I wish I had a girl who looked good, I would call her.
* *"Those are supposed to protect you from radiation, right?
... Do they work?"*\
*The Simpsons*, S07E02: ["The goggles do nothing!"](https://frinkiac.com/caption/S07E02/966381)
* *"Hmm. Looking for wabbits?"*\
Elmer Fudd.
* *"Ooh, imagine a ghost having that instead of a head. Spooky!"*\
This is about the Headless Horseman wielding a jack-o'-lantern.
* *"You look like a cultist. Don't start caw-cawing or anything weird like
that, okay?"*\
The Cultist enemy (and headpiece!) in [Slay the Spire](https://www.megacrit.com/)
says "ca-caw!"
* *"I have to say, you look a little ridiculous. Are you going to take off and
fly around?"*\
Calvin's [propeller beanie](https://assets.amuniversal.com/4753ecc0deca013171a6005056a9545d).
* *"Is that tuna I smell? Or maybe it's salmon..."*\
Hobbes.
* *"Scurvy! Man the cannons!"*\
*Dodgeball* (2004) "... Steve? Steve the pirate. Scurvy!"
* *"Looking at this hat makes me hungry for spinach."*\
Popeye.
* *"Doesn't it make you feel merry?"*\
Robin Hood (and his merry men).
* *Quest title "Hats for the Hat Mouse"*\
[Blood for the Blood God](https://knowyourmeme.com/memes/blood-for-the-blood-god)
(*Warhammer 40k*).
* *"But one does want a hint of color."*\
[*The Birdcage* (1996)](https://www.youtube.com/embed/N-CVGYw8ST4?start=144&end=154).
* *"Watch out everyone, it's the Puzzler!"*\
[This gag](https://www.youtube.com/embed/qxNsRo4eYuA?start=9&end=13) from *Batman Forever* (1995).
* *"Don't expect me to ask for milk, though."*\
*If You Give a Mouse a Cookie* (1985).
* *"That's a little strange, isn't it?"*\
This is one way you could translate Bulbasaur's Japanese name, *Fushigidane*.
* *"Oh, to be a rodent in an open-air bath with an orange on my head."*\
[One of the capybara orange posts](https://i.kym-cdn.com/photos/images/original/002/194/531/8b4.jpg).
* *"Any questions? Of course not!"*\
[Helvetica - The Movie](https://www.youtube.com/embed/ka2a4_jvB8k?start=8&end=19)
* *"You really are fond of showing her your hats, aren't you? If I didn't know better, I'd think you had feelings for her. Oh no, dear me. Pretend you didn't hear that."*\
Solaire of Astora, *Dark Souls* (2011).

And here are some intentional gags at Stardew Valley's expense:

* *"Sometimes I feel like I'm running out of new things to say."*\
This is about being a video game character with limited available dialogue
options. You are bound to get repeats eventually.
* *"I'm pretty sure someone's spiked [the fruit punch] before."*\
It was Pam.
* *"Have you figured out how they decide on the flower queen? Nobody will tell
me the rules."*\
The actual rule is "it's Haley, if she's dancing", but also it's not really a
thing.
* *"This town has a strange definition of 'potluck'."*\
I, the author, am delivering this line.
* *"There are some angles where I can't even tell you're wearing it."*\
This is poking fun at Abigail's default sprite, which wears a hair bow, versus
Abigail's default portrait, which omits it.


## I got Lacey to 8 hearts and tried to give her a bouquet, but she turned me down. What gives?

This is the trigger for the secret event. Lacey is mad at you for saying some
mean things to her in her heart events.

Go get a good night's sleep. You'll feel better in the morning.


## How do I find the secret notes you added?

You'll know a secret note is available to find when its outline appears in the
Secret Notes tab on the Collections menu. They can appear anywhere that vanilla
secret notes do (i.e. anywhere except on Ginger Island), and by doing the same
actions (digging, chopping, mining, fishing, killing monsters).

Here are the conditions for availability (but note that each one only becomes
available on **the next day** after meeting the conditions):

* #1: after reaching 6 hearts with Lacey
* #2: after reaching 7 hearts with Lacey, and after finding #1
* #3: after reaching 8 hearts with Lacey, and after finding #2
* #4: after reaching 8 hearts with Lacey, and after finding #3

You will need to have my [Secret Note
Framework](https://github.com/ichortower/SecretNoteFramework) installed.
Without it, they won't be added to the game.


## What happened to Lacey's family?

They died in an unspecified tragedy a number of years ago. Only Lacey survived.

I may specify the tragedy in the future. For now, you may substitute your own
version.


## Why aren't there any other mice?

This is explained (obliquely) in the four "Forgotten Diary" secret notes that
I added in version 1.3.0. Here's a plain-language summary:

Lacey's parents were human thieves who had worked together for years. Their
final mark was a very wealthy recluse who turned out to be a vengeful wizard;
he caught them and cursed them, transforming them into humanoid mice.

They were distraught for a time, but soon enough she convinced him (and
herself) to assume a new name and leave their old life behind. They married and
had two daughters (both mice): Lacey is the younger.

They concealed the truth from the girls, and died suddenly without having told
them, so Lacey never found out. As the product of a unique curse, her parents
were a unique type of humanoid mouse; Lacey is now the only one.
