using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class VioleumMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 32;
			Item.rare = 1;
			Item.vanity = true;
		}

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Violeum Mask");
            //Tooltip.SetDefault("'The latest fashion trend'");
            base.SetStaticDefaults();
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }
	}
}