using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class FrozenTurtleShield : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = 123110;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frozen Turtle Shield");
			//Tooltip.SetDefault("The less health, the more defense\n" +
			//"Grants 25% damage reduction");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 25)
			{
				player.statDefense += 10;
			}
			if (player.statLife < 50)
			{
				player.AddBuff(BuffID.IceBarrier, 2);
			}
			if (player.statLife < 100)
			{
				player.statDefense += 8;
			}
			if (player.statLife < 200)
			{
				player.statDefense += 6;
			}
			if (player.statLife < 300)
			{
				player.statDefense += 3;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TurtleShield>(), 1);
			recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
