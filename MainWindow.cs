using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;


namespace NicoCalk
{
    class MainWindow : Window
    {
        //Вывод результата
        [UI] private Label lable_Result = null;
        [UI] private Button btn_Calc = null;
        //Объём бустера
        [UI] private Entry text_Nico = null;
        // Объем жидкости
        [UI] private Entry text_V = null;
        // Желаемая крепость
        [UI] private Entry text_K = null;
        // Бустер делает крепость
        [UI] private Entry OtherNicoTextK = null;
        // Бустер разводится на объём
        [UI] private Entry OtherNicoTextV = null;
        // бустер типа 20/30
        [UI] private RadioButton Nico20 = null;
        // бустер типа 20/30
        [UI] private RadioButton Nico3 = null;
        [UI] private RadioButton NicoOther = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            btn_Calc.Clicked += btn_Calc_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void btn_Calc_Clicked(object sender, EventArgs a)
        {
            double Nico;
            if (Nico3.Active) Nico = 3 * 100;
            else if (Nico20.Active) Nico = 20 * 30;
            else Nico = GetOtherNico();

            double res = ToDouble(text_V.Text) * (ToDouble(text_K.Text) / 100) * ToDouble(text_Nico.Text) / (Nico / 100);
            res = Math.Round(res, 3);
            lable_Result.Text = $"Добавить никотина {res} мл";
        }

        private double ToDouble(string s)
        {
            int pos = s.IndexOf('.');
            if (pos != -1)
            {
                s = s.Remove(pos, 1);
                s = s.Insert(pos, ",");
            }

            return double.Parse(s);
        }

        private double GetOtherNico() => ToDouble(OtherNicoTextK.Text) * ToDouble(OtherNicoTextV.Text);

    }
}
