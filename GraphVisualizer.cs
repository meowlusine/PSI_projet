using SkiaSharp;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using PSI;

internal class GraphVisualizer
{
    private Graphe<Station> graphe;

    public GraphVisualizer(Graphe<Station> graphe)
    {
        this.graphe = graphe;
    }

    public void GenererImage(string fichierSortie)
    {
        // Taille de l'image et marge pour l'affichage
        int largeur = 2500;
        int hauteur = 2500;
        int rayonNoeud = 10;
        int margin = 50;

        // Extraire les longitudes et latitudes des stations
        var longitudes = graphe.noeuds.Select(n => n.Station.Longitude);
        var latitudes = graphe.noeuds.Select(n => n.Station.Latitude);
        double minLongitude = longitudes.Min();
        double maxLongitude = longitudes.Max();
        double minLatitude = latitudes.Min();
        double maxLatitude = latitudes.Max();

        // Calculer les échelles en X et Y en fonction de l'étendue géographique et de la marge
        double scaleX = (largeur - 2 * margin) / (maxLongitude - minLongitude);
        double scaleY = (hauteur - 2 * margin) / (maxLatitude - minLatitude);

        // Dictionnaire des couleurs officielles pour certaines lignes de métro
        var officialLineColors = new Dictionary<string, SKColor>
        {
            { "1", SKColor.Parse("#FFFF00") },    // Jaune
            { "2", SKColor.Parse("#00008B") },    // Bleu foncé
            { "3", SKColor.Parse("#6B8E23") },    // Vert caca d'oie (olive drab)
            { "3bis", SKColor.Parse("#87CEEB") }, // Bleu ciel (sky blue)
            { "4", SKColor.Parse("#FFC0CB") },    // Rose
            { "5", SKColor.Parse("#FFA500") },    // Orange
            { "6", SKColor.Parse("#AAF0D1") },    // Vert menthe (mint)
            { "7", SKColor.Parse("#FFB6C1") },    // Rose clair (light pink)
            { "7bis", SKColor.Parse("#90EE90") }, // Vert un peu plus clair (light green)
            { "8", SKColor.Parse("#EE82EE") },    // Violet clair
            { "9", SKColor.Parse("#78866B") },    // Vert kaki (khaki green)
            { "10", SKColor.Parse("#FFDB58") },   // Moutarde
            { "11", SKColor.Parse("#A52A2A") },   // Marron
            { "12", SKColor.Parse("#008000") },   // Vert
            { "13", SKColor.Parse("#ADD8E6") },   // Bleu clair
            { "14", SKColor.Parse("#9400D3") }
        };

        // Palette additionnelle pour assigner une couleur aux lignes manquantes
        var extraColors = new List<SKColor>
        {
            SKColors.DarkRed, SKColors.DarkBlue, SKColors.DarkGreen,
            SKColors.DarkOrange, SKColors.DarkViolet, SKColors.Teal,
            SKColors.Olive, SKColors.Maroon, SKColors.Navy, SKColors.Purple
        };
        int extraColorIndex = 0;

        // Parcourir toutes les lignes utilisées dans le graphe et assigner une couleur si absente
        var allLines = graphe.noeuds.Select(n => n.Station.Ligne).Distinct();
        foreach (var line in allLines)
        {
            if (!officialLineColors.ContainsKey(line))
            {
                // On assigne une couleur extra à la ligne manquante
                officialLineColors[line] = extraColors[extraColorIndex % extraColors.Count];
                extraColorIndex++;
            }
        }

        using (var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur)))
        {
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            // Définition de la peinture pour le texte et les arêtes.
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

            // Calculer la position en pixels pour chaque station à partir de ses coordonnées
            Dictionary<Noeud<Station>, SKPoint> positions = new Dictionary<Noeud<Station>, SKPoint>();
            foreach (var noeud in graphe.noeuds)
            {
                // Pour X, décaler par rapport au minLongitude, mettre à l'échelle puis ajouter la marge
                double x = (noeud.Station.Longitude - minLongitude) * scaleX + margin;
                // Pour Y, on inverse l'axe : les latitudes élevées en haut
                double y = (maxLatitude - noeud.Station.Latitude) * scaleY + margin;
                positions[noeud] = new SKPoint((float)x, (float)y);
            }

            // Dessiner les arêtes reliant chaque station à ses voisins
            foreach (var noeud in graphe.liste_adjacence.Keys)
            {
                foreach (var voisin in graphe.liste_adjacence[noeud])
                {
                    if (positions.ContainsKey(noeud) && positions.ContainsKey(voisin))
                    {
                        // Si les deux stations appartiennent à la même ligne, colorer l'arête avec la couleur de cette ligne
                        if (noeud.Station.Ligne == voisin.Station.Ligne && officialLineColors.TryGetValue(noeud.Station.Ligne, out SKColor edgeColor))
                        {
                            var paintEdgeLine = new SKPaint
                            {
                                Color = edgeColor,
                                StrokeWidth = 2,
                                IsAntialias = true
                            };
                            canvas.DrawLine(positions[noeud], positions[voisin], paintEdgeLine);
                        }
                        else
                        {
                            canvas.DrawLine(positions[noeud], positions[voisin], paintEdge);
                        }
                    }
                }
            }

            // Dessiner chaque nœud et afficher le nom de la station à côté
            foreach (var noeud in graphe.noeuds)
            {
                var pos = positions[noeud];
                // Récupérer la couleur officielle pour la ligne de la station
                SKColor nodeColor = officialLineColors.TryGetValue(noeud.Station.Ligne, out SKColor color)
                    ? color
                    : SKColors.Gray;
                var paintNode = new SKPaint
                {
                    Color = nodeColor,
                    IsAntialias = true
                };

                canvas.DrawCircle(pos, rayonNoeud, paintNode);
                canvas.DrawText(noeud.Station.Nom_station, pos.X + rayonNoeud, pos.Y, paintText);
            }

            // Sauvegarder l'image au format PNG
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
