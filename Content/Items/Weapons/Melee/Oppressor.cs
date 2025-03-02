using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Oppressor : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 67;
			Item.DamageType = DamageClass.Melee;
			Item.width = 35;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 20;
			Item.value = 150000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Oppressor");
			//Tooltip.SetDefault("");
		}
	}
}