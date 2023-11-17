using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            boardButtons = new Button[49];
            int[] deleteButtons = {2,3,5,6,8,10,12,14,15,16,20,21,25,29,30,34,35,36,38,40,42,44,45,47,48};
            //    for (int i = 0; i < 24; i++)
            //    {
            //        boardButtons[i] = new Button
            //        {
            //            Size = new Size(40, 40),
            //            Location = new Point(50 + i % 3 * 50, 50 + i / 3 * 50),
            //            Tag = i // Используем Tag для хранения позиции на доске
            //        };
            //        boardButtons[i].Click += BoardButton_Click;
            //        Controls.Add(boardButtons[i]);
            //    }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {   int index = Array.IndexOf(deleteButtons, boardButtons[i]);
                    if (index <= 0)
                    {
                        boardButtons[i] = new Button
                        {
                            Size = new Size(40, 40),
                            Location = new Point(50 + i * 50, 50 + j * 50),
                            Tag = i // Используем Tag для хранения позиции на доске
                        };
                        boardButtons[i].Click += BoardButton_Click;
                        Controls.Add(boardButtons[i]);
                    }
                }
            }
        }

        private void BoardButton_Click(object sender, EventArgs e)
        {
            // Обработка клика по кнопке на игровом поле
            Button clickedButton = (Button)sender;

            // TODO: Добавьте логику для обработки хода игрока и проверки выигрышной комбинации

            // Пример: меняем цвет кнопки при клике
            if (clickedButton.BackColor == Color.Red)
                clickedButton.BackColor = Color.Blue;
            else
                clickedButton.BackColor = Color.Red;
        }
    }
}