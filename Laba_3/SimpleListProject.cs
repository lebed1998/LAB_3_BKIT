using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_2
{
    // Элемент списка
    public class SimpleListItem<F>
    {
        // Данные
        public F data { get; set; }
        // Следующий элемент
        public SimpleListItem<F> next { get; set; }

        //конструктор
        public SimpleListItem(F parametr)
        {
            this.data = parametr;
        }
    }

    // Список
    public class SimpleList<F>
        where F : IComparable
    {
        // Первый элемент списка
        protected SimpleListItem<F> first = null;

        // Последний элемент списка
        protected SimpleListItem<F> last = null;

        // Количество элементов
        public int Count
        {
            get { return _count; }
            protected set { _count = value; }
        }
        int _count;

        // Добавление элемента
        public void Add(F element)
        {
            SimpleListItem<F> newItem = new SimpleListItem<F>(element);
            this.Count++;

            //Добавление первого элемента
            if (last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            //Добавление следующих элементов
            else
            {
                //Присоединение элемента к цепочке
                this.last.next = newItem;
                //Просоединенный элемент считается последним
                this.last = newItem;
            }
        }

        // Чтение контейнера с заданным номером 
        public SimpleListItem<F> GetItem(int number)
        {
            if ((number < 0) || (number >= this.Count))
            {
                //Можно создать собственный класс исключения
                throw new Exception("Выход за границу индекса");
            }

            SimpleListItem<F> current = this.first;
            int i = 0;

            //Пропускаем нужное количество элементов
            while (i < number)
            {
                //Переход к следующему элементу
                current = current.next;
                //Увеличение счетчика
                i++;
            }

            return current;
        }

        // Чтение элемента с заданным номером
        public F Get(int number)
        {
            return GetItem(number).data;
        }

    }
}