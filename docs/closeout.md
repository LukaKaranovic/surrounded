# CSCI 265 Team Charter

## Team name: We Haven’t Decided

## Project/product name: Surrounded

## Contact person and email adress

 - Connor McDermid, mcdermidc@stumail.viu.ca

## Table of Contents

1. [Final Updates](#updates)
2. [End state of the product](#product)
3. [Organizational aspects](#organization) 
4. [Technical aspects](#technical)

## 1. Final Updates


<<<<<<< HEAD


## <a name="product"></a> End State of the Product
=======
>>>>>>> f6b6cc056ae1ff45f885f2be65441e0241a7d4bf

## 2. End State of Project
Almost all the main features presented in our requirements document were successfully implemented. 
For this document we will section each part that was in our requirements key features section and describe all the features that were and weren’t built in Version 1 successfully:

### 2.1. Player, Controls, and Combat:
This section was a great success in our key features. We successfully implemented each player mechanic with ease and managed to have our final product move and function the ship as intended. Aiming and moving with WASD and mouse movements work fluid and Enemies when shot blink red as intended. We also have infinite fire rates and our formula for damage implemented successfully. Stats and collisions were also working as intended. These features were all implemented very early, which meant hypothesizing the game loop functionality was running efficiently during early stages.
One of the features that weren’t successful with implementation in our final release was invulnerability frames upon taking damage, our team wasn’t able to find a proper implementation within our time restraints, so we took to prioritizing the other features. This could likely be due to the actual requirements of development to get to the necessary stage for invulnerability frames to be made (requires testing of many other features which also need proper implementation). 
Another part of this section in our requirements which wasn’t completely implemented was animations for enemy ships being destroyed. The requirements for animation in Unity can be pretty time consuming, making individual sprite explosions run on a timeline can be tedious to implement. We also only had one person on the team do sprites and animations, which also demanded a lot from one person alone. This means if implementation would occur we would need to make sprites first before animations, which can take time. 
Besides these two features, this section was one of the most successful and was definitely one our top priorities to have fully working for Version 1.

### 2.2. Map and Terrain
For this section, we successfully got the map to generate floating asteroids as objects. Which was a huge success as early on we thought we had to scrap this feature. 
One feature that didn’t see the light of Version 1 was the asteroid belt. Early on in development as a team we didn’t have a fix for infinite terrain and wanted to have a bound for players. What we did however end up implementing was actually a comet which detects the player at specific x and y coordinates (550 in game distance from spawn). This was a huge success and worked out better than intended, and the team favoured it way more than the asteroid belt.
Another feature we didn’t end up implementing was having planets which represented quadrants on the map. This was due to the fact that it required us to do more specific art for the background. Which was again up to only one person,
besides these two scraps, we had the camera working perfectly and enemies spawn outside the player camera, so massive success.

### 2.3 XP and Levelling System
Everything for this section was implemented successfully, within our round module we actually managed to have our function working for XP gain and have the player gain more XP via killing harder enemies. The functionality of our round module also found successful implementation with the player module, updating stats for each level gained.
We intended to add a pop up for the level up to show the player stats gained and remind them they have leveled up more clearly but we ran out of time and levels remained the same as they were originally implemented.

### 2.4 Round System
We changed certain aspects of this part in our requirements for final release, round timers were successfully implemented but were changed to 50 seconds on account for better gameplay flow. 
Round credits and the round credit formula was also implemented well, which matched with enemy spawn timers. Implemented a working system between the round module and enemy module to produce spawns worked without a hitch. While we did not do our implementation with loops, we did manage to attach a proper ID to which enemy spawns.
For the boss rounds, rather than making bosses appear every 10 rounds we decided 20 was more suitable. Boss implementation is something which may or may not make version 1 in time for our presentation. We also decided to implement a portal which was mentioned in our Phase 5 documents updates as well. 
This is to make a smoother transition from the gameplay loop to the boss scene which we had working prior to phase 5 release.

### 2.5 Enemy Design
We managed to have all enemies that were intended to be implemented come to light for Version 1. The Viper, Grunt, Juggernaut, Striker, Dreadnought. 
We have unique movement for the Viper, Grunt, and Striker, but the Juggernaut and Dreadnought.

### 2.6 Bosses
For bosses however, we had a lot of time restraints and wanted two bosses to be implemented. Unfortunately we had to scrap our second boss W35-S315 from Version 1’s release, we would need to do a cutscene, attack implementation, sprite model, and have bug fixes be done all within the next 2 days, which is feasibly impossible. 
For our other boss, C0B-U5, we had a successful implementation, however this is partially done at the time of writing this document. With a cutscene implementation working and movement. However, we don't have attack functions and round scene transitions working as intended, which would need to interact with our round module, presumably, we want the attacks working first, then have transitioning work. 
This would still need time to develop and due to time constraints might not see proper implementation. 
Besides that, each enemy in our base game works with the exception of bosses, so we see this as a semi-success.

### 2.7 Items

Version 1 will have every intended upgrade fully implemented and working. 
A lot of the success of these implementations was thanks to Anmol, Quetzal, and Connor. These three managed to get each of the upgrades done. Rocket boosters, Machine Guns, and Diverge all work as intended. 
The Fortified Plating and Forcefield work as intended too, same with Piloting Enhancements. 
This was a complete success for implementation, every feature we wanted will make Version 1.

### 2.8 Menus
We originally intended to have a leaderboard and load game for stretch goals. While these won't be in Version 1 we still wanted to add them as they were originally going to interact with our score count for enemies killed on screen.
Besides this fact, The Main Menu, Gameplay HUD, Game over, Stats and Upgrade page, and Pause menu all saw the light of day and work as intended in our requirements and logical design documentation, with fully functional implementation. 

### 2.9 UI
For our UI, a majority of the implementations done found success, sprites, health and XP huds, and all of our other key features which were present in our requirements document were fully fleshed and functional as per Version 1. 

## <a name="organization"></a> Organizational Aspects

### 3. Organizational Aspects

With our organizational aspect of the project, we originally had roles for each member respectively. While we did follow with some of these roles for a majority of the duration of the project's cycle, we still had a slight imbalance of documentation and coding done between each member. 
Some members did one side of the project's spectrum versus the other with some members diverging from their original roles and doing more in another aspect. This was specified early on that due to the uncertainty of who had background in Unity versus not roles and responsibilities would vary. 
In the end we had most of the game done with a 3-3 team style which wasn’t intended but we adapted to this decision naturally versus unanimously.
We also originally were going to use other functionalities such as the built-in Github Kanban, but favored a more in-person/discord style of work organization, as it was more convenient. 
It also didn’t help that we needed to have direct communication with directors to the Kanban to check off to-do-list activities and cross reference it with the github commits as we didn’t actually choose to document each change we made properly in our commits with the Kanban.

Overall, our team was very adaptable and both the code base and documentation was very organized and produced quality content.

If the team were to do a do-over, an approach to have a fair spread of coding and documentation would be optimal. Some of us are not even touching the code base while another side is not participating in the large majority of documentation, which could also cause troubles in terms of the ‘grand idea’ everyone has in mind during development.

## <a name="technical"></a> Technical Aspects

### 4. Technical Aspects

As for our technical aspects of the design, originally we had more of an OOP directed approach with our structure. We adapted to using scripts with C# and in game assets with Unity. 
Over time something that became a recurring issue in our design was clutter of the code base in modules where functionality could be separated. Better moderation of code base and best practices would have made debugging as well as file management a lot smoother. 
Another issue was trying to find resources for each functionality we wished to implement, where we got our source for code and how someone implemented it was more of an “if it works, it works” approach rather than a technical outlook, but that is due a skill range difference of understanding Unity more so. 
