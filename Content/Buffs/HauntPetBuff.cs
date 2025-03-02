using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class HauntPetBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Haunt Pet Buff");
			// Description.SetDefault("10% increased summon damage");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
                        
            player.GetDamage(DamageClass.Summon) += 0.1f;

            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<TheHauntPro>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), Vector2.Zero, ModContent.ProjectileType<TheHauntPro>(), 0, 0f, player.whoAmI);
            }
        }
	}
}