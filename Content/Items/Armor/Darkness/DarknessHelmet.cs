using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Darkness
{
	[AutoloadEquip(EquipType.Head)]
	public class DarknessHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.defense = 22;
			Item.width = 26;

			Item.height = 32;
			Item.value = 600000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Helmet of Darkness");
			/* Tooltip.SetDefault("5% increased life regeneration\n" +
"25% increased melee speed"); */
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Your melee stats are increased during the night!");
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DarknessBreastplate>() && legs.type == ModContent.ItemType<DarknessLeggings>();
        }

        public virtual void ArmorSetShadows(Player player, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
		{
			longTrail = true;
			Main.NewText("1", 175, 75, 255);
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
			player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 54, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}

			player.setBonus = "Your melee stats are increased during the night!";
			if (!Main.dayTime)
			{
				player.GetCritChance(DamageClass.Melee) += 25;
				player.GetDamage(DamageClass.Melee) += 0.30f;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkGel>(), 32);
            recipe.AddIngredient(ModContent.ItemType<DarkMatter>(), 32);
            recipe.AddIngredient(ModContent.ItemType<DarkMass>(), 1);
            recipe.AddTile(247);
            recipe.Register();
        }
    }
}
