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
            protected int x;
            protected int y;
        }

        class EmptyTile : Tile
        {

        }

        //Question 2.2//
        public abstract class Character : Tile
        {
            protected int HP;
            protected int MaxHP;
            protected int Damage;
            string[] Tilearray = { "North", "South", "East", "West" };

            enum Movement { NoMovemnt, Up, Down, Left, Right };

            //Question 2.3//
            public Character()
            {
                X = 0;
                Y = 0;

            }

            public virtual void Attack()
            {

            }

            public bool IsDead = true;

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
            public Enemy()
            {
                X = 0;
                Y = 0;

            }

            public virtual void ToString()
            {

            }
        }

        //Question 2.5//
        public class Goblin : Enemy
        {
            public Goblin()
            {
                X = 0;
                Y = 0;

                int HP = 10;
                int Damage = 1;
            }

            public virtual void ReturnMove()
            {

            }

            //Question 2.6//
            class Hero : Character
            {
                public Hero()
                {
                    X = 0;
                    Y = 0;
                }
                public virtual void ReturnMove()
                {

                }
            }



        }

        //Question 3.1//
        public class Map
        {
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

            public void UpdateVision()
            {

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
            public Item()
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return base.ToString();
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
    

