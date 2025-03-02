using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class LesserHealingFlack : ModItem
	{

		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.crit = 4;
			Item.damage = 11;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<LesserHealingFlackPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 1;
			Item.UseSound = SoundID.Item106;
			Item.value = 70;
			Item.rare = 1;
			Item.autoReuse = false;
            //Item.useAmmo = ModContent.ItemType<BoomFlask>();
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Lesser Healing Flask");
			//Tooltip.SetDefault("Throws a flask that explodes into clouds\n" +
			//"Clouds deal damage to enemies and heal player hit enemy");
		}

		//public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		//{
		//	type = ModContent.ProjectileType<HealingCloudPro>();
		//}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.novaHelmet)
			{
				Item.autoReuse = true;
			}
			if (!modPlayer.novaHelmet)
			{
				Item.autoReuse = false;
			}

			if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) != -1)
			{
				Item.shootSpeed = 11f;
			}
			if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) < 1)
			{
				Item.shootSpeed = 8f;
			}
			if (modPlayer.core)
			{
				Item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				Item.autoReuse = false;
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ModContent.ItemType<AtisBlood>(), 1);
			recipe.AddIngredient(ModContent.ItemType<GelCube>(), 1);
			//recipe.SetResult(this, 50);
			recipe.Register();
		}
	}
}