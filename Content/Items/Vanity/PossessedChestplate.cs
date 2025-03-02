using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class PossessedChestplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = 100;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Possessed Chestplate");
			//Tooltip.SetDefault("");
		}
	}
}