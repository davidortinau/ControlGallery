using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ControlGallery.Common
{

    public static class GridExtensions
    {
        //public static void Add(this Grid grid, IView child, int row, int column)
        //{
        //    grid.Add(child);

        //    grid.SetRow(child, row);
        //    grid.SetColumn(child, column);
        //}

        public static void Add(this Grid grid, IView child, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            grid.Add(child);

            grid.SetRow(child, rowStart);
            if(rowEnd > rowStart)
            {
                grid.SetRowSpan(child, (rowEnd - rowStart) + 1);
            }

            grid.SetColumn(child, colStart);
            if(colEnd > colStart)
            {
                grid.SetColumnSpan(child, (colEnd - colStart)+1);
            }
        }
    }
}