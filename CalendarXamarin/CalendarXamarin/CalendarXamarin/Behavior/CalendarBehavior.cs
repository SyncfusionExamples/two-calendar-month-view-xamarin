using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CalendarXamarin.Behavior
{
    class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar calendar1, calendar2;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            calendar1 = bindable.FindByName<SfCalendar>("calendar1");
            calendar2 = bindable.FindByName<SfCalendar>("calendar2");
            calendar1.MonthChanged += Calendar1_MonthChanged;
            calendar2.MonthChanged += Calendar2_MonthChanged;
        }

        private void Calendar2_MonthChanged(object sender, MonthChangedEventArgs e)
        {
            calendar1.MoveToDate = calendar2.MoveToDate.AddMonths(-1);
        }

        private void Calendar1_MonthChanged(object sender, MonthChangedEventArgs e)
        {
            calendar2.MoveToDate = calendar1.MoveToDate.AddMonths(1);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar1.MonthChanged -= Calendar1_MonthChanged;
            calendar2.MonthChanged -= Calendar2_MonthChanged;
        }
    }
}
