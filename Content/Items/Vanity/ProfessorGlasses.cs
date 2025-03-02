using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class ProfessorGlasses : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 10;
			Item.value = 100;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Professor Glasses");
            //Tooltip.SetDefault("");
            base.SetStaticDefaults();
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }
	}
}
