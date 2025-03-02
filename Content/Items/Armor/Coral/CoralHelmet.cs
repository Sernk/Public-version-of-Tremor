using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Coral
{
	[AutoloadEquip(EquipType.Head)]
	public class CoralHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 26;

			Item.value = 100;
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Coral Helmet");
			// Tooltip.SetDefault("Allows you to swim");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Allows you to breath underwater and summons an starfish");
        }

		public override void UpdateEquip(Player player)
		{
			player.accFlipper = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CoralChestplate>() && legs.type == ModContent.ItemType<CoralGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Allows you to breath underwater and summons an starfish";
			if (player.breath < player.breathMax - 1)
			{
				player.breath = player.breathMax - 1;
			}
			player.AddBuff(ModContent.BuffType<StarfishBuff>(), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Coral, 8);
			recipe.AddIngredient(ItemID.Starfish, 6);
			recipe.AddTile(18);
			recipe.Register();
		}

	}
}
