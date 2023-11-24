using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Button[] boardButtons;

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
           
        }


        private void InitializeBoard()
        {
            // Создаем кнопки для игрового поля
            boardButtons = new Button[24];
            int[] deleteButtons = { 2, 3, 5, 6, 8, 10, 12, 14, 15, 16, 20, 21, 25, 29, 30, 34, 35, 36, 38, 40, 42, 44, 45, 47, 48 };

            int q = 1;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {


                    if (!deleteButtons.Contains(q))
                    {

                        boardButtons[i] = new Button
                        {
                            Name = "" + q,
                            Size = new Size(40, 40),
                            Location = new Point(50 + i * 50, 50 + j * 50),
                            Tag = i // Используем Tag для хранения позиции на доске
                        };
                        boardButtons[i].Click += BoardButton_Click;
                        Controls.Add(boardButtons[i]);
                    }
                    q++;
                }

            }
        }

        List<int> player1btns = new List<int>() { };

        List<int> player2btns = new List<int>() { };

        //List<int> victoryBtns = new List<int>() {1,4,7};

        int[,] victoryBtns = { { 1, 4, 7 }, { 1, 22, 43 }, {43, 46, 49}, {7, 28, 49},
                         { 9,11,13}, { 9, 23, 37}, {37, 39, 41}, {41 , 27, 13},
                         { 17,24,31 }, { 31,32,33}, { 33, 26, 19}, { 17, 18,19},
                         { 22,23,24}, { 32, 39, 46}, { 26,27,28}, { 4, 11, 18} };




        int schetchik = 0;
        private void BoardButton_Click(object sender, EventArgs e)
        {

            
            // Обработка клика по кнопке на игровом поле
            Button clickedButton = (Button)sender;
           

            // Пример: меняем цвет кнопки при клике
            if (schetchik % 2 == 0)
            {

                clickedButton.BackColor = Color.DarkBlue;
                clickedButton.Enabled = false;
            }
            else
                clickedButton.BackColor = Color.DarkRed;
                clickedButton.Enabled = false;


            if (schetchik % 2 == 0)
            {
                player1btns.Add(Int32.Parse(clickedButton.Name));

                Console.WriteLine("кнопки первого игрока: ");
                for (int i = 0; i < player1btns.Count; i++)
                    Console.WriteLine(player1btns[i]);
            }
            else
            {
                player2btns.Add(Int32.Parse(clickedButton.Name));

                Console.WriteLine("кнопки второго игрока: ");
                for (int i = 0; i < player2btns.Count; i++)
                    Console.WriteLine(player2btns[i]);
            }

            schetchik++;
            label1.Text = ("Ход игрока:" + (schetchik % 2 + 1));
            label2.Text = ("ход:" + schetchik);

            //вычисление победы
            int []player1 = player1btns.ToArray();
            int[] pere = new int[3];
            var rez = player1.Intersect(pere);
            int t = 0;

            for (int i = 0; i < victoryBtns.GetLength(0); i++)
            {

                pere[0] = victoryBtns[i, 0];
                pere[1] = victoryBtns[i, 1];
                pere[2] = victoryBtns[i, 2];
                rez = player1.Intersect(pere);
                foreach (int s in rez) t++;
                if (t == 3) Console.WriteLine("победил игрок 1");
                //  ДОДЕЛАТЬ
            }
            //var result1 = player1btns.Intersect(victoryBtns);
            //int w = 0;

            //foreach (int s in result1) w++;
            //if (w == 3) Console.WriteLine("победил игрок 1");

            //var result2 = player2btns.Intersect(victoryBtns);
            //int r = 0;

            //foreach (int s in result2) r++;
            //if (r == 3) Console.WriteLine("победил игрок 2");



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
