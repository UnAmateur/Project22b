using LibCore.Parametrages;
using LibCore.Parametrages.Definitions;

using System.ComponentModel;
using System.Drawing;


namespace LibCore.Controles.Donnees
{
    internal class DonneesThemes : DonneesBase, IDonneesThemes
    {
        private const int Tx = 0;
        private const int Ty = 1;
        private TypeGraphTheme mtheme = TypeGraphTheme.Default;
        private readonly SizeF[] SizeTexteMax = new SizeF[] { SizeF.Empty, SizeF.Empty };

        private bool texteX = true;
        private bool texteY = true;
        private bool axeX = true;
        private bool axeY = true;
        private bool cadre = true;
        private bool primaireX = true;
        private bool primaireY = true;
        private bool secondaireX = true;
        private bool secondaireY = true;
        private bool tertiaireX = true;
        private bool tertiaireY = true;
        private TypePosition positionX = TypePosition.Bas;
        private TypePosition positionY = TypePosition.Gauche;
        private string format = "N0";
        [Category("Donnees Graphiques")]
        public string Format { get { return format; } set { OnFormatChanged(value); } }
        public TypeGraphTheme Theme { get { return mtheme; } set { OnThemeChanged(value); } }
        public bool TexteX { get { return texteX; } set { OnTexteXChanged(value); } }

        public bool TexteY { get { return texteY; } set { OnTexteYChanged(value); } }

        public bool AxeX { get { return axeX; } set { OnAxeXChanged(value); } }

        public bool AxeY { get { return axeY; } set { OnAxeYChanged(value); } }

        public bool Cadre { get { return cadre; } set { OnCadreChanged(value); } }

        public TypePosition PositionX { get { return positionX; } set { OnPositionXChanged(value); } }

        public TypePosition PositionY { get { return positionY; } set { OnPositionYChanged(value); } }

        public bool PrimaireX { get { return primaireX; } set { OnPrimaireXChanged(value); } }

        public bool PrimaireY { get { return primaireY; } set { OnPrimaireYChanged(value); } }

        public bool SecondaireX { get { return secondaireX; } set { OnSecondaireXChanged(value); } }

        public bool SecondaireY { get { return secondaireY; } set { OnSecondaireYChanged(value); } }

        public bool TertiaireX { get { return tertiaireX; } set { OnTertiaireXChanged(value); } }

        public bool TertiaireY { get { return tertiaireY; } set { OnTertiaireYChanged(value); } }
        protected DefGraphique ThemeValeur { get { return Parametres.Themes.Graphique(mtheme.ToString()); } }
        public DonneesThemes(TypeGraphTheme theme, CoreControle parent) : this("DonneesThemes", theme, parent) { }
        public DonneesThemes(string name, TypeGraphTheme theme, CoreControle parent) : base(name, parent) { mtheme = theme; }
        private void OnFormatChanged(string value)
        {
            if (string.IsNullOrEmpty(value)) { return; }
            if (value != format)
            {
                format = value;
                OnConstructionChanged();
            }
        }
        private void OnThemeChanged(TypeGraphTheme value)
        {
            if (value != mtheme)
            {
                mtheme = value;
                OnConstructionChanged();
            }
        }
        private void OnTexteYChanged(bool value)
        {
            if (value != texteY)
            {
                texteY = value;
                OnConstructionChanged();
            }
        }
        private void OnTexteXChanged(bool value)
        {
            if (value != texteX)
            {
                texteX = value;
                OnConstructionChanged();
            }
        }
        private void OnAxeXChanged(bool value)
        {
            if (!cadre)
            {
                if (value != axeX)
                {
                    axeX = value;
                    OnConstructionChanged();
                }
            }
            else { axeX = false; }
        }
        private void OnAxeYChanged(bool value)
        {
            if (!cadre)
            {
                if (value != axeY)
                {
                    axeY = value;
                    OnConstructionChanged();
                }
            }
            else { axeY = false; }
        }
        private void OnCadreChanged(bool value)
        {
            if (value != cadre)
            {
                cadre = value;
                if (cadre)
                {
                    axeX = false;
                    axeY = false;
                }
                OnConstructionChanged();
            }
        }
        private void OnPrimaireYChanged(bool value)
        {
            if (value != primaireY)
            {
                primaireY = value;
                if (!primaireY)
                {
                    secondaireY = false;
                    tertiaireY = false;
                }
                OnConstructionChanged();
            }
        }
        private void OnPrimaireXChanged(bool value)
        {
            if (value != primaireX)
            {
                primaireX = value;
                if (!primaireX)
                {
                    secondaireX = false;
                    tertiaireX = false;
                }
                OnConstructionChanged();
            }
        }
        private void OnSecondaireYChanged(bool value)
        {
            if (value != secondaireY)
            {
                secondaireY = value;
                if (!secondaireY)
                {
                    tertiaireY = false;
                }
                OnConstructionChanged();
            }
        }
        private void OnSecondaireXChanged(bool value)
        {
            if (value != secondaireX)
            {
                secondaireX = value;
                if (!secondaireX)
                {
                    tertiaireX = false;
                }
                OnConstructionChanged();
            }
        }
        private void OnTertiaireYChanged(bool value)
        {
            if (value != tertiaireY)
            {
                tertiaireY = value;
                OnConstructionChanged();
            }
        }
        private void OnTertiaireXChanged(bool value)
        {
            if (value != tertiaireX)
            {
                tertiaireX = value;
                OnConstructionChanged();
            }
        }
        private void OnPositionXChanged(TypePosition value)
        {
            if (value == TypePosition.Haut || value == TypePosition.Centre || value == TypePosition.Bas)
            {
                if (value != positionX)
                {
                    positionX = value;
                    OnConstructionChanged();
                }
            }
        }
        private void OnPositionYChanged(TypePosition value)
        {
            if (value == TypePosition.Gauche || value == TypePosition.Centre || value == TypePosition.Droite)
            {
                if (value != positionY)
                {
                    positionY = value;
                    OnConstructionChanged();
                }
            }
        }
        private void DrawAxeX(Graphics g)
        {
            // Trace les lignes
            for (int index = 0; index <= DeltaX; index++)
            {
                float valeur = index + MinX;
                PointF p1 = ValeurToGraph(valeur, MinY);
                PointF p2 = ValeurToGraph(valeur, MaxY);
                if (valeur == 0 & AxeX) { g.DrawLine(ThemeValeur.Axe.Crayon, p1, p2); }
                else if (valeur % 10 == 0) { if (10 / RapportX > 10) { g.DrawLine(ThemeValeur.Primaire.Crayon, p1, p2); } }
                else if (valeur % 5 == 0 && SecondaireX) { if (5 / RapportX > 10) { g.DrawLine(ThemeValeur.Secondaire.Crayon, p1, p2); } }
                else { if (tertiaireX) { if (1 / RapportX > 10) { g.DrawLine(ThemeValeur.Tertiaire.Crayon, p1, p2); } } }
            }
        }
        private void DrawTexteAxeX(Graphics g)
        {
            // Trace les textes

            for (int index = 0; index <= DeltaX; index++)
            {
                float valeur = index + MinX;
                PointF p1 = ValeurToGraph(valeur, MinY);
                PointF p2 = ValeurToGraph(valeur, MaxY);
                if (valeur == 0 & AxeX)
                {
                    SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Axe.Graduation.Police);
                    if (PositionX == TypePosition.Bas)
                    {
                        p1.X -= sizetexte.Width / 2.0f;
                        p1.Y += sizetexte.Height / 4.0f;
                        g.DrawString(FormatStr(valeur), ThemeValeur.Axe.Graduation.Police, ThemeValeur.Axe.Graduation.Crayon.Brush, p1);
                    }
                    else if (PositionX == TypePosition.Haut)
                    {
                        p1.X -= sizetexte.Width / 2.0f;
                        p1.Y = p2.Y - sizetexte.Height;

                        g.DrawString(FormatStr(valeur), ThemeValeur.Axe.Graduation.Police, ThemeValeur.Axe.Graduation.Crayon.Brush, p1);
                    }
                    else
                    {
                        if (valeur != MinX)
                        {
                            if (valeur != MaxX)
                            {
                                p1.X -= sizetexte.Width / 2.0f;
                                p1.Y = (p1.Y + p2.Y) / 2.0f - sizetexte.Height / 2.0f;
                                g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                g.DrawString(FormatStr(valeur), ThemeValeur.Axe.Graduation.Police, ThemeValeur.Axe.Graduation.Crayon.Brush, p1);
                            }
                        }
                    }
                }
                else if (valeur % 10 == 0)
                {
                    if (10 / RapportX > 10)
                    {
                        if (10 / RapportX > SizeTexteMax[Tx].Width)
                        {
                            SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Primaire.Graduation.Police);
                            if (PositionX == TypePosition.Bas)
                            {
                                p1.X -= sizetexte.Width / 2.0f;
                                p1.Y += sizetexte.Height / 4.0f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                            }
                            else if (PositionX == TypePosition.Haut)
                            {
                                p1.X -= sizetexte.Width / 2.0f;
                                p1.Y = p2.Y - sizetexte.Height;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                            }
                            else
                            {
                                if (valeur != MinX)
                                {
                                    if (valeur != MaxX)
                                    {
                                        p1.X -= sizetexte.Width / 2.0f;
                                        p1.Y = (p1.Y + p2.Y) / 2.0f - sizetexte.Height / 2.0f;
                                        g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                        g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (valeur % 5 == 0 && SecondaireX)
                {
                    if (5 / RapportX > 10)
                    {
                        SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Secondaire.Graduation.Police);
                        if (5 / RapportX > SizeTexteMax[Tx].Width)
                        {
                            if (PositionX == TypePosition.Bas)
                            {
                                p1.X -= sizetexte.Width / 2.0f;
                                p1.Y += sizetexte.Height / 7.5f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                            }
                            else if (PositionX == TypePosition.Haut)
                            {
                                p1.X -= sizetexte.Width / 2.0f;
                                p1.Y = p2.Y - sizetexte.Height;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                            }
                            else
                            {
                                if (valeur != MinX)
                                {
                                    if (valeur != MaxX)
                                    {
                                        p1.X -= sizetexte.Width / 2.0f;
                                        p1.Y = (p1.Y + p2.Y) / 2.0f - sizetexte.Height / 2.0f;

                                        g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                        g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                                    }
                                }

                            }

                        }
                    }
                }
                else
                {
                    if (tertiaireX)
                    {
                        if (1 / RapportX > 10)
                        {

                            SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Tertiaire.Graduation.Police);
                            if (2f / RapportX > SizeTexteMax[Tx].Width)
                            {
                                if (PositionX == TypePosition.Bas)
                                {
                                    p1.X -= sizetexte.Width / 2.0f;
                                    p1.Y += sizetexte.Height / 10.0f;
                                    g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                }
                                else if (PositionX == TypePosition.Haut)
                                {
                                    p1.X -= sizetexte.Width / 2.0f;
                                    p1.Y = p2.Y - sizetexte.Height;
                                    g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                }
                                else
                                {
                                    if (valeur != MinX)
                                    {
                                        if (valeur != MaxX)
                                        {
                                            p1.X -= sizetexte.Width / 2.0f;
                                            p1.Y = (p1.Y + p2.Y) / 2.0f - sizetexte.Height / 2.0f;

                                            g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                            g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        private void DrawAxeY(Graphics g)
        {
            for (int index = 0; index <= DeltaY; index++)
            {
                float valeur = index + MinY;
                PointF p1 = ValeurToGraph(MinX, valeur);
                PointF p2 = ValeurToGraph(MaxX, valeur);
                if (valeur == 0 & AxeY) { g.DrawLine(ThemeValeur.Axe.Crayon, p1, p2); }
                else if (valeur % 10 == 0) { if (10 / RapportY > 10) { g.DrawLine(ThemeValeur.Primaire.Crayon, p1, p2); } }
                else if (valeur % 5 == 0 && SecondaireY) { if (5 / RapportY > 10) { g.DrawLine(ThemeValeur.Secondaire.Crayon, p1, p2); } }
                else { if (tertiaireY) { if (1 / RapportY > 10) { g.DrawLine(ThemeValeur.Tertiaire.Crayon, p1, p2); } } }
            }
        }
        private void DrawTexteAxeY(Graphics g)
        {
            for (int index = 0; index <= DeltaY; index++)
            {
                float valeur = index + MinY;
                PointF p1 = ValeurToGraph(MinX, valeur);
                PointF p2 = ValeurToGraph(MaxX, valeur);
                if (valeur == 0 & AxeY)
                {

                    SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Axe.Graduation.Police);
                    if (PositionY == TypePosition.Gauche)
                    {
                        p1.X -= sizetexte.Width;
                        p1.Y -= sizetexte.Height / 2f;
                        g.DrawString(FormatStr(valeur), ThemeValeur.Axe.Graduation.Police, ThemeValeur.Axe.Graduation.Crayon.Brush, p1);
                    }
                    else if (PositionX == TypePosition.Droite)
                    {
                        p1.X -= sizetexte.Width / 2.0f;
                        p1.Y = p2.Y - sizetexte.Height;
                        g.DrawString(FormatStr(valeur), ThemeValeur.Axe.Graduation.Police, ThemeValeur.Axe.Graduation.Crayon.Brush, p1);
                    }
                    else
                    {
                        if (valeur != MinY)
                        {
                            if (valeur != MaxY)
                            {
                                p1.X = ZoneGraphique.X + (ZoneGraphique.Width - sizetexte.Width) / 2.0f;
                                p1.Y -= sizetexte.Height;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                            }
                        }
                    }
                }
                else if (valeur % 10 == 0)
                {
                    if (10 / RapportY > 10)
                    {

                        if (10 / RapportY > SizeTexteMax[Ty].Height)
                        {
                            SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Primaire.Graduation.Police);
                            if (PositionY == TypePosition.Gauche)
                            {
                                p1.X -= sizetexte.Width * 1.25f;
                                p1.Y -= sizetexte.Height / 2.0f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                            }
                            else if (PositionY == TypePosition.Droite)
                            {
                                p1.X = p2.X + SizeTexteMax[Ty].Width - sizetexte.Width;
                                p1.Y = p2.Y - sizetexte.Height / 2.0f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                            }
                            else
                            {
                                if (valeur != MinY)
                                {
                                    if (valeur != MaxY)
                                    {
                                        p1.X = ZoneGraphique.X + (ZoneGraphique.Width - sizetexte.Width) / 2.0f;
                                        p1.Y -= sizetexte.Height / 2.0f;
                                        g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                        g.DrawString(FormatStr(valeur), ThemeValeur.Primaire.Graduation.Police, ThemeValeur.Primaire.Graduation.Crayon.Brush, p1);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (valeur % 5 == 0 && SecondaireY)
                {
                    if (5 / RapportY > 10)
                    {

                        SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Secondaire.Graduation.Police);
                        if (5 / RapportY > SizeTexteMax[Ty].Height)
                        {
                            if (PositionY == TypePosition.Gauche)
                            {
                                p1.X -= sizetexte.Width * 1.25f;
                                p1.Y -= sizetexte.Height / 2.0f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                            }
                            else if (PositionY == TypePosition.Droite)
                            {
                                p1.X = p2.X + SizeTexteMax[Ty].Width * 0.85f - sizetexte.Width;
                                p1.Y = p2.Y - sizetexte.Height / 2.0f;
                                g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                            }
                            else
                            {
                                if (valeur != MinY)
                                {
                                    if (valeur != MaxY)
                                    {
                                        p1.X = ZoneGraphique.X + (ZoneGraphique.Width - sizetexte.Width) / 2.0f;
                                        p1.Y -= sizetexte.Height / 2.0f;
                                        g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                        g.DrawString(FormatStr(valeur), ThemeValeur.Secondaire.Graduation.Police, ThemeValeur.Secondaire.Graduation.Crayon.Brush, p1);
                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (tertiaireY)
                    {
                        if (1 / RapportY > 10)
                        {

                            SizeF sizetexte = MesureString(g, valeur, ThemeValeur.Tertiaire.Graduation.Police);
                            if (2f / RapportY > SizeTexteMax[Ty].Height)
                            {
                                if (PositionY == TypePosition.Gauche)
                                {
                                    p1.X -= sizetexte.Width * 1.10f;
                                    p1.Y -= sizetexte.Height / 2.0f;
                                    g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                }
                                else if (PositionY == TypePosition.Droite)
                                {
                                    p1.X = p2.X + SizeTexteMax[Ty].Width * 0.65f - sizetexte.Width;
                                    p1.Y = p2.Y - sizetexte.Height / 2.0f;
                                    g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                }
                                else
                                {
                                    if (valeur != MinY)
                                    {
                                        if (valeur != MaxY)
                                        {
                                            p1.X = ZoneGraphique.X + (ZoneGraphique.Width - sizetexte.Width) / 2.0f;
                                            p1.Y -= sizetexte.Height / 2.0f;
                                            //p1.X = -p1.X;
                                            //p1.Y = -p1.Y;
                                            g.FillRectangle(ThemeValeur.Zone, new RectangleF(p1.X, p1.Y, sizetexte.Width, sizetexte.Height));
                                            g.DrawString(FormatStr(valeur), ThemeValeur.Tertiaire.Graduation.Police, ThemeValeur.Tertiaire.Graduation.Crayon.Brush, p1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected string FormatStr(float value) { return value.ToString(Format); }
        protected SizeF MesureString(Graphics g, float value, Font police) { return g.MeasureString(FormatStr(value), police); }
        protected void CalculMaxSize(Graphics g)
        {
            SizeF minstr = MesureString(g, MinX, ThemeValeur.Primaire.Graduation.Police);
            SizeF maxstr = MesureString(g, MaxX, ThemeValeur.Primaire.Graduation.Police);
            if (minstr.Width < maxstr.Width) { SizeTexteMax[Tx] = maxstr; } else { SizeTexteMax[Tx] = maxstr; }
            minstr = MesureString(g, MinY, ThemeValeur.Primaire.Graduation.Police);
            maxstr = MesureString(g, MaxY, ThemeValeur.Primaire.Graduation.Police);
            if (minstr.Width < maxstr.Width) { SizeTexteMax[Ty] = maxstr; } else { SizeTexteMax[Ty] = maxstr; }
        }
        protected override void Create(Graphics g)
        {
            base.Create(g);
            g.FillRectangle(ThemeValeur.Zone, ZoneGraphique);
            if (Cadre) { g.DrawRectangles(ThemeValeur.Cadre, new RectangleF[] { ZoneGraphique }); }
            if (PrimaireX) { DrawAxeX(g); }
            if (PrimaireY) { DrawAxeY(g); }
            if (PrimaireX && TexteX) { DrawTexteAxeX(g); }
            if (PrimaireY && TexteY) { DrawTexteAxeY(g); }
        }
        protected override RectangleF CalculZoneGraphique(Graphics g)
        {
            RectangleF result = base.CalculZoneGraphique(g);
            if (SizeTexteMax[0] == SizeF.Empty) { CalculMaxSize(g); }
            float X;
            float Y;
            float L;
            float H;
            if (texteX & !texteY) // Seulement le texte sur l'axe X
            {
                if (positionX == TypePosition.Bas) // En bas du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y;
                    L = result.Width - SizeTexteMax[Tx].Width;
                    H = result.Height - SizeTexteMax[Tx].Height * 1.5f;
                }
                else if (positionX == TypePosition.Haut) // En haut du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y + SizeTexteMax[Tx].Height;
                    L = result.Width - SizeTexteMax[Tx].Width;
                    H = result.Height - SizeTexteMax[Tx].Height;
                }
                else // Au centre du graphique
                {
                    X = result.X;
                    Y = result.Y;
                    L = result.Width;
                    H = result.Height;
                }
            }
            else if (!texteX & texteY) // Seulement le texte sur l'axe Y
            {
                if (positionY == TypePosition.Gauche) // A gauche du graphique
                {
                    X = result.X + SizeTexteMax[Ty].Width;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width;
                    H = result.Height - SizeTexteMax[Ty].Height;
                }
                else if (positionY == TypePosition.Droite) // A droite du graphique
                {
                    X = result.X;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width;
                    H = result.Height - SizeTexteMax[Ty].Height;
                }
                else // Au centre du graphique
                {
                    X = result.X;
                    Y = result.Y;
                    L = result.Width;
                    H = result.Height;
                }
            }
            else if (texteX & texteX) // Le texte sur les deux axe X et Y
            {
                if (positionX == TypePosition.Bas & positionY == TypePosition.Gauche) // En bas et a gauche du graphique
                {
                    X = result.X + SizeTexteMax[Ty].Width;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width - SizeTexteMax[Tx].Width / 2.0f;
                    H = result.Height - SizeTexteMax[Tx].Height * 1.5f - SizeTexteMax[Ty].Height / 2.0f;
                }
                else if (positionX == TypePosition.Bas & positionY == TypePosition.Droite) // En bas et a droite du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width * 1.5f - SizeTexteMax[Tx].Width / 2.0f;
                    H = result.Height - SizeTexteMax[Tx].Height * 1.5f - SizeTexteMax[Ty].Height / 2.0f;
                }
                else if (positionX == TypePosition.Bas & positionY == TypePosition.Centre)  // En bas et au centre du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y;
                    L = result.Width - SizeTexteMax[Tx].Width;
                    H = result.Height - SizeTexteMax[Tx].Height * 1.5f;
                }
                else if (positionX == TypePosition.Haut & positionY == TypePosition.Gauche)  // En haut et a gauche du graphique
                {
                    X = result.X + SizeTexteMax[Ty].Width;
                    Y = result.Y + SizeTexteMax[Tx].Height;
                    L = result.Width - SizeTexteMax[Ty].Width - SizeTexteMax[Tx].Width / 2.0f;
                    H = result.Height - SizeTexteMax[Tx].Height;
                }
                else if (positionX == TypePosition.Haut & positionY == TypePosition.Droite)  // En haut et a droite du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y + SizeTexteMax[Tx].Height;
                    L = result.Width - SizeTexteMax[Ty].Width - SizeTexteMax[Tx].Width / 2.0f;
                    H = result.Height - SizeTexteMax[Tx].Height;
                }
                else if (positionX == TypePosition.Haut & positionY == TypePosition.Centre)  // En haut et au centre du graphique
                {
                    X = result.X + SizeTexteMax[Tx].Width / 2.0f;
                    Y = result.Y + SizeTexteMax[Tx].Height;
                    L = result.Width - SizeTexteMax[Tx].Width;
                    H = result.Height - SizeTexteMax[Tx].Height;
                }
                else if (positionX == TypePosition.Centre & positionY == TypePosition.Gauche)  // Au centre et a gauche du graphique
                {
                    X = result.X + SizeTexteMax[Ty].Width;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width;
                    H = result.Height - SizeTexteMax[Ty].Height;
                }
                else if (positionX == TypePosition.Centre & positionY == TypePosition.Droite)  // Au centre et a droite du graphique
                {
                    X = result.X;
                    Y = result.Y + SizeTexteMax[Ty].Height / 2.0f;
                    L = result.Width - SizeTexteMax[Ty].Width;
                    H = result.Height - SizeTexteMax[Ty].Height;
                }
                else if (positionX == TypePosition.Centre & positionY == TypePosition.Centre)  // Au centre et au centre du graphique
                {
                    X = result.X;
                    Y = result.Y;
                    L = result.Width;
                    H = result.Height;
                }
                else // Erreur
                {
                    X = result.X;
                    Y = result.Y;
                    L = result.Width;
                    H = result.Height;
                }
            }
            else // pas de texte
            {
                X = result.X;
                Y = result.Y;
                L = result.Width;
                H = result.Height;
            }
            return new RectangleF(X, Y, L, H);
        }

    }
}
