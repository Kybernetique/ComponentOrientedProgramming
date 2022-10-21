using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.AlexandrovComponents.HelperModels
{
    public class ExcelTableHeaderBlockParameters
    {
        public int RowCount 
        { 
            get 
            { 
                if(titlesSecondRow != null) { if (titlesSecondRow.Length > 1) return titlesSecondRow.Length; else return 1; } 
                else return 1; 
            } 
        }

        public ExcelTableHeaderCellProperties titleFirstRow;
        public ExcelTableHeaderCellProperties[] titlesSecondRow;
    }
}
