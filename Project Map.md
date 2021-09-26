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

