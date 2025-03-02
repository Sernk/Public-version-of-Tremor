using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Nova
{
	[AutoloadEquip(EquipType.Body)]
	public class NovaBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 24;
			Item.rare = 10;
			Item.defense = 22;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Breastplate");
			Tooltip.SetDefault("25% increased alchemical damage\n" + 
			"20% increased alchemical critical strike chance\n" +
			"Grants 40% chance to not consume flasks");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalCrit += 20;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.25f;
			player.GetModPlayer<MPlayer>().novaChestplate = true;
			Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.0f, 1.27f, 0.64f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 20);
			recipe.AddIngredient(3467, 16);
			recipe.AddTile(412);
			//recipe.SetResult(this, 1);
			recipe.Register();
		}
	}
}
