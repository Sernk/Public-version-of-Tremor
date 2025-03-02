using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ScorpionStinger : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 41;
			Item.DamageType = DamageClass.Melee;
			Item.width = 46;
			Item.height = 54;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 12000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Scorpion Stinger");
			//Tooltip.SetDefault("Poisons enemies");
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(70, 100);
		}
	}
}
