using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Utilities;
using TremorMod.Content;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class NovaFlask : ModItem
    {

		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.damage = 46;
			Item.width = 18;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.height = 28;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.shoot = ModContent.ProjectileType<NovaFlask_Proj>();
			Item.shootSpeed = 13f;
			Item.useStyle = 1;
			Item.knockBack = 1;
			Item.UseSound = SoundID.Item106;
			Item.value = 30;
			Item.rare = 10;
			Item.crit = 12;
			Item.autoReuse = false;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Flask");
			Tooltip.SetDefault("Shoots out a nova flask that explodes into two balls\n" +
			"Balls explode into flames after some time or when they hit enemy\n" +
			"Flames explode into damagin bursts after some time or when they hit enemy");
		}*/

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.novaHelmet)
			{
				Item.autoReuse = true;
			}
			if (!modPlayer.novaHelmet)
			{
				Item.autoReuse = false;
			}

			if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) != -1)
			{
				Item.shootSpeed = 15f;
			}
			if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) < 1)
			{
				Item.shootSpeed = 13f;
			}
			if (modPlayer.core)
			{
				Item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				Item.autoReuse = false;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 3);
			recipe.AddIngredient(ModContent.ItemType<BasicFlask>(), 1);
			//recipe.SetResult(this, 111);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
