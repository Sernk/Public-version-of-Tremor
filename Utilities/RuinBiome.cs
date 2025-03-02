using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Biomes.Ice.Dungeon;
using TremorMod.Content.Biomes.Ice.Items;
using TremorMod.Content.Biomes.Ice.Items.Furniture;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace TremorMod.Utilities
{
    public class RuinBiome : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            return BiomeTileCounterSystem.RuinAltar > 1;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override int Music
        {
            get
            {
                if (ModLoader.HasMod("TremorModMusic"))
                {
                    Mod musicMod = ModLoader.GetMod("TremorModMusic");
                    if (musicMod != null)
                    {
                        return MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Eternal-Echoes");
                    }
                }
                return MusicID.Underground;
            }
        }
    }
}