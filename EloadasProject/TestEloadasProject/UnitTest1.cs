namespace TestEloadasProject
{
    public class Tests
    {
        Eloadas eloadas;

        [SetUp]
        public void Setup()
        {
            eloadas = new Eloadas(5, 5);
        }


        [Test]
        public void NemNull()
        {
            Assert.NotNull(eloadas);
        }


        [Test]
        public void Letrehoz_JoMeret()
        {
            Eloadas eloadas2 = new Eloadas(6, 6);
            Assert.AreEqual((eloadas2.Foglalasok.GetLength(0) * eloadas2.Foglalasok.GetLength(1)), 6 * 6);
        }


        [Test]
        public void Letrehoz_MindSzabad()
        {
            bool ures = true;
            foreach (var item in eloadas.Foglalasok)
            {
                if (item)
                {
                    ures = false;
                }
            }
            Assert.IsTrue(ures);
        }


        [Test]
        public void Lefoglal_szabad()
        {
            Assert.IsTrue(eloadas.lefoglal());
        }


        [Test]
        public void Lefoglal_ElsoHely()
        {
            eloadas.lefoglal();
            Assert.IsTrue(eloadas.Foglalasok[0, 0]);
        }


        [Test]
        public void Lefoglal_teli()
        {
            for (int i = 0; i < (eloadas.Foglalasok.GetLength(0)*eloadas.Foglalasok.GetLength(1)); i++)
            {
                eloadas.lefoglal();
            }
            Assert.IsFalse(eloadas.lefoglal());
        }

        [Test]
        public void Szabadhely_mind()
        {
            Assert.AreEqual(eloadas.Foglalasok.GetLength(0) * eloadas.Foglalasok.GetLength(1), eloadas.SzabadHelyek);
        }

        [Test]
        public void Szabadhely_nincs()
        {
            for (int i = 0; i < (eloadas.Foglalasok.GetLength(0) * eloadas.Foglalasok.GetLength(1)); i++)
            {
                eloadas.lefoglal();
            }
            Assert.AreEqual(0, eloadas.SzabadHelyek);
        }

        [Test]
        public void Szabadhely_van()
        {
            Random r = new Random();
            int i;
            for (i = 0; i < r.Next(0, 25); i++)
            {
                eloadas.lefoglal();
            }
            Assert.AreEqual(eloadas.Foglalasok.GetLength(0) * eloadas.Foglalasok.GetLength(1) - i, eloadas.SzabadHelyek);
        }

        [Test]
        public void NincsSor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas eloadas2 = new Eloadas(0, 5);
            });
        }

        [Test]
        public void NincsHely()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas eloadas2 = new Eloadas(5, 0);
            });
        }

        [Test]
        public void NincsSemmi()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Eloadas eloadas2 = new Eloadas(0, 0);
            });
        }


        [Test]
        public void Teli_igaz()
        {
            for (int i = 0; i < (eloadas.Foglalasok.GetLength(0) * eloadas.Foglalasok.GetLength(1)); i++)
            {
                eloadas.lefoglal();
            }
            Assert.IsTrue(eloadas.Teli);
        }


        [Test]
        public void Teli_hamis()
        {
            Assert.IsFalse(eloadas.Teli);
        }


        [Test]
        public void Teli_kicsit()
        {
            Random r = new Random();
            for (int i = 0; i < r.Next(0, (eloadas.Foglalasok.GetLength(0) * eloadas.Foglalasok.GetLength(1))); i++)
            {
                eloadas.lefoglal();
            }
            Assert.IsFalse(eloadas.Teli);
        }


        [Test]
        public void Foglalt_foglalt()
        {
            eloadas.lefoglal();
            Assert.IsTrue(eloadas.foglalt(1, 1));
        }


        [Test]
        public void Foglalt_szabad()
        {
            Assert.IsFalse(eloadas.foglalt(1, 1));
        }


        [Test]
        public void Foglalt_helytelenSor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.foglalt(0, 1);
            });
        }

        [Test]
        public void Foglalt_helytelenHely()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.foglalt(1, 0);
            });
        }

        [Test]
        public void Foglalt_helytelenMinden()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.foglalt(0, 0);
            });
        }

        [Test]
        public void Foglalt_helytelenSorSok()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.foglalt(8, 1);
            });
        }

        [Test]
        public void Foglalt_helytelenHelySok()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.foglalt(1, 8);
            });
        }
    }
}