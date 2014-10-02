using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AppointmentsService" in code, svc and config file together.
    public class AppointmentsService : IAppointmentsService
    {
        public void DoWork()
        {
        }

        public IEnumerable<Appointment> GetAppointmentsNeedingReview()
        {
            return new AppointmentRepository().GetAppointmentsNeedingReview();
        }

        public Common.Appointment GetAppointment(int appid)
        {
            return new AppointmentRepository().GetAppointment(appid);
        }

        public void AddAppointment(Common.Appointment a)
        {
            new AppointmentRepository().AddAppointment(a);
        }

        public void ChangeStatus(int appid, int statusid)
        {
             new AppointmentRepository().ChangeStatus(appid, statusid);
        }
        public void SendEmail(string destinationaddress,string body)
        {
            new EmailRepository().SendEmail(destinationaddress,body);
        }
    }
}
