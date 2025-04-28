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
        int largeur = 2500;
        int hauteur = 2500;
        int rayonNoeud = 10;
        int margin = 50;

    
        var longitudes = graphe.noeuds.Select(n => n.Station.Longitude);
        var latitudes = graphe.noeuds.Select(n => n.Station.Latitude);
        double minLongitude = longitudes.Min();
        double maxLongitude = longitudes.Max();
        double minLatitude = latitudes.Min();
        double maxLatitude = latitudes.Max();


        double scaleX = (largeur - 2 * margin) / (maxLongitude - minLongitude);
        double scaleY = (hauteur - 2 * margin) / (maxLatitude - minLatitude);

        
        var officialLineColors = new Dictionary<string, SKColor>
        {
            { "1", SKColor.Parse("#FFFF00") },    
            { "2", SKColor.Parse("#00008B") },    
            { "3", SKColor.Parse("#6B8E23") },    
            { "3bis", SKColor.Parse("#87CEEB") }, 
            { "4", SKColor.Parse("#FFC0CB") },    
            { "5", SKColor.Parse("#FFA500") },    
            { "6", SKColor.Parse("#AAF0D1") },   
            { "7", SKColor.Parse("#FFB6C1") },    
            { "7bis", SKColor.Parse("#90EE90") }, 
            { "8", SKColor.Parse("#EE82EE") },    
            { "9", SKColor.Parse("#78866B") },    
            { "10", SKColor.Parse("#FFDB58") },  
            { "11", SKColor.Parse("#A52A2A") },   
            { "12", SKColor.Parse("#008000") },   
            { "13", SKColor.Parse("#ADD8E6") },  
            { "14", SKColor.Parse("#9400D3") }
        };

        
        var extraColors = new List<SKColor>
        {
            SKColors.DarkRed, SKColors.DarkBlue, SKColors.DarkGreen,
            SKColors.DarkOrange, SKColors.DarkViolet, SKColors.Teal,
            SKColors.Olive, SKColors.Maroon, SKColors.Navy, SKColors.Purple
        };
        int extraColorIndex = 0;

        
        var allLines = graphe.noeuds.Select(n => n.Station.Ligne).Distinct();
        foreach (var line in allLines)
        {
            if (!officialLineColors.ContainsKey(line))
            {
               
                officialLineColors[line] = extraColors[extraColorIndex % extraColors.Count];
                extraColorIndex++;
            }
        }

        using (var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur)))
        {
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            
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

           
            Dictionary<Noeud<Station>, SKPoint> positions = new Dictionary<Noeud<Station>, SKPoint>();
            foreach (var noeud in graphe.noeuds)
            {
                
                double x = (noeud.Station.Longitude - minLongitude) * scaleX + margin;
                double y = (maxLatitude - noeud.Station.Latitude) * scaleY + margin;
                positions[noeud] = new SKPoint((float)x, (float)y);
            }

            
            foreach (var noeud in graphe.liste_adjacence.Keys)
            {
                foreach (var voisin in graphe.liste_adjacence[noeud])
                {
                    if (positions.ContainsKey(noeud) && positions.ContainsKey(voisin))
                    {
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
            var couleurs = WelshPowell(graphe);

            foreach (var noeud in graphe.noeuds)
            {
                var pos = positions[noeud];
                int couleurIndex = couleurs[noeud];
                var palette = new SKColor[] { SKColors.Pink, SKColors.LightSeaGreen, SKColors.Purple, SKColors.Orange, SKColors.Lime };
                SKColor nodeColor = palette[couleurIndex % palette.Length];

                var paintNode = new SKPaint
                {
                    Color = nodeColor,
                    IsAntialias = true
                };

                canvas.DrawCircle(pos, rayonNoeud, paintNode);
                canvas.DrawText(noeud.Station.Nom_station, pos.X + rayonNoeud, pos.Y, paintText);
            }


            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite(fichierSortie))
            {
                data.SaveTo(stream);
            }
        }
    }

    /// <summary>
    /// Permet de faire afficher le graphe
    /// </summary>
    /// <param name="fichierSortie"></param>
    public void AfficherImage(string fichierSortie)
    {
        Process.Start(new ProcessStartInfo(fichierSortie) { UseShellExecute = true });
    }

    #region Coloration de graphe 

    /// <summary>
    /// compare les degres de noeuds
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int <0 si degreB inferieur a degreA, 0 si degreB est égal à degreA, int>0 si degreB supérieur à degreA.</returns>
    public int ComparerParDegré(Noeud<Station> a, Noeud<Station> b)
    {
        int degreA = graphe.liste_adjacence[a].Count;
        int degreB = graphe.liste_adjacence[b].Count;
        return degreB.CompareTo(degreA);
    }

    Dictionary<Noeud<Station>, int> WelshPowell(Graphe<Station> graphe)
    {
        List<Noeud<Station>> noeudsTries = graphe.noeuds.ToList();
        noeudsTries.Sort(ComparerParDegré);
        var couleurs = new Dictionary<Noeud<Station>, int>();

        int couleurActuelle = 0;
        while (couleurs.Count < graphe.noeuds.Count)
        {
            foreach (var noeud in noeudsTries)
            {
                if (!couleurs.ContainsKey(noeud))
                {
                    bool voisinAvecCouleur = false;
                    foreach (var voisin in graphe.liste_adjacence[noeud])
                    {
                        if (couleurs.ContainsKey(voisin) && couleurs[voisin] == couleurActuelle)
                        {
                            voisinAvecCouleur = true;
                            break;
                        }
                    }
                    if (voisinAvecCouleur==false)
                    {
                        couleurs[noeud] = couleurActuelle;
                    }
                }
            }
            couleurActuelle++;
        }
        return couleurs;
    }

    #endregion

}
