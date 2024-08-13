# Albatross
___________________________________________________________________________
**Disclaimer**

ALbatross is a tool to modify the data of some yokai watch games. The tool is for:
- modders who want to create a mod 
- people who want to test some things 

It should only be used for creating a mod or for personal use. Don't use Albatross to modify your game and cheat online, you will just ruin the experience of other players and ruin the reputation of Albatross. If I see a lot of people bypass my tool to ruin the online experien, there will be no more updates.

**What is a Game Editor?**

Albatross is a Game Editor, you should'n confuse a Save Editor with a Game Editor.  
- Save editor: is a tool that reads a save and modifies the data in the save (e.g add yokai in your party, raise the level of your yokai). If you pass your save to someone, the guy will have acces to the change you made on your save.
- Game Editor: is a tool that reads the game data and can modify some data (e.g yokai tribe, yokai attack, yokai soultumate, ...). If you modify your game, only you can see the modified data, if you pass your save to someone, the guy will haven't acces to your modified data, to have acces to your modified data you have to pass him your game file (not your save)

**What is the project?**

Albatross is a project to create an application that can modify some Yo-Kai Watch games like PK3DS.
The Tool is written in C# and the project is Open Source, everyone can contribute.

**Supported Game**
- Yo-Kai Watch ✅
- Yo-Kai Watch 2 ✅ (BF/FS/PS)
- Yo-kai Watch 3 ✅
- Yo-kai Watch Blasters ✅

**Special Thanks**  

My tool couldn't have been done without the logic that I could learn by studying Metanoia and Kurriimu.
- [RoadrunnerWMC (For LZ10)](https://github.com/RoadrunnerWMC/ndspy)
- [Ploaj (For some logic about L5 files)](https://github.com/Ploaj/Metanoia/tree/master/Metanoia)
- [onepicefreak (For some logic about L5 files)](https://github.com/FanTranslatorsInternational/Kuriimu2)
- Reza Aghaei, tobeypeters, r-aghaei  (For the dark mod of some vs control)

**Screenshot**

![](https://i.imgur.com/sKDoY2J.png)

**How to use it**

1. Decrypt your game (google it)
2. After decrypting your game you will get ExtractedRomFs folder *if your game has an update and you are playing the update, it's recommended to merge .fa
3. Open Albatross create a new project, specify project name, project game, project language and select the ExtractedRomFs
4. Load your new Project, Allbatross will open HomeGame window, click on an option like charaparam to edit yokais
5. Edit some stuff
6. When it's done, on the HomeGame window click on Save, wait... During save process Albatross will freeze, don't panic!  
- **Apply your mod on Citra:**
1. Go to ExtractedRomFs Folder
2. 
- If you have YKW1: copy yw1_a.fa. 
- If you have YKW2: copy yw2_a.fa and yw2_lg_[YourLanguageCode].fa. 
- If you have YKW3 copy yw_a.fa and yw_lg_[YourLanguageCode].fa
- If you have YKWB1 copy yw_a.fa and ywb_lg_[YourLanguageCode].fa
3. Open Citra
4. Right click on your Yokai-Watch Game
5. Click on "Open mod location", citra will open a new file explorer window
6. On the new window create a romfs folder
7. Click on romfs folder and paste
8. Now you can run your game, your game will have the changes, if there are no changes try the tutorial again
- **Apply your mod on 3ds (Custom Firmware):**
1. Go to ExtractedRomFs Folder
2. 
- If you have YKW1: copy yw1_a.fa. 
- If you have YKW2: copy yw2_a.fa and yw2_lg_[YourLanguageCode].fa. 
- If you have YKW3 copy yw_a.fa and yw_lg_[YourLanguageCode].fa
- If you have YKWB1 copy yw_a.fa and ywb_lg_[YourLanguageCode].fa
3. Connect your 3DS to your Computer
4. On 3DS files go to luma/titles folder
5. Create a new folder called as the Title ID of your game (check the table)

|Name|Region|Title ID|
|:----------|-------------|------|
| Yo-Kai Watch |Europe|0004000000167800|
| Yo-Kai Watch |Oceania|000400000017C200|
| Yo-Kai Watch |US|0004000000167700|
| Yo-Kai Watch 2 Psychic Specter|Europe|00040000001B2900|
| Yo-Kai Watch 2 Psychic Specter|Oceania|00040000001B2800|
| Yo-Kai Watch 2 Psychic Specter|US|00040000001B2700|
| Yo-Kai Watch 3 (English UK)|Europe|00040000001D6800|
| Yo-Kai Watch 3 (Français)|Europe|00040000001D6900|
| Yo-Kai Watch 3 (Deutsch)|Europe|00040000001D6A00|
| Yo-Kai Watch 3 (Italiano)|Europe|00040000001D6B00|
| Yo-Kai Watch 3 (Español)|Europe|00040000001D6C00|
| Yo-Kai Watch 3 (English US)|US|00040000001D6700|
| Yo-kai Watch Blasters: White Dog Squad|Europe|00040000001CF000|
| Yo-kai Watch Blasters: Red Cat Corps|Europe|00040000001CEC00|
| Yo-kai Watch Blasters: White Dog Squad|US|00040000001CEF00|
| Yo-kai Watch Blasters: Red Cat Corps|US|00040000001CEB00|

6. Click on folder that you have created
7. Create a new folder called romfs
8. Click on romfs folder and paste
9. Disconnect your 3DS to your Computer
10. Boot your console while holding (Select) to launch the Luma configuration menu
11. Use the (A) button and the D-Pad to turn on the following: "Enable game patching" (In some cases it may already be enabled. If so, proceed to the next step)
12. Press (Start) to save and reboot
13. Now you can run your game, your game will have the changes, if there are no changes try the tutorial again

If you want to cancel your modification, rename the folder "romfs" to "romfs2" or delete it.

Yu want to join a discord server about YKW modding: [click here!](https://discord.gg/wmuhEaNaSZ)
