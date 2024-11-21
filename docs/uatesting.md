# CSCI 265 User Acceptance Testing Document (Phase 5)

## Team name: We Haven’t Decided 

## Project/product name: Surrounded

## Contact person and email address

- Connor McDermid, mcdermidconnor@outlook.com

## Table of Contents

1. [Known Issues](#issues)
2. [Test Plan](#tplan)
    2.1 [Testing Overview](#toverview)
    2.2 [Key Testing Challenges](#tchallenges)
    2.3 [Testing Timeline](#ttimeline)
    2.4 [Test Process](#tprocess)
    2.5 [Test Cases Summary and Organization](#tcases)
    2.6 [Test Case List](#tlist)
3. [Test Infrastructure](#infra)
    3.1 [Software Tools and Environmen](#tools)
    3.2 [Executables](#exec)
    3.3 [Version Control and Branch Structure](#vc)
    3.4 [Directory, File Structure, and Content](#content)
    3.5 [Independent Subsystems and External Resources](#external)
4. [Appendix: Detailed Test Case Descriptions](#appendix)

The document will have four key sections:
known issues,
the test plan to be followed,
the test infrastructure to be used,
detailed descriptions of all the individual test cases.
## <a name="issues"></a>1. Known issues 

This is likely to be a large and highly detailed document, describing many scripts, files, and other resources on the team repo (and possibly elsewhere). It is likely that the team will not have the time to fully complete all the various repo-side test content, so the known issues section should clearly and precisely identify what is incomplete (along with any other known errors/omissions in the document).

## <a name="tplan"></a>2. Test Plan

### <a name="toverview"></a>2.1 Testing Overview 

Here is a general overview of the testing environment, process, challenges, timeline, and test cases for our project.

#### 2.1.1 Testing Environment

We are using Unity’s Test Framework and Unity’s ‘Test Runner’ tool. This allows us to test through the Unity game engine, accurately simulating the live environment that the game runs through.

#### 2.1.2 Testing Process

Our tests will be automated, so we will not have any allocated ‘testers’. Group members will review test scripts to verify that they are working as intended before adding them to the testing branch.
The way the UTF works removes the need for us to manually test features every single time, allowing all tests to be done automatically (for CI/CD).
To run a test case, open Unity and go to Window > General > Test Runner in the options to open the Test Runner tool.
We compare the actual results to the predefined results to see if a test has passed or failed.

To ensure that our test process adheres to the version control process, all test scripts must be added to the testing branch immediately after being reviewed and verified to work properly.

#### 2.1.3 Test Cases

The purposes of a test case could be for a multitude of reasons, such as having objects behave as intended, interactions between objects work properly, having proper statistical updates, and ensuring UI features are updated throughout the game. As we are looking at user acceptance tests, we only are testing features and values specified in the [requirements document](#requirements.md), namely the ‘Key features and behaviour’ and ‘User interface and navigation’ sections.

#### 2.1.4 Testing Challenges

We have three major issues:
1. The unit testing and nature of the game - It’s difficult to write unit tests for each low-level unit, as they rely on some sort of input/action, or for multiple factors to occur at once.
2. Using the Unity Test Framework - The UTF is very restrictive and requires significant refactoring and reorganisation of our codebase to begin using it.
3. Possible errors with implementation - With the UTF we need to have predefined conditions, user actions, and expected results. Human error with these is very likely and may lead to inaccurate testing. 

#### 2.1.5 Testing Timeline
We will have two groups of three for our testing phase, three who will develop the test scripts, and three who will develop the test cases and their forms. A review will be done by one member of each group for each test script to verify that it works as intended.
After all core features for our product have been successfully implemented (by December 6, 2024), we aim to have all test scripts and forms for every feature developed, reviewed, run successfully, and reported by the end of February 2025.

### <a name="tchallenges"></a>2.2 Key Testing Challenges 

**Unit testing and the nature of the game:**
* Due to the nature of our game, it’s difficult to write deterministic unit tests for each low-level unit, as nearly all of them rely on user input/action of some complexity, or for a multitude of factors to occur at once. Instead, we will be using moderately-integrated behaviour-based testing. 
* Doing behaviour-driven testing instead doesn’t fully eliminate our problem, but it does make it much easier to simulate user input, without the time consuming nature of having to repeat user actions each time we want to test something.

**Using the Unity Test Framework:**
* The UTF (Unity Test Framework) is very restrictive, and requires significant refactoring and reorganisation of our codebase to begin working with it.
* examples/elaboration
* An additional problem with Unity testing creating extra unit test scenes for each run of the testing, which appears in our root access folder.

**Possible errors with implementation:**
* Since we are using the Unity Test Framework, we need to have predefined conditions, user actions, and expected results. It is very likely the author of the test case script could make an error which either causes a test to pass when it's not supposed to, or tests the wrong feature.

### <a name="ttimeline"></a>2.3 Testing Timeline 

Via our [standards and processes](#standards.md), anything that isn’t working as intended should not be pushed to main under any circumstances. This means we would have to have successfully tested everything in requirements before releasing the game as a product. The testing must be completed before Surrounded is released in its ‘v1.0’ state. Our plan and timeline to complete testing is as follows:

**Plan:**

As Anmol, Quetzal, and Connor have developed most of the project’s codebase, they will be responsible for writing tests that cover everything in the requirements.

As Luka, Casey, and Brandon have written most of the project’s documentation, they will be responsible for creating test cases based off of the requirements, and filling out test case forms.

When a test script has been implemented, one member from each group of three must review the script together to address any concerns and to verify that it works as intended (checks the right behaviour, has the right actions, etc.). 

The responsibility of the member from the first group is to have clean, concise, and well-documented code that can be explained easily to the other reviewer. The member from the second group is responsible for ensuring that the test checks every edge case and that it works as intended.
We plan to category by category, as tests are designed to not rely on tests from other categories working (Player Take Damage (PCC03 test) relies on having an enemy bullet with a damage value, not the fact whether the enemies shoot at the target or not (ENY00 test)).

With 10 hours per person, we are confident we are able to get one category done a week, as about 2-3 hours will be used for reviewing, and the rest for development. We may need to allocate an extra week to bosses and UI, as they are much larger categories than the rest. The timeline accounts for this concern.

**Timeline:**

* December 13, 2024 - All PCC test forms and scripts have been developed, reviewed, run successfully, and reported.
* December 20, 2024 - All MAT test forms and scripts have been developed, reviewed, run successfully, and reported.
* December 27, 2024 - All XPL test forms and scripts have been developed, reviewed, run successfully, and reported.
* January 3, 2024 - All RND test forms and scripts have been developed, reviewed, run successfully, and reported.
* January 10, 2024 - All ENY test forms and scripts have been developed, reviewed, run successfully, and reported.
* January 24, 2024 - All BOS test forms and scripts have been developed, reviewed, run successfully, and reported.
* January 31, 2024 - All UPG test forms and scripts have been developed, reviewed, run successfully, and reported.
* February 7, 2024 - All SAM test forms and scripts have been developed, reviewed, run successfully, and reported.
* February 21, 2024 - All UI test forms and scripts have been developed, reviewed, run successfully, and reported.
* February 28, 2024 - All test forms and scripts have been double checked, and a test run of all the tests will be conducted.

### <a name="tprocess"></a>2.4 Test Process 

As our tests are automated, we will not have any roles or responsibilities for the testers. We will have group members review our test case scripts to make sure they aren’t missing anything and are checking for the correct behaviour/values before adding them to the testing branch.
Our testing environment uses Unity’s Test Framework (UTF) and Unity’s ‘Test Runner’ tool. The UTF environment allows us to test through the Unity game engine, through ‘play mode’ on the Test Runner tool, on all target platforms. This works perfectly for us as it most accurately simulates the live environment that the game runs through. 

The Unity Test Runner tool uses an open-source unit testing library for .net languages. This allows us to run specific tests within the Unity environment, and be able to visually see the tests as the scripts execute as if the game were being played under those conditions. This allows us to more accurately observe tests to see where they could be messing up (especially for UI tests).

Unity’s Test Framework allows us to predefine user actions and the expected results to check if features are behaving as intended. This removes the need for us to manually test features every single time, allowing all tests to be automatically (for CI/CD).

To run a test case, open Unity and go to Window > General > Test Runner in the options to open the Test Runner tool.

To check that the expected results match the actual results, we compare the actual results to the predefined results. If the behaviour matches, the test has passed. If the behaviour doesn’t match, the test has failed. If all of the tests are run, just one test failure causes the whole test run to be a failure.

Our test results will then be output in a machine-readable XML file which can be read by Unity and GitHub Actions giving us a log of how the tests were run and if they either passed or failed.

To ensure that our test process adheres to the version control process, all test scripts must be added to the testing branch immediately after being reviewed and verified to work properly.

### <a name="tcases"></a>2.5 Test Cases Summary and Organization

We broke down the tests based on the section the feature was under in our [requirements document](). We have two main types of tests: tests on gameplay features and tests on UI features.

**Gameplay features:**
Each section in key features has a three letter code corresponding to the section the feature is from in its ID (for example, PCC = player, controls, and combat). The ID also contains a  0-indexed two digit number which describes the order the features appear in that section of the requirements (00 is the first feature listed that is tested, or closest to the top of that section).

* The reason for this is to ensure every feature in the requirements is tested, and to be able to easily refer to the requirements for writing test case conditions/requirements.
* For example, test RND01 will be the feature second closest to the top (of all features tested) under the “round system” feature section.

**UI features:**
All UI tests have an ID beginning with “UI” to separate them from the main gameplay features, they will be tested in their own custom order one by one.

All test categories (the letter codes) are listed in order of where they occur in requirements (sections 5 and 6).
* For example, the first section, PCC, is the first subsection of key features. To reiterate, all features under section 6 (UI and Navigation), have tag UI.

### <a name="tlist"></a>2.6 Test Case List

Below is a list of all test cases for the project, this list will be updated as more cases are added.

#### 2.6.1 Player, Controls, and Combat Tests

ID: PCC00
Name: Player Movement
Description: Checks that the WASD keys make the player ship move, and that the player has velocity.

ID: PCC01
Name: Player Aim and Weapon 
Description:Checks that the player ship looks towards the mouse cursor and that left click makes you fire + holding left click makes you fire. 

ID: PCC02
Name: Enemy Take Damage
Description: Checks that the enemy takes appropriate damage (based on player’s damage) from an enemy bullet. Also that the enemy flashes red for 0.2s

ID: PCC03
Name: Player Take Damage
Description: Checks that the player takes appropriate damage from an enemy bullet.

ID: PCC04
Name: Player Defense
Description: Checks that the player takes appropriate damage (reduced by defence) from an enemy bullet and based on the player’s base defence stat.

ID: PCC05
Name: Player I-frames 
Description: Checks that the player gains 20 invincibility frames upon hit, and that the player blinks when invincible.

ID: PCC06
Name: Player Death 
Description: Checks that when player health hits 0, they die.

ID: PCC07
Name: Enemy Death
Description: Checks that when enemy health hits 0, they die (also applies to asteroids).

ID: PCC08
Name: Collision Damage 
Description: Checks that collisions do correct amount of damage (depends on requirements, still being changed), (also applies to asteroids).

ID: PCC09
Name: Speed Capacity
Description: Checks that player speed does not go above 30, by setting player speed to 30 and then setting it to something above 30.

#### 2.6.2 Map and Terrain Tests

ID: MAT00
Name: Asteroid Spawn
Description: Check if asteroid objects can be spawned and in clusters (random assortment).

ID: MAT01
Name: Comet Spawn 
Description: Checks that the on-screen countdown for the comet appears when the player is out of bounds, and that the comet appears and chases the player when the timer reaches 0.

ID: MAT02
Name: Asteroid Capacity
Description: Check that more than 16 asteroid clusters can’t be on the map at once.

ID: MAT03
Name: Asteroid Movement
Description: Check if asteroid clusters move together at a slow rate in a straight line, while rotating.

ID: MAT04
Name: Asteroid Death
Description: Checks that asteroids die after 3 player bullets hit it.

ID: MAT05
Name: Camera Follow 
Description: Check if the camera tracks the player’s movement.

#### 2.6.3 XP and Levelling System Tests

ID: XPL00
Name: Player XP Enemy
Description: Checks that the player gains the correct amount of XP when killing an enemy.

ID: XPL01
Name: Player XP Boss
Description: Checks that the player gains the correct amount of XP when killing a boss.

ID: XPL02
Name: Player Level Up
Description: Checks that when XP requirement is met, player levels up. Then checks that stats are increased by the appropriate amount and XP gets set back to 0.

ID: XPL03
Name: Level Up Requirement
Description: Checks that upon level up, the XP requirement for the next level increases by 10%.

#### 2.6.4 Round System Tests

ID: RND00
Name: Round Startup
Description: Checks that the game receives credits for the round and that the timer is set to 55.

ID: RND01
Name: Enemy Spawn
Description: Make sure enemies spawn when the timer reaches 50 seconds, and every 5 seconds after that. Also checks that 90% of credits for the round are remaining after the first spawn, and 10% less after each spawn.

ID: RND02
Name: Credit Increase
Description: Check that the credits increase by 10% each round.

ID: RND03
Name: Enemy Spawn Prevention
Description: Make sure juggernaut doesn’t spawn before round 5, striker before round 11, and dreadnought before round 15 (check credits/10 at each round and compare to credit cost of enemy).

ID: RND04
Name: Enemy and Asteroid Wipe
Description: Checks that all enemies and asteroids are wiped at the end of each round.

ID: RND05
Name: Item Selection
Description: Check that item selection condition is started and that the next round will not start until an item is selected.

ID: RND06
Name: Player Health Restoration
Description: Checks that the player's health is replenished at the start of a new round.

ID: RND07
Name: Portal Instantiation
Description: Checks that on round 10 (a boss round) that a portal appears in the middle of the map and sucks the player in.

ID: RND08
Name: Portal Scene Transition
Description: Checks that entering the portal transitions the game into a ‘boss round’ scene.

ID: RND09
Name: Boss Round Screen Lock
Description: Check that the player and boss can’t leave the screen, and that the camera doesn’t track the player.

Note that the boss health bar will be checked in the UI tests.

ID: RND10
Name: Enemy Spawn in Boss Round
Description: Check that no enemies spawn in boss round.

ID: RND11
Name: Return to Gameplay Scene
Description: Checks that the game leaves the 'boss round’ scene and is in the ‘gameplay’ scene after item selection at the end of boss round.

#### 2.6.5 Enemy Design Tests

ID: ENY00
Name: Enemies Shoot at Target
Description: Checks that enemies shoot towards the player and not in random directions.

ID: ENY01
Name: Enemies Spawn Off-Screen
Description: Checks that enemies don’t spawn on-screen.

ID: ENY02
Name: Enemy Stat Increase
Description: Checks that enemy stats increase when a new round starts.

ID: ENY03
Name: Enemy Stat Spawn
Description: Checks that enemies spawn with correct stats on current round (e.g. juggernauts spawn with base stats on round 5, vipers with 4 level ups on round 5).

ID: ENY04
Name: Enemy Collision Avoidance
Description: Checks that enemies actively avoid colliding with asteroids or each other if possible.

ID: ENY05
Name: Viper Behaviour
Description: Check that vipers have proper behaviour.

ID: ENY06
Name: Grunt Behaviour
Description: Check that grunts have proper behaviour.

ID: ENY07
Name: Juggernaut Behaviour
Description: Check that juggernauts have proper behaviour.

ID: ENY08
Name: Striker Behaviour
Description: Check that strikers have proper behaviour.

ID: ENY09
Name: Dreadnought Behaviour
Description: Check that dreadnoughts have proper behaviour.

#### 2.6.6 Bosses Tests

ID: BOS00
Name: Boss Instantiation
Description: Checks that a boss spawns instead of normal enemies (and no normal enemies spawn).

ID: BOS01
Name: W35-S315 Instantiation
Description: Checks that the W35-S315 boss spawns on the correct round (round 10), and not any other bosses. Also checks that W35-S315 has the correct stats when spawned.

ID: BOS02
Name: W35-S315 - Merge Conflict Execution
Description: Checks that the W35-S315 telegraphs and executes the merge conflict attack properly.  

ID: BOS03
Name: W35-S315  - Merge Conflict Behaviour
Description: Checks that the W35-S315 merge conflict attack properly behaves properly (based on requirements, expected to change)

ID: BOS04
Name: W35-S315 - Merge Conflict Interaction
Description: Checks that the W35-S315 merge conflict attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS05
Name: W35-S315 - Git Branch Execution
Description: Checks that the W35-S315 telegraphs and executes the git branch attack properly.  

ID: BOS06
Name: W35-S315  - Git Branch Behaviour
Description: Checks that the W35-S315 git branch attack behaves properly (based on requirements, expected to change)

ID: BOS07
Name: W35-S315 - Git Branch Interaction
Description: Checks that the W35-S315 git branch attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS08
Name: W35-S315 - Ponytail Whip Execution
Description: Checks that the W35-S315 telegraphs and executes the ponytail whip attack properly.  

ID: BOS09
Name: W35-S315  - Ponytail Whip Behaviour
Description: Checks that the W35-S315 ponytail whip attack behaves properly (based on requirements, expected to change)

ID: BOS10
Name: W35-S315 - Ponytail Whip Interaction
Description: Checks that the W35-S315 ponytail whip  attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS11
Name: W35-S315 - Movement
Description: Checks that the W35-S315 has proper movement behaviour (tracks and follows player), and speed (75% of player’s speed).

ID: BOS12
Name: C0B-U5 Instantiation
Description: Checks that the C0B-U5 boss spawns on the correct round (round 20), and not any other bosses. Also checks that C0B-U5 has the correct stats when spawned.

ID: BOS13
Name: C0B-U5 - Cartesian Product Execution
Description: Checks that the C0B-U5 telegraphs and executes the cartesian product attack properly.  

ID: BOS14
Name: C0B-U5 - Cartesian Product Behaviour
Description: Checks that the C0B-U5 cartesian product attack properly behaves properly (based on requirements, expected to change)

ID: BOS15
Name: C0B-U5 - Cartesian Product Interaction
Description: Checks that the C0B-U5 cartesian product attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS16
Name: C0B-U5 - Matrix Bomb Execution
Description: Checks that the C0B-U5 telegraphs and executes the matrix bomb attack properly.  

ID: BOS17
Name: C0B-U5 - Matrix Bomb Behaviour
Description: Checks that the C0B-U5 matrix bomb attack behaves properly (based on requirements, expected to change)

ID: BOS18
Name: C0B-U5 - Matrix Bomb Interaction
Description: Checks that the C0B-U5 matrix bomb attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS19
Name: C0B-U5 - Factorial Execution
Description: Checks that the C0B-U5 telegraphs and executes the factorial attack properly.  

ID: BOS20
Name: C0B-U5 - Factorial Behaviour
Description: Checks that the C0B-U5 factorial attack behaves properly (based on requirements, expected to change)

ID: BOS21
Name: C0B-U5 - Factorial Whip Interaction
Description: Checks that the C0B-U5 factorial attack damages the player for an appropriate amount and has appropriate collision behaviour with the player.

ID: BOS22
Name: C0B-U5 - Movement
Description: Checks that the C0B-U5 has proper movement behaviour (moves in left to right top third of the screen), and speed is 75.

ID: BOS23
Name: Boss Take Damage
Description: Checks that bosses take an appropriate amount of damage (based on player damage) from player bullets.

#### 2.6.7 Upgrade Items and System Tests

ID: UPG00
Name: Rocket Boosters
Description: Checks that the player’s movement speed is increased by 10%.

ID: UPG01
Name: Machine Guns
Description: Checks that the player’s fire rate increases by 10%.

ID: UPG02
Name: Diverge
Description: Checks that the player shoots 3 bullets in a cone formation and that the player’s fire rate is reduced by 50%.

ID: UPG03
Name: Fortified Plating
Description: Checks that the player’s health is increased by 10% of their current max health.

ID: UPG04
Name: Forcefield
Description: Checks that the player gets the forcefield status update.

ID: UPG05
Name: Roulette
Description: Checks that the player’s orb count variable is increased to 1 and that the roulette orb object is instantiated.

ID: UPG06
Name: Piercing Rounds
Description: Checks that the player’s bullets pierce through one enemy/asteroid.

ID: UPG07
Name: Piloting Enhancements
Description: Checks that the player’s level is increased by 2 and that their stats are updated for the level ups.

#### 2.6.8 Sounds and Music Tests

ID: SAM00
Name: Firing Sound
Description: Check that the appropriate sound file executes when the player fires their weapon.

ID: SAM01
Name: Enemy Death Sound
Description: Check that the appropriate sound file executes when an enemy dies.

ID: SAM02
Name: Round Music
Description: Check that the appropriate music plays for the duration of a round.

ID: SAM03
Name: Menu Music
Description: Check that the appropriate music plays when in the main menu.

#### 2.6.9 User Interface and Navigation Tests

ID: UI00
Name: Main Menu
Description: Check that the main menu properly displays upon boot of game and exit of gameplay.

ID: UI01
Name: Game Screen
Description: Check that upon pressing the start game button that game and UI is displayed.

ID: UI02
Name: Health Bar
Description: Check that the health bar is accordingly updating upon damage taken.

ID: UI03
Name: XP Bar and Level Counter
Description: Check that XP bar is updated accordingly when exp is gained, and that the level counter shows the current player level.

ID: UI04
Name: Timer And Round Counter
Description: Check that the in-game timer is correctly counting down as well as the round count.

ID: UI05
Name: Score Bar
Description: Checks that the score bar is being updated accordingly when score has been gained.

ID: UI06
Name: Boss Health Bar
Description: On boss rounds, check that boss health bar is instantiated with the proper boss name and health. Also check that the health bar is updated accordingly when the boss takes damage.

ID: UI07
Name: Pause Menu
Description: Checks that when the ESC key is pressed, the pause menu is opened.

ID: UI08
Name: Stats and Upgrades Menu
Description: Check that when selected in the pause menu, the stats and upgrades menu is displayed and accordingly shows stats and acquired upgrades.

ID: UI09
Name: Restart Option
Description: Check that the restart button in the pause menu is working as intended and restarts the game from beginning.

ID: UI10
Name: Quit Game
Description: Check that when the quit game option is selected, the game exits to the main menu.

ID: UI11
Name: Item Selection Screen
Description: Upon completion of round, the item menu is displayed and correctly displays three randomly selected items (no duplicates). Also checks that the player can select an item to close the menu, and that it correctly displays player stats below.

ID: UI12
Name: Shield Bar
Description: Check that shield acquisition correctly displays and works on player health bar UI.

ID: UI13
Name: Game Over Screen
Description: Correctly displays game over menu when players health reaches ZERO, make sure that players score is displayed and that options in game over screen are working correctly (restart, quit to main menu).

## <a name="infra"></a>3. Test Infrastructure

### <a name="tools"></a>3.1 Software Tools and Environment 

Our testing process will be using Unity’s Test Framework, which is Unity’s built in testing environment which allows us to create a test script that runs alongside our game scripts, letting us create tests in ‘edit mode’ and run them in ‘play mode’.

The Unity Test Framework will be configured to run the tests for the following platforms:
* Windows 64-bit
* Mac 64-bit
* Linux 64-bit

For our testing, our group members will use their laptops, giving us a variety of different operating systems to test on to ensure that all tests are passing across all of our required operating systems. They will also be tested on a Linux Virtual Machine as part of the GitHub Actions CI/CD, so when we merge additional code changes, they will be tested alongside their integration to make sure all old tests still pass, ensuring our game still works as intended.

Our tests are 100% behaviour-driven and will not be using any “user action scripts”, however, they will simulate said ‘user action scripts’ in an automated fashion. Unity’s Test Framework allows us to pre-define user actions and the expected results to check if features are behaving as intended. This removes the need for us to manually test features every single time, allowing all tests to be done automatically (for CI/CD).

The Unity Test Framework also allows us to see the tests run in realtime through the ‘Test Runner’ tool in Unity, which allows us to individually test each test script showing in the gameplay screen the test being initiated and ran to completion.

With all of these things running internally in Unity, we have no need for external resources such as AI, databases and web servers to run our tests.

Our test results will then be output in a machine-readable XML file which can be read by Unity and GitHub Actions giving us a log of how the tests were run and if they either passed or failed.

### <a name="exec"></a>3.2 Executables (Test Programs/Scripts, Stubs and Drivers)

Unity is the driver of all test scripts. Test case scripts will be set up in a one-per-file structure – one test case, one file. All set-up and tear-down required for the case will be performed in that file. Test cases will be grouped into directories by subsection in the requirements (E.g. all PCC tests in one directory, RND tests in another, etc.).

Tests will be entirely automated as they are behaviour-driven. To run tests, a user must:
1. Open Unity’s Test Runner Window
2. Click “Run All Tests”
3. Observe the test results as they appear in the Test Runner output window or in the log outputted by GitHub Actions/Unity after it reads the XML file.

The Test Runner tool will be used in the process of setting up and evaluating tests. When the tool opens up, go into ‘Play Mode’ select the test script you want to use. The Test Runner will then display visual feedback via a checkmark or an ‘X’ whether the test has passed or failed.

Tests will return pass/fail to the Test Runner. All tests must pass for the run to be considered successful. Failing at least ONE test renders the whole test run as a failure.

A cleanup script located in the project root named ‘clean.sh’, will be used to do all cleanup after each test case. As all scripts are run the same way, all of them will have the same cleanup process. This process is simply just deleting the garbage Scene files created by the Test Runner located in the ‘surrounded/Assets’ directory

Test directories are grouped under the directory `surrounded/Assets/Tests`, and under their own assembly definition. Tests will only be compiled as-needed, and are not compiled with regular release builds.

#### This information is the same for all test scripts:

Setup actions: No prior setup needed, use the Unity Test Runner tool and select the script. This is how scripts will be executed.

Tester actions: Open the Test Runner tool through Unity by going to Window > General > Test Runner in the options. When the tool opens up, go into ‘Play Mode’ select the test script you want to use. The Test Runner will then display visual feedback via a checkmark or an ‘X’ whether the test has passed or failed.

How to assess pass/fail: The Test Runner tool will tell you whether the test has passed or failed based on the expected behaviour. Later on, we will have the test data output into an XML file that will be viewable via a test log.

Cleanup: The `clean.sh` script will handle all test script cleanup after the test script has terminated. This script is located in the project root.

#### Here is the list of each specific test script (to date):

Last updated November 21, 2024.

Name: PCC00.cs
Location: surrounded/Assets/Tests/PCC00.cs
[Link to source code](../surrounded/Assets/Scripts/Bullet.cs)
Overview:

Name: PCC01.cs
Location: surrounded/Assets/Tests/PCC01.cs
[Link to source code]()
Overview:

Name: PCC03.cs
Location: surrounded/Assets/Tests/PCC03.cs
[Link to source code]()
Overview:

Name: MAT01.cs
Location: surrounded/Assets/Tests/MAT01.cs
[Link to source code]()
Overview:

Name: MAT05.cs
Location: surrounded/Assets/Tests/MAT05.cs
[Link to source code]()
Overview:

Name: XPL00.cs
Location: surrounded/Assets/Tests/XPL00.cs
[Link to source code]()
Overview:

Name: RND01.cs
Location: surrounded/Assets/Tests/RND01.cs
[Link to source code]()
Overview:

Name: ENY01.cs
Location: surrounded/Assets/Tests/ENY01.cs
[Link to source code]()
Overview:

### <a name="vc"></a>3.3 Version Control and Branch Structure 

For our version control and branch structure we will closely follow the rules we have laid out in our standards and processes document:
* The ‘Testing’ branch remains the total integration branch for all playtesting and beta build distribution.
* GitHub Actions automated testing will be incorporated into the merge checks for the ‘testing’ and ‘main’ branches.
* GitHub configurations, information, and scripts will be held in ‘.github’ in our project root.
* GitHub Actions scripts will run all of the tests defined for the game on each pull request of the branch, checking if code changes alter the existing test results.

### <a name="content"></a>3.4 Directory, File Structure, and Content

* All testing scripts will be kept in the ‘Assets/Tests’ directory. This directory will have subdirectories for each category of tests, a ‘PCC’ subdirectory will contain all PCC category tests.
* Each test case has its own script, which is named after its ID. Each test case is executed by the Test Runner tool in Unity. These scripts essentially act as our action scripts and executables. The simulated user input, test setup, and expected output, are all contained in this file. If the expected output matches the output from the test, the test has passed. Otherwise, the test has failed.
* As explained before, the ID corresponds to what kind of testing the script is used for. All category tests are gameplay tests, except tests with IDs ‘UIxx’, which are for UIX and navigation tests.

### <a name="external"></a>3.5 Independent Subsystems and External Resources (Project Web/Database Servers)

GitHub Actions uses a yaml configuration document to describe a script that is run on a Linux Virtual Machine and whose results are reported to GitHub. These yaml files will be located in the `.github` file in the project root. If the project is not pushed to GitHub, these yaml files are inert.

No other external resources are used as Unity, the Unity Testing Framework, and its tools are all that is required for our testing.

## 4. <a name="appendix"></a>Appendix: Detailed Test Case Descriptions 

Our detailed test case descriptions are located in our [testcases.md document](#testcases.md). All of them are separated by a divider and are in order based on where they appear in [section 2.6](#tlist).
