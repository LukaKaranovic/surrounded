# Appendix: Detailed User Acceptance Test Case Descriptions (Phase 5)
This document holds detailed descriptions for all currently compeleted user acceptance test cases. As of November 21, 2024, there are 14 test cases completed.

ID: PCC00
Name: Player Movement
Description: Checks that the WASD keys make the player ship move, and that the player has velocity.
Overview/Purpose:
This test is intended to check whether player movement has been properly implemented and x  and y coordinates of player ships vectors are being updated appropriately. The purpose of this test is to check if the player ship is running for gameplay functionality to work. 
Test Approach: 
This test will be performed by creating a new scene in which the player ship is spawned at (0,0) of our map and if the player ship is moving and we can observe changes then it passes the test. This test really only needs one person to check if the player's ship movement is implemented properly and vectors are shifting when all four keys are pressed. When this check has passed we also want to make sure it's being updated with our speed stats as well as soon as our implementation is merged. 
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: The script for the player movement can be found in the player controller module. For our test case we have a PCC00 script that exists in a tests folder.
Expected Results/Output: Player ship will move across the map and have its x and y updated accordingly.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.














ID: PCC01
Name: Player Aim and Weapon 
Description: Checks that the player ship looks towards the mouse cursor and that left click makes you fire + holding left click makes you fire. 
Overview/Purpose: 
This test is intended to check whether player's weapons are firing properly when left click is pressed. This test checks if the bullet prefab is being spawned when left click is pressed the bullet object is spawned, and thus is created from the player ship's spawn point and checks if the mouse direction also accounts for firing. The purpose of this test is to check if bullet functionality works as intended. This test will be performed by creating a new scene in which the player ship is spawned and if the scene loads and the tester presses left click.
Test Approach:
This test will be performed by creating a new scene in which the player ship is spawned and if the scene loads and the tester presses left click it passes the test as intended, if not we consider this a failed test.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: The bullet prefab and bullet script are part of the game controller. However the way functionality is implemented is in the player controller script and inherits from the game controller. Thus, the game controller must also have proper implementation of bullet objects in order for the player controllers shooting functionality to work. For our test case we have a PCC01 script which tests a load screen that prompts the game scene
Expected Results/Output: Players will move, shoot on the map, and bullets will spawn at any point the mouse is aimed at.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.











ID: PCC03 
Name: Player Damage
Description: Checks that the player takes appropriate damage from an enemy bullet.
Overview/Purpose: 
This test is intended to check that player damage is being appropriately updated from an enemy bullet. This checks if bullet objects will collide with the player ship and player damage updates the health stats in the player module. This test will pass if player health is updated and UI also updates.
Test Approach:
This test will be performed by the test runner via our Damage Test script in which the player ship is spawned and if the scene loads and the ship is spawned in the centre of the screen where a bullet prefab spawns on the screen and damages the player ship.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: Currently we have our damage test script which takes assets from our Game Control scripts, unity scripts, and our player script.
Expected Results/Output: Bullet spawns and shoots on the map, and bullets will pass through the player updating health and damaging the player ship.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.

















ID: MAT01
Name: Comet Spawn 
Description: Checks that the on-screen countdown for the comet appears when the player is out of bounds, and that the comet appears and chases the player when the timer reaches 0.
Overview/Purpose: 
This test is intended to check that the comet spawn when the player is out of a certain range and that the comet spawn.
Test Approach:
This test will be performed in test runner via our MAT01 test script, and we will have a check when the player reaches out of bounds, we have the player instantly go out of bounds which will show the prompt for the comet spawning.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: Currently we have our MAT05 script which takes assets from our Game Control scripts, unity scripts, and our player script.
Expected Results/Output: Players going out of bounds will prompt the comet to spawn and destroy the player ship.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.


















ID: MAT05
Name: Camera Follow 
Description: Check if the camera tracks the player’s movement.
Overview/Purpose: 
This test is intended to check that when the player ship moves with the camera, we check 
Test Approach:
This test will be performed in test runner via our MAT05 test script, and we will have a check to see that the player camera will also be moving alongside the player as both their x’s and y’s update at the same time. 
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: Currently we have our MAT01 script which takes assets from our Game Control scripts, unity scripts, and our player script.
Expected Results/Output: Player camera is followed at the same time as camera movement is updated.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.




















ID: XPL00
Name: Player XP Enemy
Description: Checks that the player gains the correct amount of XP when killing an enemy. 

Overview/Purpose: 
This test is intended to check that when the player kills an enemy, XP is added to the player stats, this test ensures that our stats in our player module is being updated properly as enemies are destroyed.
Test Approach:
This test will be performed in the test runner via our XPL00 test script, and we will have a check to see that if the player destroys an enemy it will also be granting XP to the player and their player module also updates at the same time as the enemy object is destroyed. 
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: XPL00 test script is inheriting assets from the enemy and player module and will 
Expected Results/Output: Player presses ESC, menu opens and game is paused
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.


















ID: ENY00
Name: Enemies Shoot at Target
Description: Checks that enemies shoot towards the player and not in random directions.
Overview/Purpose: This test is intended to check that when the game is booted, enemies shoot at the player pov and enemies aim at the players in vector space.
Test Approach:
This test will be performed in the test runner via our ENY00 test script, and we will have a check to see if the enemies are aiming at players. We will have a check for enemies tracking players vectors and assert when enemies successfully damage players.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: ENY00 test script is inheriting assets from the enemy and player module and game module.
Expected Results/Output: Enemies shoot at the player and track them at any coordinate.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.





















ID: ENY01
Name: Enemies Spawn Off-Screen
Description: Checks that enemies don’t spawn on-screen.
Overview/Purpose: This test is intended to check that when the game is booted, enemies spawn outside of the player pov and not within the camera range
Test Approach:
This test will be performed in the test runner via our ENY01 test script, and we will have a check to see that if the enemies have spawned that they are outside of camera range. We will use a for each loop and assert when enemies have spawned or not outside of the boundary.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: ENY01 test script is inheriting assets from the enemy and player module and game module.
Expected Results/Output: Player spawn and enemies spawn outside of camera range.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.





















ID: RND01
Name: Enemy Spawn
Description: Make sure enemies spawn when the timer reaches 50 seconds, and every 5 seconds after that. Also checks that 90% of credits for the round are remaining after the first spawn, and 10% less after each spawn.
Overview/Purpose: This test is intended to show that enemies always spawn at specific times in order to show that our round system works according to the round module.
Test Approach: For our test case we gave the approach of checking when time was at 49 seconds and do a comparison of enemies, essentially if enemies did not spawn past 50 seconds it would yield enemies total to 0 and fail the test and if not presume enemies spawn.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: RND01 test script is using the player module, enemy module, round module, game control module, and is also running unity built in code.
Expected Results/Output: Enemies spawn past 49 seconds and will spawn according to round timer function.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.



















ID: BOS12
Name: C0B-U5 Instantiation
Description: Checks that the C0B-U5 boss spawns on the correct round (round 20), and not any other bosses. Also checks that C0B-U5 has the correct stats when spawned.
Overview/Purpose: This test is intended to show that C0B-U5 will spawn.
Test Approach: We will load a scene at round 20 by setting round count to 20, and then check if C0B-U5 is present when the portal opens with an assert statement on the object.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: BOS12 test script is using the player module, enemy module, round module, game control module, and the UI module, and is also running unity built in code.
Expected Results/Output: C0B-U5 spawns on round count 20 and is present when scene is loaded.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.
















ID: UPG00

Name: Rocket Boosters

Description: Checks that the player’s movement speed is increased by 10%.

Overview/Purpose: This test ensures that the players stats are being updated accordingly to the items given stat increase.

Test Approach: The player stats will be checked at base, the player will then be given the Rocket Boosters upgrade, then the players new stats will be compared to base stats to check that the players speed was increased by 10% 
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: UI00 test script is using the upgrades module to acquire the stats for the Rocket boosters upgrade as well as the player module to acquire player stats for upgrade.
Expected Results/Output: Player is spawned with base stats which are stored, player is given Rocket Boosters upgrade, players new stats are checked and compared to base stats to ensure upgrade is giving 10% increased move speed.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.
















ID: UPG04

Name: Force Field

Description: Checks that the player gets the forcefield status update.

Overview/Purpose: This test is to ensure that the item “Forcefield” is working correctly, and that the item is correctly refreshing the shield

Test Approach: The player will be given the forcefield upgrade, then the player will be damaged, checking if the shield has blocked the enemy attack, the player will be damage again ensuring they can take damage while the shield is on cooldown, and then damaged again once the shield has refreshed to ensure that the refresh mechanic is working as intended at that it will block the enemy projectile again.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: UI04 test script is using the upgrades module to acquire the scripts for the forcefield, which then will be tested along with player module ensuring it is protecting player health stats.
Expected Results/Output: Player acquires shield, player IS NOT damaged with shield active, shield deactivates upon blocking, player IS damaged when the shield is on cooldown, and that the shield is refreshed and can block damage once again.
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.











ID: UI02

Name: Health Bar

Description: Check that the health bar is accordingly updating upon damage taken.

Overview/Purpose: This test is to ensure that the UI interface for the health bar is being properly updated and displayed when damage is taken

Test Approach: This test will be performed by spawning an enemy projectile that will damage the player which in turn will cause the damage script to run and health bar UI to be decreased by the set amount of damage the enemy projectile is set to do.
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: UI02 test script is using the UIX Module and receiving input from the enemy module to acquire and use the health bar UI and update it via the damage received.
Expected Results/Output: Player takes damage, UI for health bar is decreased by amount of damage taken
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.

















ID: UI07

Name: Pause Menu

Description: Checks that when the ESC key is pressed, the pause menu is opened.

Overview/Purpose: This Test is to ensure the operation of the Pause menu is working as intended, allowing the player upon the use of ESC key to open a pause menu

Test Approach: This test will be performed by simulating the press of the ESC key and then checking for the UI update of the pause menu being displayed and that the opening of the pause menu is stopping the round timer from decreasing
[Link to where it is in requirements] (here)
Amount of Testers: Currently, we will have group members review the test case implementation via Discord. No testers are required to run the test as it is automated.
Scripts/Arguments: UI07 test script is using the UIX Module to acquire and use the pause menus script.
Expected Results/Output: Player presses ESC, menu opens and game is paused
Cleanup Process: All file management is done via a script which will manually sort files, and this will only work on Linux.

Reporting Process: Checks will be updated as passed or failed in an XML via a test log.