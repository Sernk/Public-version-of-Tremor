using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.HeaterOfWorldsItems
{
    [AutoloadEquip(EquipType.Shield)]
    public class InfernalShield : ModItem
    {
        const int ShootType = 376;
        const float ShootRange = 600.0f;
        const float ShootKN = 1.0f;
        const int ShootRate = 60;
        const int ShootCount = 3;
        const float ShootSpeed = 15f;
        const int spread = 45;
        const float spreadMult = 0.045f;

        int TimeToShoot = ShootRate;

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.value = 45000;
            Item.rare = 9;
            Item.expert = true;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;
                int target = GetTarget(player);
                if (target != -1)
                    Shoot(player, target, GetDamage(player));
            }
        }

        int GetTarget(Player player)
        {
            int target = -1;
            for (int k = 0; k < Main.npc.Length; k++)
            {
                NPC npc = Main.npc[k];
                if (npc.active && npc.lifeMax > 5 && !npc.dontTakeDamage && !npc.friendly &&
                    npc.Distance(player.Center) <= ShootRange &&
                    Collision.CanHitLine(player.Center, 1, 1, npc.Center, 1, 1))
                {
                    target = k;
                    break;
                }
            }
            return target;
        }

        int GetDamage(Player player)
        {
            return (10 * ((int)player.GetDamage(DamageClass.Magic).Multiplicative +
                          (int)player.GetDamage(DamageClass.Melee).Multiplicative +
                          (int)player.GetDamage(DamageClass.Summon).Multiplicative +
                          (int)player.GetDamage(DamageClass.Ranged).Multiplicative +
                          (int)player.GetDamage(DamageClass.Throwing).Multiplicative)) + 15;
        }

        void Shoot(Player player, int target, int damage)
        {
            Vector2 velocity = Helper.VelocityToPoint(player.Center, Main.npc[target].Center, ShootSpeed);
            for (int l = 0; l < ShootCount; l++)
            {
                velocity.X += Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y += Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(player.GetSource_Accessory(Item), player.Center, velocity, ShootType, damage, ShootKN, player.whoAmI);
            }
        }
    }
}
