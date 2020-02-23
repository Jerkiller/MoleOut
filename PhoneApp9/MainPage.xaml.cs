using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp9
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Campi della classe
        DispatcherTimer timer;
        protected double CursorCenter;
        protected double accelY = 0;
        protected double accelX = 0;
        protected double xdiff;
        protected double ydiff;
        protected double width = 480;
        protected double height = 800;
        protected double centerX = 480 / 2;
        protected double centerY = 800 / 2;
        protected double timerX = 0;
        protected double timerY = 0;
        protected bool nord = false;
        protected bool sud = false;
        protected bool est = false;
        protected bool ovest = false;
        protected bool riposo = false;
        protected bool risposta = false;
        #endregion

        // Constructor
        public MainPage()
        {
            InitializeComponent();


            timer = new DispatcherTimer();
            // Intervallo ottimo perché l'occhio umano veda qualcosa di fluido
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += new EventHandler(timer_Tick);

            

            timer.Start();
        }



        /// <summary>
        /// Ogni tick del timer vado ad invocare i metodi in caso di movimento verso nord, est, sud, ovest...
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            
            CursorCenter = Cursor.Width / 2;

            UpdateImagePos();
        }

        #region Modifica posizione del cursore

        /// <summary>
        /// Aggiorna la posizione del cursore ridefinendone i margini
        /// </summary>
        void UpdateImagePos()
        {
            /* Vado a fare data smoothing dei dati presi dall'accelerometro */
            timerX +=1;
            timerY +=1.5;
            Cursor.Margin = new Thickness(timerX, timerY, (width - (timerX + Cursor.Width)), (height - (timerY + Cursor.Height)));
        }


        /// <returns> La nuova posizione del margine sinistro del cursore in modo che non esca dal rettangolo</returns>
        double getX()
        {
            var newX = centerX + (timerX * 1.5 * centerX);
            if ((newX - CursorCenter) < 0)
            {
                return 0;
            }
            else if ((newX + CursorCenter) > width)
            {
                return width - 2 * CursorCenter;
            }
            return newX - CursorCenter;
        }

        /// <returns> La nuova posizione del margine superiore del cursore in modo che non esca dal rettangolo</returns>
        double getY()
        {
            var newY = centerY + (timerY * 1.7 * centerY);

            if ((newY - CursorCenter) < 0)
            {
                return 0;
            }
            else if ((newY + CursorCenter) > height)
            {
                return height - 2 * CursorCenter;
            }
            return newY - CursorCenter;
        }
        #endregion

    }
}