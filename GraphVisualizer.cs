using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    internal class GraphVisualizer
    {
        private Graphe graphe;

        public GraphVisualizer(Graphe graphe)
        {
            this.graphe = graphe;
        }

        public void GenererImage(string fichierSortie)
        {
            int largeur = 800;
            int hauteur = 600;
            int rayonNoeud = 20;
            int rayonGraphe = 250;
            int centreX = largeur / 2;
            int centreY = hauteur / 2;

            using (var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                // Police pour l'ID du nœud
                var paintText = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 16,
                    IsAntialias = true
                };

                var paintEdge = new SKPaint
                {
                    Color = SKColors.Black,
                    StrokeWidth = 2,
                    IsAntialias = true
                };

                var paintNode = new SKPaint
                {
                    Color = SKColors.Pink,
                    IsAntialias = true
                };

                int nbNoeuds = graphe.noeuds.Count;
                Dictionary<Noeud, SKPoint> positions = new Dictionary<Noeud, SKPoint>();

                // Calculer les positions des nœuds en cercle
                for (int i = 0; i < nbNoeuds; i++)
                {
                    double angle = 2 * Math.PI * i / nbNoeuds;
                    int x = (int)(centreX + rayonGraphe * Math.Cos(angle));
                    int y = (int)(centreY + rayonGraphe * Math.Sin(angle));
                    positions[graphe.noeuds[i]] = new SKPoint(x, y);
                }

                // Dessiner les arêtes
                foreach (var noeud in graphe.liste_adjacence.Keys)
                {
                    foreach (var voisin in graphe.liste_adjacence[noeud])
                    {
                        canvas.DrawLine(positions[noeud], positions[voisin], paintEdge);
                    }
                }

                // Dessiner les nœuds
                foreach (var noeud in graphe.noeuds)
                {
                    var position = positions[noeud];
                    canvas.DrawCircle(position, rayonNoeud, paintNode);
                    canvas.DrawText(noeud.Id.ToString(), position.X - 5, position.Y + 5, paintText);
                }

                // Sauvegarder l'image
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite(fichierSortie))
                {
                    data.SaveTo(stream);
                }
            }
        }

        public void AfficherImage(string fichierSortie)
        {
            Process.Start(new ProcessStartInfo(fichierSortie) { UseShellExecute = true });
        }
    }
}