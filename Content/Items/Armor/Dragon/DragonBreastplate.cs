using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Dragon
{
	[AutoloadEquip(EquipType.Body)]
	public class DragonBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 26;
			Item.value = 35000;
			Item.rare = 11;
			Item.defense = 29;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dragon Breastplate");
			//Tooltip.SetDefault("50% increased ranged damage\n" +
			//"Increased ranged critical strike chance by 34");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 34;
			player.GetDamage(DamageClass.Ranged) += 0.5f;
		}

		public virtual void ArmorSetShadows(Player player, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
		{
			longTrail = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonCapsule>(), 12);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 10);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
