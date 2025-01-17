using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
//using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CalValEX.Tiles.FurnitureSets.Wulfrum {
    public class WulfrumChair : ModTile {
        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wulfrum Chair");
            AddMapEntry(new Color(103, 137, 100), name);
            
            DustType = 226;

            AdjTiles = new int[] { TileID.Chairs };
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
            int xFrameOffset = Main.tile[i, j].TileFrameX;
            int yFrameOffset = Main.tile[i, j].TileFrameY;
            Texture2D glowmask = ModContent.Request<Texture2D>("CalValEX/Tiles/FurnitureSets/Wulfrum/WulfrumChair_Glow").Value;
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = Color.White;
            Tile trackTile = Main.tile[i, j];
            if (!trackTile.IsHalfBlock && trackTile.Slope == 0)
                spriteBatch.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 18, 18), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            else if (trackTile.IsHalfBlock)
                spriteBatch.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 18, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info) {
            Tile tile = Framing.GetTileSafely(i, j);

            info.DirectionOffset = 0;
            info.VisualOffset = new Vector2(-6f, 0);
            info.TargetDirection = -1;

            if (tile.TileFrameX != 0)
                info.TargetDirection = 1;

            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;

            if (tile.TileFrameY % 40 == 0)
                info.AnchorTilePosition.Y++;
        }

        public override bool RightClick(int i, int j) {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance)) {
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }
            return true;
        }

        public override void MouseOver(int i, int j) {
            Player player = Main.LocalPlayer;

            if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
                return;

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            //player.cursorItemIconID = ModContent.ItemType<WulfrumChairItem>();

            if (Main.tile[i, j].TileFrameX / 18 < 1)
                player.cursorItemIconReversed = true;
        }

        //public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            //Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<WulfrumChairItem>());

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
        }
    }
}