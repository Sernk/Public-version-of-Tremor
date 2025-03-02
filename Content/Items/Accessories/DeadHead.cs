using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories
{
	public class DeadHead : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 110;
			Item.rare = 4;
			Item.defense = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dead Head");
			//Tooltip.SetDefault("4% increased damage and critical strike chance\n" +
			//"15% increased movement speed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{

			player.GetDamage(DamageClass.Melee) += 0.04f;
			player.GetCritChance(DamageClass.Melee) += 4;

			player.GetDamage(DamageClass.Magic) += 0.04f;
			player.GetCritChance(DamageClass.Magic) += 4;

			player.GetDamage(DamageClass.Ranged) += 0.04f;
			player.GetCritChance(DamageClass.Ranged) += 4;

			player.GetDamage(DamageClass.Throwing) += 0.04f;
			player.GetCritChance(DamageClass.Throwing) += 4;

			player.GetDamage(DamageClass.Summon) += 0.04f;

            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            modPlayer.alchemicalDamage += 0.04f;
            modPlayer.alchemicalCrit += 4;


            player.moveSpeed += 0.15f;
			player.maxRunSpeed += 0.15f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TheBrain>(), 1);
			recipe.AddIngredient(ModContent.ItemType<AtisBlood>(), 15);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ModContent.ItemType<UntreatedFlesh>(), 25);
			recipe.AddIngredient(ModContent.ItemType<SharpenedTooth>(), 6);
			recipe.AddIngredient(ItemID.Lens, 2);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<FleshWorkstationTile>());
			recipe.Register();
		}
	}
}
