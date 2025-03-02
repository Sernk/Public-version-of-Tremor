using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Awakening : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 300;
            Item.DamageType = DamageClass.Melee;
            Item.width = 70;
			Item.height = 70;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Awakening");
			Tooltip.SetDefault("Hitting enemies temporarily increases maximum health");
		}*/

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 13);
			}
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			player.AddBuff(113, 120);
		}
	}
}
