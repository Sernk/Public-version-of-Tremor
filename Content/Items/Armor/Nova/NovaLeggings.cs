using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;
using TremorMod.Content;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Nova
{
	[AutoloadEquip(EquipType.Legs)]
	public class NovaLeggings : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 16;
			Item.rare = 10;
			Item.defense = 16;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Leggings");
			Tooltip.SetDefault("18% increased alchemical damage\n" + 
			"12% increased alchemical critical strike chance\n" +
			"14% increased movement speed");
		}*/

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.18f;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 12;
            player.GetModPlayer<MPlayer>().novaLeggings = true;
            player.moveSpeed += 0.14f;
			player.maxRunSpeed += 0.14f;
			Lighting.AddLight((int)((player.position.X + player.width / 2) / 16f), (int)((player.position.Y + player.height / 2) / 16f), 0.8f, 0.7f, 0.3f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 15);
			recipe.AddTile(412);
			//recipe.SetResult(this, 1);
			recipe.Register();
		}
	}
}
