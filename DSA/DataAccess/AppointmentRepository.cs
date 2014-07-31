using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
   public class AppointmentRepository : ConnectionClass
    {
        public Appointment GetAppointment(int appid)
        {
            return Entity.Appointments.SingleOrDefault(i => i.AppointmentID == appid);
        }
        public IEnumerable<Appointment> GetAppointmentsNeedingReview()
        {
            return Entity.Appointments.Where(i => i.AppointmentStatusID == 3);
        }
        public void AddAppointment(Appointment a)
        {
            Entity.Appointments.AddObject(a);
            Entity.SaveChanges();
        }
        public void ChangeStatus(int appid,int statusid)
        {
            Appointment a = GetAppointment(appid);
            a.AppointmentStatusID = statusid;
            Entity.SaveChanges();
        }
    }
}
