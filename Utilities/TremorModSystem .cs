using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ModLoader.IO;

public class TremorModSystem : ModSystem
{
    public static bool HasGeneratedCometiteOre = false;

    public override void OnWorldLoad()
    {
        HasGeneratedCometiteOre = false; 
    }

    public override void OnWorldUnload()
    {
        HasGeneratedCometiteOre = false; 
    }

    public override void SaveWorldData(TagCompound tag)
    {
        tag["HasGeneratedCometiteOre"] = HasGeneratedCometiteOre;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        HasGeneratedCometiteOre = tag.GetBool("HasGeneratedCometiteOre");
    }
}

