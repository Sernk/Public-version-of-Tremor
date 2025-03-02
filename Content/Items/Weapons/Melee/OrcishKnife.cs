using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class OrcishKnife : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 28;
			Item.useAnimation = 9;
			Item.useStyle = 3;
			Item.knockBack = 2;
			Item.value = 2200;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Knife");
			Tooltip.SetDefault("");
		}*/

	}
}
