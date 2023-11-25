using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        int[,] victoryBtns = { { 1, 4, 7 }, { 1, 22, 43 }, {43, 46, 49}, {7, 28, 49},
                         { 9,11,13}, { 9, 23, 37}, {37, 39, 41}, {41 , 27, 13},
                         { 17,24,31 }, { 31,32,33}, { 33, 26, 19}, { 17, 18,19},
                         { 22,23,24}, { 32, 39, 46}, { 26,27,28}, { 4, 11, 18} };




        int schetchik = 0;
        public bool a = true;
        private void BoardButton_Click(object sender, EventArgs e)
        {
            if (a == true)
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

                //вычисление победы 1
                int[] player1 = player1btns.ToArray();
                int[] pere = new int[3];
                var rez = player1.Intersect(pere);
                int t = 0;

                for (int i = 0; i < victoryBtns.GetLength(0); i++)
                {
                    t = 0;
                    pere[0] = victoryBtns[i, 0];
                    pere[1] = victoryBtns[i, 1];
                    pere[2] = victoryBtns[i, 2];
                    rez = player1.Intersect(pere);

                    foreach (int s in rez) t++;
                    if (t == 3)
                    {
                        Console.WriteLine("победил игрок 1");
                        a = false;
                        label1.Text = ("победил игрок 1");

                    }

                }

                int[] player2 = player2btns.ToArray();
                int[] pere2 = new int[3];
                var rez2 = player2.Intersect(pere2);
                int y = 0;

                for (int i = 0; i < victoryBtns.GetLength(0); i++)
                {
                    y = 0;
                    pere2[0] = victoryBtns[i, 0];
                    pere2[1] = victoryBtns[i, 1];
                    pere2[2] = victoryBtns[i, 2];
                    rez2 = player2.Intersect(pere2);

                    foreach (int s in rez2) y++;
                    if (y == 3)
                    {
                        Console.WriteLine("победил игрок 2");
                        a = false;
                        label1.Text = ("победил игрок 2");

                    }

                }

            }
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
