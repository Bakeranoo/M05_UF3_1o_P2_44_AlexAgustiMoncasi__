using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Product
    {
        public int Id { get; set; }
        public enum TYPE { GAME, VIDEO, NONE }
        public TYPE Type { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public string Trailer { get; set; }
        public float Price { get; set; }
        public DateTime Publishing { get; set; }
        public float Size { get; set; }
        public int Developer_Id { get; set; }
        public Company Developer { get; set; }
        public int Editor_Id { get; set; }
        public Company Editor { get; set; }

        public Product()
        {

        }

        public Product(DataRow row)
        {
            Fill(row);
        }
        public Product(int Id) : this(DatabaseManager.Select("Product", null, "Id = " + Id + " ").Rows[0]) { }

        public void Fill(DataRow row)
        {
            //Id
            try
            {
                Id = (int)row[0];
            }
            catch
            {
                Id = 0;
            }
            //TYPE
            try
            {
                Type = (TYPE)int.Parse(row[1].ToString());
            }
            catch
            {
                Type = 0;
            }
            //Summay, Icon, Banner, Trailer
            Summary = row[2].ToString();
            Icon = row[3].ToString();
            Banner = row[4].ToString();
            Trailer = row[5].ToString();
            //Price
            try
            {
                Price = float.Parse(row[6].ToString());
            }
            catch
            {
                Price = 0;
            }
            //publishing
            try
            {
                Publishing = DateTime.Parse(row[7].ToString());
            }
            catch
            {
                Publishing = DateTime.MinValue;
            }
            //Size
            try
            {
                Size = float.Parse(row[8].ToString());
            }
            catch
            {
                Size = 0;
            }
            //Developer
            try
            {
                Developer_Id = (int)row[9];
            }
            catch
            {
                Developer_Id = 0;
            }
            if (Developer_Id > 0)
            {
                Developer = new Company(Developer_Id);
            }
            //Editor
            try
            {
                Editor_Id = (int)row[10];
            }
            catch
            {
                Editor_Id = 0;
            }
            if (Editor_Id > 0)
            {
                Editor = new Company(Editor_Id);
            }
        }
        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Type", (int)Type),
                new DatabaseManager.DB_Field("Summary", Summary),
                new DatabaseManager.DB_Field("Icon", Icon),
                new DatabaseManager.DB_Field("Banner", Banner),
                new DatabaseManager.DB_Field("Trailer", Trailer),
                new DatabaseManager.DB_Field("Price", Price),
                new DatabaseManager.DB_Field("Publishing", Publishing),
                new DatabaseManager.DB_Field("Size", Size),
                new DatabaseManager.DB_Field("Developer", Developer_Id),
                new DatabaseManager.DB_Field("Editor", Editor_Id)
            };
            return DatabaseManager.Update("Product", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Type", (int)Type),
                new DatabaseManager.DB_Field("Summary", Summary),
                new DatabaseManager.DB_Field("Icon", Icon),
                new DatabaseManager.DB_Field("Banner", Banner),
                new DatabaseManager.DB_Field("Trailer", Trailer),
                new DatabaseManager.DB_Field("Price", Price),
                new DatabaseManager.DB_Field("Publishing", Publishing),
                new DatabaseManager.DB_Field("Size", Size),
                new DatabaseManager.DB_Field("Developer", Developer_Id),
                new DatabaseManager.DB_Field("Editor", Editor_Id)
            };
            return DatabaseManager.Insert("Product", fields) > 0 ? true : false;
        }
        public bool Remove()
        {
            return Remove(Id);
        }
        public static bool Remove(int id)
        {
            return DatabaseManager.Delete("Product", id) > 0 ? true : false;
        }
    }
}