using System;
using System.Collections.Generic;
using System.Drawing;

namespace Yaprak_Kerem_12IT_TD_Game 
{ 
    public class BackgroundPathDrawer
{
    private Image backgroundImg;
    private Image pathTileImg;
    private Bitmap finalBackground;

    public BackgroundPathDrawer(string backgroundImgPath, string pathTileImgPath)
    {
        LoadImages(backgroundImgPath, pathTileImgPath);
    }

    private void LoadImages(string backgroundImgPath, string pathTileImgPath)
    {
        // Load your images here
        backgroundImg = Image.FromFile(backgroundImgPath);
        pathTileImg = Image.FromFile(pathTileImgPath);
    }

        public void DrawPathOnBackground(LinkedList<(int, int)> path)
        {
            // Create a new bitmap with the size of the form
            finalBackground = new Bitmap(1068, 632);

            using (Graphics g = Graphics.FromImage(finalBackground))
            {
                // Draw the background image
                g.DrawImage(backgroundImg, 0, 0, finalBackground.Width, finalBackground.Height);

                foreach (var tile in path)
                {
                    int y = tile.Item1 * 30;
                    int x = tile.Item2 * 30;
                    g.DrawImage(pathTileImg, x, y, 30, 30);
                }
            }
        }

        public Image GetFinalBackground()
    {
        return finalBackground;
    }
}

}