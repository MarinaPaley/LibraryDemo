// <copyright file="BookMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Library.Domain;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Book"/> на таблицу в БД и наоборот.
    /// </summary>
    internal class BookMap : ClassMap<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookMap"/>.
        /// </summary>
        public BookMap()
        {
            //this.Schema("dbo");

            this.Table("Books");

            this.Id(x => x.Id);

            this.Map(x => x.Title);

            this.HasManyToMany(x => x.Authors).Inverse();
        }
    }
}
