using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Guardian
{
	[AutoloadEquip(EquipType.Head)]
	public class GuardianHelmet : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.defense = 50;
			Item.width = 26;
			Item.height = 32;
			Item.value = 25000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Guardian Helmet");
            //Tooltip.SetDefault("");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Decreases movement speed");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GuardianBreastplate>() && legs.type == ModContent.ItemType<GuardianGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Decreases movement speed";
			player.moveSpeed -= 0.3f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AncientArmorPlate>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Squorb>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}