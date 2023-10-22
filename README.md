# Remote Game Settings
This is the package project for the exercise/example for MadBox.  
The "main project" is here: https://github.com/romainPechot/remote-game-settings

## How To Use This Module
1. Create/open a unity project using Unity 2021.3.24.
2. Open Unity's Package Manager (from the menu `Window/Package Manager`).
3. Copy this repo URL: https://github.com/romainPechot/com.madbox.exercice.remote-game-settings
4. Inside the Package Manager window, click the top left button "+".
5. Inside the new dropdown menu, select "Add package from git URL...".
6. Paste this repo URL inside the new "URL" textfield.
7. Click the button "Add".
8. Wait for the package to download and import.
9. Once the package has been imported you can:
   1. Check the ingame/editor samples (inside the Samples section of the Package Manager window).
   2. Directly fetch the `GameSettings` from the `GameSettingsManager` inside the `MadBox.Exercice` namespace from your script.

## Description
### Editor Demo
The editor demo is a simple window that allow you to view the game's settings.  
  
**⚠️At the moment those settings can only be fetched/loaded while the game is running.**  
This is due to the fact that those settings most important context is ingame/runtime).  
The whole process could be running inside the editor but requires more specs/time that didn't seems necessary at the moment.  

### Ingame Demo
The ingame demo is a simple script that fetch the game's settings, wait for them and instantiate a number of capsule (with random colors) based on the number of entities of the game's settings.  
  
To test it, add the script `MonoBehaviorThatNeedsGameSettings` to any `GameObject` inside a `Scene` and play the game.  
A UI label should be visible at the top left corner of the game screen indicating the status of the fetching processus.  
If the processsus fail, a single red capsule should be visible (with the label showing "Error").  
The whole processus should also generate logs to have a more detailed report.

## Note
The whole coding took me one standard work day. There was nothing extremely new to me (which is a good thing).  
I've used/"wasted" half a day to script a distribution processus that would extract the package folder from the Unity project but it was messy and didn't really solve my real problem...  
... which was to correctly setup my local repo so I could create a clean/valid github project for Unity's Package Manager, which also took me half a day.  
But now I can quickly edit something inside the Unity project, commit and push to the package repo and update any project that use this module/repo :+1:  
~~Technically the "main project" repo (https://github.com/romainPechot/remote-game-settings) is not useable as is, but I don't really have a proper solution right now.~~  
~~I've found a solution using `git submodule`.~~  
I can't really make it work using `git submodule`.
