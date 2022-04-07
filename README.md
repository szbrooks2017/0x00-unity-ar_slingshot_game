# 0x00-unity-ar_slingshot_game
 An "Angry Birds-like" augmented reality game. This project aims to explore ARKit and ARCore under the AR Foundation SDK.

 ## How to Install
 - Builds are located [here](https://drive.google.com/drive/folders/1Asb0yfI-RbNbvum4cZBZ88HaGyTOXzBQ?usp=sharing)
 - Further instructions coming.

 ## Applied Features
 - Plane Detection - Using AR Foundation the user can detect surface planes and select them.
 - Nav Meshes - a NavMesh is then added after runtime on to the selected plane
 - Nav Agents - AI spawn on the plane for you to shoot!!
 - UI - There is an integrated dashboard that guides the user through the game.

 ## Upcoming Features
 - The AI needs models!
 - Currently the ammo spawns in a weird relation to the NavMesh, It's like it is below the NavMesh if you're too close. 
 - Line Rendering - So that the predicted direction the ammo can be displayed to the user.

 ## Challenges
 - Debugging, i added text to the screen as a debug.log outlet but it was tedious deploying from Unity to Xcode to my phone.
 - NavMeshes - NavMeshes are a lot of fun! Creating them after runtime not so much! Especially in Augmented Reality, but i did it!
 - Linear Algebra - This was the first project where I had to utilize in-depth knowledge of working with vectors. The length of the vector between the Ammo's starting postion and the position of the end of the drag affects teh force applied to the ammo.
 - Gravity - Applying physics so that its relative for the proximity of the objects and to you.

## Developer
I'm Stratton Brooks, an XR developer based in Tulsa, OK. I'm Native American. I specialize in Unity and WebXR.
[Linkedin](https://www.linkedin.com/in/stratton-brooks/)
