namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;
        public int SzabadHelyek { get
            {
                int c = 0;
                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (!foglalasok[i, j])
                        {
                            c++;
                        }
                    }
                }
                return c;
            } }

        public bool Teli { get
            {
                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (!foglalasok[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            } }

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama > 0 && helyekSzama > 0)
            {
                foglalasok = new bool[sorokSzama, helyekSzama];
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public bool lefoglal()
        {
            int i=0;
            int j = 0;
            while (i<foglalasok.GetLength(0) && foglalasok[i, j] == true)
            {
                j++;
                if (j == foglalasok.GetLength(1))
                {
                    j = 0;
                    i++;
                }
            }
            if (i == foglalasok.GetLength(0))
            {
                return false;
            }
            else
            {
                foglalasok[i, j] = true;
            }
            return true;
        }

        public bool foglalt(int sorSzam, int helySzam)
        {
            sorSzam -= 1;
            helySzam -= 1;
            if (sorSzam >= 0 && helySzam >= 0 && sorSzam<foglalasok.GetLength(0) && helySzam<foglalasok.GetLength(1))
            {
                return foglalasok[sorSzam, helySzam];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool[,] Foglalasok { get => foglalasok; set => foglalasok = value; }
    }
}