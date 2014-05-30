using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ControlsBase
{
    /// <summary>
    /// Clase que contiene la  Attached Property
    /// </summary>
    public class DataGridEx
    {
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.RegisterAttached("ColumnsSource",
            typeof(ObservableCollection<DataGridColumn>), typeof(DataGridEx),
                new FrameworkPropertyMetadata(null,
                    new PropertyChangedCallback(OnColumnsSourceChanged)));

        public static ObservableCollection<DataGridColumn> GetColumnsSource(DependencyObject d)
        {
            return (ObservableCollection<DataGridColumn>)d.GetValue(ColumnsSourceProperty);
        }

        public static void SetColumnsSource(DependencyObject d, ObservableCollection<DataGridColumn> value)
        {
            d.SetValue(ColumnsSourceProperty, value);
        }

        /// <summary>
        /// Metodo que es invocado cuando la propiedad ColumnsSource cambia
        /// </summary>
        /// <param name="d">control donde cambia la propiedad</param>
        /// <param name="e">contiene información del cambio</param>
        private static void OnColumnsSourceChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            DataGrid gridView = d as DataGrid;
            ObservableCollection<DataGridColumn> newColumns = e.NewValue as ObservableCollection<DataGridColumn>;

            gridView.Columns.Clear();
            foreach (var col in newColumns)
            {
                gridView.Columns.Add(col);

            }
        }

    }
}
