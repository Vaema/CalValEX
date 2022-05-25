﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace CalValEX.Projectiles.Boi
{
    public class AnahitaTear : ModProjectile
    {
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBall";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anahita");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 23;
            Projectile.height = 23;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            int bop=0;
            {
                bop++;
                Player player = Main.player[Projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

                if (Projectile.position.X < player.Center.X - 382)
                {
                    Projectile.active = false;
                }
                else if (Projectile.position.X > player.Center.X + 372)
                {
                    Projectile.active = false;
                }
                if (Projectile.position.Y < player.Center.Y - 238)
                {
                    Projectile.active = false;
                }
                else if (Projectile.position.Y > player.Center.Y + 193)
                {
                    Projectile.active = false;
                }
                if (!modPlayer.boiactive)
                {
                    Projectile.timeLeft = 2;
                }
                else
                {
                    Projectile.timeLeft = 120 - bop;
                }
            }
        }        

        public override void PostDraw(Color lightColor)
        {
        }
    }
}