using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Mythril
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilMask : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions");
            //DisplayName.SetDefault("Mythril Mask");
            //Tooltip.SetDefault("20% increased minion damage");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 379 && legs.type == 380;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases your max number of minions";
			player.maxMinions += 2;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}