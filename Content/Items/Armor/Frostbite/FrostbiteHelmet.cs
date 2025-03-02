using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Frostbite
{
	[AutoloadEquip(EquipType.Head)]
	public class FrostbiteHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 100;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frostbite Helmet");
			//Tooltip.SetDefault("");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Grants immunity to frozen effect and to ice breaking");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FrostbiteChestplate>() && legs.type == ModContent.ItemType<FrostbiteGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = SetBonusText.Value;
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Grants immunity to frozen effect and to ice breaking");
			player.buffImmune[44] = true;
			player.iceSkate = true;
			player.statDefense += 2;
			player.moveSpeed -= 0.21f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlock, 45);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
