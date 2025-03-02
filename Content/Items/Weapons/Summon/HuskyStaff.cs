using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class HuskyStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 10;
			Item.width = 34;
			Item.height = 28;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			//Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 8000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<HuskyStaffPro>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<HuskyBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Husky Staff");
			//Tooltip.SetDefault("Summons a husky to fight for you.");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.altFunctionUse != 2;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BorealWood, 25);
			recipe.AddIngredient(ModContent.ItemType<WolfPelt>(), 7);
			recipe.AddIngredient(ModContent.ItemType<AlphaClaw>(), 2);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}