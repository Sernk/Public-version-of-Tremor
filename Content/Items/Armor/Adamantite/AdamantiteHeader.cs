using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Adamantite
{
    [AutoloadEquip(EquipType.Head)]
    internal class AdamantiteHeader : ModItem
    {

        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
            // Setting IsTallHat is the only special thing this item does.
            ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
            // CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("DamageClass.Throwing");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.value = 400;
            Item.rare = 4;
            Item.defense = 7;
        }
        
        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Header");
			Tooltip.SetDefault("24% increased thrown damage");
		}
        */
		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Throwing) += 0.24f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 403 && legs.type == 404;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.GetDamage(DamageClass.Throwing) += 0.15f;
        }

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
            recipe.Register();
        }
	}
}