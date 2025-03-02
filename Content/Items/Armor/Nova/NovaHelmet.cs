using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;
using TremorMod.Content.Items;
using TremorMod.Content.NPCs;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Terraria.GameInput;
using Terraria.GameContent.Events;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;
using TremorMod.Utilities;
using TremorMod.Content;
using TremorMod;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;

namespace TremorMod.Content.Items.Armor.Nova
{
	[AutoloadEquip(EquipType.Head)]
	public class NovaHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.rare = 10;
			Item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Nova Helmet");
			Tooltip.SetDefault("12% increased alchemical damage and critical strike chance\n" +
			"Enemies are more likely to target you");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("15% increased alchemical damage and summons alchemical cauldron to protect you");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalCrit += 12;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.12f;
            player.GetModPlayer<MPlayer>().novaHelmet = true;
            player.aggro += 10;
			Lighting.AddLight((int)((player.position.X + player.width / 2) / 16f), (int)((player.position.Y + player.height / 2) / 16f), 0.8f, 0.7f, 0.3f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NovaBreastplate>() && legs.type == ModContent.ItemType<NovaLeggings>();
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.GetModPlayer<MPlayer>().novaSet = true;
            player.GetModPlayer<MPlayer>().novaAura = true;

            if (player.ownedProjectileCounts[ModContent.ProjectileType<NovaCauldron>()] < 1)
            {
                var entitySource = new EntitySource_ItemUse(player, Item); 
                Vector2 position = player.position; 
                Vector2 velocity = Vector2.Zero; 
                int damage = 50;
                float knockback = 0; 
                Projectile.NewProjectile(entitySource, position, velocity, ModContent.ProjectileType<NovaCauldron>(), damage, knockback, player.whoAmI);
            }
        }

        public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 10);
			recipe.AddIngredient(3467, 8);
			recipe.AddTile(412);
			//recipe.SetResult(this, 1);
			recipe.Register();
		}
	}
}
