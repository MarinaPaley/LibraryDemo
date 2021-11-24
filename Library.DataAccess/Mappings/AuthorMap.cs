// <copyright file="AuthorMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Library.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Library.Domain;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Author"/> на таблицу в БД и наоборот.
    /// </summary>
    internal class AuthorMap : ClassMap<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorMap"/>.
        /// </summary>
        public AuthorMap()
        {
            this.Table("Authors");

            this.Id(x => x.Id);

            this.Map(x => x.FirstName);
            this.Map(x => x.MiddleName);
            this.Map(x => x.LastName);

            this.HasManyToMany(x => x.Books);
        }
    }
}
