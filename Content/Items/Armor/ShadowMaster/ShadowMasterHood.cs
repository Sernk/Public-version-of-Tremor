using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.ShadowMaster
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowMasterHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        private const float ShootRange = 600.0f;
		private const float ShootKN = 1.0f;
		private const int ShootRate = 120;
		private const int ShootCount = 2;
		private const float ShootSpeed = 20f;
		private const int spread = 45;
		private const float spreadMult = 0.045f;

		private int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 11;
			Item.defense = 18;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Shadow Master Hood");
            //Tooltip.SetDefault("20% increased alchemical damage\n" +
            //"25% increased throwing damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Creates dangerous alchemical bubbles\n" +
			"35% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
            player.GetModPlayer<MPlayer>().alchemicalDamage += 0.20f;
            player.GetDamage(DamageClass.Throwing) += 0.20f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ShadowMasterChestplate>() && legs.type == ModContent.ItemType<ShadowMasterPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Creates dangerous alchemical bubbles\n" +
			"35% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 35;

			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Main.player[Item.playerIndexTheItemIsReservedFor].Center) <= ShootRange && Collision.CanHitLine(Main.player[Item.playerIndexTheItemIsReservedFor].Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

        int GetDamage()
        {
            var player = Main.player[Item.playerIndexTheItemIsReservedFor];
            return (10 * (int)(player.GetDamage(DamageClass.Magic).Flat + player.GetDamage(DamageClass.Melee).Flat + player.GetDamage(DamageClass.Summon).Flat + player.GetDamage(DamageClass.Ranged).Flat + player.GetDamage(DamageClass.Throwing).Flat)) + 15;
        }

        void Shoot(int Target, int Damage)
        {
            var player = Main.player[Item.playerIndexTheItemIsReservedFor];
            Vector2 velocity = Helper.VelocityToPoint(player.Center, Main.npc[Target].Center, ShootSpeed);
            for (int l = 0; l < ShootCount; l++)
            {
                velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                int i = Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<AlchemicBubble>(), 100, ShootKN, Item.playerIndexTheItemIsReservedFor);
            }
        }


        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroArmorplate>(), 1);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ModContent.ItemType<SoulofFight>(), 10);
            recipe.AddIngredient(ModContent.ItemType<DarkGel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<DarknessCloth>(), 6);
            //recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();
        }
	}
}
