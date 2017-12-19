using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_2
{
    public class Matrix<F>
    {//Словарь для хранения значений
        Dictionary<string, F> F_matrix = new Dictionary<string, F>();

        //Количество элементов по горизонтали (макс количество столбцов)
        int max_x;

        //Количество элементов по вертикали (макс количество строк)
        int max_y;

        //Добавленное измерение
        int max_z;

        //Пустой элемент, который возвращается если элемент с нужными координатами не был задан
        F null_el;

        //Конструктор
        public Matrix(int fx, int fy, int fz, F null_elParam)
        {
            this.max_x = fx;
            this.max_y = fy;
            this.max_z = fz;
            this.null_el = null_elParam;
        }

        //Индекстатор для доступа к данным
        public F this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this.F_matrix.ContainsKey(key))
                {
                    return this.F_matrix[key];

                }
                else
                {
                    return this.null_el;
                }
            }
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this.F_matrix.Add(key, value);
            }
        }

        //Проверка границ
        void CheckBounds(int x, int y, int z)
        {if (x < 0 || x >= this.max_x) throw new Exception("Значение x =" + x + "выходит за пределы");
            if (y < 0 || y >= this.max_y) throw new Exception("Значение y =" + y + "выходит за пределы");
            if (z < 0 || z >= this.max_z) throw new Exception("Значение z =" + z + "выходит за пределы");
        }

        //Формирование ключа
        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }

        //Приведение к строке
        public override string ToString()
        {
            //Класс StringBuilder используется для построения длинных строк
            //Это увеличивает производительность по сравнению с созданием и склеиванием 
            //большого количества обычных строк
            StringBuilder d = new StringBuilder();
            d.Append("Вывод плоскостей XY при фиксированных значениях Z\n");
            for (int k = 0; k < this.max_z; k++)
            {
                d.Append("z=" + k + "\n");
                for (int j = 0; j < this.max_y; j++)
                {
                    d.Append("[");
                    for (int i = 0; i < this.max_x; i++)
                    {
                        if (i > 0) d.Append("\t");
                        F temp = this[i, j, k];
                        if (temp != null)
                        {
                            d.Append(temp.ToString());
                        }
                        else
                        {
                            d.Append("-");
                        }
                    }
                    d.Append("]\n");
                }
            }

            return d.ToString();
        }
    }
    }
