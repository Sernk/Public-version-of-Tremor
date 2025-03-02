using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class NecromancerArmor : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 34;
			Item.value = 150000;
			Item.rare = 3;
			Item.defense = 10;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Necromancer Armor");
			//Tooltip.SetDefault("18% increased minion damage\n" +
			//"20% increased minion knockback");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.18f;
            player.GetKnockback(DamageClass.Summon) += 0.2f;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<HardArmor>(), 1);
			recipe.AddIngredient(ModContent.ItemType<TikiArmor>(), 1);
			recipe.AddIngredient(ModContent.ItemType<NecromancerBelt>(), 1);
			recipe.AddIngredient(ItemID.SoulofNight, 25);
			recipe.AddTile(114);
			//recipe.SetResult(this);
			recipe.Register();
		}

	}
}
