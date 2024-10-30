# CSCI 265 Design Document (Phase 3)

## Team name: We Haven’t Decided 

## Project/product name: Surrounded

## Contact person and email address

- Connor McDermid, mcdermidconnor@outlook.com

## Table of Contents
1. [Known Issues](#issues)
1. [Overview](#overview)
1. [Core Design Influences](#core)
1. [System Context](#syscon)
1. [Architectural Design](#arch)
	1. [Game Control Module](#archgcm)
		1. [Description](#archgcmdesc)
		1. [Initial Setup](#archgcminit)
		1. [Game Logic Processes](#archgcmproc)
		1. [The End Game Process](#archgcmend)
	1. [UIX Module](#uix)
		1. [The Input Process](#uixin)
		1. [The Output Process](#uixout)
		1. [Menu Navigation Map](#uixmenu)
	1. [Round Module](#roundmod)
		1. [Description](#roundesc)
		1. [Round Initialization Process](#roundinit)
		1. [Round Progression processes](#roundprog)
		1. [Boss Round Logic](#roundboss)
		1. [Round Transition Process](#roundtrans)
		1. [Game State and End Round Detection](#roundend)
		1. [Round Module Interaction Overview](#roundint)
	1. [Player Module](#play)
		1. [Responsibilities](#playmod)
		1. [Player Data Structure](#playdata)
		1. [Player Actions and Updates](#playact)
		1. [Player Interaction](#playint)
		1. [Player Initialization and Setup](#playset)
	1. [Enemy Module](#enemy)
		1. [Responsibilities](#enemyresp)
		1. [Enemy Data Structure](#enemydata)
		1. [Player Actions and Updates](#enemyact)
1. [Data Design](#data)
	1. [Player Data](#dataplay)
	1. [Enemy Data](#dataenemy)
	1. [Boss Data](#databoss)
	1. [Game Logic Data](#datalog)
		1. [Player Ship Data](#dataship)
		1. [Enemy Ship Data](#dataenship)
		1. [Item Upgrade Data](#dataup)
		1. [Round Data](#dataround)
		1. [Boss Ship Data](#databship)
		1. [Map Data](#datamap)
		1. [Display Data](#datadis)
	1. [Logical Entity Relation Diagram](#logerd)
1. [Game State and Flow](#gamstat)
1. [Transition to Physical Design](#phys)
	1. [Implementation Decisions](#physim)
	1. [Object Model](#physobj)
1. [Appendix](#appendix)

## List of figures
[Figure 1. Context Diagram](#condiag)  
[Figure 2. Game Control Module Diagram](#gcmdiag)  
[Figure 3. UIX Module Diagram](#uixdiag)  
[Figure 4. Menu Navigation Map](#menudiag)  
[Figure 5. Player Module Diagram](#playdiag)  
[Figure 6. Logical ERD](#erddiag)  
[Figure 7. Appendix Diagram](#appdiag)  

## <a name="issues"></a>1. Known Issues/Omissions

In this section we list any currently-known errors, omissions, or other problems with the rest of this design document.

1. Confusion on how we should start approaching our code base

2. How we will know how certain aspects of Unity engine will function

## <a name="overview"></a>2. Product Overview

In this document, we discuss the design of our game Surrounded. Our [requirements document](requirements.md) discusses these core features and our overall design perspective of the game. These core features are essential to our game and its overall design. These will be elaborated on in our core design section of this document.

The full vision for this game is essentially a single player experience, whereas it is launched and hosted locally by a singular player that interacts with AI opponents. The player is started in an open world filled with obstacles, where they are given basic movement abilities and a basic weapon to begin with. Here the player will engage in combat with the opposing enemies, who come in many different sizes and strengths and get increasingly more difficult as the game progresses. The design and function of the game is very simple: eliminate enemies, acquire upgrades, and repeat without dying.

There are several game features and mechanics whose design are essential and straight forward, our key ones are:

* Detection of player actions (movement, combat, opening menus)
* Handling of all menu systems, options and menu navigation (main menu, game over, main game hud, player stats and upgrades)
* Collision detection (obstacles, enemy collision)
* Sound representation (on-map and enemy interaction)
* Controlling and updating enemy AI (their movement and combat)
* Handling of XP and level system
* Handling of the round system
* Handling of the enemy spawning system (credits system)
* Handling of bosses and boss rounds
* Handling and storage of item and upgrade system
* Handling of random item generation system
* Handling of player statistics relative to upgrades (upgrades alter player)
* Detection/Handling of game-over situations (Game over menu presentation and ability to quit, restart)

## <a name="core"></a>3. Core Design Influences 

There are four core facets of the system we discuss here:

* An overall design methodology,
* The design implications of the round system and how it works,
* The general overview of the upgrade system,
* The design implications of the various objects and statistical design.

In terms of an overall design methodology, we wanted a 2D landscape with a restricted area with hordes of enemies. For a majority of game designers, this type of gameplay design is relatively common, and for the most part, easy to understand. We found that there were various game engines that could support implementation of the system (Godot and Unreal for example), but we ended up choosing Unity because of their built-in assets (such as built-in colliders and 2D physics engine). Overall, the other options had their pros too.

Some of our biggest overall design problems we’ve faced so far relate to uncertainty of the extent of how to implement systems and ideas. This is due to our lack of background with the engine and game development in general. Some of these uncertainties include:

- Unfamiliarity with C# as compared to C++
- Lack of foundation for implementing structures in game assets and features (such as enemy UI, floating objects in space, creating abilities, etc). 
- General ability to navigate the Unity engine fluently.

With respect to our first problem, we intend on using as many built in assets with the Unity engine. This will be our main crux for the issue of us not being as efficient programmers with C#, as we don’t see it as a necessity to be completely fluent with C#. With this unfamiliarity affecting every member of the team. We all agreed to help each other with the programming aspect of the project if needed. Each and every member of the team has the ability to give input on design and programming choices.

For our methodology, it’s foreseeable that there might be some confusion on programming the back-end side of the project. In our schooling, we have only focused on C++ so far, using an engine that is built using C# will definitely cause some confusion. This does not mean however that we should abandon our current learnt design principles we’ve acquired from other classes so far here.

With respect to our second and third problems, after a bit of research on abstractable content and discussion of our GitHub branch system, the team has decided our main methodology was doing smaller implementations from whatever resources we could find (YouTube tutorials, other documentation for similar past projects, etc) and discussing what is likely best for our system and what isn't using our current background in programming. This discussion will occur via our Discord and pull requests. We will also review each segment of code to assure proper conventions before adding each to main.

Due to this issue of a lack of background, we plan on having a resource page built into our Discord for our project, which we will use to gather as much knowledge from the landscape of game development using Unity. This fixes any sort of questions that might arise from working with our other teammates (eg. “What methodological procedure is best?” As well as “Where did you find this?”).

As mentioned above, one of our other challenges with the core design of the game will be our round system.

Our current philosophy of the round system is to have each round be 55 seconds, with the ending of each round destroying all current enemies which then features the prompt for the upgrade system (More details including the math and back-end philosophy are included in our [requirements document](requirements.md)).

To give a brief overview of the round system, it will feature a credit system wwhere the credit amount is dictated by the round number. While we have yet to have any background with implementing such features, the philosophy of our game plan for implementation of this feature will be dictated using a mathematical function and an array containing an ID and will run through a while loop. All of this will not be visible to the player, but this sort of implementation will be present in each round. The credit rate will be increased by each round to dictate greater enemy spawns. We plan on tweaking this to account for balance changes and any potential misalignment with how our code runs.

To address the current upgrade system, we plan on having an entirely separate UI overlay which will appear over our current gameplay loop. Our methodology for this is to reference objects from prior classes which hold each upgrade and use a switch case to determine which upgrade to select that will be added to the player. The implementation of this overlay has yet to be fully fleshed out and is still in early talks in terms of design philosophy. We will be using this switch-case like approach for the meantime as our current solution to how the back-end of the upgrade system could work as of right now. 

Finally, for our final facet implementation of our design of objects and statistical approaches we will be using a basic OOP class structure which will feature enemies, the player’s ship, and bosses as classes. All of the statistical elements such as enemy defense and player attacks will be already fleshed out in the class objects and will be updated based on upgrade. How each damage number is updated will be by conditions. An example of a condition could be if a ship's attack hits an enemy ship (collision) then subtract enemy health by the player attack function multiplied by an arbitrary number (however this is not finalized and is just a snippet of how functionality could theoretically work). As the game 
progresses, we expect the adjustment of enemy difficulty won't be dictated by enemy stats, but rather the amount of enemies that spawn in each round. This makes our difficulty align more with our game's philosophy on the player's challenge.

A majority of these design choices are not final and are subject to change. This is all due to the uncertainty of how to fully grasp Unity and our inexperience with game development. With that said, we will still remain confident in our project design and what any challenges could appear for us this term as game designers.

## <a name="syscon"></a>4. System Context

Based on a single player game and having round functionality, the diagram below will show how the game’s logical loop will function and how replayability will be handled.

Each interaction will feature a new UI for each decision made, and will follow boolean logic and other algorithms for progression of the system.

Figure 1. Context Diagram<a name="condiag"></a>
![Context Diagram](Images/condiag.png)

## <a name="arch"></a>5. Architectural Design

### 5.1:<a name="archgcm"></a> Game Control Module
The game control module works all from a local system, as everything is local and requires no network connection to work. The game control module is responsible for handling all in-play game logic. It is responsible for: 

* Responding to player input (mouse and keyboard input)
* Game status determination (Menu options, player death, application termination)
* Updating round data such as credit amount and number (communicates with round module) with due respect to game conditions (timer)
* Updating UI (communicates with UIX module) with due respect to game conditions (game pause, player death, round end)
* Updating player and enemy information based on player interaction (combat, collision)
* Updating player data based on game conditions (level up, upgrades), this communicates with our player module (and enemy module to get XP amount from enemies)

The game control module is our central system module that communicates with other modules such as: 

* UIX Module: controller module tells UIX when to switch scenes, display menus and overlays, update UI elements (XP bar, health, score and stats/upgrades menu), requests the map design, and all necessary sound and music.
* Round Module: controller module communicates with the round module by updating the credit amount and round number, alerting when to start boss rounds, and the in-game round timer to tell it when to spawn enemies.
* Player Module: controller module communicates with the player module to update the player's current health, XP, and score. Will also notify this module on the case of a level up to update player stats (speed, attack, defense, total health)
* The Enemy Module: controller module communicates with the enemy module to update current enemy health, current boss health, and to retrieve the XP amount from killing those entities. 

#### 5.1.1<a name="archgcmdesc">: Game Control Module Description

The game control module is responsible for the tracking of the current state of the player, the given input from the user, the control of enemies, all of objects and map information, round data, score, and all displayed UI and Menus, as well as the ability to detect game states such as boss rounds, game overs and pauses.

The core processes that are involved in the game module are:
1. Setup Process
2. Game Logic Process
3. End Game Process

The provided model below depicts the interactions of our game control module as it interacts with other modules and handles information given from user and other modules as the game progresses.

Figure 2. Game Control Module Diagram<a name="gcmdiag"></a>
![Game Control Module Diagram](Images/gcmdiag.png)

#### 5.1.2: <a name="archgcminit"></a>Initial Setup/Menu Process

The initial setup process begins upon execution of the game files, this where the title screen will be displayed and the player is given options to proceed before beginning with any gameplay. 

The anticipated sequence of events is:

1. User initializes game entering the setup process
2. Setup process display opening game menu
3. Player chooses to start a new game
4. Game Logic process is invoked


#### 5.1.3: <a name="archgcmproc"></a>Game Logic Processes

The game logic processes are responsible for moment-to-moment game control itself. All core gameplay actions and events are resolved here.

*This is a rough outline of the expected sequence of events, these are explained further in their respective subsections:*

User triggers start of gameplay from setup process, entering into the game logic process. All checks are repeated until End Game process is initiated.  

	1.  Start game boot-strap with 60 FPS lock  

	2. Generate the map, from map data which is stored in the game logic module

	3. Contact UIX Module for display of initial game UI and continue to update accordingly

	4. Contact Player Module for player stat and control information
		* Determine if player actions occur and update accordingly

	5. Contact round module for round and enemy spawn information
		* Determine round module for any changes in rounds according to game clock

	6. Contact enemy module for enemy stat and control information
		* Determine if enemy actions occur and update accordingly

	7. Resolve all Player/Enemy/Round/UIX updates
		* Apply any updates sent by any of the modules and reiterate loop constantly

	8. Check for game-over (either go back through loop or proceed to step 3)

Invoke End Game process

##### 5.1.3.1 Game Data Updates

In this section, we try to discuss all possible events/actions the game can recognize and respond to through user input. This information is as well shared with enemy AI which determines how they approach and interact with the player.

* Player Movement (WASD)
	* Omnidirectional movement through usage of WASD keys, player moves forward with W, backwards with S, and can move left and right with respective A and D.
	* New location and direction is updated with camera as it is fixed on player

* Pause Menu (ESC)
	* Opens pause menu, allowing access to Resume Game, Stats and Upgrades List, Quit game

* Player projectile fire and aim (Mouse Movement and Left Click)
	* Player fires projectile with left click which is aimed at position of cursor
	* Projectile is created, and assigned stats according to player module 
	* Projectile information is stored until expiry (collision, expired distance)

* Collisions
	* Between Player/Enemy:
		* Player and enemy both take 50 damage
	* Between Player/Asteroid:
		* Player takes 50 damage and asteroid gets destroyed
	* Between Enemy/Enemy:
		* Enemy takes 100 damage, damaging both enemies
	* Between Player/Asteroid Belt:
		* Player takes damage equal to their total health
	* Between Player/Projectile:
		* Player takes damage according to projectile stat, projectile is then expired according to its stats and relative conditions
	* Between Player/Enemy Projectile:
		* Player takes damage relevant to enemies projectile stat minus the players defense stat, projectile is then expired according to its stats and relative conditions

* Sound Generation
	* Sound is generated upon nearly any action created by player or enemy (Projectile fire, death, damage taken)
	* Sounds are generated upon menu interaction as well

* Upgrade Decision
	* Player is presented with item selection pop-up at the end of each round, which is determined by round module
	* Player selects upgrade decision from 3 randomly generated items from items pool
	* Selected upgrade is then saved to player, adjusting stats accordingly and being stored for viewing in upgrades list menu, other options are deleted
	* Next round begins

* Player Death
	* Upon player's current health reaching 0 through means mentioned above, game will be sent into end of game process

* Round Update
	* Upon beginning of game, round count is set to 1, in which the round 1 data is called and requested from the round module
	* After the round timer hits 0, the round counter is increased by 1, the player is sent to the upgrade decision, and the next round is updated from the round module, increasing enemy credit count, and possible enemy spawns
	* After player finishes Upgrade Decision, next round begins

##### 5.1.3.2 Enemy Actions and Updates

In Surrounded, the space is filled with enemy ships, these enemy ships will be spawned by the round module and will attempt to get the player to the end of game process by eliminating all of the players health.

Each enemy's specific AI will be highlighted and further explained in the enemy module, but to put it simply, enemies will approach the player's x, y coordinates, and upon reaching a certain threshold distance, begin to fire, attempting to damage and further kill the player.

##### 5.1.3.3 Game-Over Detection

There are two ways for the game to be sent into the end of game process
1. Players health stat = 0, causing the player death to occur
2. The player chooses the quit game option in the Pause Menu

Under any other circumstance, the game is not over.

#### <a name="archgcmend"></a>5.1.4 The End Game Process

This process is what proceeds the game logic process, as we have met the criteria to enter the end game process, meaning the player has either died, or has decided to quit the game. 
The steps to be taken are outlined here:

1. Check and determine if the player has died or quit the game.
2a. If player has died, present game over screen, showing them their score, upgrades acquired and what round they achieved, as well as present them with the options on how to proceed next (Quit Game, return to main menu, restart game)
2b. If player has instead chosen to quit, return them to the main menu, the setup process is then reengaged.

### <a name="uix"></a>5.2 UIX Module: 

The UIX module handles all of the local visual updates which happen to the player, all of the player inputs (such as camera movement, WASD, shooting, etc), and all visual information displaying player and enemy data that will be processed on start up.

The control module will begin as soon as we run the game, containing the game logic and assets from the engine, this will pull UI elements with a display update, prompting the display data containing menus, and HUDs, and will be displayed based on the input.

The update to player display will directly be based on input as all files are local, we will discuss an input/output process in 5.2.1 and 5.2.2.

Figure 3. UIX Module Diagram<a name="uixdiag"></a>
![UIX module design diagram](Images/uixdiag.png)

#### <a name="uixin"></a> 5.2.1 The input process

The input process is for user commands such as keyboard, mouse, esc, etc. It will detect actions made by the user and then this data will be sent through the display data, which in turn creates the output on the screen (All local files, so no need for any delays in terms of input).

#### <a name="uixout"></a>5.2.2 The output process

The output process will be the main UI which feature main HUD elements and menus, different processes or actions for output in the local display include:

* Going from menu to menu (through main menu and pause menu).
* Adjustments to projectiles based on upgrades on player.
* Adjustments to enemy and player sprites (briefly) when taking damage.
* Adjustments to position of ship on the map.
* Adjustments to player health bar.
* Adjustments to boss health bar
* Adjustments to XP bar.
* Round number, timer, and player score.

The type definition for all of this data will be discussed in section 6 of this document.

#### <a name="uixmenu"></a>5.2.3 Menu navigation map

The screens here are listed below, followed by a diagram showing each potential flow of menus

* Main menu: start screen with options to start and quit the game
* Gameplay screen: general game overlay
* Game over screen: the UI overlay when players lose
* Pause menu: for when players press ESC
* Stats and upgrades list: shows players stats and upgrades
* Upgrade selection screen: the player upgrade menu after round completion

Figure 4. Menu Navigation Map<a name="menudiag"></a>
![Menu Diagram](Images/menudiag.png)

### <a name="roundmod"></a>5.3: Round Module

The Round Module manages all the data and mechanics related to game rounds, ensuring smooth progression throughout each stage. It is responsible for tracking the current round number, calculating available credits, managing enemy and asteroid spawns, and updating enemy statistics to maintain gameplay balance and challenge.
Responsibilities of the Round Module:
* Round Tracking: Maintains the current round number and monitors round progression.
* Credit Calculation: Implements a scaling system for available credits, calculated using the formula: Credits=30×(1.1)^(x−1) where x is the round number
* Boss Round Logic: Special logic for boss rounds triggers the spawning of unique enemies (e.g., W35-S315 and C0B-U5) at predetermined intervals (e.g., rounds 10 and 20).
* Enemy Spawning: Utilizes a dictionary mapping enemy types to their respective credit costs and IDs to facilitate efficient and balanced spawning logic. Tracks round timer from game control module to know when to spawn enemies.
* Asteroid Spawning: Whenever enemy spawns are called (every 5 seconds starting at 50), will spawn asteroids until there are 16 clusters on the map as well.
* Dynamic Difficulty Adjustment: As rounds progress, the module dynamically updates enemy stats (damage, health, and speed) to increase the difficulty, keeping players challenged.

#### <a name="roundesc"></a>5.3.1: Round Module Description

The round module operates as the central system for managing all aspects of gameplay related to rounds. It tracks player progress, manages enemy dynamics, and ensures that each round presents new challenges and rewards.

#### <a name="roundinit"></a>5.3.2: Round Initialization Process

At the start of the game or after completing a round, the round module initializes the parameters for the upcoming round:
1. The game control module signals the round module to begin round initialization.
2. The round module sets the current round to 1 and calculates available credits based on the round number.
3. It populates the enemy spawn dictionary and prepares special boss logic for applicable rounds.
4. The module notifies the game control module that the round has begun.

#### <a name="roundprog"></a>5.3.3: Round Progression Processes

During the round progression process, the module manages real-time gameplay, enemy spawning, and player interactions:
1. The round module is activated by the game control module.
2. Monitor the round timer, which determines the duration of the current round.
3. Spawn enemies based on the predefined credit costs and the dictionary mapping.
	* Enemy spawns are limited to 10% of the total available credits every 5 seconds, ensuring balanced encounters.
4. Notify the enemy module to manage enemy behaviors and interactions with the player.
5. Adjust enemy stats dynamically based on the current round to increase challenge:
	* Update enemy damage, health, and speed based on scaling factors as rounds progress.
	
#### <a name="roundboss"></a>5.3.4: Boss Round Logic

In rounds that qualify for boss encounters (e.g., rounds 10 and 20), the round module will trigger the following:
1. Notify the game control module to prepare for a boss encounter.
2. Set player to center of the map and lock the camera. Move world boundaries to the size of the screen only.
3. Spawn designated boss enemies (e.g., W35-S315, C0B-U5) at the start of the designated round.
4. Adjust the round data despite no enemies spawning, to ensure credit amounts challenge the player appropriately in further rounds.

#### <a name="roundtrans"></a>5.3.5: Round Transition Process

At the end of each round, the module manages transitions effectively:
1. Upon completion of the round, the round module communicates with the game control module to signal the end of the current round.
2. Present players with cryptic text about story for 5 seconds.
3. Present players with random upgrade options.
4. Update the round count and prepare the next round's data.
5. Transition back to the round progression process for the next initialized round.

#### <a name="roundend"></a>5.3.6: Game State and End Round Detection

The round module checks for the completion of rounds based on two conditions:
* The round timer has reached zero.
* All enemies in the current round have been defeated, resulting in successful round completion (for boss rounds).

#### <a name="roundint"></a>5.3.7: Round Module Interaction Overview

The interaction model outlines how the round module communicates with the game control, player, and enemy modules throughout the game, ensuring a seamless and engaging gameplay experience.

### <a name="play"></a>5.4: Player Module

The player module is designed to manage all aspects of player data within the game, ensuring a seamless experience as the player progresses through various rounds. This module communicates frequently with the game control module and the round module to ensure correct data is given to update the player data.

#### <a name="playmod">5.4.1: Player Module Responsibilities

The player module is responsible for:
* Tracking Player Statistics: Keeping a detailed record of player stats, experience points (XP), levels, score, and acquired upgrades.
* Facilitating Player Input: Interpreting user commands for movement, combat, and menu navigation to ensure responsive gameplay.
* Updating Player Status: Modifying player attributes based on in-game events, such as leveling up, taking damage, or acquiring upgrades.
* Communicating With Other Modules: Collaborating with the game control module for game events and the round module for tracking current round conditions and enemy interactions.
This is how the player module interacts with other modules, and why they are interacting:

Figure 5. Player Module Diagram<a name="playdiag"></a>
![Player Module Diagram](Images/playdiag.png)

#### <a name="playdata"></a>5.4.2: Player Data Structure

The player module maintains the following key data elements:
* Health: Current health points, decreasing as damage is sustained from enemy attacks or environmental hazards.
* Experience Points (XP): Accumulated points gained through gameplay, contributing to leveling up and unlocking upgrades.
* Level: Represents the player's current level, which affects overall stats and available upgrades.
* Stats: The player's attack, speed, and defense statistics which are updated on level up or by obtaining upgrade items.
* Upgrades: A list of enhancements selected by the player that improve abilities or stats, stored for reference during gameplay.
* Movement State: The player’s current position and orientation within the game environment, updated in real-time based on user input.

#### <a name="playact"></a>5.4.3: Player Actions and Updates

The Player Module gets data from the game control module which manages various actions and updates as follows:
1. Movement Control:
	* Players navigate using the WASD keys for omnidirectional movement.
	* The module continuously updates the player's location and facing direction, maintaining camera focus on the player.

2. Combat Mechanics:
	* Players utilize mouse movement and left-click to aim and fire projectiles.
	* Each projectile is generated with specific stats (e.g., damage, speed) and tracked until it either collides with a target or expires.
	* If the player gets hit by an enemy's body or projectiles, their current health will decrease based on the enemy's damage stat.

3. Upgrade Mechanism:
	* At the end of each round, players are presented with an upgrade menu displaying randomly selected options.
	* The chosen upgrade is sent from the round module and enhances the player's stats.

4. Player Death:
	* If the player’s health reaches zero, the module triggers a game-over sequence, coordinating with the game control module to initiate the end game process.

#### <a name="playint"></a>5.4.4: Player Interaction with Other Modules

The Player Module communicates effectively with various other modules:
* Game Control Module:
	* Provides real-time updates on player stats (e.g. health and XP) and reacts to gameplay events initiated by user actions.

* Round Module:
	* Interacts closely to track the current round number, which in turn is related to upgrade system, the round module gives upgrades which in turn need to be applied to player stats and module.

* UIX Module:
	* Updates the user interface to reflect player stats, (e.g. health and XP), enhancing the player’s understanding of their current status.

#### <a name="playset"></a>5.4.5: Player Initialization and Setup

Upon the initiation of a new game or round, the Player Module executes the following steps:
1. Setup Player Stats:
	* Initialize player attributes, including stats, XP, level, and available upgrades, according to game parameters and outcomes from previous rounds.

2. Display Player UI:
	* Collaborate with the UIX Module to render the player’s HUD, ensuring that real-time feedback on stats, upgrades, and scores is readily available.

3. Prepare for Input:
	* Establish input listeners for keyboard and mouse actions, allowing for immediate response to player commands for movement and combat.

4. Reset Positioning:
	* Position the player at a defined starting point in the game world, ensuring proper camera alignment and interaction with the environment.

The player module is integral to the user experience, managing player interactions and evolving capabilities in conjunction with the game’s round and upgrade dynamics. By maintaining a responsive and adaptable framework, the module enhances player engagement by ensuring they feel consistently rewarded and challenged throughout the game.

#### <a name="enemy"></a>5.5 Enemy Module

The enemy module, similar to the player module, holds data and information for the game control module, UIX module, and round module to use. The enemy module also contains the information for their AI and as well as the bosses AI and data.

#### <a name="enemyresp"></a>5.5.1: Enemy Module Responsibilities

The Enemy Module is responsible for:
* Tracking Enemy Statistics: Keeping a detailed record of enemy health and experience points (XP) that will be given to players upon defeat.	
* AI: Updated movement of enemies, enemy decision making, how enemies collide with objects.
* Communicating With Other Modules: Collaborating with the game control module for game events and the round module for current enemy stats and available enemy types.

#### <a name="enemydata"></a>5.5.2: Enemy Data Structure

The Enemy Module maintains the following key data elements:
* Stats: Health, damage, and speed for each enemy, updated every round which are kept in the classes booted by the game control module.
* Behaviour: Enemy types' movement and decision making patterns.
* Movement State: The enemy’s current position and orientation within the game environment, updated in real-time based on collision detection.

#### <a name="enemyact"></a>5.4.3: Player Actions and Updates

The Enemy Module gets data from the game control module which manages various actions and updates as follows:
* Movement Control:
	* The module continuously updates the enemy's location and facing direction, spawning outside players POV.
* Combat Mechanics:
	* Enemies aim and fire projectiles.
	* Each projectile is generated with specific stats (e.g., damage, speed) and tracked until it either collides with a target or expires.
* Enemy Death:
	* If the enemy health reaches zero, the UI will display animation and XP will be given to the player on kill.

## <a name="data"></a>6. Data Design

In this section we describe how the information elements are manipulated by the game system.
Currently we have information divided into these broad categories:
* Player data (information about the player's stats and attributes paired with the overlay)
* Enemy data (enemy stats and how enemy attributes are updated)
* Boss data (How boss functionality works and how it pairs with round system)
* In-game data
The four information groups will be covered respectively 6.1 - 6.4 respectively, and the entirety of the information will be represented by a diagram in 6.5.

### <a name="dataplay"></a>6.1 Player data:

Player data refers to information which concerns how gameplay data will function outside the game loop which means:
* The player will spawn with the base ship (base case will be introduced as a class)
* The player's data, upgrades, and statistics will be stored in a class containing in game data (see 6.4.1)
This player data will stay static through the boot up process, with the ship's features being updated with the in-game upgrade system and will update UI during the game loop.
The player data will update along with each upgrade as well. The upgrade system will use pre-built classes containing upgrades as objects. Each object will be added to our current base stats and character functions. 

### <a name="dataenemy"></a>6.2 Enemy data:

Enemy data will refer to how the actual gameplay data of enemy IDs will flow. This concerns the likes of enemy spawns and enemy types. Examples of enemy data which will be updated outside of the gameplay loop include:
* The enemy spawns which will be determined by each round (base case of enemies dictated by credit and thrown into our function referred to in our round module).
* Enemy types will feature different UI (Each enemy object uses a sprite).
* Enemy types will also be contained in a class and will be spawned using a function.
All of these spawns and types will be updated as each round increases, most likely syncing to when each round starts after our item-upgrade menu is completed. 

### <a name="databoss"></a>6.3 Boss data:

Boss data will refer to how the actual gameplay data of boss IDs will appear in game. This concerns the likes of UI overlay with bosses and how each boss class will look. Examples of boss data which will be updated outside of the gameplay loop include:
* UI updates with a boss health bar over the game loop UI
* Boss attack algorithm, (will be included in a class which has each unique move, will have a telegraphed attack pattern).
* Round system acknowledging it's a boss round (Will look at round count to start boss round).

All of these boss data types will be updated at round 10 to round 20, with assets of bosses most likely being reused at rounds higher than 20. The round system will check for round 10 or 20 respectively (most likely will use an if condition).

### <a name="datalog"></a>6.4 Game logic data:

The game logic data needs to represent all the information about every player ship variant, enemy variant, boss data, and item upgrade, and any map related data which will appear in the current game state. This will be the biggest section to organize but this collection of data will be generalized for ease of understanding. 

Our data will be dissected into these categories:

* Player data
* Enemy data
* Item upgrade data
* Round data
* Boss data
* Map data
* Display data

We will go into more depth of each category individually (in sections 6.3.1 to 6.3.8 below), then modeled as an entity-relationship diagram (section 6.5).

#### <a name="dataship"></a>6.4.1 Player ship data:

The information to be maintained for each player ship is as follows:

* Unique class ID
* Sprite, colour
* Health stat
* Attack stat
* Defense stat
* Speed stat
* Current (x, y) coordinates and map zone
* Current direction facing
* Current upgrade
* Level and XP total

#### <a name="dataenship"></a>6.4.2 Enemy ship data:

The information to be maintained for each enemy data is very similar to player data, it appears as follows:

* Unique Class ID
* Sprite, colour
* Health stat
* Attack stat
* Defense stat
* Speed stat
* Current (x, y) coordinates and map zone
* Current direction facing
* Current ship total
* Current credit cost of each enemy

We need to add some more specifics to enemy AI movement however, these include:

* Their working WASD with telegraphed movement patterns
* Constant player movement and collision detection
* Sound and Indicators

#### <a name="dataup"></a>6.4.3 Item Upgrade ship data: 

The information needed for items will include these following:

* Unique ID
* Display over sprite (New UI update per each upgrade)
* Current stat changes (will also change with XP system)
	* Stat changes for when multiple of the same item are picked up
* Current upgrade system adding count for each upgrade
* Visuals for items if required (diverge and forcefield)

#### <a name="dataround"></a>6.4.4 Round data:

The current round system involves inputting round count into a function as the game logic process begins.

The current round system will have these properties updated:

* Credit count
* Round count
* Credits spent
* Enemy IDs and credit costs
* Enemy spawning (using while loop)
* In-game timer
* Player health (At end of each round, player will have health restored)

#### <a name="databship"></a>6.4.5 Boss Ship Data:

The boss data will be dictated by specific round count, the current boss properties which need to be identified include:

* Unique ID
* Current (x, y) location and area on map
* Current boss health 
* Health UI for boss
* Display and animations of hit registration
* Possible attack moveset and damage values for each attack.
* Current ability usage
* Current speed stats

#### <a name="datamap"></a>6.4.6 Map data:

The design of the map data is most likely going to feature a simple restricted area with the bounds visually indicated by an asteroid belt that kills the player on impact.
The asteroids will be handled in the round module when enemy spawns are called, ensuring there are enough asteroid clusters on the map.

* Unique ID for asteroids
* Current (x, y) location for asteroids on map
* Current health for asteroids
* Collision data for asteroids/asteroid belt
* Current Asteroid Count

#### <a name="datadis"></a>6.4.7 Display data:

The display data covers which portion of the map the current player's gameplay will view. It will be in a locked camera which will show a portion of the map.
The specific properties that will be stored are:
* Current width and height of the display (on a locked screen)
* Current x,y coordinates updated in our system

### <a name="logerd"></a>6.5 Logical ERD

In this section we relate the data components (class objects) used for the game, as well as attributes such as stats related to each object.

The current list of entities goes as follows:

* Game
* Ship Display
* Round Data
* Player Ship
* Map
* Upgrade
* Enemy
* Boss
* Sounds

The entities we will reference in this diagram will be all of the ones referenced prior in 6.4’s list.
We will use a chart to determine the logical components of each attribute to reduce complexity:

Figure 6. Logical Entity-Relationship Diagram <a name="erddiag"></a>
![Logical ERD](Images/erddiag.png)

## <a name="gamstat"></a>7 Game state and flow of play

In our current iteration of the game we are restricted to one map with a set boundary that will spawn enemies outside of the camera radius, this process is relatively structured with our game logic and has an intuitive sequence of actions with spawns occurring based on a credit count. Ideally, we could refine our algorithm to be more dynamic rather than an exponential function to prevent a wall of difficulty occuring in the late game, as having an exponentially increasing function can cause balancing to get out of hand extremely quickly.
Generally, our game flow will follow a series of events listed below, however the bulk of our steps are mostly covered in the system context design diagram listed in 4. The game will be primarily based around menu prompts, round conditions, and the game over condition, all simultaneously updating each sequence of the UI.
This list will be a very bare bones summary of the system context but in a rather user faced perspective to give a general idea of what the user might encounter on first start.

The sequence follows:
1. In Main Menu
	* Select Start Game or Quit
2. In the Gameplay Loop
	* Begin piloting ship and encountering enemies
	* XP increases per enemy ship destroyed
	* Enemies begin to spawn based on round number
3. Round Ends:
	* Upgrade prompt appears and the user selects an upgrade
4. New Round Begins
	* Player health returns to full, upgrades gets applied
5. Boss Round:
	* Prompt appears indicating a boss round
	* Distinct moves selected from boss’s tool kit
6. Game Over prompt
	* Player has reached 0 health
	* Game over UI is prompted

At the game over prompt the user will be able to decide whether they want to play again or quit.

The game could go on for many rounds, with much of the gorey details of higher round counts and discussion of scope creep still on the table for discussion.

The enemies will all spawn outside of the player camera, and will positionally shoot based on distance from the player. The game logic will mostly deal with enemy spawn rates and updated credits to dictate spawns. The enemies will spawn infinitely and the credit amount and costs will determine which enemies spawn. This goes on infinitely until the round timer is done.

## <a name="phys"></a>8 Transition to physical design

In this section we will give a layout of transitioning from logical design to a physical design suitable for our game. As of the present moment, we have only just started the actual physical design process and are not very deep into fleshing out version 1 of our game. We have chosen C# and the Unity engine has discussed as a team types of pseudo code from prior meetings to make implementations. However we have not modeled all of the pseudo code.

In the current iterations we have made in our github testing branch we already have some actions such as WASD and projectile design in its alpha state. With some sprites and objects starting to see light of implementation but in a very early state. Examples of these include collision detention of our enemy sprites and projectile registration on hit.

### <a name="physim"></a>8.1 Implementation decisions

The question we asked ourselves in the beginning was which game engine we would like to work with. Our main options at the time were Godot, Unreal, and Unity. The decision was Unity, however there was some speculation early on to have Godot be our engine as it is very beginner friendly.

Because we wanted to use Unity as our engine, the mandatory step was to use C# as our main language of choice, and use any pre-built assets given to us by Unity to create physics, sprites, and projectiles without the necessity of having to form many class/object designs from scratch.

### <a name="physobj"></a>8.2 Object model

As of what was discussed prior in section 6, we did have many of our various pieces of data we wanted for each class object already decided. However as of now we have yet to start implementing these objects, and have not discussed a fleshed out approach to implementing the system. The hope is that as we begin to approach phase 4 this decision process will be mostly decided as a team.

## <a name="appendix"></a>9 Appendix: the total design

This diagram captures all of the module diagrams together into a “total” design, capturing all of the interactions between key elements of the modules. It is intended to be used to cross reference various module diagrams. Module information is discussed prior in section 6.

Figure 7. Appendix Diagram<a name="appdiag"></a>
![Appendix](Images/appdiag.png)

