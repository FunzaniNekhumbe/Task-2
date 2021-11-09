using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Obstacle obstacle1 = new Obstacle();//object//
            Map Hero = new Map();


            Console.ReadLine();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Question 2.1//
        public abstract class Tile
        {
            protected int x;
            protected int y;
            enum TileType { Hero, Enemy, Gold, Weapon };


            //Constructor//
            public Tile()
            {
                x = 0;
                y = 0;
            }

            public int X
            {
                get { return X; }
                set { }
            }

            public int Y
            {
                get { return Y; }
                set { }
            }
        }

        class Obstacle : Tile
        {
            public Obstacle(int x, int y) : base()
            {

            }
        }

        class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base ()
            {

            }
        }

        //Question 2.2//
        public abstract class Character : Tile
        {
            protected int hp;

            public int HP
            {
                get { return hp; }
                set { hp = value; }
            }
            protected int maxhp;

            public int MAXHP
            {
                get { return maxhp; }
                set { maxhp = value; }
            }
            protected int damage;

            public int DAMAGE
            {
                get { return damage; }
                set { damage = value; }
            }

            private List<Tile> Vision
            {
                get { return Vision; }
                set { Vision = value; }
            }

            private Movement movement;

            public Movement MOVEMENT
            {
                get { return movement; }
                set { movement = value;}
            }

            protected Character(int x, int y, int HP, int MAXHP, int DAMAGE)
            {
                HP = HP;
                MAXHP = MAXHP;
                DAMAGE = DAMAGE;
            }
            string[] Tilearray = { "North", "South", "East", "West" };

            public enum TileType
            {
                Hero,
                Enemy,
                Gold,
                Weapon,
                Barrier,
                Empty,
            }

            public enum Movement
            {
                NoMovement,
                Up,
                Down,
                Left,
                Right,
            }

            //Question 2.3//
            public Character()
            {
                X = 0;
                Y = 0;

            }

            public virtual void Attack(Character Target)
            {
                Target.HP -= DAMAGE;
            }

            public bool IsDead()
            {
                if(HP <= 0)
                {
                    return true;
                }
            }

            public virtual bool CheckRange { get; set; }


            private int DistanceTo()
            {
                return 2;
            }

            public void Move()
            {
                int left = 156;
                int right = 501;

                if (left <= x)
                {
                    x++;
                }
                if (x >= 501)
                {
                    x -= 1;
                }
            }

        }

        //Question 2.4//
        public abstract class Enemy : Character
        {
            protected Random random = new Random();

           protected Enemy(int X, int Y, int DAMAGE, int HP, int MAXHP)
            {
                DAMAGE = DAMAGE;
                HP = HP;
                MAXHP = MAXHP;

            }
            public override string ToString()
            {
                return base.ToString();
            }

        }

        //Question 2.5//
        public class Goblin : Enemy
        {
            public Goblin(int X, int Y, string SYMBOL,int DAMAGE=1, int MAXHP=10, int STARTINGHP=10) : base (X, Y, DAMAGE, STARTINGHP, MAXHP)
            {
              
            }

            public virtual void ReturnMove()
            {

            }

            //Question 2.6//
            class Hero : Character
            {
                public Hero(int X, int Y, string SYMOBOL, int HP, int MAXHP, int DAMAGE) : base (X, Y, HP, MAXHP, DAMAGE)
                {
                   
                }
                public virtual void ReturnMove(Movement CharcaterMove = Movement.NoMovement)
                {
                  
                }

                public override string ToString()
                {
                    string info = "Player Stats : \n";
                    info += "HP: " + HP.ToString() + "/" + MAXHP.ToString() + "\n";
                    info += "Damage: " + DAMAGE.ToString() + "\n";
                    info += "[" + X.ToString() + "," + Y.ToString() + "]";
                    return info;
                }
                //bool CheckForValidMove(Movement CharacterMove)
                //{

               // }
            }





        }

        //Question 3.1//
        public class Map
        {
            private Tile[,] mapcontainer;
            public Tile[,] MAPCONTAINER
            {
                get { return mapcontainer; }
                set { mapcontainer = value; }
            }
            //private Hero playercharacter;
            //public Hero PLAYERCHARCTER
            // {
            //   get { return playercharacter; }
            //    set { playercharacter = value; }
            //}

            private List<Enemy> enemies;

            public List<Enemy> ENEMIES
            {
                get { return enemies; }
                set { enemies = value; }
            }

            private int mapwidth;
            public int MAPWIDTH
            {
                get { return mapwidth; }
                set { mapwidth = value; }
            }

            private int mapheight;
            public int MAPHEIGHT
            {
                get { return mapheight; }
                set { mapheight = value; }
            }

            protected Random random = new Random();

            public Map(int MINWIDTH, int MAXWIDTH, int MINHEIGHT, int MAXHEIGHT, int NUMBEROFENEMIES)
            {
                MAPWIDTH = random.Next(MINWIDTH, MAXHEIGHT);
                MAPHEIGHT = random.Next(MINHEIGHT, MAXHEIGHT);

                MAPCONTAINER = new Tile[MAPWIDTH, MAPHEIGHT];

                ENEMIES = new List<Enemy>();

                GenerateInitialMap();

                UpdateVision();
            }

            public void UpdateVision()
            {
                foreach (Enemy E in ENEMIES)
                {
                    E.VISION.CLEAR();
                    if(E.X> 0)
                    {
                        E.VISION.Add(MAPCONTAINER[E.X - 1, E.Y]);
                    }
                }
            }



            int[,] TileArray;
            int[] Enemy;
            int minheight { get; set; }
            int minwidth { get; set; }
            int maxheight { get; set; }
            int maxwidth { get; set; }
            Random randomrandom = new Random();

            public Map()
            {
                minheight = 1;
                minwidth = 2;
                maxheight = 100;
                maxwidth = 200;
            }

           void GenerateInitialMap()
            {
                for (int y = 0; y < MAPWIDTH; y++)
                {
                    for (int x = 0; x < MAPHEIGHT; x++)
                    {
                        Create(TileType.Barrier, x, y);
                    }
                    else
                    {
                        Create(TileType.Empty, x, y);
                    }
                }
            }

            public void Create(TileType TypeOfTyle, int X = 0, int Y = 0)
            {
                switch (TypeOfTyle)
                {
                    Obstacle NewBarrier = new Obstacle(X, Y, "X", TypeOfTyle);
                MAPCONTAINER[X,Y]= NewBarrier
                }
            }
        }

        //Question 3.3//
        class GameEngine
        {
            private Map confirmed { get; set; }

            public GameEngine()
            {
                bool playerUp = false;
                bool playerDown = false;
                bool playerLeft = false;
                bool playerRight = false;
            }
        }

        //Task 2//

        // Question 2.1//
        class Item: Tile
        {
        public Item(int X, int Y)
        {

        }

        }

        // Question 2.2//
        abstract class Gold: Item 
        {
            private int gold;
        }

        // Question 2.3//
        class Mage
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
    

