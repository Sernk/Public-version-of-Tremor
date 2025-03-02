using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.CogLordItems
{
	public class HeatCore : ModItem
	{
		const int ShootType = ProjectileID.HeatRay; // Тип выстрела
		const float ShootRange = 600.0f; // Дальность выстрела
		const float ShootKN = 1.0f; // Отбрасывание 
		const int ShootRate = 40; // Частота выстрела (60 - 1 секунда)
		const int ShootCount = 2; // Лазеров за выстрел
		const float ShootSpeed = 30f; // Скорость выстрела (для лазера - дальность)
		const int spread = 45; // Разброс
		const float spreadMult = 0.045f; // Модификатор разброса

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 36;
			Item.value = 240000;
			Item.rare = 9;
			Item.expert = true;
			Item.accessory = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heat Core");
			Tooltip.SetDefault("Shoots rays at nearby enemies");
		}*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;
                int Target = GetTarget(player);
                if (Target != -1) Shoot(player, Target, GetDamage(player));
            }
        }

        int GetTarget(Player player)
        {
            int Target = -1;
            for (int k = 0; k < Main.npc.Length; k++)
            {
                if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly &&
                    Main.npc[k].Distance(player.Center) <= ShootRange &&
                    Collision.CanHitLine(player.Center, 4, 4, Main.npc[k].Center, 4, 4))
                {
                    Target = k;
                    break;
                }
            }
            return Target;
        }

        int GetDamage(Player player)
        {
            // Получение множителей урона для всех типов
            float magicMultiplier = player.GetDamage(DamageClass.Magic).Additive;
            float meleeMultiplier = player.GetDamage(DamageClass.Melee).Additive;
            float minionMultiplier = player.GetDamage(DamageClass.Summon).Additive;
            float rangedMultiplier = player.GetDamage(DamageClass.Ranged).Additive;

            // Суммирование всех типов урона
            return (int)(10 * (magicMultiplier + meleeMultiplier + minionMultiplier + rangedMultiplier)) + 15;
        }


        void Shoot(Player player, int Target, int Damage)
        {
            // Создание источника для снаряда
            var source = player.GetSource_FromThis();

            Vector2 velocity = Helper.VelocityToPoint(player.Center, Main.npc[Target].Center, ShootSpeed);
            for (int l = 0; l < ShootCount; l++)
            {
                velocity.X += Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y += Main.rand.Next(-spread, spread + 1) * spreadMult;

                // Использование источника вместо float
                int i = Projectile.NewProjectile(source, player.Center.X, player.Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, player.whoAmI);
            }
        }
    }
}
