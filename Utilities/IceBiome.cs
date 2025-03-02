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
    public class IceBiome : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            return BiomeTileCounterSystem.IceBlock > 150;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Content/Music/Snow2");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle =>
            ModContent.GetInstance<IceBiomeBackground>();

        public override string BestiaryIcon => "TremorMod/Assets/Icons/IceBiomeIcon";
        public override string BackgroundPath => "TremorMod/Assets/Backgrounds/Ice3";
        public override string MapBackground => BackgroundPath;
    }
}
