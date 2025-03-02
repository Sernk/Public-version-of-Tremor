using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class MassiveHammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 25;
			Item.useAnimation = 45;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 12000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Massive Hammer");
			//Tooltip.SetDefault("");
		}
	}
}