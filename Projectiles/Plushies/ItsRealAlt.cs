﻿using CalValEX.Items.Plushies;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Plushies
{
    public class ItsRealAlt : ModProjectile
    {
        bool invincibility = false;
        int counter;
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 84;
            Projectile.height = 154;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            counter++;
            if (counter == 60)
            {
                Projectile.tileCollide = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<CalaFumoYeetable>());
        }
    }
}