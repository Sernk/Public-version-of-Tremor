using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Buffs
{
	public class ManaStimPack : ModItem
	{
		public override void SetDefaults()
		{
			Item.Size = new Vector2(36);
			Item.maxStack = 999;
			Item.rare = 11;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override bool ConsumeItem(Player player) => true;

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mana Stim Pack");
			//Tooltip.SetDefault("Restores 20 mana\n" +
			//"Has no cooldown");
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Item3, player.position);
				player.ManaEffect(20);
				player.statMana = Math.Min(player.statManaMax2, player.statMana + 20);
				return true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BrassBar>(), 2);
			recipe.AddIngredient(ItemID.SuperManaPotion);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 5);
			//recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.Register();
		}
	}
}