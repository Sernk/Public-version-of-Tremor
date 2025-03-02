using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Omnikron
{ 
    [AutoloadEquip(EquipType.Head)]
	public class OmnikronMask : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 0;
			Item.rare = 0;
			Item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Omnikron Mask");
			//Tooltip.SetDefault("20% increased damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Calls ancient soul to protect you");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73);
                }
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OmnikronBreastplate>() && legs.type == ModContent.ItemType<OmnikronGreaves>();
        }

        public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Calls ancient soul to protect you";
            player.AddBuff(ModContent.BuffType<Omnibuff>(), 2);
            if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 60, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Generic) += 0.2f;
            player.GetModPlayer<MPlayer>().alchemicalDamage += 0.2f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OmnikronBar>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();
        }
    }
}
