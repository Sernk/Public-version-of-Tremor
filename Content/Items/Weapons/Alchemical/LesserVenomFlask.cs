using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class LesserVenomFlask : ModItem
    {

		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.crit = 4;
			Item.damage = 22;
			//item.thrown = true;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<LesserVenomFlaskPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 1;
			Item.UseSound = SoundID.Item106;
			Item.value = 150;
			Item.rare = 1;
			Item.autoReuse = false;

			//Item.ammo = Mod.Find<ModItem>("BoomFlask").Type;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lesser Venom Flask");
			/* Tooltip.SetDefault("Throws a flask that explodes into venom clouds\n" +
"Clouds deal damage to enemies and poison them"); */
		}

        public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
        {
            type = ModContent.ProjectileType<PurpleCloudPro>();
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
			Recipe recipe = CreateRecipe(40);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.SpiderFang, 1);
			recipe.AddIngredient(ModContent.ItemType<GelCube>(), 3);
			//recipe.SetResult(this, 40);
			recipe.Register();
		}

	}
}
