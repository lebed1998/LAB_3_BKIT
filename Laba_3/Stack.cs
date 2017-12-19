using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_2
{
    class Stack<F> : SimpleList<F> where F : IComparable
    {

        // Добавление в стэк
        public void Push(F element)
        {
            //Добавление в конец списка уже реализовано 
            Add(element);
        }

        // Удаление и чтение из стека
        public F Pop()
        {
            //default(T) - значение для типа T по умолчанию
            F Result = default(F);

            if (this.Count == 0) return Result;

            //Если элемент единственный
            if (this.Count == 1)
            {
                //то из него читаются данные
                Result = this.first.data;
                this.first = null;
                this.last = null;
            }
            else
            {
                //В списке более одного элемента

                //Поиск предпоследнего элемента
                SimpleListItem<F> newLast = this.GetItem(this.Count - 2);
                //Чтение значения из последнего элемента
                Result = newLast.next.data;
                //предпоследний элемент считается последним
                this.last = newLast;
                //последний элемент удаляется из списка
                newLast.next = null;
            }

            //Уменьшение количества элементов в списке
            this.Count--;

            return Result;
        }

    }
}