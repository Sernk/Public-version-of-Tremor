using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Flesh
{
	[AutoloadEquip(EquipType.Head)]
	public class FleshHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 18000;
			Item.rare = 1;
			Item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Flesh Helmet");
			Tooltip.SetDefault("5% increased minion damage\n" +
			"Increases your max number of minions");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases regeneration!");
        }

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.05f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FleshBreastplate>() && legs.type == ModContent.ItemType<FleshGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases regeneration!");
			player.crimsonRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PieceofFlesh>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }

	}
}
