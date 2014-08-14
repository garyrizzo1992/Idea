using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAppointmentsService" in both code and config file together.
    [ServiceContract]
    public interface IAppointmentsService
    {
        [OperationContract]
        Appointment GetAppointment(int appid);
        [OperationContract]
        void AddAppointment(Appointment a);
        [OperationContract]
        void ChangeStatus(int appid, int statusid);

        [OperationContract]
        void DoWork();


        [OperationContract]
        IEnumerable<Appointment> GetAppointmentsNeedingReview();
        [OperationContract]
        void SendEmail(string destinationaddress,string body);
    }
}
