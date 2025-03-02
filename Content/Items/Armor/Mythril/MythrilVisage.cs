using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Mythril
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilVisage : ModItem
	{

		public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("16% increased alchemical critical strike chance");
            //DisplayName.SetDefault("Mythril Visage");
			//Tooltip.SetDefault("20% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 379 && legs.type == 380;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "16% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 16;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
