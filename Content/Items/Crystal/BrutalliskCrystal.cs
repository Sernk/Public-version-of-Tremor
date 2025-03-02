using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Items.Crystal
{
	public class BrutalliskCrystal : ModItem
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aquamarine Crystal");
			Tooltip.SetDefault("Summons a rideable aquamarine crystal mount");
		}*/

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 26;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 4;
			Item.value = 50000;
			Item.rare = 11;
			Item.expert = true;
			Item.UseSound = SoundID.Item44;
			//item.noMelee = true;
			Item.mountType = ModContent.MountType<BrutalliskCrystalMounts>();
		}
	}
}