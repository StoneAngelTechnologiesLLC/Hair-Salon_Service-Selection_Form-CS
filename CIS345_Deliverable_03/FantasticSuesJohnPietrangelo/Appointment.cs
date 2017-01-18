//John Pietrangelo CIS345 Tues/Thurs 9am
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasticSuesJohnPietrangelo
{
    class Appointment
    {
        private static int appointmentTotal{ get; set; }
        private static double totalRevenue { get; set; }
        private string aptFirstName { get; set; }
        private string aptLastName { get; set; }
        private int aptPhoneNumber { get; set; }
        private bool aptAdultHairCut { get; set; }
        private bool aptChldSrHairCut { get; set; }
        private bool aptStyling { get; set; }
        private bool aptPerm { get; set; }
        private bool aptBangNeckBeardTrim { get; set; }
        private bool aptShampoo { get; set; }
        private double aptTotalBill { get; set; }

       

        //Constructor
        //public Appointment()
        //{
        //    appointmentTotal++;
            

        //}
        public Appointment(string first, string last, int pNum, bool adultCut,bool chldSrCut, 
            bool styling, bool perm, bool bNBTrim, bool shampoo, double billTotal)
        {
            appointmentTotal++;
            aptFirstName = first;
            aptLastName = last;
            aptPhoneNumber = pNum;
            aptAdultHairCut = adultCut;
            aptChldSrHairCut = chldSrCut;
            aptStyling = styling;
            aptPerm = perm;
            aptBangNeckBeardTrim = bNBTrim;
            aptShampoo = shampoo;
            aptTotalBill = billTotal;
            totalRevenue += billTotal;
        }
    }
}
