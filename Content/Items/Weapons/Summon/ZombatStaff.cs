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
	public class ZombatStaff : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 20;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 10;
			Item.width = 34;
			Item.height = 28;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<ZombatStaffPro>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<ZombatBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zombat Staff");
			// Tooltip.SetDefault("Summons a zombat to fight for you.");
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
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.AddIngredient(ModContent.ItemType<RupicideBar>(), 6);
			recipe.AddIngredient(ModContent.ItemType<TearsofDeath>(), 6);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<NecromaniacWorkbenchTile>());
			recipe.Register();
		}
	}
}
