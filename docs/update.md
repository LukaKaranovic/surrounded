# CSCI 265 Project Update (Phase 4)

## Team name: We Haven't Decided

## Project/product name: Surrounded

## Contact person and email

The following person has been designated the main contact person for questions from the reader:

 - Connor McDermid, mcdermidc@stumail.viu.ca

## Key revisions since phase 3

Nothing massive was changed since phase 3. Most of the changes were small and were included to either fill in gaps, to be consistent with information across documents, or to be consistent with changes made in our actual game.

### Changes and updates to the standards and processes (standards.md)

* Added a line that discusses our new `archived/` subdirectory in `docs/`, which is where we keep old documents that aren't useful anymore.
* Updated list of documents to be maintained to include phase 4 documents.

### Changes and updates to the product requirements (requirements.md)

* Added subsections of "Key features and behaviour" section to the table of contentes, and numbered the table of contents for ease of reference.
    * Note: Didn't add subsections of "User interface and navigation" section to the table as the list of figures already links to every section already.
    * Other sections we felt weren't long enough to warrant adding their subsections to the table of contents.
* Changed how collisions between enemies and players work so it scales with the game better.
* Changed asteroid's health so it scales with the player.
* Made numerous changes to the "Map and Terrain" subsection of the "Key features and behaviour" section to match our evolving plan with the map.
* We felt high values of speed became uncontrollable, so we set a cap to player speed (also updated base defense stat).
* We reduced the length of each round to 55 seconds because we felt 105 seconds was way too long, and didn't allow for interesting (and chaotic) enough gameplay.
* Made changes to items and their stat values a bit.
* We realized we were super vague about how score was counted in our requirements, so we fixed this by adding concrete values to score (and a calculation).

### Changes and updates to the logical design (logicaldesign.md)

* Added information about asteroids that wasn't included before
    * Asteroid data is in enemy module, asteroid spawning is in round module.
* Added information about background and world boundary that wasn't included before
    * Background and world boundary is held in game control module.
* Added more information about bosses to design (mainly wording to include them) now that we know more about them.
* Added a description for ERD (was feedback for phase 3).
* Added further explanation to data design section.
* Added parts about sound data and asteroid data (in map data) to data design.
