using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;

namespace TremorMod.Content.Items.Accessories
{
	public class Skullheart : ModItem
	{
		const int ShootType = 270; 
		const float ShootRange = 600.0f; 
		const float ShootKN = 1.0f; 
		const int ShootRate = 40; 
		const int ShootCount = 1; 
		const float ShootSpeed = 30f; 
		const int spread = 45; 
		const float spreadMult = 0.045f; 

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			Item.width = 36;
			Item.height = 36;

			Item.value = 2500000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Skullheart");
			//Tooltip.SetDefault("Shoots skulls at nearby enemies");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
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
            float totalDamage = Main.player[Item.playerIndexTheItemIsReservedFor].GetDamage(DamageClass.Magic).ApplyTo(1) +
                                Main.player[Item.playerIndexTheItemIsReservedFor].GetDamage(DamageClass.Melee).ApplyTo(1) +
                                Main.player[Item.playerIndexTheItemIsReservedFor].GetDamage(DamageClass.Summon).ApplyTo(1) +
                                Main.player[Item.playerIndexTheItemIsReservedFor].GetDamage(DamageClass.Ranged).ApplyTo(1) +
                                Main.player[Item.playerIndexTheItemIsReservedFor].GetDamage(DamageClass.Throwing).ApplyTo(1);

            return (int)(10 * totalDamage) + 15;
        }


        void Shoot(int Target, int Damage)
		{
			Vector2 velocity = Helper.VelocityToPoint(Main.player[Item.playerIndexTheItemIsReservedFor].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                int i = Projectile.NewProjectile(Item.GetSource_FromThis(), Main.player[Item.playerIndexTheItemIsReservedFor].Center.X, Main.player[Item.playerIndexTheItemIsReservedFor].Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, Item.playerIndexTheItemIsReservedFor);
            }
        }
	}
}
