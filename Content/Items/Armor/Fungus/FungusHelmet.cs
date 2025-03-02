using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.Items.Armor.Fungus
{
	[AutoloadEquip(EquipType.Head)]
	public class FungusHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        
		public override void SetDefaults()
		{

			Item.width = 18;
			Item.height = 18;
			Item.value = 40000;
			Item.rare = 3;
			Item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Fungus Helmet");
			Tooltip.SetDefault("");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum health by 25 and grants Nature's Blessing");
        }

		/*public override void UpdateEquip(Player player)
		{
		}*/

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FungusBreastplate>() && legs.type == ModContent.ItemType<FungusGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            //SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum health by 25 and grants Nature's Blessing");
			player.statLifeMax2 += 25;
			player.AddBuff(165, 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadowLokis = true; //�����쪨� ⥭�
		}

        public override void AddRecipes()
		{
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 16);
            recipe1.AddIngredient(ItemID.GlowingMushroom, 14);
            recipe1.AddIngredient(ItemID.GoldHelmet, 1);
            //recipe1.SetResult(this);
            recipe1.AddTile(16);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 16);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 14);
            recipe2.AddIngredient(ItemID.PlatinumHelmet, 1);
            //recipe2.SetResult(this);
            recipe2.AddTile(16);
            recipe2.Register();
        }
	}
}