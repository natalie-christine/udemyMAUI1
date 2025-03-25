using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemyMAUI1.MVVM.Models;

namespace udemyMAUI1.MVVM.ViewModels
{
    public class BMIViewModel
    {
        public BMI BMI { get; set; }

        public BMIViewModel()
        {
            BMI = new BMI();
            BMI.Height = 180;
            BMI.Weight = 73;

        }
    }
}
