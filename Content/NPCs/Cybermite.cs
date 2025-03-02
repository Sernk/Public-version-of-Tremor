using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TremorMod.Content.NPCs
{ 
	public class Cybermite : ModNPC
	{
		public Vector2 bossCenter
		{
			get { return NPC.Center; }
			set { NPC.position = value - new Vector2(NPC.width / 2, NPC.height / 2); }
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cybermite");
		}*/

		public override void SetDefaults()
		{
            NPC.aiStyle = 63;
            NPC.lifeMax = 600;
            NPC.damage = 70;
            NPC.defense = 25;
            NPC.knockBackResist = 0f;
            NPC.width = 74;
            NPC.height = 74;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void AI()
		{
			Lighting.AddLight(bossCenter, 1f, 0.3f, 0.3f);
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)            
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CybermiteGore").Type, 1f);
        }
    }
}