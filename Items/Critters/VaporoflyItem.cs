using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    [LegacyName("NukeFlyItem")]
    public class VaporoflyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GlowingSnail);
            Item.bait = 5;
            Item.makeNPC = (short)NPCType<Vaporofly>();
        }
    }
}