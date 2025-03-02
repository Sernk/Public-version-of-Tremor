using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Nano
{
	[AutoloadEquip(EquipType.Head)]
	public class NanoHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 60000;
			Item.rare = 6;
			Item.defense = 12;
		}

        public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Nano Helmet");
			Tooltip.SetDefault("Maximum mana increased by 60\n" +
			"8% increased critical strike chance");*/
		    SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a Nano Drone to fight for you");
		}

        public override void UpdateEquip(Player player)
		{
            player.statManaMax2 += 60;
            player.GetCritChance(DamageClass.Melee) += 20;
			player.GetCritChance(DamageClass.Ranged) += 20;
            player.GetCritChance(DamageClass.Magic) += 20;
            player.GetCritChance(DamageClass.Throwing) += 20;
			//player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NanoBreastplate>() && legs.type == ModContent.ItemType<NanoGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
			player.AddBuff(ModContent.BuffType<NanoDronBuff>(), 2);
			player.nightVision = true;
			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 226, 0f, 0f, 100, default(Color), 0.4f);
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
            recipe.AddIngredient(ModContent.ItemType<NanoBar>(), 12);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
	}
}
