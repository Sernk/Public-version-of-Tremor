using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Biomes.Ruins.Tiles
{
    public class RuinAltarBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ruin Powers");
            //Description.SetDefault("Ancient powers prevent you from breaking Mudstone Brick and increase enemy spawn rate.");
            Main.debuff[Type] = false; 
            Main.buffNoTimeDisplay[Type] = false; 
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            modPlayer.enchanted = true;

            player.enemySpawns = true;
        }
    }

    public class MudstoneBrickProtection : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            if (type == Terraria.ID.TileID.Mudstone && Main.LocalPlayer.HasBuff(ModContent.BuffType<RuinAltarBuff>()))
            {
                return false; 
            }
            return base.CanExplode(i, j, type);
        }

        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            if (type == Terraria.ID.TileID.Mudstone && Main.LocalPlayer.HasBuff(ModContent.BuffType<RuinAltarBuff>()))
            {
                return false; 
            }
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }
    }
}
