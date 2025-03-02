using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TremorMod.Content.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.Liquid;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Biomes.Ice.Dungeon;
using TremorMod.Content.Biomes.Ice.Items;
using TremorMod.Content.Biomes.Ice.Items.Furniture;
using TremorMod.Utilities;

namespace TremorMod
{
    public class TremorMod : Mod
    {

        public static DamageClass alchemicalDamage;

        public static Texture2D Ice3;
        public static bool HasGeneratedLunarRootTile;
        public static bool HasGeneratedCometiteOre;
        public static TremorMod Instance;
        public static bool DungeonBlock;
        public static bool IceChest;



        public override void Load()
        {
            ModContent.TileType<LunarRootTile>();
            ModContent.TileType<CometiteOreTile>();
            ModContent.TileType<HardCometiteOreTile>();
            ModContent.TileType<DungeonBlock>();
            ModContent.TileType<IceChest>();

            // Инициализация флагов
            HasGeneratedLunarRootTile = false;
            HasGeneratedCometiteOre = false;
            alchemicalDamage = ModContent.GetInstance<AlchemicalClass>();
        }


        public TremorMod()
        {
            Instance = this; // Присваиваем текущий экземпляр мода
        }

        private void LoadClient()
        {
            Ice3 = ModContent.Request<Texture2D>("TremorMod/Utilities/Ice3", AssetRequestMode.ImmediateLoad).Value;
        }
    }
}
// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.