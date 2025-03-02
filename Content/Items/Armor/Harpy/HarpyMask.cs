using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Harpy
{
	[AutoloadEquip(EquipType.Head)]
	public class HarpyMask : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = 100;
			Item.rare = 2;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Harpy Mask");
			Tooltip.SetDefault("10% increased ranged damage");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum health by 25 and grants Nature's Blessing");
        }

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Ranged) += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HarpyChestplate>() && legs.type == ModContent.ItemType<HarpyLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.slowFall = true;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.Feather, 4);
			//recipe.SetResult(this);
			recipe.AddTile(18);
            recipe.Register();
        }

	}
}
