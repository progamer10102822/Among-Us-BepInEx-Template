# Among-Us-BepInEx-Template
Among Us Android Medic Role Mod (BepInEx & Harmony)
​This project provides the basic skeleton for a custom Medic role mod developed for Among Us on Android (ARM64) using the BepInEx.IL2CPP and Harmony framework.
​📋 Features
​Blue Name Color: Players with the Medic role automatically have their names displayed in blue in-game.
​Revive Mechanic: The Medic can approach a dead player's body and revive them back to life within a specific distance range.
​🛠️ Requirements
​A rooted or mod-supported Android device (such as Galaxy Tab A9)
​Among Us (with BepInEx.IL2CPP installation compatible with the IL2CPP version)
​.NET SDK (to compile the C# class library)
​Il2CppInterop / BepInEx libraries (for game classes like PlayerControl, DeadBody, etc.)
​🚀 Installation and Compilation
​Open the project in Visual Studio or Visual Studio Code as a C# Class Library.
​Add the necessary DLL files from the game directory (BepInEx/core and BepInEx/plugins) as references to your project.
​Build the project to get the .dll output.
​Copy the resulting .dll file into the Android/data/com.innersloth.spacemafia/files/BepInEx/plugins directory on your Android device.
​Launch the game.
​⚠️ Notes
​This code provides a base template. Synchronization (RPC) is required in multiplayer modes; otherwise, the revive action will only appear on your screen and will be rejected by the server.
