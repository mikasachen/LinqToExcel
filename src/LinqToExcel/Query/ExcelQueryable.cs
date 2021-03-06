﻿using System.Collections.Generic;
using System.Linq;
using Remotion.Data.Linq;
using System.Linq.Expressions;
using LinqToExcel.Attributes;
using System;

namespace LinqToExcel.Query
{
    public class ExcelQueryable<T> : QueryableBase<T>
    {
        private static IQueryExecutor CreateExecutor(ExcelQueryArgs args)
        {
            return new ExcelQueryExecutor(args);
        }

        // This constructor is called by users, create a new IQueryExecutor.
        internal ExcelQueryable(ExcelQueryArgs args)
            : base(CreateExecutor(args))
        {
            foreach (var property in typeof(T).GetProperties())
            {
                ExcelColumnAttribute[] att = (ExcelColumnAttribute[])Attribute.GetCustomAttributes(property, typeof(ExcelColumnAttribute), true);
                if (att.Length > 0 && !args.ColumnMappings.ContainsKey(property.Name))
                {
                    args.ColumnMappings.Add(property.Name, att.Select(a => a.ColumnName).ToList());
                }
            }
        }

        // This constructor is called indirectly by LINQ's query methods, just pass to base.
        public ExcelQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        { }
    }
}
