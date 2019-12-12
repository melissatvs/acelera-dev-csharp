using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;

namespace Codenation.Challenge
{
    public abstract class ModelBaseTest
    {
        private DbContext context;

        protected string Model { get; set; }

        protected string Table { get; set; }

        public ModelBaseTest(DbContext context)
        {
            this.context = context;
        }

        public IEntityType GetEntity()
        {
            return context.Model.FindEntityType(Model);
        }

        protected string GetTableName(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }

        protected string GetFieldName(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");
            return annotation?.Value?.ToString();
        }

        public void AssertTable()
        {
            var entity = GetEntity();
            Assert.NotNull(entity);
            var actual = this.GetTableName(entity);
            Assert.Equal(Table, actual);
        }

    }
}