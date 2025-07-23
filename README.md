# Yogurt Commercial 3 - Ensure Speed Hat
BepInEx Plugin for Yogurt Commercial 3 that ensures the speed hat spawns in the first area.

## Why??
The Speed Hat is a necessary item for Yogurt Commercial 3 speedruns. This item has a chance of spawning on an NPC in the starting area of the game (the outside). However, the odds of this are slim, and my attempts to inject a seed into the RNG of the game was fruitless, so instead I've created this patch to brute force the hat onto one of the first randomly spawned NPCs.

## Requirements
- [Yogurt Commercial 3](https://store.steampowered.com/app/1319790/Yogurt_Commercial_3/) *(the game)*
- [BepInEx](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.3) *(the base modding tool)*

## Instructions
- Download [BepInEx](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.3) *(I used v5.4.23.3 when making this plugin)*.
- Download the YogurtCommercial_EnsureSpeedHat.dll file from [Releases](https://github.com/thana-than/Yogurt-Commercial-3-Ensure-Speed-Hat/releases).
- Extract BepInEx zip contents into the Yogurt Commercial 3 Folder: `{STEAM LIBRARY FOLDER}\steamapps\common\Yogurt Commercial 3`
- Create a folder titled `plugins` in the extracted `BepInEx` folder, and place the YogurtCommercial_EnsureSpeedHat.dll in there.
  - The result should look like this:  `{STEAM LIBRARY FOLDER}\steamapps\common\Yogurt Commercial 3\BepInEx\plugins\YogurtCommercial_EnsureSpeedHat.dll`
- Run the game as you would normally.
  - See [BepInEx Documentation](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_mono.html) if you need any more help.

## Config
An optional config file is generated on game startup in `{STEAM LIBRARY FOLDER}\steamapps\common\Yogurt Commercial 3\BepInEx\config\YogurtCommercial_EnsureSpeedHat.cfg`
- `HatIndex = 4` Hat index to spawn. Default value is the index of the speed hat.
- `OccurrenceIndex = 3` At which random NPC occurrence do we force a hat. The default value is more central to the starting area.

## To Build Yourself
- Requires placing Assembly-CSharp.dll in project working directory
  - You can get this dll from `{STEAM LIBRARY FOLDER}\steamapps\common\Yogurt Commercial 3\Yogurt Commercial 3_Data\Managed\Assembly-CSharp.dll`
- Familiarize yourself with developing [BepInEx Plugins](https://docs.bepinex.dev/master/articles/dev_guide/plugin_tutorial/2_plugin_start.html)
