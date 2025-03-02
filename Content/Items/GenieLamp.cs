using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items
{
	public class GenieLamp : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.value = 40000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Genie Lamp");
			//Tooltip.SetDefault("Summons a Genie");
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.AddBuff(ModContent.BuffType<petGenie>(), 2);
			for (int i = 0; i < Main.projectile.Length; i++)
				if (Main.projectile[i].type == ModContent.ProjectileType<projGenie>() && Main.projectile[i].owner == Item.playerIndexTheItemIsReservedFor)
					Main.projectile[i].Center = Main.player[Item.playerIndexTheItemIsReservedFor].Center;
			return true;
		}
	}
}
