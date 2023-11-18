using System;
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
                            Name = "btn" + q,
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

        List<Button> player1btns = new List<Button>();
        List<Button> player2btns = new List<Button>();

        int schetchik = 0;
        private void BoardButton_Click(object sender, EventArgs e)
        {
            // Обработка клика по кнопке на игровом поле
            Button clickedButton = (Button)sender;

            Console.WriteLine(clickedButton);
            // TODO: Добавьте логику для обработки хода игрока и проверки выигрышной комбинации

            // Пример: меняем цвет кнопки при клике
            Console.WriteLine(clickedButton.Name);
            if (schetchik % 2 == 0)
            {

                clickedButton.BackColor = Color.DarkBlue;
                clickedButton.Enabled = false;
            }
            else
                clickedButton.BackColor = Color.DarkRed;
                clickedButton.Enabled = false;


            if(schetchik % 2 == 0)
            player1btns.Append(clickedButton);
            else
                player2btns.Append(clickedButton);
            Console.WriteLine(player1btns);
            Console.WriteLine(player2btns);

           

            schetchik++;
            label1.Text = ("Ход игрока:" + (schetchik % 2 + 1));
            label2.Text = ("ход:" + schetchik);
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
