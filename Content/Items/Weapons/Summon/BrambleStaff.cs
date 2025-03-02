using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class BrambleStaff : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.mana = 10;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 2.5f;
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = 2;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Bramble>();
			Item.DamageType = DamageClass.Summon;
			Item.sentry = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bramble Staff");
			//Tooltip.SetDefault("Summons a bramble bush to spit spikes at your enemies");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(true); // »ли false, в зависимости от того, что вам нужно
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.Stinger, 16);
			recipe.AddIngredient(ItemID.Vine, 2);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
            Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == Item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			return player.altFunctionUse != 2;
		}
	}
}
