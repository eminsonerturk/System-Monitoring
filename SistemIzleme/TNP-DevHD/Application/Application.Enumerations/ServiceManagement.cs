using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enumerations
{
    public class ServiceManagement
    {
        public const string jsonResultSuccessLabel = "success";
        public const string jsonResultFailLabel = "fail";
        public const string arkasTurizm = "9960037100";
        public const string arkasLimar = "6090064296";
        public const string arkasBimar = "8920044460";
        public const string arkasMarport = "6120273778";

        public enum ServiceResult
        {
            Success = 1,
            Error = 2,
            Warning = 3
        }

        public enum OnayStatu
        {
            Taslak = 1,
            Iptal = 2,
            YoneticiOnayi1 = 3,
            YoneticiOnayi2 = 4,
            Onaylandi = 5,
            Arsivlendi = 7
        }

        public enum DosyaTipi
        {
            Xml = 2,
            Html = 3
        }
    }
}
