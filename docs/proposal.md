# CSCI 265 Initial Project Proposal

## Team name: We Haven’t Decided 

## Project/product name: Surrounded

## Contact person and email address

- Connor McDermid, mcdermidconnor@outlook.com

## Project Overview

Surrounded is a single player top-down shooter where enemies gain strength over time and uses an in-game upgrade system to progress. The player operates a ship and fights on a top-down 2D plane. The game will be point based and will also have an XP system. The game is best suited for solo gamers who are interested in playing a bullet-mayhem style that is an endless roguelike.

The player will battle with enemy ships. The goal is to survive as long as possible by eliminating enemy ships before they eliminate you. Eliminating enemy ships yields XP that will increase base stats (attack, health, speed, etc.) on level up. Additionally, the ship can be hit by asteroids and blocked by other terrain. New ship parts and upgrades are unlocked between rounds.

The enemies of the game will increase in difficulty based on the round and will gradually get more difficult and have different variants. We plan to use an enemy director point system similar to Risk of Rain, where enemies cost a certain amount of points to spawn and points go up as the time and level goes up.

The objective of the game is to keep playing for as long as possible and gain enough points and upgrades to see how long you (the player) will last.
 
## Target audience and motivation

The game appeals to single-player top-down enjoyers who like to operate multi-directional combat. It is a mesh between the bullet hell and roguelike genres of games, the gameplay is intended to be chaotic and for users who enjoy arcade type games with crazy scaling.

Everyone in the discord has some form of background playing video games, with each of us giving inputs based on games we were already aware of from being gamers. This will be our first time creating games together, and we haven’t started implementing our system yet. However we are very eager to use our background in games and background in programming and combine the two.  

## Key features and discussion

Here is a list of key features we plan to implement, sorted by concept type:

**Round Based Wave Progression System:**
Enemies and resource spawns will be based on a round system, the further you are into a run the more difficult enemies become, as well as the more resources that become available for you to take advantage of.
Endless rounds, with the possibilities of bosses and elites (buffed enemies) spawning on continuously repeating rounds (elites every 5 rounds, bosses every 10 rounds).
As we will be implementing multiple enemy types, this allows us to have scaling enemy difficulty, introducing the player to concepts as they progress in the game.

**Map and Movement:** 
8-directional omni movement system (controlled by WASD)
Enemies will also move in 8-directional omni with some limitations to certain enemies.
The ship will look towards your cursor, hold left click to shoot
Players will also be able to scale map view in different directions, control not decided
Potentially implement different backgrounds of planets, galaxies, etc.

**Enemies and Combat:**
Different variations of enemies with bullet styles, ship models, and stats.
Bullets will be upgradable and given a shop system.
Will have a distinct colour and upgraded enemies will have a distinct UI. 
Will move in various directions similar to player movement patterns, fire rate will be determined by ship variant and upgrade.

**Upgrades + Level System:**
Ship upgrades can be acquired at the end of every round
At the end of every round, you have 3 random upgrade choices to choose from, you can only choose 1 per round.
The higher the round, the better the upgrades. For example, upgrades have a rarity attached to them (common, rare, epic, legendary). The chances for higher rarities increase with each round.
An XP bar fills up to level up the ship, increasing their base stats by a flat amount (+2 damage, +3 health, +5 speed, etc.)
Upgrades can replace other upgrades - if you pick up a weapon, it replaces your current weapon with the new one.

**Sounds:**
8-bit sound design
Background music as well as sounds for weapon fire, enemy death (as well as your death), level ups, and upgrades
Round starts will play music

**Ship Upgrade Ideas:**
Regenerating shield - blocks 1 hit and regenerates every 10 seconds
Manoeuvrability upgrade - makes ship accelerate faster and more controllable
Missile turrets - Bullets have an AOE attack instead 
Triple shot - Each shot shoots 3x the bullets
Aimbot turrets - Shots slightly home towards the target
Wave shot - Surrounding wave shots which go in a circle

## Preliminary interface sketches

Game will have a main menu, the game loop interface with UI for upgrades and abilities, and a game over screen with a leaderboard.

### Alpha combat UI sketch:

The main interface shows the top down view, with the ship locked in the centre of the screen and has asteroids and enemies surrounding the ship. The green bar represents health with the blue representing XP. The set of icons on the bottom left will feature different upgrade icons representing their upgrade type.

![Gameplay](gameplay.png)


### Main menu sketch:

We plan on keeping the main menu fairly simplistic. With the options only containing a start button and a name button which will be kept track of for a potential leaderboard option.

The ship will move along the same background as the main background used in the game loop.

![Mainmenu](menu.png)


### Game over screen:

Game over screen will have a prompt alerting the player of the end, also will give an option to retry and quit. 

![GameOver](gameover.png)

### Coin Upgrade system

A timed shop appearance which allows the user to upgrade their ship, timing of the prompt for the items to be purchased is still in the crux of being decided. However, the team is leaning towards having the prompt appear based on rounds.



![CoinUpgrade](coinupgrade.png)

## Scaling plans

As we don’t have prior experience with game development, we don’t know how long things will take to implement. We also don’t know when the implementation phase will start exactly, meaning we don’t know our time frame. These things lead to a lot of uncertainty with what we will complete.

In the key features and discussion section, we discussed every core feature we are aiming to add. Down below, we will discuss upscaling and downscaling options.

**Ways to scale up if everything goes well:**
Ability to save game (autosave at the start of each round) to be continued later
Gold is obtained through destroying asteroids
Gold system that is used to purchase upgrades instead of them being given at end or round
Add a leaderboard at the game over screen
Have secondary weapons controlled by right clicking

**Ways to scale down if things don’t go to plan:**
Remove item rarities
Less items
Remove bosses and boss round
Simplify background design
Simplify XP system
Remove upgrade choices

## Risks and potential issues

Since we are new to this area of computer science, we aren’t fully confident in every aspect of our decisions within game design. We just want to make a game that we believe others will enjoy and have fun during the process. With solutions to problems we hope with our communication as a team and ability to adapt to past experiences from our degree, that we can overcome design adversities.

With some of our challenges we could foresee, we determined these are some potential issues:
Scaling Issues/Scope Creep: It’s easy with a game to want to add a ton of features and expand on what we already have. However, time constraints don’t allow us to add all of these features within deadlines, so we have to know our limits. We can overcome this by having a clear, defined list of key features with upscaling and downscaling options.
Balancing Gameplay: It’s hard to come up with numbers that all scale together that makes the game not too easy and not too hard at certain points. Lots of playtesting will be required to locate what is unbalanced and how to fix it. Good communication is essential to pinpoint exactly what is unbalanced and what is balanced.
Monotonous Gameplay: Our game is an endless roguelike and we will have limited time to add game mechanics, so we have to work with what limited time and resources we have to make the game interesting. Adding unexpected rounds, plot twists, or hidden gimmicks could spice up the gameplay.
Unfamiliarity with Unity and C#: None of us have much experience with game engines at all, so learning the menus and how to navigate and work efficiently with a new interface and language will take some time. Getting familiar with the engine before the technical design phase will give us a head start.

