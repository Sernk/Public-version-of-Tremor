using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Wolf
{
	[AutoloadEquip(EquipType.Head)]
	public class WolfHood : ModItem
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
			// DisplayName.SetDefault("Wolf Hood");
			// Tooltip.SetDefault("6% increased minion damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<WolfJerkin>() && legs.type == ModContent.ItemType<WolfLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases your max number of minions";
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WolfPelt>(), 8);
			recipe.AddIngredient(ModContent.ItemType<AlphaClaw>(), 1);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
