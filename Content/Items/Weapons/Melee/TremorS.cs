using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TremorS : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 210;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 70;
			Item.height = 70;
			Item.useTime = 18;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = 67800;
			Item.rare = 10;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Tremor");
			// Tooltip.SetDefault("");
		}

	}
}
