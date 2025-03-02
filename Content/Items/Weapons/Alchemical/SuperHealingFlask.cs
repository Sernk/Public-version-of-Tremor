using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class SuperHealingFlask : ModItem
    {
		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.crit = 4;
			Item.damage = 96;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<SuperHealingFlaskPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 1;
			Item.UseSound = SoundID.Item106;
			Item.value = 7;

			Item.rare = 8;
			Item.autoReuse = false;
			//item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Super Healing Flask");
			/* Tooltip.SetDefault("Throws a flask that explodes into clouds\n" +
"Clouds deal damage to enemies and restore health"); */
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
		{
			type = ModContent.ProjectileType<HealingCloudPro>();
		}

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
			Recipe recipe = CreateRecipe(20);
			recipe.AddIngredient(ModContent.ItemType<BigHealingFlack>(), 20);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
			recipe.Register();

            Recipe recipe1 = CreateRecipe(20);
            recipe1.AddIngredient(ModContent.ItemType<BigHealingFlack>(), 20);
            recipe1.AddIngredient(3457, 1);
            recipe1.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe(20);
            recipe2.AddIngredient(ModContent.ItemType<BigHealingFlack>(), 20);
            recipe2.AddIngredient(3458, 1);
            recipe2.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe(20);
            recipe3.AddIngredient(ModContent.ItemType<BigHealingFlack>(), 20);
            recipe3.AddIngredient(3459, 1);
            recipe3.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
            recipe3.Register();
		}
	}
}