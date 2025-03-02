using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Magmonium
{
	[AutoloadEquip(EquipType.Head)]
	public class MagmoniumHelmet : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

		public override void SetDefaults()
		{
			Item.defense = 20;
			Item.width = 26;
			Item.height = 32;
			Item.value = 40000;
			Item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Magmonium Helmet");
			Tooltip.SetDefault("Inflicts fire damage on attack");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Provides immunity to lava and fire");
        }

		public override void UpdateEquip(Player player)
		{
			player.magmaStone = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<MagmoniumBreastplate>() && legs.type == ModContent.ItemType<MagmoniumGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagmoniumBar>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
	}
}
