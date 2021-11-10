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
            InitializeComponent();
            GameEngine GameEngine = new GameEngine();
            label1.Text = GameEngine.MAP.ToString();


            Console.ReadLine();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Question 2.1//
        public abstract class Tile
        {
            protected string symbol;
            public string SYMBOL
            {
                get { return symbol; }
                set { symbol = value; }
            }
            protected int x;
            protected int y;
            enum TileType { Hero, Enemy, Gold, Weapon };


            //Constructor//
            public Tile(int x,int y, string symbol)
            {
                this.x = x;
                this.y = y;
                this.symbol = symbol;
            }

            public int X
            {
                get { return x; }
                set { }
            }

            public int Y
            {
                get { return y; }
                set { }
            }
        }

        class Obstacle : Tile
        {
            public Obstacle(int x, int y) : base(x,y, "X")
            {

            }
        }

        class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base(x,y,"=")
            {

            }
        }
        // Task 2//
        public abstract class Item : Tile
        {
            public Item(int X, int Y, string symbol) : base (X,Y, symbol)// delegtes//
            {

            }
            public abstract string ToString();
           
        }

        // Question 2.2//
        public class Gold : Item 
        {
            public Gold(int X, int Y): base (X, Y, "D")
            {
                gold = random.Next(1, 6);
            }
            private int gold;
            public int GOLD
            {
                get { return gold; }
                set { gold = value; }
            }
            private Random random = new Random();

            public override string ToString()
            {
                return "gold ";
            }
        }


        //Question 2.2//
        public abstract class Character : Tile
        {
            protected List<Tile> vision = new List<Tile>();

            public List<Tile> VISION
            {
                get { return vision; }
                set { vision = value; }
            }


            protected TileType tile;
            public TileType TILE
            {
                get { return tile; }
                set { tile = value; }
            }

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
                set { movement = value; }
            }

            protected Character(int x, int y, int HP, int MAXHP, int DAMAGE, string symbol) : base(x,y, symbol)
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
            

            public virtual void Attack(Character Target)
            {
                Target.HP -= DAMAGE;
            }

            public bool IsDead()
            {
                if (HP <= 0)
                {
                    return true;
                }
                return false;
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

            protected Enemy(int X, int Y, int DAMAGE, int HP, int MAXHP, string symbol) : base (X,Y,HP,MAXHP,DAMAGE, symbol)
            {
                

            }
            public override string ToString()
            {
                return base.ToString();
            }

        }

        //Question 2.5//
        public class Goblin : Enemy
        {
            public Goblin(int X, int Y) : base(X, Y,1,10, 10, "G")
            {

            }

            public virtual void ReturnMove()
            {

            }
        }

        class Mage : Enemy
        {
            public Mage (int X, int Y) : base(X, Y, 5, 10, 10, "M")
            {

            }
        }

        //Question 2.6//
        class Hero : Character
            {
                public Hero(int X, int Y, string SYMOBOL, int HP, int MAXHP, int DAMAGE) : base(X, Y, HP, MAXHP, DAMAGE, "H")
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





        

        //Question 3.1//
        public class Map
        {
            private int enemyNum;
            private Hero PLAYER;
            
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
                MAPWIDTH = random.Next(MINWIDTH, MAXWIDTH);
                MAPHEIGHT = random.Next(MINHEIGHT, MAXHEIGHT);

                MAPCONTAINER = new Tile[MAPWIDTH, MAPHEIGHT];

                ENEMIES = new List<Enemy>();
                enemyNum = NUMBEROFENEMIES;
                GenerateInitialMap();
                
                UpdateVision();
            }

            public override string ToString()
            {
                string mapp = "";
                for (int y = 0; y < MAPWIDTH; y++)
                {
                    for (int x = 0; x < MAPHEIGHT; x++)
                    {
                        mapp += mapcontainer[y, x].SYMBOL;
                    }
                    mapp += "\n";
                }
                return mapp;
            }

            public void UpdateVision()
            {
                foreach (Enemy E in ENEMIES)
                {
                    E.VISION.Clear();
                    if (E.X > 0)
                    {
                        E.VISION.Add(MAPCONTAINER[E.X - 1, E.Y]);
                    }
                }
            }


            void GenerateInitialMap()
            {
                for (int y = 0; y < MAPWIDTH; y++)
                {
                    for (int x = 0; x < MAPHEIGHT; x++)
                    {
                        if (y == 0 || y == mapwidth - 1 || x == 0 || x == mapheight -1)
                        { Create(Character.TileType.Barrier, y, x); }
                        else
                        {
                            Create(Character.TileType.Empty, y, x);
                        }
                    }

                }
                Create(Character.TileType.Hero, random.Next(mapwidth - 1), random.Next(mapheight - 1));
                for(int e = 0; e < enemyNum; e++)
                {
                    int x = random.Next(mapwidth - 1);
                    int y = random.Next(mapheight - 1);
                    while(!(mapcontainer[x,y] is EmptyTile))
                    {
                        x = random.Next(mapwidth - 1);
                        y = random.Next(mapheight - 1);
                    }
                    Create(Character.TileType.Enemy, x, y);
                }
            }

            public void Create(Character.TileType TypeOfTyle, int X = 0, int Y = 0)
            {
                switch (TypeOfTyle)
                {
                    case Character.TileType.Barrier:
                        MAPCONTAINER[X, Y] = new Obstacle(X, Y);
                        break;
                    case  Character.TileType.Empty: MAPCONTAINER[X, Y] = new EmptyTile(X, Y);
                        break;
                    case Character.TileType.Hero: MAPCONTAINER[X, Y] = new Hero(X, Y, "H", 10, 10, 5);
                        break;
                    case Character.TileType.Enemy: MAPCONTAINER[X, Y] = new Goblin(X, Y);
                        enemies.Add((Enemy)mapcontainer[X, Y]);
                        break;
                }
            }
        }
        //Question 3.3//
        class GameEngine
        {
            public Label maplabel = new Label();
            private Map map;

        public Map MAP
            {
                get { return map; }
                set { map = value; }
            }

            public GameEngine()
            {
                map = new Map(10, 20, 10, 20, 5);
            }

            public void ShowMap()
            {
                //for (int y = 0; )
            }
        }
    }
} 

        
        //Task 2//

        // Question 2.1//
        

        // Question 2.3//
        

 
    

