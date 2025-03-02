using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories;

public class SolarBand : ModItem
{
	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.Carrot);

		Item.rare = 11;
		Item.value = 380000;
		Item.useTime = 25;
		Item.useAnimation = 25;

		Item.shoot = ModContent.ProjectileType<SolarMeteor>();
		Item.buffType = ModContent.BuffType<SolarMeteorBuff>();
	}

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Solar Band");
		// Tooltip.SetDefault("Summons a solar meteor");
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		{
			player.AddBuff(Item.buffType, 3600, true);
		}
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(this.Type);
		recipe.AddIngredient(ModContent.ItemType<UnchargedBand>());
		recipe.AddIngredient(3458, 10);
		recipe.AddTile(412);
		recipe.Register();
	}
}
