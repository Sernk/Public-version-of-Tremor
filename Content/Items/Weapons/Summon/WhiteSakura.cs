using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class WhiteSakura : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 122;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 12;
			Item.width = 30;
			Item.height = 28;

			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 0, 1, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<WhiteSakuraPro>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<WhiteSakuraBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Sakura");
			// Tooltip.SetDefault("Summons a white wind to fight for you.");
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
			recipe.AddIngredient(ModContent.ItemType<BlueSakura>(), 1);
			recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
