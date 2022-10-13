using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibrary
{
    public partial class DataGrid : UserControl
    {
        public int IndexRow
        {
            get { return dataGridView.SelectedRows[0].Index; }
            set
            {
                if (dataGridView.SelectedRows.Count <= value || value < 0)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", value));
                else
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[value].Selected = true;
                }
            }
        }

        // Инициализация DataGrid
        public DataGrid()
        {
            InitializeComponent();
        }

        // Метoд очистки строк DataGrid
        public void ClearDataGrid()
        {
            dataGridView.DataSource = null;
        }

        // Метод конфигурации DataGridView. Отдельный метод для конфигурации столбцов. Через 
        // метод указывается сколько колонок в DataGridView добавлять, 
        // их заголовки, ширину, признак видимости и имя свойства/поля
        // объекта класса, записи которого будут в таблице выводиться,
        // значение из которого потребуется выводить в ячейке этой колонки.
        public void ConfigColumn(ColumnsDataGrid columnsData)
        {
            dataGridView.ColumnCount = columnsData.CountColumn;
            for (int i = 0; i < columnsData.CountColumn; i++)
            {
                dataGridView.Columns[i].Name = columnsData.NameColumn[i];
                dataGridView.Columns[i].Width = columnsData.Width[i];
                dataGridView.Columns[i].Visible = columnsData.Visible[i];
                dataGridView.Columns[i].DataPropertyName = columnsData.PropertiesObject[i];
            }
        }

        // Полуение объекта из строки
        public T GetSelectedObjectIntoRow<T>()
        {
            T objectMy = (T)Activator.CreateInstance(typeof(T));
            var propertiesObj = typeof(T).GetProperties();
            foreach (var properties in propertiesObj)
            {
                bool propIsExist = false;
                int columnIndex = 0;
                for (; columnIndex < dataGridView.Columns.Count; columnIndex++)
                {
                    if (dataGridView.Columns[columnIndex].DataPropertyName.ToString() == properties.Name)
                    {
                        propIsExist = true;
                        break;
                    }
                }
                if (!propIsExist) { throw new Exception("can not find propertie"); };
                object value = dataGridView.SelectedRows[0].Cells[columnIndex].Value;
                properties.SetValue(objectMy, value);
            }
            return objectMy;
        }

        //  Заполнение DataGridView построчно
        // Заполнение DataGridView построчно
        public void AddRow<T>(T objectMy)
        {
            int count = dataGridView.Columns.Count;
            object[] objValue = new object[count];
            int j = 0;
            foreach (var prop in typeof(T).GetProperties())
            {
                objValue[j] = prop.GetValue(objectMy).ToString();
                Console.WriteLine(prop.Name + prop.GetValue(objectMy));
                j++;
            }
            dataGridView.Rows.Add(objValue);
        }
    }
}
