# 1-HP-Wizard

## Introduction
1 HP Wizard is a multi-level, gesture-based, spellcasting game. In this game, the user stands in a stationary location and fends off waves of enemies homing in on their position. 

The player will have to react quickly and strategically since it only takes one hit to defeat them.


## Getting Started (Just Playing)
### Prerequisites
* Oculus (Software)
* Oculus Rift (Hardware)
* Internet connection

### Downloading (55.3MB)

1. Go to the release page by clicking this link

	https://github.com/scott0123/1-HP-Wizard/releases

2. Click the most recent `Build.zip` to download the latest build

3. Unzip the `Build.zip` at the location where you would like to store the game.
	
	Only the Windows version is available at present time.

### Running

Double click `1 HP Wizard.exe` from the folder from the previous step to start the game.

## In-game Pictures

![1 HP Wizard Menu](./Images/demo1.png)

![1 HP Wizard Level 1](./Images/demo2.png)

## Getting Started (Development)
### Prerequisites
* Oculus (Software)
* Oculus Rift (Hardware)
* Unity 2018.2.14f1 (for development)

### Downloading (1.77G)

Clone this project.

`cd CLONE_LOCATION` (use cd to navigate to your desired clone location)

`git clone git@github.com:scott0123/1-HP-Wizard.git` or `git clone https://github.com/scott0123/1-HP-Wizard.git`

### Scenes

* `1-HP-Wizard/Assets/Scenes/Menu.unity`
* `1-HP-Wizard/Assets/Scenes/Tutorial.unity`
* `1-HP-Wizard/Assets/Scenes/Level1.unity`
* `1-HP-Wizard/Assets/Scenes/Level2.unity`
* `1-HP-Wizard/Assets/Scenes/Level3.unity`

### Building

`File > Build Settings`

Select your target platform.

`Build`

Select your build location.


## Design

### Theme
![Theme image](./Images/theme.png)

### Class Hierarchy
![Hierarchy image](./Images/hierarchy.png)

### Spell gestures
![Fireball gesture](./Images/fireball_icon.png)
![Lightning gesture](./Images/lightning_icon.png)
![Ice gesture](./Images/ice_icon.png)
![Earth gesture](./Images/earth_icon.png)
![Air gesture](./Images/air_icon.png)
![Shield gesture](./Images/shield_icon.png)

### Gesture Model Serving Architecture
![Gesture Model Serving Architecture](./Images/GestureServingArchitecture.png)

### Gesture collection data sample
3D representation of one of our earth gestures datasets.

This is used to train the `Earth` Class in our model.
![Earth gesture 3d](./Images/earth.gif)

3D representation of one of our erroneous gestures datasets.
This is used to train the `Unknown` Class in our model.
![Error gesture 3d](./Images/error.gif)

### Game Design Document
https://docs.google.com/document/d/1hs4El7qzT2vCHhaPN9zTqvtF0LksF_KemcwoVwB_Los/edit?usp=sharing

### Project initial proposal
https://s3.us-east-2.amazonaws.com/scott-liu-storage/Project+Proposal+498.pdf

## Contact

You may reach me at `1hpwizard@scott-liu.com` to inquire about this project.
