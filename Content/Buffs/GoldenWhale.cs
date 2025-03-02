using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TremorMod.Content.Buffs
{
    public class GoldenWhale : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Golden Whale");
            //Description.SetDefault("Promote your business!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeEnchant = 4;

            player.buffTime[buffIndex] = 18000;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<GoldenWhalePro>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(
                    player.GetSource_Buff(buffIndex), 
                    new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), 
                    Vector2.Zero, 
                    ModContent.ProjectileType<GoldenWhalePro>(), 
                    0, 
                    0f, 
                    player.whoAmI 
                );
            }
        }
    }
}