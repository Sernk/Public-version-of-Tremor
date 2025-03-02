using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Salamander
{
	[AutoloadEquip(EquipType.Head)]
	public class SalamanderMask : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.rare = 1;
			Item.value = 100;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Salamander Mask");
			//Tooltip.SetDefault("Increases movement speed");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases armor penetration by 5");
        }

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SalamanderCloth>() && legs.type == ModContent.ItemType<SalamanderLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases armor penetration by 5";
            player.GetArmorPenetration(DamageClass.Generic) += 5;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SalamanderSkin>(), 6);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
