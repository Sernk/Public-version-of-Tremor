using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class CryptomageSkull : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 24;
			Item.rare = 4;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cryptomage Skull");
			// Tooltip.SetDefault("");
		}
	}
}
