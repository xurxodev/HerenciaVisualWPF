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

namespace ControlsBase
{
    /// <summary>
    /// Ventana base de tipo lista
    /// </summary>
    public class WindowBase : Window
    {
        /// <summary>
        /// Contructor estático donde se asigna el estilo por defecto
        /// </summary>
        static WindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowBase), new FrameworkPropertyMetadata(typeof(WindowBase)));
        }

        /// <summary>
        /// Sobreescribimos cuando se aplica la plantilla para acceder a los controles
        /// y suscribirnos a los eventos segun necesitemos
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            #region Minimize, maximize y close
            //accedemos al boton cerrar definido en el estilo
            Button ButtonClose = GetTemplateChild("btClose") as Button;

            if (ButtonClose != null)
            {
                //nos suscribimos al evento click del botón cerrar
                ButtonClose.Click += ButtonClose_Click;

            }

            //accedemos al boton minimizar definido en el estilo
            Button ButtonMinimize = GetTemplateChild("btMinimize") as Button;

            if (ButtonMinimize != null)
            {
                //suscripcion al click del boton minimizar
                ButtonMinimize.Click += ButtonMinimize_Click;
            }

            //accedemos al boton maximizar definido en el estilo
            Button ButtonMaximize = GetTemplateChild("btMaximize") as Button;

            if (ButtonMaximize != null)
            {
                //suscripcion al click del boton maximizar
                ButtonMaximize.Click += ButtonMaximize_Click;
            }
            #endregion

            //accedemos al boton maximizar definido en el estilo
            Border TopBorder = GetTemplateChild("TopBorder") as Border;

            if (TopBorder != null)
            {
                //suscripcion al mousebuttondown del border de la ventana para permitir mover la ventana
                TopBorder.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(TopBorder_MouseLeftButtonDown);
            }
        }

        #region Manejadores de eventos de la ventana
            void ButtonClose_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            void ButtonMinimize_Click(object sender, RoutedEventArgs e)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            }

            void ButtonMaximize_Click(object sender, RoutedEventArgs e)
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                {
                    this.WindowState = System.Windows.WindowState.Normal;
                }
                else
                {
                    this.WindowState = System.Windows.WindowState.Maximized;
                }
            }

            /// <summary>
            /// Manejador del mousedown para poder mover la ventana
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void TopBorder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                this.DragMove();
            }
        #endregion

    }
}
