using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Adamantite
{
    [AutoloadEquip(EquipType.Head)]
    internal class AdamantiteHat : ModItem
    {
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(3);
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.24f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            //SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions");
            //player.setBonus = Language.GetTextValue("Mods.TremorMod.ArmorSetBonus.Adamantite");
            //player.setBonus = "Increases your max number of minions";
            player.maxMinions += 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 403 && legs.type == 404;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}   
