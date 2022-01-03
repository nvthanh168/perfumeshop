using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ShopNuocHoa.Models
{
    public partial class DBContext : DbContext
    {
        //dong mo ket noi
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt; //bang luu tru ban sao CSDL
        string str = ConfigurationManager.ConnectionStrings["strconnection"].ConnectionString;
        public DBContext()
            : base("name=strconnection")
        {
            con = new SqlConnection(str); //mo ket noi csdl
        }

        //func load data
        public DataTable readData(string query)
        {
            con.Open();
            da = new SqlDataAdapter(query, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //func ghi dl
        public void writeData(string query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public virtual DbSet<LoaiSP> LoaiSP { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSP>()
                .Property(e => e.maLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maLoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Anh)
                .IsUnicode(false);
        }
    }
}
