using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ControlsBase
{
    /// <summary>
    /// Ventana base de tipo lista
    /// </summary>
    public class WindowListBase : WindowBase
    {
        /// <summary>
        /// Contructor estático donde se asigna el estilo por defecto
        /// </summary>
        static WindowListBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowListBase), new FrameworkPropertyMetadata(typeof(WindowListBase)));
        }

        #region Regiones
            public object FilterRegion
            {
                get { return (object)GetValue(FilterRegionProperty); }
                set { SetValue(FilterRegionProperty, value); }
            }

            public static readonly DependencyProperty FilterRegionProperty =
                DependencyProperty.Register("FilterRegion", typeof(object),
                typeof(WindowListBase), new UIPropertyMetadata());

            public object ButtonRegion
            {
                get { return (object)GetValue(ButtonRegionProperty); }
                set { SetValue(ButtonRegionProperty, value); }
            }

            public static readonly DependencyProperty ButtonRegionProperty =
                DependencyProperty.Register("ButtonRegion", typeof(object),
                typeof(WindowListBase), new UIPropertyMetadata());
        #endregion

        #region Regiones
            public ObservableCollection<DataGridColumn> Columns
            {
                get { return (ObservableCollection<DataGridColumn>)GetValue(ColumnsProperty); }
                set { SetValue(ColumnsProperty, value); }
            }

            public static readonly DependencyProperty ColumnsProperty =
                DependencyProperty.Register("Columns", typeof(ObservableCollection<DataGridColumn>),
                typeof(WindowListBase), new UIPropertyMetadata(new ObservableCollection <DataGridColumn>()));
        #endregion

    }
}
