using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TremorMod.Content.Items.Materials.OreAndBar;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Argite
{
	[AutoloadEquip(EquipType.Head)]
	public class ArgiteHelmet : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 15000;
			Item.rare = 3;
			Item.defense = 6;
		}

        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Argite Helmet");
			//Tooltip.SetDefault("10% increased melee speed");
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Your body become spiky");
		}

        public override void UpdateEquip(Player player)
		{
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ArgiteBreastplate>() && legs.type == ModContent.ItemType<ArgiteGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Your body become spiky");
			player.thorns = 1;

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 44, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ArgiteBar>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}
