using PersonalManagamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagamentSystem.ServiceOperations
{
    public class MenuManager<T>

    {
        public static void serviceCall()
        {

            Type personal = typeof(Personal);
            if (typeof(T) == personal)
            {
                PersonalManager.AddPersonal();
            }

            Type worktime = typeof(WorkTime);
            if (typeof(T) == worktime)
            {
                WorkTimeManager.AddWorkTime();
            }
        }

        public static void serviceShow()
        {

            Type personal = typeof(Personal);
            if (typeof(T) == personal)
            {
                PersonalManager.ShowPersonal();
            }

            Type personal1 = typeof(Personal);
            if (typeof(T) == personal1)
            {
                PersonalManager.ShowPersonalForPosition();
            }

          
        }

        public static void serviceDelete()
        {
            Type personal = typeof(Personal);
            if (typeof(T) == personal)
            {
                PersonalManager.DeletePersonal();
            }
        }


    }
}
