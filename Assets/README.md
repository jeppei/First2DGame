# First 2D Game - Unity notes

## If game objects are missing after cloning the repo
After cloning and opening the project, it might seem like the game objects are missing. This is because a new scene is shown in the Hierarchy. 
To open an existing scene with game objects go to the Project view (usually at the bottom of unity when having default settings) then in the 
folder scenes you can find all the scenes. Open the first one and you will find the level with the player, terrain etc. [Source](https://forum.unity.com/threads/game-objects-missing-from-hierarchy-pane.23289/)

## Good tutorials:
- This project was created with this tutorial: [link](https://youtube.com/playlist?list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U)
- Tutorial on how to build to android devices: [link](https://youtu.be/Nb62z3J4A_A)

## Camera movement
The camera is set as a child to the player object. In that way it follows the player.

## Hierarchy
The position of child objects it relative to their parents.

## Components
### **Grid**
Controls the size of the grid (probably best to leave it as default) and if you want a squared grid, hexagonal grid or something else.

### **Transform**
Defines the postiion, rotation and scale for the object

### **Tilemap**
This one is used by the Tile palette to draw tiles in this object. This is used by the background and the terrain. Here is a good tutorial on how to set this up: [link](https://youtu.be/QkbGr1rAya8)

### **Tilemap renderer**
The sorting layer is to sort the background behind the Terrain and player.

### **Rigid body 2D**
Add a rigid body to make the object behave as an physics object with gravity.
- Set "Body Type: Static" to not make them fall.
- Set Constraint / Freeze Rotation = True to not make the player rotate.

### **Colliders**
Are use to check collisions between objects. Collisions can only be detected between a Collider and a RigidBody. For more info see this thread: https://forum.unity.com/threads/how-do-i-detect-collision-between-colliders.264594/
- Colliders:
    - Tilemap collider 2D
    - Composite colider 2D
        - Add this and set Tilemap Collider 2D / Used by composite = true to make the platform bounds around the terrain and not arround each square/tile.
    - Box Collider 2D
        - "Is Trigger" disables so that the player doesn collide with the object and instead goes throug it and then it triggers something.

### **Plattform effector 2D**
This one is added so that the player cannot stick to the side of plattforms. Untick the "Use One Way" and In "Composite Collider 2d" check the box "Used By Effector"

### **Scripts**
Are added to add code to objects. For example a movement script is added to the player to add movement to the player.

### **Sprite renderer**
To add a sprite to an object. The players sprite is added here.

### **UI Components**
When creating a text (legacy) game object, a canvas game object and a Event system game object will also be created (dont delete these). 
The text game object will be placed under a canvas game object. 

The Canvas game object has the following components:
- Rect Transform
- Canvas
- Canvas Scalar
- Graphic Raycaster

The Text game object has the following components:
- Rect Transform
- Canvas Renderer
- Text

The EventSystem game object has the following components:
- Transform
Event System
Standalone Input Module

The EventSystem is handles inputs mouse clicks and buttons.