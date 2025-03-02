using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Chainsword : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 55;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 56;
			Item.height = 64;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.axe = 22;

			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 60000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item22;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chainsword");
			// Tooltip.SetDefault("'It looks like a sword, but its actually a saw! Buy yours today!'");
		}

	}
}
