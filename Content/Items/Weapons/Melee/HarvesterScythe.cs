using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class HarvesterScythe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 66;
			Item.height = 50;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 35400;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Harvester Scythe");
			//Tooltip.SetDefault("");
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			int newLife = Main.rand.Next(hit.Damage / 4) + 3;
			Main.player[Item.playerIndexTheItemIsReservedFor].statLife += newLife;
			Main.player[Item.playerIndexTheItemIsReservedFor].HealEffect(newLife);
		}

	}
}