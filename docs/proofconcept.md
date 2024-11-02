# CSCI 265 Design Document (Phase 4)

## Team name: We Haven’t Decided 

## Project/product name: Surrounded

## Contact person and email address

- Connor McDermid, mcdermidc@stumail.viu.ca

## Table of Contents

1. [Core technical challenges](#challenges)
2. [Approach to meet each challenge](#approach)
3. [Assets produced to meet challenges](#production)
4. [Results of proof of concept and implications](#results)

## <a name="challenges"></a> 1. Core technical challenges.

In this section we outline our four major technical hurdles the team expects to encounter when trying to complete the game:

* Bosses and boss rounds 
* Making enemy behaviour (AI)
* World boundary
* Advanced item implementation

Each of the issues listed are issues because we haven’t thought deeply about how we are going to implement these areas (no pseudocode/algorithms), unlike the round system where we did. Additionally, we need a lot of sprites to implement these parts of our game, which takes a lot of time. More specifically for enemies and bosses, we have a lack of experience with programming any sort of AI to dictate their behaviour.

* **Bosses and boss rounds**: Implementing boss round conditions, UI elements such as health bar, the moveset of bosses, and how their attack patterns will work.
* **Making enemy behaviour (AI)**: Making sure each enemy feels unique, and that their behaviour is consistent with their design (as per requirements).
* **World boundary:** Implementing the world boundary and the asteroid belt as one object, while having our asteroid belt deal damage. 
* **Advanced Item Implementation:**: Implementing less straight-forward items such as forcefield and roulette, and implementing item stacking features.

We will be tackling each of the four problems above individually. Section 2 will discuss the approaches to address each challenge individually. Section 3 will provide the necessary sprites, pseudocode, or algorithms needed to perform live demos of the proof of concept. Our results and implications of the proof of concept will be discussed in section 4.

## <a name="approach"></a> 2. Approach to meet each challenge

Here we will discuss each individual approach used to solve our current issues addressed in Section 1. The issue of wrapping every issue together will be discussed in section 4.

### 2.1 Bosses and Boss Rounds: 
Approach: 
* Create a new scene that implements the rules of boss rounds when boss round conditions are met.
* Implement a unique health bar for bosses.
* Create code for each of the boss’s unique attacks, and an array that holds each boss attack.
* Create a function where each attack is randomly selected from the array to create an unpredictable pattern while still getting a spread of all the attacks.

### 2.2 Enemy Behaviour (AI): 
Approach: 
* Create unique movement algorithms for each individual enemy type to match the requirements.
* Create unique attacking algorithms for each individual enemy type to match the requirements.

### 2.3 World Boundary: 
Approach: 
* Create an asteroid belt, a new unique object that is fixed and used to keep the bounds of the map.
* Implement a system for players, asteroids, and enemies to take damage upon contact with the boundary.
* Implement deadzones so that enemies and asteroids don’t spawn outside of the world boundaries.

### 2.4 Advanced Item Implementation: 
Approach: 
* Creating new unique code and sprites for more advanced items (such as forcefield, roulette) to give them unique properties unlike basic items (such as rocket boosters, machine guns, etc.)
* Working out a consistent system for the stacking of all items.

## <a name="production"></a> 3. Assets produced to meet challenges

We will be creating a proof of concept branch named `PoC`. Since we have already developed a good portion of our game, each of the demos will start off of the base game with all of the basic features implemented. The base game will be changed to implement the technical challenge and to illustrate the changes.

The `PoC` branch will hold a single executable game file named `surrounded.exe` that brings you to the main menu with options for each of our four technical challenges. The options are outlined below:

* Bosses: Sends you to the boss round scene and provides a demo of a boss round with a boss fight.
* Enemies: Sends you to the base game with a demo of the updated enemy behaviour.
* World Boundary: Sends you to the base game with a demo of the asteroid belt world boundary in place.
* Items: Sends you to the base game with a demo of advanced items (such as roulette and forcefield) implemented and item stacking for all items.
* Quit: Closes the executable.

### 3.1: Bosses and boss rounds (In C#)

The demo will be playable through the ‘Bosses’ option of the main menu. The runtime behaviour of the demo will:
* Send you into the boss round scene on round 1, implementing the rules of boss rounds
* Spawns a demo of our round 20 boss C0B-U5, with lowered stats as the player is level 1.
* The boss demo will contain only C0BU5 as a floating sprite, if development of the boss finds more success, the boss demo will also feature a move which was stated from our requirements document.

The implementation of this proof of concept can be found in a script called C0BU5.cs found in the enemy module directory and be accessible within a scene called boss.
It updates based on round module counter
C0BU5.cs will carry data for interactions, movesets, and functionality
BossBar.cs will update along with the UI in assets and give new overlays under the player health bar
Enemy modules are updating as we inherit specific vectors and inheriting from the module, we will be grabbing data from this module to update the boss.

### 3.2: Enemy behaviour (AI) (In C#)

The demo will be playable through the ‘Enemies’ option of the main menu. The runtime behaviour of the demo will:
* Send you into the game on round 1, gives the player 1000 health (so they don’t die instantly).
* 5 seconds in, spawns one grunt with new behaviour
* 10 seconds in, spawns one viper with new behaviour
* 15 seconds in, spawns one juggernaut with new behaviour
* 20 seconds in, spawns one striker with new behaviour
* 25 seconds in, spawns one dreadnought with new behaviour

All of the files data can be found within the EnemyController.cs and will be found in our scripts folder. This scene will be denoted as 'Enemies’ in our scenes list as well.

The data for the spawn rates and spawn decisions will be dictated in Spawns.cs and will inherit data from the round module.

### 3.3: World boundary (In C#)

Originally, we intended to have an asteroid belt surround the map to indicate a boundary, the functionality of this was originally conceptualised as follows:
*Have the game load and player goes to outer regions of the map to find a field of asteroids which the player cannot move past.*

However, after some design changes and group meetings we decided to approach this problem of out of bounds differently, instead we did this approach:
* Loads the base game in round 1, everything is the same except there is now a new feature for a comet to chase and kill the player 5 seconds after being out of the map bounds.
    * Note: Text will appear on the screen stating that the player is out of bounds and needs to get within bounds again in 5 seconds (the number of seconds will countdown to 0).

The world boundary detections and implementations will all be found in WorldBoundary.cs. All of the data referring to how comet interaction works is in a file which will be found in Comet.cs. 

All of these scripts are located in the 'Game Control' and 'Enemy' subdirectories in 'Scripts', with WorldBoundary.cs being in game control and Comet.cs being in enemy.

This does not mean we scrapped the idea of having the world boundary completely, but rather we have decided to use this approach/implementation as an alternative solution.

### 3.4: Advanced Item Implementation (In C#)

The demo will be playable through the ‘Items’ option of the main menu. The runtime behaviour of the demo will:
* Load the base game in round 1, giving the player roulette and forcefield automatically.
* The items at the end of the round will always have forcefield and roulette, the third item will be random. This is to show that stacking the items works as intended.
* Accessing the game from menu will load a scene which has been implemented in the main menu on the test case of the game

The implementations for all items will be found in PlayerController.cs which is under the 'Player' subdirectory in 'Scripts'. The prefabs and sprites can be found in the 'Assets' directory (for now).

## <a name="results"></a> 4. Results of proof of concept and implications

We have two sections concerning both our results and implications:
Results of our POC challenges on a rate of success.
how the team plans to address any remaining concerns (e.g. changes to the requirements and/or design, different approaches to the implementation, etc).
### 4.1: Results
The results for each technical challenge in our proof of concept were: 

**Bosses - somewhat successful**
We got the boss round conditions to work (camera lock, UI, etc.) to work, but no boss attacks or movement for the boss has been implemented yet. We also got boss sprites for one boss, but there are some errors with attaching them together.

**Enemies - somewhat successful** 
We got two distinct enemy behaviour patterns working - one that charges the player and one that orbits the player and shoots at them. The other 3 enemies have variations of these two patterns for now.

**World boundary - unsuccessful** 
We couldn’t implement the world boundary the way we wanted (with the asteroid belt). We mainly failed this because we didn’t know how to make an asteroid belt object without having a ton of entities loaded all of the time making the game laggy. We decided to do an alternative method, using a message warning and a comet that strikes you when going out of bounds, which is implemented in our proof of concept branch.

**Items - completely successful** 
Both forcefield and roulette work as intended and stack properly. I believe at this stage all items have been implemented successfully and stack properly. The only thing that may change about them is where their code is stored, as right now it is stored in the ‘PlayerController’ script.

### 4.2: Implications

The proofs-of-concept above have given us a good idea of which things can and cannot be achieved by the end of the term realistically. It convinced the team that:

* Boss features may need to be scaled down (less complex attacks)
* Unique enemy behaviour for all enemies will be difficult but is realistic to achieve by the end of the term.
* The world boundary idea we had before was too difficult to implement, and a much simpler system has taken its place (will update docs for this in phase 5).
* We have gotten items to work as intended successfully.

**Which concerns did it address (from section 1)?:**

The boss demo successfully addressed implementing boss round conditions and UI elements as we achieved that goal in our demo. It did not address our concerns of implementing the moveset of bosses, or how their attack and movement patterns will work, as we didn’t get that far into implementation in our demo.

The enemy behaviour demo successfully addressed the concern of each enemy feeling unique, as fighting against the two types of patterns we implemented felt very different. It also showed that their behaviour is consistent with their design for the two that it did. It also addressed the concern of whether or not we can implement them all by the end of the term. We are relatively confident we can.

The world boundary demo addressed our concerns about making the asteroid belt and world boundary the same object. We realised this was too difficult and went with a different approach. 

The item demo successfully addressed all of our concerns regarding implementing the more complex items and whether or not they will work well with other parts of the game. This is because we implemented the items successfully and could test them on the base version of our game, where they worked as intended.

**Addressing remaining concerns:**

Our team held a meeting to discuss the remaining concerns listed above. We've decided that we will implement what we can for these concerns (trying to follow requirements, but altering it if needed), and then update the requirements/design documentation afterwards to match what we actually implemented. We decided to do this as changing the requirements/design of these things before implementing them may lead to having to update the documents way more than once if things don't go to plan (as we don't know what we can and cannot do, we cannot construct a specific backup plan as of yet). 

In general, our backup plans for these implementations will be simplified (easier to make) versions of what was described in the requirements, or any alternative features/concepts that we think would make the game more enjoyable than the current features.
* An example of the latter is that we have decided to stick with the new world boundary approach as it caused less issues, fit the game better, and made the game more enjoyable.
