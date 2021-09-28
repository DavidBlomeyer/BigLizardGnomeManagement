INDEX -


Code Flow Diagram -

01_KomodoConsole
	00_Program.cs -> 
		01_ProgramUI.cs - UI - Nested Menus - Local Methods - Seed Data
			ref: PeopleRepo, TeamRepo, LogRepo
		
02_KomodoTest (TestMethods)

03_PeopleRepo
	People.cs - POCO
		PeopleRepo.cs - ML - CRUD - Helper

04_TeamRepo
	Team.cs - POCO
		TeamRepo.cs - ML - CRUD - Helper

05_LogRepo - (P)
	Log.cs - POCO
		LogRepo.cs - ML - CRUD


Key -

( )				( ) - Note pertaining to this section of code. Generally, should identify where in code and what action needed.

(V) 			Vestige - Commented out incomplete/unused/old features.
(P)				Placeholder - Prototype or faked so other things work.
(I)				Incomplete - Incomplete stuff.

(Words !) 		Important Issue - This section of code has a known issue that needs fixed but is not critical. (Important but not Urgent)
(Words !!!)		Critical Issue - This section of code has a critical issue. (Important and Urgent)


Known Issues/To Do For the Future -

While File Names are consitent with the assignment, the namespaces and some naming is not.
Some inputs (not using an input one example) can throw exceptions - (not mapped) or (handled)
While Loops are left open by menus (not an issue here, but sloppy)
Create and Update Commands work, but do not currently have coded confirmations
Password, Access Level, and Log Functions Incomplete and Currently (V)
Both "U"'s in the CRUD's currently work but are not used in the current Code
Console.WriteLine "UI TEXT" is not 100% consistent - '.'s are sometimes there, sometimes not - (not mapped)
Test Method basically unused.
Does not save data - research bookmarked JSON libary
Is not a free standing .exe
Migrate Methods from Program UI to the Repos
Maybe forms for UI
Get more sleep
Odd files in Git repo - FIXED


AAR - (after action review)

UI
	1. its kind of "old school" - for better and for worse
	2. function could be more obvious - less explaining how it works, more "context clues"

Naming Convention
	1. Not 100% consistnet - mix of my own and source code
	2. Often not descriptive enough

Comments
	1. Less content in comments, more in naming

Structure/Organization
	1. Number of Methods in ProgramUI not optimal - should have either moved to Repo or other library
	2. Seriously question the decision to use fields in this way

