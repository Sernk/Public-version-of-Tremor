using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class DungeonGuardian : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dungeon Guardian");
			//Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(3279);
			Item.width = 30;
			Item.height = 26;
			Item.shoot = ModContent.ProjectileType<DungeonGuardianPro>();
			Item.knockBack = 4;
			Item.DamageType = DamageClass.Melee;
            Item.value = 10000;
			Item.rare = 2;
			if (!NPC.downedBoss1)
			{
				Item.damage = 15;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 25;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 30;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 35;
			}
			if (Main.hardMode)
			{
				Item.damage = 50;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 75;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 125;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 175;
			}
		}
	}
}
