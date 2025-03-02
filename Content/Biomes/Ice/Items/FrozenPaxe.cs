using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class FrozenPaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 20000;
			Item.rare = 3;
			Item.axe = 10;
			Item.pick = 60;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Paxe");
			Tooltip.SetDefault("");
		}*/

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 80);
			}
		}
	}
}
