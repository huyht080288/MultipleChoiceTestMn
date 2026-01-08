using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

public static class DataTableExtensions
{
    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));

        DataTable table = new DataTable();

        // 1. Create Columns
        foreach (PropertyDescriptor prop in properties)
        {
            // Handle Nullable<T> types (e.g. int?, DateTime?)
            // If it is nullable, we use the underlying type, otherwise the property type
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        // 2. Populate Rows
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                // If value is null, replace with DBNull.Value
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }
            table.Rows.Add(row);
        }

        return table;
    }
}