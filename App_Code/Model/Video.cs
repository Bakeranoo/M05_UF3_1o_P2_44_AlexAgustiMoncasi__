using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Video
    {
        public int Id;
        public int Product_Id;
        public Product product;
        public float Duration;

        public Video()
        {

        }
        public Video(DataRow row)
        {
            try
            {
                Id = int.Parse(row[0].ToString());
            }
            catch
            {
                Id = 0;
            }
            try
            {
                Product_Id = int.Parse(row[1].ToString());
            }
            catch
            {
                Product_Id = 0;
            }
            try
            {
                Duration = float.Parse(row[2].ToString());
            }
            catch
            {
                Duration = 0;
            }

            if (Product_Id > 0)
            {
                product = new Product(DatabaseManager.Select("Product", null, "Id= " + Product_Id + " ").Rows[0]);
            }


        }

        public Video(int Id) : this(DatabaseManager.Select("Product", null, "Id= " + Id + " ").Rows[0]) { }

        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration)
            };
            return DatabaseManager.Update("Video", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration)
            };
            return DatabaseManager.Insert("Video", fields) > 0 ? true : false;
        }
    }
}

