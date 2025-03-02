using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class ChaoticCross : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 150000;
			Item.rare = 6;
			Item.accessory = true;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Chaotic Cross");
			//Tooltip.SetDefault("The less health, the more critical strike chance...\n" +
			//"The less health, the more damage...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.GetCritChance(DamageClass.Magic) += 20;
				player.GetCritChance(DamageClass.Melee) += 20;
				player.GetCritChance(DamageClass.Ranged) += 20;
				player.GetDamage(DamageClass.Magic) += 0.20f;
				player.GetDamage(DamageClass.Melee) += 0.20f;
				player.GetDamage(DamageClass.Ranged) += 0.20f;
			}
			if (player.statLife < 100)
			{
                player.GetCritChance(DamageClass.Magic) += 15;
                player.GetCritChance(DamageClass.Melee) += 15;
                player.GetCritChance(DamageClass.Ranged) += 15;
                player.GetDamage(DamageClass.Magic) += 0.15f;
                player.GetDamage(DamageClass.Melee) += 0.15f;
                player.GetDamage(DamageClass.Ranged) += 0.15f;
			}
			if (player.statLife < 200)
			{
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetDamage(DamageClass.Magic) += 0.10f;
                player.GetDamage(DamageClass.Melee) += 0.10f;
                player.GetDamage(DamageClass.Ranged) += 0.10f;
            }
			if (player.statLife < 300)
			{
                player.GetCritChance(DamageClass.Magic) += 5;
                player.GetCritChance(DamageClass.Melee) += 5;
                player.GetCritChance(DamageClass.Ranged) += 5;
                player.GetDamage(DamageClass.Magic) += 0.5f;
                player.GetDamage(DamageClass.Melee) += 0.5f;
                player.GetDamage(DamageClass.Ranged) += 0.5f;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChaoticAmplifier>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Stigmata>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
