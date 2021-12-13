// <copyright file="ShelfMap.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Library.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Library.Domain;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Shelf"/> на таблицу и наоборот.
    /// </summary>
    internal class ShelfMap : ClassMap<Shelf>
    {
        /// <inheritdoc />
        public ShelfMap()
        {
            this.Table("Shelves");

            this.Id(x => x.Id);

            this.Map(x => x.Name).Not.Nullable().Length(255);

            this.HasMany(x => x.Books)
                .Cascade.Delete()
                .Not.Inverse();
        }
    }
}