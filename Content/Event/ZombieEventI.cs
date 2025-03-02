using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.ZombieEvent;
using TremorMod.Utilities;
using TremorMod;
//using Terraria.Content.Fonts;

namespace TremorMod.Content.Event
{
	public class ZombieEventI : ModPlayer
	{
		public override void UpdateDead()
		{

		}

        /*public override void Load()
        {
            if (!Main.dedServ) 
            {
                PlayerDrawLayer.RegisterData(typeof(NewLayer));
            }
        }

        public static readonly PlayerLayer MiscEffects = new PlayerLayer("TremorMod", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawSet drawInfo) // я не знаю как решить эту ошибку связанную с PlayerLayer
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = Tremor.instance;
			CyberWrathInvasion modPlayer = drawPlayer.GetModPlayer<CyberWrathInvasion>();

			Texture2D CyberWrathI = mod.GetTexture("TremorMod/Content/Event/System/System1");
			Texture2D CyberWrathI1 = mod.GetTexture("TremorMod/Content/Event/System/System2");
			Texture2D CyberWrathI2 = mod.GetTexture("TremorMod/Content/Event/System/System3");
			Texture2D CyberWrathI3 = mod.GetTexture("TremorMod/Content/Event/System/System4");
			Texture2D CyberWrathI4 = mod.GetTexture("TremorMod/Content/Event/System/System5");
			Texture2D CyberWrathI5 = mod.GetTexture("TremorMod/Content/Event/System/System6");
			Texture2D CyberWrathI6 = mod.GetTexture("TremorMod/Content/Event/System/System7");
			Texture2D CyberWrathI7 = mod.GetTexture("TremorMod/Content/Event/System/System8");
			Texture2D CyberWrathI8 = mod.GetTexture("TremorMod/Content/Event/System/System9");
			Texture2D CyberWrathI9 = mod.GetTexture("TremorMod/Content/Event/System/System10");
			Texture2D texture1 = mod.GetTexture("TremorMod/Content/Event/System/System");
			SpriteBatch sb1 = Main.spriteBatch;

			int iH1 = texture1.Height;
			int iW1 = texture1.Width;

			int sX1 = 37;
			int sY1 = 30;

			int eH = CyberWrathI.Height;
			int eW = CyberWrathI.Width;

			int XX1 = ((24 - iW1) / 2) + Main.screenWidth - sX1;
			int YY1 = ((24 - iH1) / 2) + sY1 + (int)(280 * 1.4) + (24 - iW1) * (-1) + 20;

			int eX = XX1 - 333;
			int eY = YY1 - 430 + (24 - eW) * (-1);

			bool _number = true;
			int number = 1;
		});

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            MiscEffects.visible = true;
            layers.Add(MiscEffects);
            layers.Insert(0, MiscEffects);
            NewLayer.visible = true;
            layers.Add(NewLayer);
        }*/

        public override void PostUpdateBuffs()
		{

		}

		public override void PostUpdate()
		{
			bool First = true;
			const int XOffset = 1200;
			const int YOffset = 1200;

			/*CyberWrathInvasion modPlayer = Player.GetModPlayer<CyberWrathInvasion>();
			if (!ZWorld.ZInvasion)
			{
				ZWorld.ZPoints = 0;
			}*/

			if (ZWorld.ZPoints >= 100)
			{
				ZWorld.ZInvasion = false;
			}

			if (ZWorld.ZPoints > 100)
			{
				ZWorld.ZPoints = 100;
			}

			if (!ZWorld.ZInvasion)
			{
				ZWorld.ZPoints = 0;
			}

            if (ZWorld.ZInvasion)
            {
                //Always
                if (Main.rand.Next(3000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Arsonist").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling1").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling2").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling3").Type);
                if (Main.rand.Next(2250) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("FatSack").Type);

                if (Main.rand.Next(3000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Arsonist").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling1").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling2").Type);
                if (Main.rand.Next(700) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Deadling3").Type);
                if (Main.rand.Next(2250) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("FatSack").Type);
                //EoC defeated
                if (NPC.downedBoss1 && Main.rand.Next(4000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("FarmerZombie").Type);

                if (NPC.downedBoss1 && Main.rand.Next(4000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("FarmerZombie").Type);
                //EoW/BoC defeated
                if (NPC.downedBoss2 && Main.rand.Next(3000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombat").Type);
                if (NPC.downedBoss2 && Main.rand.Next(8000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("DiceZombie").Type);
                if (NPC.downedBoss2 && Main.rand.Next(5000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombeast").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie1").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie2").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie3").Type);

                if (NPC.downedBoss2 && Main.rand.Next(3000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombat").Type);
                if (NPC.downedBoss2 && Main.rand.Next(8000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("DiceZombie").Type);
                if (NPC.downedBoss2 && Main.rand.Next(5000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombeast").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie1").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie2").Type);
                if (NPC.downedBoss2 && Main.rand.Next(1000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("PetrifiedZombie3").Type);
                //Skeletron defeated
                if (NPC.downedBoss3 && Main.rand.Next(10000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Painmaker").Type);
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("SpearZombie").Type);
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombomber").Type);

                if (NPC.downedBoss3 && Main.rand.Next(10000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Painmaker").Type);
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("SpearZombie").Type);
                if (NPC.downedBoss3 && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Zombomber").Type);
                //Hardmode
                if (NPC.downedMechBossAny && Main.rand.Next(20000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Almagron").Type);
                if (Main.hardMode && Main.rand.Next(15000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Cryptomage").Type);
                if (Main.hardMode && Main.rand.Next(12500) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Dapperblook").Type);
                if (Main.hardMode && Main.rand.Next(10000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Scourge").Type);
                if (Main.hardMode && Main.rand.Next(8550) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Bonecing").Type);
                if (Main.hardMode && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("TheHaunt").Type);
                if (Main.hardMode && Main.rand.Next(4375) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("GhoulOfficer").Type);
                if (Main.hardMode && Main.rand.Next(1055) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Corpse1").Type);
                if (Main.hardMode && Main.rand.Next(1055) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X + XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Corpse2").Type);

                if (NPC.downedMechBossAny && Main.rand.Next(20000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Almagron").Type);
                if (Main.hardMode && Main.rand.Next(15000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Cryptomage").Type);
                if (Main.hardMode && Main.rand.Next(12500) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Dapperblook").Type);
                if (Main.hardMode && Main.rand.Next(10000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Scourge").Type);
                if (Main.hardMode && Main.rand.Next(8550) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Bonecing").Type);
                if (Main.hardMode && Main.rand.Next(6000) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("TheHaunt").Type);
                if (Main.hardMode && Main.rand.Next(4375) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("GhoulOfficer").Type);
                if (Main.hardMode && Main.rand.Next(1055) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Corpse1").Type);
                if (Main.hardMode && Main.rand.Next(1055) == 1)
                    NPC.NewNPC(NPC.GetSource_NaturalSpawn(), (int)Player.Center.X - XOffset, (int)Player.Center.Y, Mod.Find<ModNPC>("Corpse2").Type);
            }

			if (Main.dayTime && ZWorld.ZInvasion)
			{
				Main.NewText("Undead creatures has been defeated!", 175, 75, 255);
				Main.NewText("The Night of Undead has ended!", 135, 17, 17);
				ZWorld.ZPoints = 0;
				ZWorld.ZInvasion = false;
			}
		}

        /*public override void UpdateBiomeVisuals() // я не знаю как решить эту ошибку связанную с PlayerLayer
		{
			bool usePurity = ZWorld.ZInvasion;
			Player.ManageSpecialBiomeVisuals("Tremor:Zombie", usePurity);
		}*/
    }
}
