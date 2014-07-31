using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
        public string time { get; set; }
        public string Description { get; set; }
        public int userid { get; set; }
        public int AppointmentStatusID { get; set; }

        public SelectList SelectedDate { get; set; }
        public SelectList SelectedTime { get; set; }

        public AppointmentModel()
        {
            List<string> datesavalible = new List<string>();
            List<string> timeAvalible = new List<string>();

            for (int i = 0; i <= 7; i++)
            {
                datesavalible.Add(DateTime.Now.AddDays(i).ToShortDateString());
            }
            timeAvalible.Add("9-10am");
            timeAvalible.Add("10-11am");
            timeAvalible.Add("12-1pm");

            SelectedDate = new SelectList(datesavalible);
            SelectedTime = new SelectList(timeAvalible);


        }
    }
}