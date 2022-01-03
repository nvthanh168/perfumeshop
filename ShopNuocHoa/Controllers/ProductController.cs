
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopNuocHoa.Models;

namespace ShopNuocHoa.Controllers
{
    public class ProductController : Controller
    {
        SanPhamModels db = new SanPhamModels();
        LoaiSPModels lspModel = new LoaiSPModels();
        ThuongHieuModels thModel = new ThuongHieuModels();
        // GET: Product
        public ViewResult ProDetail(string id)
        {

            SanPham sp = db.get1sanPham(id);
            ViewBag.LoaiSP = lspModel.get1LSP(sp.maLoai);
            return View(sp);
        }
        public ViewResult ProCata(string id)
        {
            LoaiSP lsp;
            List<SanPham> listSp;
            List<LoaiSP> list = lspModel.getAllLSP();
            if (id == null)
            {
             
                listSp = db.getAllSP();
                ViewBag.tenLoai = "Tất cả sản phẩm";
            }
            else
            {
                lsp = lspModel.get1LSP(id);
                listSp  = db.getSanPhambyLoai(id);
                var tenlsp = lsp.tenLoai;
                ViewBag.LoaiSP = lsp;
                ViewBag.tenLoai = tenlsp;
            }
          
            return View(listSp);
        }
        public ViewResult ProbyTH(string id)
        {
            ThuongHieu th;
            SanPham sanPham = new SanPham();
            List<SanPham> listSp;
            if (id == null)
            {

                listSp = db.getAllSP();
                ViewBag.tenLoai = "Tất cả sản phẩm";
            }
            else
            {
                th = thModel.get1TH(id);
                listSp = db.getSPbyThuongHieu(id);
                var tenTH = th.tenTH;
                ViewBag.TH = th;
                ViewBag.tenTH = tenTH;
            }
            return View(listSp);
        }
    }
}