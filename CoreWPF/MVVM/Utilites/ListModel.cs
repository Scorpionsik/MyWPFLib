﻿using CoreWPF.MVVM.Interfaces;
using CoreWPF.Utitltes;
using System.Collections.Generic;

namespace CoreWPF.MVVM.Utilites
{
    /// <summary>
    /// Наследуется от <see cref="ListExt{T}"/>, адаптируя и расширяя функционал для <see cref="IModel"/>
    /// </summary>
    /// <typeparam name="T">Должен наследоваться от <see cref="IModel"/></typeparam>
    public partial class ListModel<T> : ListExt<T> where T : IModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ListModel() : base() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="collection">Принимает коллекцию, из которой создает массив элементов</param>
        public ListModel(IEnumerable<T> collection) : base(collection) { }

        /// <summary>
        /// Удаляет из данного массива элементы коллекции; сравнивает объекты массива и коллекции как критерий
        /// </summary>
        /// <param name="collection">Принимает коллекцию элементов для удаления</param>
        public new void RemoveRange(IEnumerable<T> collection)
        {
            foreach (T remove in collection)
            {
                foreach (T model in this)
                {
                    if (model.Equals(remove))
                    {
                        this.Remove(model);
                        break;
                    }
                }
            }
        } //---метод RemoveRange

        /// <summary>
        /// Определяет, входил ли элемент в коллекцию; сравнивает через Equals
        /// </summary>
        /// <param name="model">Принимает <see cref="IModel"/> для сравнения</param>
        /// <returns>Возвращает true, если элемент найден, иначе false</returns>
        public new bool Contains(T model)
        {
            foreach (T check in this)
            {
                if (check.Equals(model)) return true;
            }
            return false;
        } //---метод Contains

        /// <summary>
        /// Создает копию текущей коллекции
        /// </summary>
        /// <returns>Возвращает копию текущей коллекции</returns>
        public ListModel<T> Clone()
        {
            ListModel<T> tmp_send = new ListModel<T>();
            foreach (T model in this)
            {
                tmp_send.Add((T)model.Clone());
            }
            return tmp_send;
        }
    } //---класс ListModel<T>
}