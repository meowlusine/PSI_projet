using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PSI
{
    public class GrapheUtilisateurVisualizer
    {
        private GrapheUtilisateur graphe;

        public GrapheUtilisateurVisualizer(GrapheUtilisateur graphe)
        {
            this.graphe = graphe;
        }

        public void GenererImage(string fichierSortie)
        {
            int largeur = 2000;
            int hauteur = 2000;
            int rayonNoeud = 30;
            int margin = 100;
            int centerX = largeur / 2;
            int centerY = hauteur / 2;
            double angleStep = 2 * Math.PI / graphe.Utilisateurs.Count;

            Dictionary<Utilisateur, SKPoint> positions = new Dictionary<Utilisateur, SKPoint>();
            for (int i = 0; i < graphe.Utilisateurs.Count; i++)
            {
                double angle = i * angleStep;
                float x = centerX + (float)(Math.Cos(angle) * (largeur / 2 - margin));
                float y = centerY + (float)(Math.Sin(angle) * (hauteur / 2 - margin));
                positions[graphe.Utilisateurs[i]] = new SKPoint(x, y);
            }

            var palette = new SKColor[]
            {
                SKColors.HotPink, SKColors.Purple, SKColors.Blue, SKColors.Orange,
                SKColors.Purple, SKColors.Teal, SKColors.Brown, SKColors.Cyan
            };
            var couleurs = WelshPowell();

            using (var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                var paintEdge = new SKPaint { Color = SKColors.Gray, StrokeWidth = 2, IsAntialias = true };
                var paintText = new SKPaint { Color = SKColors.Black, TextSize = 20, IsAntialias = true };

                // Dessiner les arêtes
                foreach (var utilisateur in graphe.Utilisateurs)
                {
                    foreach (var (voisin, commande) in graphe.ObtenirCommandes(utilisateur))
                    {
                        if (positions.ContainsKey(utilisateur) && positions.ContainsKey(voisin))
                        {
                            canvas.DrawLine(positions[utilisateur], positions[voisin], paintEdge);
                        }
                    }
                }

                // Dessiner les sommets
                foreach (var utilisateur in graphe.Utilisateurs)
                {
                    var pos = positions[utilisateur];
                    int couleurIndex = couleurs[utilisateur];
                    var paintNode = new SKPaint { Color = palette[couleurIndex % palette.Length], IsAntialias = true };
                    canvas.DrawCircle(pos, rayonNoeud, paintNode);
                    canvas.DrawText(utilisateur.Nom, pos.X + rayonNoeud + 5, pos.Y, paintText);
                }

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

        private Dictionary<Utilisateur, int> WelshPowell()
        {
            var couleurs = new Dictionary<Utilisateur, int>();
            var utilisateursTries = graphe.Utilisateurs
                .OrderByDescending(u => graphe.GetDegre(u))
                .ToList();

            int couleurActuelle = 0;
            while (couleurs.Count < graphe.Utilisateurs.Count)
            {
                foreach (var u in utilisateursTries)
                {
                    if (!couleurs.ContainsKey(u))
                    {
                        bool voisinAvecMemeCouleur = graphe.ObtenirCommandes(u)
                            .Any(v => couleurs.TryGetValue(v.Voisin, out int c) && c == couleurActuelle);

                        if (!voisinAvecMemeCouleur)
                        {
                            couleurs[u] = couleurActuelle;
                        }
                    }
                }
                couleurActuelle++;
            }
            return couleurs;
        }
    }
}
